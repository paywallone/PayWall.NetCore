using System.Collections.Generic;
using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Payment;

public class InstallmentResponse : IResponseResult
{
    /// <summary>
    /// Kartın bağlı olduğu bankanın adı.
    /// </summary>
    public string CardBank { get; set; }

    /// <summary>
    /// Kartın markasının adı.
    /// </summary>
    public string CardBrand { get; set; }

    /// <summary>
    /// Kartın ait olduğu kart ailesinin adı.
    /// </summary>
    public string CardFamily { get; set; }

    /// <summary>
    /// Kartın türünün adı.
    /// </summary>
    public string CardKind { get; set; }

    /// <summary>
    /// Kartın tipinin adı.
    /// </summary>
    public string CardType { get; set; }

    public List<InstallmentOptionResponse> Options { get; set; }
}

public class InstallmentSingleResponse
{
    /// <summary>
    /// Kartın ait olduğu kart ailesinin Id'si.
    /// </summary>
    public int CardFamilyId { get; set; }
    /// <summary>
    /// Kartın ait olduğu kart ailesinin adı.
    /// </summary>
    public string CardFamily { get; set; }
    public List<InstallmentOptionResponse> Option { get; set; }
}

public class InstallmentOptionResponse
{
    /// <summary>
    /// Taksit sayısı.
    /// </summary>
    public byte Installment { get; set; }

    /// <summary>
    /// İşlem için alınan komisyon ücreti.
    /// </summary>
    public decimal Commission { get; set; }

    /// <summary>
    /// İşlem için uygulanan faiz oranı.
    /// </summary>
    public decimal Interest { get; set; }

    /// <summary>
    /// İşlemin brüt tutarı (faiz ve diğer masraflar hariç).
    /// </summary>
    public decimal RawAmount { get; set; }

    /// <summary>
    /// İşlemde uygulanan faiz tutarı.
    /// </summary>
    public decimal InterestAmount { get; set; }

}