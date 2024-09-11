using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.CardProduction.CardOperations;

public class CardOperationAccountResponse : IResponseResult
{
    public CardProductionBalances[] Balances { get; set; }
    public string ProviderDump { get; set; }
    public int ProviderHttpStatus { get; set; }
    public int ProviderConnectedId { get; set; }
    public int ProviderId { get; set; }
    public string ProviderKey { get; set; }
    public int CurrencyId { get; set; }
}

public class CardProductionBalances
{
    public double TotalBalance { get; set; }
    public double LockedBalance { get; set; }
    public double AvailableBalance { get; set; }
}

