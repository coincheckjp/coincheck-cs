using System;
using System.Collections.Generic;
using RestSharp;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class Transfer
    {
        private readonly CoinCheck _client;

        public Transfer(CoinCheck client)
        {
            _client = client;
        }

        /** Transfer Balance to Leverage. **/
        public IRestResponse ToLeverage(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/exchange/transfers/to_leverage", JsonConvert.SerializeObject(myDictionary));
        }

        /** Transfer Balance from Leverage. **/
        public IRestResponse FromLeverage(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/exchange/transfers/from_leverage", JsonConvert.SerializeObject(myDictionary));
        }
    }
}