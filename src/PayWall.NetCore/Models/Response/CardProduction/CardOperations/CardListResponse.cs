using System;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.CardProduction.CardOperations;

public class CardListResponse : IResponseResult
{
    public Data[] Data { get; set; }
    public int TotalRecord { get; set; }
}

public class Data
{
    public int Id { get; set; }
    public string CardProductionName { get; set; }
    public int CardExternalId { get; set; }
    public string ExternalId { get; set; }
    public string Description { get; set; }
    public string InsertDateTime { get; set; }
    public string Phone { get; set; }
    public string CardNumber { get; set; }
    public string ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
    public int LastActivityTypeId { get; set; }
    public string LastActivityType { get; set; }
    public bool Usable { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
}





