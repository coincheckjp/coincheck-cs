using RestSharp;

namespace CoinCheck
{
    internal class Account
    {

        private readonly CoinCheck _client;

        public Account(CoinCheck client)
        {
            _client = client;
        }

        /** Make sure a balance **/
        public IRestResponse Balance()
        {
            return _client.Request(Method.GET, "api/accounts/balance");
        }

        /** Make sure a leverage balance.**/
        public IRestResponse LeverageBalance()
        {
            return _client.Request(Method.GET, "api/accounts/leverage_balance");
        }

        /** Get account information. **/
        public IRestResponse Info()
        {
            return _client.Request(Method.GET, "api/accounts/balance");
        }
    }
}