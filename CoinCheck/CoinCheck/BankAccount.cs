using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class BankAccount
    {
        private readonly CoinCheck _client;

        public BankAccount(CoinCheck client)
        {
            _client = client;
        }

        /** Create a new BankAccount. **/
        public IRestResponse Create(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/bank_accounts", JsonConvert.SerializeObject(myDictionary));
        }

        /** Get account information.**/
        public IRestResponse All()
        {
            return _client.Request(Method.GET, "api/bank_accounts");
        }

        /** Delete a BankAccount. **/
        public IRestResponse Delete(string id)
        {
            return _client.Request(Method.DELETE, "api/bank_accounts/" + id);
        }
    }
}