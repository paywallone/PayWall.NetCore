using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Recurring.ItemPool;

public class ItemPoolResponse : IResponseResult
{
    public int Id { get; set; }
    public int Type { get; set; }
    public string Name { get; set; }
    public double Amount { get; set; }
    public string LastChangesDateTime { get; set; }
    public int ActiveUsedSubscription { get; set; }
}


