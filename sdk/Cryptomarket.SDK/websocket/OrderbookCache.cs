using Java.Math;
using Java.Util;
using Cryptomarket.SDK;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.Websocket.AccountType;
using static Cryptomarket.SDK.Websocket.ContingencyType;
using static Cryptomarket.SDK.Websocket.Depth;
using static Cryptomarket.SDK.Websocket.IdentifyBy;
using static Cryptomarket.SDK.Websocket.NotificationType;
using static Cryptomarket.SDK.Websocket.OBSpeed;
using static Cryptomarket.SDK.Websocket.OrderBy;
using static Cryptomarket.SDK.Websocket.OrderStatus;
using static Cryptomarket.SDK.Websocket.OrderType;
using static Cryptomarket.SDK.Websocket.Period;
using static Cryptomarket.SDK.Websocket.PriceSpeed;
using static Cryptomarket.SDK.Websocket.ReportType;
using static Cryptomarket.SDK.Websocket.Side;
using static Cryptomarket.SDK.Websocket.Sort;
using static Cryptomarket.SDK.Websocket.SortBy;
using static Cryptomarket.SDK.Websocket.SubAccountStatus;
using static Cryptomarket.SDK.Websocket.SubAccountTransferType;
using static Cryptomarket.SDK.Websocket.SubscriptionMode;
using static Cryptomarket.SDK.Websocket.TickerSpeed;
using static Cryptomarket.SDK.Websocket.TimeInForce;
using static Cryptomarket.SDK.Websocket.TransactionStatus;
using static Cryptomarket.SDK.Websocket.TransactionSubtype;
using static Cryptomarket.SDK.Websocket.TransactionType;
using static Cryptomarket.SDK.Websocket.UseOffchain;
using static Cryptomarket.SDK.Websocket.HttpMethod;

namespace Cryptomarket.SDK.Websocket
{
    public class OrderbookCache
    {
        private Adapter adapter = new Adapter();
        private Dictionary<string, OrderBook> orderbooks = new HashMap<string, OrderBook>();
        private Dictionary<string, OrderBookState> orderbookStates = new HashMap<string, OrderBookState>();
        private int ASCENDING = 0;
        private int DESCENDING = 1;
        public virtual void Update(string method, string key, WSJsonResponse response)
        {
            switch (method)
            {
                case "snapshotOrderbook":
                    try
                    {
                        OrderBook orderbook = adapter.ObjectFromValue(response.GetParams(), typeof(OrderBook));
                        orderbookStates.Put(key, OrderBookState.UPDATING);
                        orderbooks.Put(key, orderbook);
                    }
                    catch (ParseException e)
                    {
                        orderbookStates.Put(key, OrderBookState.BROKEN_PARSE_ERROR);
                    }

                    break;
                case "updateOrderbook":
                    if (!orderbookStates[key].Equals(OrderBookState.UPDATING))
                        return;
                    OrderBook orderbookUpdate;
                    try
                    {
                        orderbookUpdate = adapter.ObjectFromValue(response.GetParams(), typeof(OrderBook));
                    }
                    catch (ParseException e)
                    {
                        orderbookStates.Put(key, OrderBookState.BROKEN_PARSE_ERROR);
                        return;
                    }

                    OrderBook oldOrderbook = orderbooks[key];
                    if (orderbookUpdate.GetSequence() - oldOrderbook.GetSequence() != 1)
                    {
                        orderbookStates.Put(key, OrderBookState.BROKEN);
                        return;
                    }

                    oldOrderbook.SetTimestamp(orderbookUpdate.GetTimestamp());
                    oldOrderbook.SetSequence(orderbookUpdate.GetSequence());
                    IList<OrderbookLevel> asksUpdates = orderbookUpdate.GetAsk();
                    if (asksUpdates != null)
                    {
                        oldOrderbook.SetAsk(UpdateBookSide(oldOrderbook.GetAsk(), asksUpdates, ASCENDING));
                    }

                    IList<OrderbookLevel> bidsUpdates = orderbookUpdate.GetBid();
                    if (bidsUpdates != null)
                    {
                        oldOrderbook.SetBid(UpdateBookSide(oldOrderbook.GetBid(), bidsUpdates, DESCENDING));
                    }

                    break;
            }
        }

        private IList<OrderbookLevel> UpdateBookSide(IList<OrderbookLevel> oldList, IList<OrderbookLevel> updateList, int sortDirection)
        {
            IList<OrderbookLevel> newList = new List<OrderbookLevel>();
            OrderbookLevel oldEntry;
            int oldIdx = 0;
            OrderbookLevel updateEntry;
            int updateIdx = 0;
            int order;
            while (oldIdx < oldList.Count && updateIdx < updateList.Count)
            {
                updateEntry = updateList[updateIdx];
                oldEntry = oldList[oldIdx];
                order = PriceOrder(oldEntry, updateEntry, sortDirection);
                if (order == 0)
                {
                    if (!ZeroSize(updateEntry))
                    {
                        newList.Add(updateEntry);
                    }

                    oldIdx++;
                    updateIdx++;
                } // old value first
                else if (order == 1)
                {

                    // old value first
                    newList.Add(oldEntry);
                    oldIdx++;
                } // (order == -1)
                else
                {

                    // (order == -1)
                    newList.Add(updateEntry);
                    updateIdx++;
                }
            }

            if (updateIdx == updateList.Count)
            {
                for (int idx = oldIdx; idx < oldList.Count; idx++)
                {
                    oldEntry = oldList[idx];
                    newList.Add(oldEntry);
                }
            }

            if (oldIdx == oldList.Count)
            {
                for (int idx = updateIdx; idx < updateList.Count; idx++)
                {
                    updateEntry = updateList[idx];
                    if (!ZeroSize(updateEntry))
                    {
                        newList.Add(updateEntry);
                    }
                }
            }

            return newList;
        }

        private bool ZeroSize(OrderbookLevel entry)
        {
            BigDecimal size = new BigDecimal(entry.GetAmount());
            return size.CompareTo(new BigDecimal("0.00")) == 0;
        }

        private int PriceOrder(OrderbookLevel oldEntry, OrderbookLevel updateEntry, int sortDirection)
        {
            BigDecimal oldPrice = new BigDecimal(oldEntry.GetPrice());
            BigDecimal updatePrice = new BigDecimal(updateEntry.GetPrice());
            int direction = oldPrice.CompareTo(updatePrice);
            if (sortDirection.Equals(ASCENDING))
                return -direction;
            return direction;
        }

        public virtual OrderBook GetOrderbook(string key)
        {
            if (!orderbooks.ContainsKey(key))
                return null;
            return orderbooks[key];
        }

        public virtual bool OrderbookBroken(string key)
        {
            OrderBookState currencState = orderbookStates[key];
            return currencState.Equals(OrderBookState.BROKEN) || currencState.Equals(OrderBookState.BROKEN_PARSE_ERROR);
        }

        public virtual void WaitOrderbook(string key)
        {
            orderbookStates.Put(key, OrderBookState.WAITING);
        }

        public virtual bool OrderbookWaiting(string key)
        {
            return orderbookStates[key].Equals(OrderBookState.WAITING);
        }
    }
}