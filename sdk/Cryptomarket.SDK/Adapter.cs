using Java.Io;
using Java.Lang.Reflect;
using Java.Util;
using Cryptomarket.SDK.Exceptions;
using Cryptomarket.SDK.Models.Adapters;
using Com.Squareup.Moshi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.SDK.AccountType;
using static Cryptomarket.SDK.ContingencyType;
using static Cryptomarket.SDK.Depth;
using static Cryptomarket.SDK.IdentifyBy;
using static Cryptomarket.SDK.NotificationType;
using static Cryptomarket.SDK.OBSpeed;
using static Cryptomarket.SDK.OrderBy;
using static Cryptomarket.SDK.OrderStatus;
using static Cryptomarket.SDK.OrderType;
using static Cryptomarket.SDK.Period;
using static Cryptomarket.SDK.PriceSpeed;
using static Cryptomarket.SDK.ReportType;
using static Cryptomarket.SDK.Side;
using static Cryptomarket.SDK.Sort;
using static Cryptomarket.SDK.SortBy;
using static Cryptomarket.SDK.SubAccountStatus;
using static Cryptomarket.SDK.SubAccountTransferType;
using static Cryptomarket.SDK.SubscriptionMode;
using static Cryptomarket.SDK.TickerSpeed;
using static Cryptomarket.SDK.TimeInForce;
using static Cryptomarket.SDK.TransactionStatus;
using static Cryptomarket.SDK.TransactionSubtype;
using static Cryptomarket.SDK.TransactionType;
using static Cryptomarket.SDK.UseOffchain;

namespace Cryptomarket.SDK
{
    /// <summary>
    /// Json Adapter, uses moshi
    /// </summary>
    public class Adapter
    {
        private readonly Moshi moshi;
        private readonly ParameterizedType mapStringString;
        private readonly JsonAdapter<Dictionary<string, object>> mapStrStrJsonAdapter;
        /// <summary>
        /// </summary>
        public Adapter()
        {
            moshi = new Builder().Add(new OrderBookLevelAdapter()).Add(new OrderStatusAdapter()).Add(new OrderTypeAdapter()).Add(new SideAdapter()).Add(new UseOffchainAdapter()).Add(new ReportTypeAdapter()).Add(new SubAccountStatusAdapter()).Build();
            mapStringString = Types.NewParameterizedType(typeof(Dictionary), typeof(string), typeof(object));
            mapStrStrJsonAdapter = moshi.Adapter(mapStringString);
        }

        public virtual string ObjectToJson<T>(T @object, Class<T> cls)
        {
            JsonAdapter<T> jsonAdapter = moshi.Adapter(cls);
            return ConvertingException.IoAndJsonDataAndAssertionToParse(jsonAdapter.ToJson(), @object);
        }

        public virtual string MapStrStrToJson(Dictionary<string, object> map)
        {
            return ConvertingException.IoAndJsonDataAndAssertionToParse(mapStrStrJsonAdapter.ToJson(), map);
        }

        public virtual T ObjectFromJson<T>(string json, Class<T> cls)
        {
            JsonAdapter<T> jsonAdapter = moshi.Adapter(cls);
            return ConvertingException.IoAndJsonDataAndAssertionToParse(jsonAdapter.FromJson(), json);
        }

        public virtual IList<T> ListFromJson<T>(string json, Class<T> cls)
        {
            Type type = Types.NewParameterizedType(typeof(IList), cls);
            JsonAdapter<IList<T>> jsonAdapter = moshi.Adapter(type);
            return ConvertingException.IoAndJsonDataAndAssertionToParse(jsonAdapter.FromJson(), json);
        }

        public virtual Dictionary<string, IList<T>> ListMapFromJson<T>(string json, Class<T> cls)
        {
            try
            {
                Type type = Types.NewParameterizedType(typeof(Dictionary), typeof(string), typeof(object));
                JsonAdapter<Dictionary<string, object>> mapAdapter = moshi.Adapter(type);
                Dictionary<string, object> objectMap = mapAdapter.FromJson(json);
                type = Types.NewParameterizedType(typeof(IList), cls);
                JsonAdapter<IList<T>> jsonAdapter = moshi.Adapter(type);
                Dictionary<string, IList<T>> parsed = new HashMap<string, IList<T>>();
                objectMap.ForEach((key, value) =>
                {
                    parsed.Put(key, jsonAdapter.FromJsonValue(value));
                });
                return parsed;
            }
            catch (IOException e)
            {
                throw new ParseException("failed to parse json response", e);
            }
            catch (JsonDataException e)
            {
                throw new ParseException("failed to parse json response", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ParseException("failed to parse json response", e);
            }
        }

        public virtual Dictionary<string, IList<T>> ListMapFromObject<T>(object @object, Class<T> cls)
        {
            Type type = Types.NewParameterizedType(typeof(Dictionary), typeof(string), typeof(object));
            JsonAdapter<Dictionary<string, object>> mapAdapter = moshi.Adapter(type);
            Dictionary<string, object> objectMap = mapAdapter.FromJsonValue(@object);
            type = Types.NewParameterizedType(typeof(IList), cls);
            JsonAdapter<IList<T>> jsonAdapter = moshi.Adapter(type);
            Dictionary<string, IList<T>> parsed = new HashMap<string, IList<T>>();
            try
            {
                objectMap.ForEach((key, value) =>
                {
                    IList<T> parsedValue = jsonAdapter.FromJsonValue(value);
                    parsed.Put(key, parsedValue);
                });
            }
            catch (InvalidOperationException e)
            {
                throw new ParseException("failed to parse json response", e);
            }
            catch (JsonDataException e)
            {
                throw new ParseException("failed to parse json response", e);
            }

            return parsed;
        }

        public virtual Dictionary<string, T> MapFromJson<T>(string json, Class<T> cls)
        {
            try
            {
                Type type = Types.NewParameterizedType(typeof(Dictionary), typeof(string), cls);
                JsonAdapter<Dictionary<string, T>> mapAdapter = moshi.Adapter(type);
                return mapAdapter.FromJson(json);
            }
            catch (IOException e)
            {
                throw new ParseException("failed to parse json response", e);
            }
            catch (InvalidOperationException e)
            {
                throw new ParseException("failed to parse json response", e);
            }
            catch (JsonDataException e)
            {
                throw new ParseException("failed to parse json response", e);
            }
        }

        public virtual T ObjectFromJsonValue<T>(string json, string key, Class<T> cls)
        {
            Dictionary<string, object> objectMap = MapFromJson(json, typeof(object));
            JsonAdapter<T> jsonAdapter = moshi.Adapter(cls);
            object value = objectMap[key];
            return ConvertingException.IoAndJsonDataAndAssertionToParse(jsonAdapter.FromJsonValue(), value);
        }

        public virtual IList<T> ListFromJsonValue<T>(string json, string key, Class<T> cls)
        {
            Dictionary<string, object> objectMap = MapFromJson(json, typeof(object));
            Type type = Types.NewParameterizedType(typeof(IList), cls);
            JsonAdapter<IList<T>> jsonAdapter = moshi.Adapter(type);
            object value = objectMap[key];
            return ConvertingException.IoAndJsonDataAndAssertionToParse(jsonAdapter.FromJsonValue(), value);
        }

        public virtual T ObjectFromValue<T>(object value, Class<T> cls)
        {
            JsonAdapter<T> jsonAdapter = moshi.Adapter(cls);
            return ConvertingException.IoAndJsonDataAndAssertionToParse(jsonAdapter.FromJsonValue(), value);
        }

        public virtual Dictionary<string, T> MapFromValue<T>(object value, Class<T> cls)
        {
            Type type = Types.NewParameterizedType(typeof(Dictionary), typeof(string), cls);
            JsonAdapter<Dictionary<string, T>> mapAdapter = moshi.Adapter(type);
            return ConvertingException.IoAndJsonDataAndAssertionToParse(mapAdapter.FromJsonValue(), value);
        }

        public virtual IList<T> ListFromValue<T>(object value, Class<T> cls)
        {
            Type type = Types.NewParameterizedType(typeof(IList), cls);
            JsonAdapter<IList<T>> jsonAdapter = moshi.Adapter(type);
            return ConvertingException.IoAndJsonDataAndAssertionToParse(jsonAdapter.FromJsonValue(), value);
        }

        public virtual IList<string> StringlistFromStringMap(object value, string key)
        {
            Type type = Types.NewParameterizedType(typeof(Dictionary), typeof(string), typeof(object));
            JsonAdapter<Dictionary<string, object>> mapAdapter = moshi.Adapter(type);
            Dictionary<string, object> map = mapAdapter.FromJsonValue(value);
            object list = map[key];
            if (key == null)
            {
                return Arrays.AsList();
            }

            return ListFromValue(list, typeof(string));
        }

        public virtual string ListToJson<T>(IList<T> list, Class<T> cls)
        {
            Type type = Types.NewParameterizedType(typeof(IList), cls);
            JsonAdapter<IList<T>> listAdapter = moshi.Adapter(type);
            return ConvertingException.IoAndJsonDataAndAssertionToParse(listAdapter.ToJson(), list);
        }
    }
}