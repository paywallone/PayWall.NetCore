using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Recurring.ItemPool;

public class ItemPoolListResponse : IResponseResult
{
    public int TotalRecord { get; set; }
    public ItemPoolData[] Data { get; set; }
}

public class ItemPoolData
{
    public int Id { get; set; }
    public int Type { get; set; }
    public string Name { get; set; }
    public decimal Amount { get; set; }
    public string LastChangesDateTime { get; set; }
    public int ActiveUsedSubscription { get; set; }
}


