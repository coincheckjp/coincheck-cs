using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class Borrow
    {
        private readonly CoinCheck _client;

        public Borrow(CoinCheck client)
        {
            _client = client;
        }

        /** Create a new Borrow. **/
        public IRestResponse Create(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/lending/borrows", JsonConvert.SerializeObject(myDictionary));
        }

        /** Get a borrowing list.**/
        public IRestResponse Matches()
        {
            return _client.Request(Method.GET, "api/lending/borrows/matches");
        }

        /** Based on this id, you can repay. **/
        public IRestResponse Delete(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/lending/borrows/" + myDictionary["id"] + "/repay", JsonConvert.SerializeObject(myDictionary));
        }

    }
}