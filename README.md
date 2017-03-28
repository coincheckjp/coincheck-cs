# coincheck-cs

```cs
var client = new CoinCheck("ACCESS_KEY", "API_SECRET");

/** Public API */
client.Ticker.All();
client.Trade.All();
client.OrderBook.All();

/** Private API */

// 新規注文
// "buy" 指値注文 現物取引 買い
// "sell" 指値注文 現物取引 売り
// "market_buy" 成行注文 現物取引 買い
// "market_sell" 成行注文 現物取引 売り
// "leverage_buy" 指値注文 レバレッジ取引新規 買い
// "leverage_sell" 指値注文 レバレッジ取引新規 売り
// "close_long" 指値注文 レバレッジ取引決済 売り
// "close_short" 指値注文 レバレッジ取引決済 買い
//
client.Order.Create(new Dictionary<string, string>
{
    {"rate", "28500"},
    {"amount", "0.00508771"},
    {"order_type", "buy"},
    {"pair", "btc_jpy"}
});

//未決済の注文一覧
client.Order.Open();

//注文のキャンセル
client.Order.Cancel("2953613");

//取引履歴
client.Order.Transactions();

//ポジション一覧
client.Leverage.Positions();

//残高
client.Account.Balance();

//レバレッジアカウントの残高
client.Account.LeverageBalance();

//アカウント情報
client.Account.Info();

//ビットコインの送金
client.Send.Create(new Dictionary<string, string>
{
    {"address", "1Gp9MCp7FWqNgaUWdiUiRPjGqNVdqug2hY"},
    {"amount", "0.0002"}
});

//ビットコインの送金履歴
client.Send.All(new Dictionary<string, string>
{
    {"currency", "BTC"}
});

//ビットコインの受け取り履歴
client.Deposit.All(new Dictionary<string, string>
{
    {"currency", "BTC"}
});

//ビットコインの高速入金
client.Deposit.Fast(new Dictionary<string, string>
{
    {"id", "2222"}
});

//銀行口座一覧
client.BankAccount.All();

//銀行口座の登録
client.BankAccount.Create(new Dictionary<string, string>
{
    {"bank_name", "MUFG"},
    {"branch_name", "tokyo"},
    {"bank_account_type", "futsu"},
    {"number", "1234567"},
    {"name", "DonaldTrump"}
});

//銀行口座の削除
client.BankAccount.Delete("111111");

//出金履歴
client.Withdraw.All();

//出金申請の作成
client.Withdraw.Create(new Dictionary<string, string>
{
    {"bank_account_id", "1234567"},
    {"amount", "1000"},
    {"currency", "JPY"},
    {"is_fast", "false"},
});

//出金申請のキャンセル
client.Withdraw.Cancel("111");

//借入申請
client.Borrow.Create(new Dictionary<string, string>
{
    {"amount", "0.01"},
    {"currency", "BTC"},
});

//借入中一覧
client.Borrow.Matches();

//返済
client.Borrow.Repay(new Dictionary<string, string>
{
    {"id", "1234567"}
});

//レバレッジアカウントへの振替
client.Transfer.ToLeverage(new Dictionary<string, string>
{
    {"amount", "100"},
    {"currency", "JPY"},
});

//アカウントからの振替
client.Transfer.FromLeverage(new Dictionary<string, string>
{
    {"amount", "100"},
    {"currency", "JPY"},
}); 
```
