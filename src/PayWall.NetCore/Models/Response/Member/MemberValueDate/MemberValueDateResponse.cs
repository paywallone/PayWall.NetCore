using PayWall.NetCore.Models.Abstraction;

namespace PayWall.NetCore.Models.Response.Member.MemberValueDate;

public class MemberValueDateResponse : IResponseResult
{
 
    public int Id { get; set; }
    /// <summary>
    /// Üye işyerinin hakedişinin hangi aralık tipinde hesaplanacağını belirtir. Sistem verilerinden daha detaylı ulaşabilirsiniz. 1 = PlusDay 2 = ADayOfWeek 3 = ADayOfMonth.
    /// </summary>
    public int CalculationType { get; set; }
    /// <summary>
    /// Üye işyeri hakedişini hangi aralıkta alacağının değeri. Bu değer tipe göre farklı aralıklar almaktadır. 1 ise (1-100) arasında 2 ise (1-7) arasında 3 ise (1-28) arasında.
    /// </summary>
    public int CalculationValue { get; set; }
    /// <summary>
    /// Alt üye işyerinden alınacak komisyon yüzdesi belirtilir, hak ediş hesaplandığında alt üye işyerinde yüzde kadar kazanç düşülür Alışveriş 100TL, hak edişiniz 10% ve gün sonunda 90TL üye işyerine 10TL (ödeme sağlayıcı komisyonu düşülecektir) sizin hesabınıza yansır.
    /// </summary>
    public decimal Commission { get; set; }
}