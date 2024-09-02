using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.CardProduction.CardOperations;

public class CardTransactionsListResponse : IResponseResult
{
    public int Page { get; set; }
    public int PageItemCount { get; set; }
    public int TotalItemCount { get; set; }
    public int TotalPageCount { get; set; }
    public int PageSkip { get; set; }
    public CardTransactions[] Transactions { get; set; }
}

public class CardTransactions
{
    public int TransactionId { get; set; }
    public string CardNumber { get; set; }
    public string DateTime { get; set; }
    public decimal Amount { get; set; }
    public string MerchantId { get; set; }
    public int CardType { get; set; }
    public int CardId { get; set; }
    public string CardDescription { get; set; }
    public string Description { get; set; }
    public double AvailableBalance { get; set; }
}


