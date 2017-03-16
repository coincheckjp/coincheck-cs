using System.Collections.Generic;
using RestSharp;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class Send
    {

        private readonly CoinCheck _client;

        public Send(CoinCheck client)
        {
            _client = client;
        }

        /** Sending Bitcoin to specified Bitcoin addres. **/
        public IRestResponse Create(Dictionary<string,string> myDictionary)
        {
            return _client.Request(Method.POST, "api/send_money", JsonConvert.SerializeObject(myDictionary));
        }

        /** You Get Send history  **/
        public IRestResponse All(string id)
        {
            return _client.Request(Method.GET, "api/send_money" + id);
        }
    }
}