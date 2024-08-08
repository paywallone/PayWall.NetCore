using System.Collections.Generic;
using PayWall.AspNetCore.Models.Abstraction;

namespace PayWall.AspNetCore.Models.Response.Payment;

public class InstallmentResponse : IResponseResult
{
    public string CardBank { get; set; }
    public string CardBrand { get; set; }
    public string CardFamily { get; set; }
    public string CardKind { get; set; }
    public string CardType { get; set; }
    public List<InstallmentOptionResponse> Options { get; set; }
}

public class InstallmentSingleResponse
{
    public int CardFamilyId { get; set; }
    public string CardFamily { get; set; }
    public List<InstallmentOptionResponse> Option { get; set; }
}

public class InstallmentOptionResponse
{
    public byte Installment { get; set; }
    public decimal Commission { get; set; }
    public decimal Interest { get; set; }
    public decimal RawAmount { get; set; }
    public decimal InterestAmount { get; set; }
}