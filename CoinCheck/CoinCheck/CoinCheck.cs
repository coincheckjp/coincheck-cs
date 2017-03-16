using System;
using RestSharp;
using System.Security.Cryptography;
using System.Text;

namespace CoinCheck
{
    internal class CoinCheck
    {
        private readonly string _accessKey;

        private readonly string _secretKey;

        private const string BaseUri = "https://coincheck.jp/";

        public  Account Account { get; set; }

        public BankAccount BankAccount { get; set; }

        public Borrow Borrow { get; set; }

        public Deposit Deposit { get; set; }

        public Leverage Leverage { get; set; }

        public Order Order { get; set; }

        public OrderBook OrderBook { get; set; }

        public Send Send { get; set; }

        public Ticker Ticker { get; set; }

        public Trade Trade { get; set; }

        public Transfer Transfer { get; set; }

        public Withdraw Withdraw { get; set; }

        public CoinCheck(string accessKey, string secretKey)
        {
            _accessKey = accessKey;
            _secretKey = secretKey;
             Account = new Account(this);
            BankAccount = new BankAccount(this);
            Borrow = new Borrow(this);
            Deposit = new Deposit(this);
            Leverage = new Leverage(this);
            Order = new Order(this);
            OrderBook = new OrderBook(this);
            Send = new Send(this);
            Ticker = new Ticker(this);
            Trade = new Trade(this);
            Transfer = new Transfer(this);
            Withdraw = new Withdraw(this);
        }

        public IRestResponse Request(Method method, string path, string param= "")
        {
            var url = BaseUri + path;
            var nonce = GetNonce;
            var message = Convert.ToString(nonce) + url + param;
            var signature = GenerateNewHmac(_secretKey, message);
            var client = new RestClient(url);
            var request = new RestRequest(method);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("access-signature", signature);
            request.AddHeader("access-nonce", Convert.ToString(nonce));
            request.AddHeader("access-key", _accessKey);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", param, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            return response;
        }

        //Get current timestamp
        public static long GetNonce
        {
            get
            {
                var jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                return (long)((DateTime.UtcNow - jan1St1970).TotalMilliseconds);
            }
        }

        //create Hmac 256 key
        public static string GenerateNewHmac(string password, string challenge)
        {
            var hmc = new HMACSHA256(Encoding.ASCII.GetBytes(password));
            var hmres = hmc.ComputeHash(Encoding.ASCII.GetBytes(challenge));
            return BitConverter.ToString(hmres).Replace("-", "").ToLower();
        }
    }
}