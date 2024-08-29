using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Request.Member.MemberValueDate;

public class AddMemberValueDateRequest : IRequestParams
{
    /// <summary>
    /// Üye'nin PayWall'daki Id bilgisi.
    /// </summary>
    public int MemberId { get; set; }
    /// <summary>
    /// Hakediş hesaplama tipi. Sistem verileri alanından daha detaylı bilgiye ulaşabilirsiniz.
    /// </summary>
    public int CalculationType { get; set; }
    /// <summary>
    /// Hakediş hesaplama değeri. Sistem verileri alanından daha detaylı bilgiye ulaşabilirsiniz.
    /// </summary>
    public int CalculationValue { get; set; }
    /// <summary>
    /// Hakediş hesaplama anında alt üye işyerine uygulanacak komisyon değeri.
    /// </summary>
    public decimal Commission { get; set; }
}


