using System;
using System.Collections.Generic;
using RestSharp;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace CoinCheck
{
    internal class CoinCheck
    {
        private readonly string _accessKey;

        private readonly string _secretKey;

        private const string BaseUri = "https://coincheck.jp/";

        public static void Main(string[] args)
        {
            var client = new CoinCheck("sXK0PCCFSjpSpu9c", "FRYnWH4eop5aFb7_E75cWyEarhwdWPhS");
            var udemy = new Dictionary<string, string>();
            udemy.Add("bank_name", "gggggg");
            udemy.Add("branch_name", "tanaka");
            udemy.Add("bank_account_type", "futsu");
            udemy.Add("number", "1234567");
            udemy.Add("name", "kakaka");
            var bankAccount = JsonConvert.SerializeObject(udemy);
            client.Request(Method.POST, "api/bank_accounts", bankAccount);

        }

        public CoinCheck(string accessKey, string secretKey)
        {
            _accessKey = accessKey;
            _secretKey = secretKey;
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