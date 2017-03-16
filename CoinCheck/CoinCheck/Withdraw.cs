using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class Withdraw
    {
        private readonly CoinCheck _client;

        public Withdraw(CoinCheck client)
        {
            _client = client;
        }

        /** Create a new Withdraw. **/
        public IRestResponse Create(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/withdraw", JsonConvert.SerializeObject(myDictionary));
        }

        /** Get a withdraw list. **/
        public IRestResponse All()
        {
            return _client.Request(Method.GET, "api/withdraws");
        }

        /** Based on this id, you can repay. **/
        public IRestResponse Cancel(string id)
        {
            return _client.Request(Method.DELETE, "api/withdraws/" + id);
        }
    }
}