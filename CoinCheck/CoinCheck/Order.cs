using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class Order
    {
        private readonly CoinCheck _client;

        public Order(CoinCheck client)
        {
            _client = client;
        }

        /** Create a order object with given parameters. In live mode, this issues a transaction. **/
        public IRestResponse Create(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/exchange/orders", JsonConvert.SerializeObject(myDictionary));
        }

        /** cancel a created order specified by order id. Optional argument amount is to refund partially.  **/
        public IRestResponse Cancel(string id)
        {
            return _client.Request(Method.DELETE, "api/exchange/orders/" + id);
        }

        /**  List charges filtered by params  **/
        public IRestResponse Open()
        {
            return _client.Request(Method.GET, "api/exchange/orders/opens");
        }

        /**  Get Order Transactions  **/
        public IRestResponse Transactions()
        {
            return _client.Request(Method.GET, "api/exchange/orders/transactions");
        }
    }
}