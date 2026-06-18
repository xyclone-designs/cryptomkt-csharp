using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models;

namespace Cryptomarket.SDK.Websocket
{
    public class OrderbookCache
    {
        private int ASCENDING = 0;
        private int DESCENDING = 1;
        private Adapter adapter = new Adapter();
        private Dictionary<string, OrderBook> orderbooks = [];
        private Dictionary<string, OrderBookState> orderbookStates = [];        

        public virtual void Update(string method, string key, WSJsonResponse response)
        {
            switch (method)
            {
                case "snapshotOrderbook":
                    try
                    {
                        OrderBook orderbook = adapter.ObjectFromValue<OrderBook>(response.Parameters);
                        orderbookStates.Add(key, OrderBookState.UPDATING);
                        orderbooks.Add(key, orderbook);
                    }
                    catch (ParseException)
                    {
                        orderbookStates.Add(key, OrderBookState.BROKEN_PARSE_ERROR);
                    }

                    break;
                case "updateOrderbook":
                    if (!orderbookStates[key].Equals(OrderBookState.UPDATING))
                        return;
                    OrderBook orderbookUpdate;
                    try
                    {
                        orderbookUpdate = adapter.ObjectFromValue<OrderBook>(response.Parameters);
                    }
                    catch (ParseException)
                    {
                        orderbookStates.Add(key, OrderBookState.BROKEN_PARSE_ERROR);
                        return;
                    }

                    OrderBook oldOrderbook = orderbooks[key];

                    if (orderbookUpdate.Sequence - oldOrderbook.Sequence != 1)
                    {
                        orderbookStates.Add(key, OrderBookState.BROKEN);
                        return;
                    }

                    oldOrderbook.Timestamp = orderbookUpdate.Timestamp;
                    oldOrderbook.Sequence = orderbookUpdate.Sequence;

                    if (orderbookUpdate.Ask != null)
                        orderbookUpdate.Ask = UpdateBookSide(oldOrderbook.Ask, orderbookUpdate.Ask, ASCENDING);

                    if (orderbookUpdate.Bid != null)
                        orderbookUpdate.Bid = UpdateBookSide(oldOrderbook.Bid, orderbookUpdate.Bid, DESCENDING);

                    break;
            }
        }

        private IList<OrderbookLevel> UpdateBookSide(IList<OrderbookLevel> oldList, IList<OrderbookLevel> updateList, int sortDirection)
        {
            IList<OrderbookLevel> newList = [];
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
            BigDecimal size = new BigDecimal(entry.Amount);
            return size.CompareTo(new BigDecimal("0.00")) == 0;
        }

        private int PriceOrder(OrderbookLevel oldEntry, OrderbookLevel updateEntry, int sortDirection)
        {
            BigDecimal oldPrice = new BigDecimal(oldEntry.Price);
            BigDecimal updatePrice = new BigDecimal(updateEntry.Price);
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
            orderbookStates.Add(key, OrderBookState.WAITING);
        }

        public virtual bool OrderbookWaiting(string key)
        {
            return orderbookStates[key].Equals(OrderBookState.WAITING);
        }
    }
}