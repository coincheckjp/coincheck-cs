using RestSharp;

namespace CoinCheck
{
    internal class Ticker
    {
        private readonly CoinCheck _client;

        public Ticker(CoinCheck client)
        {
            _client = client;
        }

        /** 各種最新情報を簡易に取得することができます。 **/
        public IRestResponse All()
        {
            return _client.Request(Method.GET, "api/ticker");
        }
    }
}