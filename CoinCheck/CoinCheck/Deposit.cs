using System;
using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class Deposit
    {
        private readonly CoinCheck _client;

        public Deposit(CoinCheck client)
        {
            _client = client;
        }

        /** Deposit Bitcoin Faster **/
        public IRestResponse Fast(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/deposit_money/" + myDictionary["id"] + "/fast" , JsonConvert.SerializeObject(myDictionary));
        }

        /** You Get Deposit history **/
        public IRestResponse All(Dictionary<string,string> myDictionary = null)
        {
            return _client.Request(Method.GET, "api/deposit_money" + _client.QueryString(myDictionary));
        }
    }
}