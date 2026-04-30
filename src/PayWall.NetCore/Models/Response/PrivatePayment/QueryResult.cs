using System;
using System.Collections.Generic;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.PrivatePayment;

public class QueryResponse : IResponseResult
{
    public QueryPaywallResponse Paywall { get; set; }
}

public class QueryListResponse : IResponseResult
{
    public List<QueryPaywallResponse> List { get; set; }
}

public class QueryPaywallResponse
{
    public int PaymentId { get; set; }
    public string UniqueCode { get; set; }
    public string MerchantUniqueCode { get; set; }
    public string TrackingCode { get; set; }
    public int ActivityId { get; set; }
    public int PaymentGatewayId { get; set; }
    public string PaymentGatewayName { get; set; }
    public string PaymentGatewayProviderName { get; set; }
    public string PaymentGatewayProviderKey { get; set; }
    public bool IsThreeDSecure { get; set; }
    public bool IsNonThreeDSecure { get; set; }
    public bool IsInsuranceSecure { get; set; }
    public bool IsProvision { get; set; }
    public bool IsOtp { get; set; }
    public bool AnySuccessPayment { get; set; }
    public bool AnySuccessRefund { get; set; }
    public bool AnySuccessPartialRefund { get; set; }
    public bool AnySuccessCancel { get; set; }
    public bool IsFullyRefunded { get; set; }
    public bool PendingProvisionClose { get; set; }
    public decimal? RemainingRefundAmount { get; set; }
    public QueryPaywallErrorResponse Error { get; set; }
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
    public int? CardBankId { get; set; }
    public string CardBankName { get; set; }
    public int? CardBrandId { get; set; }
    public string CardBrandName { get; set; }
    public int? CardTypeId { get; set; }
    public string CardTypeName { get; set; }
    public int? CardFamilyId { get; set; }
    public string CardFamilyName { get; set; }
    public DateTime LastActivityDateTime { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal ActivityAmount { get; set; }
    public string IP { get; set; }
    public string ClientIP { get; set; }
    public bool? AppliedInterest { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? CommissionRate { get; set; }
    public decimal? OriginalAmount { get; set; }
    public decimal? InterestAmount { get; set; }
    public decimal? CommissionAmount { get; set; }
    public bool UsedSavedCard { get; set; }
    public bool UsedTempCard { get; set; }
    public List<QueryPaywallActivityResponse> Activities { get; set; }
    public string PaymentExternalAuthCode { get; set; }
    public string PaymentExternalOrderId { get; set; }
    public string PaymentExternalTransId { get; set; }
    public string PaymentExternalHostReference { get; set; }
    public string PaymentExternalMerchantId { get; set; }
}

public class QueryPaywallErrorResponse
{
    public bool AnyError { get; set; }
    public int ErrorType { get; set; }
    public string ErrorMessage { get; set; }
}

public class QueryPaywallActivityResponse
{
    public int Id { get; set; }
    public int PaymentActivityTypeId { get; set; }
    public string PaymentActivityTypeName { get; set; }
    public int PaymentStatusId { get; set; }
    public string PaymentStatusName { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateTime { get; set; }
    public int PaymentGatewayId { get; set; }
    public string PaymentGatewayName { get; set; }
    public string PaymentGatewayProviderName { get; set; }
    public string PaymentGatewayProviderKey { get; set; }
}