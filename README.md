<p align="center">
  <img src="https://paywall.one/assets/img/logos/paywall-logo-3.png" alt="Logo" width="200"/>
</p>

# PayWall.AspNetCore

`PayWall.AspNetCore`, ASP.NET Core 5 ve üzeri sürümler için geliştirilmiş bir NuGet paketidir. Bu paket, PayWall API'sine kolay ve etkili bir şekilde entegrasyon sağlar ve uygulamanızda ödeme duvarı (paywall) işlevselliğini basit bir şekilde uygulamanıza eklemenizi sağlar.

## PayWall

PayWall, ödeme almak isteyen işletmelere uçtan uca kontrol sağlayan bir altyapı sunar. Bu altyapı, gelişmiş abonelik yönetimi, pazaryeri çözümleri, akıllı yönlendirme algoritmaları ve mikro ölçekli ödeme kontrolü gibi hizmetler sunarak işletmelerin karlılığını artırır ve operasyonel yüklerini azaltır. PayWall, bir ödeme orkestrasyon platformu olarak işlev görür; bu sayede kullanıcılar, tercih ettikleri ödeme kuruluşları veya bankalar aracılığıyla ödeme yapabilir ve alabilir.

- **Sanal POS:** PayWall, sanal POS özelliği ile çevrimiçi mağazalar için güvenli ve hızlı ödeme işlemleri gerçekleştirmenizi sağlar.
- **PayOut:** Para transferi/para dağıtımı (IBAN'a transfer) servisidir.
- **KartÜretim:** İşletmelerin kendilerine, alt üye işyerlerine veya çalışanlarına sanal kart ve fiziksel ön ödemeli kart oluşturmalarını sağlayan bir servistir.
- **Alternatif Ödeme(APM):** Farklı ödeme yöntemlerini destekleyerek, müşterilere kredi kartı, banka kartı, dijital cüzdanlar ve daha fazlası gibi çeşitli ödeme seçenekleri sunar.
- **Web ile Ödeme Alma:** Web sitesi üzerinden doğrudan ödeme alma imkanı tanır, böylece çevrimiçi satışlarınızı artırabilirsiniz.
- **Link/QR ile Ödeme Alma:** Müşterilere ödeme linki veya QR kodu göndererek, ödemeleri hızlı ve kolay bir şekilde almanızı sağlar.
- **Ortak Ödeme Sayfası:** Birden fazla işletmenin veya hizmet sağlayıcının aynı ödeme sayfasını kullanabilmesine olanak tanır, bu da iş birliği ve entegrasyonu kolaylaştırır.
- **Tekrarlı Ödeme Servisi:** Tekrarlı ödeme servisleri, sisteminizdeki periyodik ödeme alma senaryolarında tüm süreci sizin için yöneten servislerdir.
- **PayRoute:** Ödeme akışını yönlendiren bu özellik (Komisyona tutarına göre veya özel sıralama), en uygun ödeme yöntemlerini seçmenizi ve işlemlerinizi optimize etmenizi sağlar.
- **RouteTable:** Ödeme işlemlerinin nasıl yönlendirileceğini ve yönetileceğini belirleyen bir tablo sağlar, böylece süreçleri daha verimli hale getirir.
- **PayJump:** Bir ödeme sağlayıcısında sorun yaşandığında otomatik olarak diğer seçili sağlayıcıya geçiş yaparak işlemleri hızlı ve kesintisiz sürdürür.
- **PayBalancer:** Ödemelerinizin sağlayıcılar arasında yönlendirilmesini sağlar. Ödemelerinizi tutar bazlı olarak yönetebilir, aktif sağlayıcılarınız arasında dağıtabilirsiniz.
- **Pazaryeri:** Çoklu satıcıları destekleyen bir pazaryeri çözümü sunarak, birden fazla tedarikçinin ürünlerini aynı platformda satışa sunmasına olanak tanır.


## Özellikler

- **Basit Entegrasyon:** PayWall API'sine hızlı ve kolay erişim.
- **Esnek Yapılandırma:** Yapılandırma seçenekleri ile özelleştirilebilir.
- **Kapsamlı Dokümantasyon:** Kullanım kılavuzları ve API referansları.

## Metotlar

### Kayıtlı Kart İşlemleri

- **Kart Kayıt Etme**
- **Kayıtlı Kart Listeleme**
- **Kayıtlı Kart Silme**
- **Kayıtlı Kart Güncelleme**

### Üye Yönetimi

- **Üye Oluştur**
- **Üye Güncelle**
- **Üye Sil**
- **Üye Sil**
- **Üye Ara**

### Üye Banka Yönetimi

- **Banka Yöntemi Ekle**
- **Banka Yöntemi Düzenle**                                                                     
- **Banka Yöntemi Sil**
- **Banka Yöntemlerini Listele**

### Üye Valör/Komisyon

- **Valör/Komisyon Ayarını Getir**
- **Valör/Komisyon Ayarını Ekle (Var olanı da günceller)**

### Ödeme İşlemleri

- **Direkt Ödeme (2D)** 
- **Güvenli Ödeme (3D)** 
- **Provizyon İşlemleri**
- **Taksit Sorgulama** 
- **BIN Sorgulama**

### PayOut

- **Bakiye Kontrol**
- **Bakiye Kontrol (Ana Hesap)**
- **Iban'a Gönderme**
- **Kayıtlı Üye Iban Gönderme (Member)**
- **Hesaba Gönderme**
- **İşlem Sorgulama**
- **Hesap Sorgulama**

## Kurulum

### NuGet Paket Yöneticisi Kullanarak

Visual Studio'da NuGet Paket Yöneticisi'ni açın, `PayWall.AspNetCore` paketini arayın ve yükleyin.


### .NET CLI Kullanarak

Aşağıdaki komutu kullanarak NuGet paketini yükleyebilirsiniz:

```bash
dotnet add package PayWall.AspNetCore
```
## Yapılandırma

### appsettings.json

Paketi yükledikten sonra `appsettings.json` içinde `PayWall` kısmının olduğu yerde `PublicClient`, `PublicKey`, `PrivateClient` ve `PrivateKey` bilgileri karşınıza çıkıcak. Bilgileri edinmek için PayWall panelini kullanabilirsiniz. İlgili sayfa: `Geliştirici > Entegrasyon`

### Yapılandırma Json
```json
"PayWall" : {
  "Prod": false,
  "PublicClient": "********************",
  "PublicKey": "***********************",
  "PrivateClient": "***********************",
  "PrivateKey": "****************************"
}
```

- **Prod:** Test ortamında işlem yapmak istediğiniz zaman `Prod:` `false` olmalı. Prod ortamda yapmak isterseniz `Prod:` `true` olmalı.
- **PublicClient:** Kimlik bilgisini panelden alabilirsiniz.
- **PublicKey:** Kimlik bilgisini panelden alabilirsiniz.
- **PrivateClient:** Kimlik bilgisini panelden alabilirsiniz.
- **PrivateKey:** Kimlik bilgisini panelden alabilirsiniz.

## Adresler 

- **PayWall Entegrasyon Dökümanı:** [https://developer.paywall.one/](https://developer.paywall.one/)                                                        
- **Website:** [https://paywall.one/](https://paywall.one/)
- **Test Paneli:** [https://dev-panel.itspaywall.com/](https://dev-panel.itspaywall.com/)
- **Canlı Panel:** [https://panel.itspaywall.com/](https://panel.itspaywall.com/)
<p align="center">
  <img src="https://sc-images-prod.s3.eu-central-1.amazonaws.com/logos/e137b4f1-730c-42d8-9d11-af7c2d2d4715" alt="Logo" width="100"/>
</p>
