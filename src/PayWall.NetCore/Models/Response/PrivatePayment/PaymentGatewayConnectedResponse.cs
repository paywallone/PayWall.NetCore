using System;
using System.Collections.Generic;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.PrivatePayment;

public class PaymentGatewayConnectedResponse : IResponseResult
{
    public int Count { get; set; }
    public List<PaymentGatewayConnectedItem> Data { get; set; }
}

public class PaymentGatewayConnectedItem
{
    public int Id { get; set; }
    public int PosType { get; set; }
    public string ConnectionName { get; set; }
    public string ProviderKey { get; set; }
    public string ProviderName { get; set; }
    public bool DirectPayment { get; set; }
    public bool ThreeDPayment { get; set; }
    public bool PaymentWithoutCvv { get; set; }
    public int EndOfDayId { get; set; }
    public DateTime InsertDateTime { get; set; }
    public bool WeekendSettlement { get; set; }
    public bool HolidaySettlement { get; set; }
    public bool IsConnected { get; set; }
}
