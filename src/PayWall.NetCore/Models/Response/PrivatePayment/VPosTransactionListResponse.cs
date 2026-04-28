using System;
using System.Collections.Generic;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.PrivatePayment;

/// <summary>
/// Ödeme listeleme (işlem bazlı veya hareket bazlı) sayfalı cevap gövdesi.
/// </summary>
public class VPosTransactionListResponse : IResponseResult
{
    public string SortType { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalRecords { get; set; }
    public List<VPosTransactionListItem> Data { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}

public class VPosTransactionListItem
{
    public int Id { get; set; }
    public int PosType { get; set; }
    public int? RegionId { get; set; }
    public string UniqueCode { get; set; }
    public string MerchantUniqueCode { get; set; }
    public string TrackingCode { get; set; }
    public decimal Amount { get; set; }
    public short MethodId { get; set; }
    public short TypeId { get; set; }
    public short StatusId { get; set; }
    public byte Installment { get; set; }
    public short ChannelId { get; set; }
    public int TagId { get; set; }
    public string Ip { get; set; }
    public string ClientIp { get; set; }
    public DateTime InsertDateTime { get; set; }
    public VPosTransactionListCard Card { get; set; }
    public VPosTransactionListCommission Commission { get; set; }
    public VPosTransactionListPaymentGateway PaymentGateway { get; set; }
    public List<VPosTransactionListActivity> Activities { get; set; }
}

public class VPosTransactionListCard
{
    public int CardBankId { get; set; }
    public string CardBank { get; set; }
    public int CardBrandId { get; set; }
    public string CardBrand { get; set; }
    public int CardFamilyId { get; set; }
    public string CardFamily { get; set; }
    public int CardKindId { get; set; }
    public string CardKind { get; set; }
    public int CardTypeId { get; set; }
    public string CardType { get; set; }
    public string Owner { get; set; }
    public string Number { get; set; }
    public bool UsedSavedCard { get; set; }
    public bool UsedTempCard { get; set; }
}

public class VPosTransactionListCommission
{
    public bool Exists { get; set; }
    public decimal? Commission { get; set; }
    public bool AppliedInterest { get; set; }
    public decimal? Interest { get; set; }
    public decimal OriginalAmount { get; set; }
    public decimal? InterestAmount { get; set; }
}

public class VPosTransactionListPaymentGateway
{
    public int PaymentGatewayId { get; set; }
    public string PaymentGatewayName { get; set; }
    public string PaymentGatewayProviderName { get; set; }
    public string PaymentGatewayProviderKey { get; set; }
}

public class VPosTransactionListActivity
{
    public int Id { get; set; }
    public short TypeId { get; set; }
    public short StatusId { get; set; }
    public decimal Amount { get; set; }
    public DateTime InsertDateTime { get; set; }
}
