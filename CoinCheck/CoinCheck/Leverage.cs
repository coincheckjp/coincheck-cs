using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class Leverage
    {
        private readonly CoinCheck _client;

        public Leverage(CoinCheck client)
        {
            _client = client;
        }

        /** Get a leverage positions list. **/
        public IRestResponse Positions(Dictionary<string,string> myDictionary = null)
        {
            return _client.Request(Method.POST, "api/exchange/leverage/positions" , JsonConvert.SerializeObject(myDictionary));
        }
    }
}