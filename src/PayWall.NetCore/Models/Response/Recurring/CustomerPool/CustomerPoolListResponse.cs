using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Recurring.CustomerPool;

public class CustomerPoolListResponse : IResponseResult
{
    public int TotalRecord { get; set; }
    public CustomerPoolData[] Data { get; set; }
}

public class CustomerPoolData
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerLastname { get; set; }
    public string CustomerPhone { get; set; }
    public string CustomerEmail { get; set; }
    public string CustomerCountry { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerAddress { get; set; }
    public string CustomerIdentity { get; set; }
    public string LastChangesDateTime { get; set; }
    public int ActiveUsedSubscription { get; set; }
}


