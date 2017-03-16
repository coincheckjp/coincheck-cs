using RestSharp;

namespace CoinCheck
{
    internal class Trade
    {
        private readonly CoinCheck _client;

        public Trade(CoinCheck client)
        {
            _client = client;
        }

        /** 最新の取引履歴を取得できます。 **/
        public IRestResponse All()
        {
            return _client.Request(Method.GET, "api/trades");
        }
    }
}