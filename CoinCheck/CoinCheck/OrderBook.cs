using RestSharp;

namespace CoinCheck
{
    internal class OrderBook
    {
        private readonly CoinCheck _client;

        public OrderBook(CoinCheck client)
        {
            _client = client;
        }

        /** 板情報を取得できます。  **/
        public IRestResponse All()
        {
            return _client.Request(Method.GET, "api/order_books");
        }
    }
}