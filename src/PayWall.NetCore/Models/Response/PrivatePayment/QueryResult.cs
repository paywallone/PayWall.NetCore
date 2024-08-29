using System;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.PrivatePayment;

public class QueryResponse : IResponseResult
{
    public QueryPaywallResponse Paywall { get; set; }
}

public class QueryPaywallResponse
{
    public int PaymentId { get; set; }
    public int ActivityId { get; set; }
    public int PaymentGatewayId { get; set; }
    public string PaymentGatewayName { get; set; }
    public string PaymentGatewayProviderName { get; set; }
    public bool AnySuccessPayment { get; set; }
    public bool AnySuccessRefund { get; set; }
    public bool AnySuccessPartialRefund { get; set; }
    public bool AnySuccessCancel { get; set; }
    public bool Status { get; set; }
    public string StatusName { get; set; }
    public int StatusId { get; set; }
    public string TypeName { get; set; }
    public int TypeId { get; set; }
    public byte Installment { get; set; }
    public short CurrencyId { get; set; }
    public string CurrencyName { get; set; }
    public int PaymentMethodId { get; set; }
    public string PaymentMethodName { get; set; }
    public int PaymentChannelId { get; set; }
    public string PaymentChannelName { get; set; }
    public int PaymentTagId { get; set; }
    public string PaymentTagName { get; set; }
    public string CardNumber { get; set; }
    public string CardOwnerName { get; set; }
    public string CardBankName { get; set; }
    public string CardBrandName { get; set; }
    public string CardTypeName { get; set; }
    public string CardFamilyName { get; set; }
    public DateTime LastActivityDateTime { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal ActivityAmount { get; set; }
    public string IP { get; set; }
    public bool? AppliedInterest { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? CommissionRate { get; set; }
    public decimal? OriginalAmount { get; set; }
    public decimal? InterestAmount { get; set; }
    public decimal? CommissionAmount { get; set; }
}