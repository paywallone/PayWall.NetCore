#region Using Directives

using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PayWall.NetCore;
using PayWall.NetCore.Models.Abstraction;
using PayWall.NetCore.Models.Request.Apm;
using PayWall.NetCore.Models.Request.Apm.CheckoutBasedRequest;
using PayWall.NetCore.Models.Request.Apm.OtpBasedRequest;
using PayWall.NetCore.Models.Request.Apm.PayRequest;
using PayWall.NetCore.Models.Request.Apm.QrBasedRequest;
using PayWall.NetCore.Models.Request.CardWall;
using PayWall.NetCore.Models.Request.Checkout;
using PayWall.NetCore.Models.Request.LinkQr;
using PayWall.NetCore.Models.Request.Member;
using PayWall.NetCore.Models.Request.Member.MemberBankAccount;
using PayWall.NetCore.Models.Request.Member.MemberValueDate;
using PayWall.NetCore.Models.Request.Payment;
using PayWall.NetCore.Models.Request.PayOut;
using PayWall.NetCore.Models.Request.PrivatePayment;
using PayWall.NetCore.Models.Request.Reconciliation.VPos;
using PayWall.NetCore.Models.Response.Apm.OtpResponse;
using PayWall.NetCore.Services;

#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                    { Version = "1", Description = "PayWall API C# Nuget Sample", Title = "PayWall API" });
        }
    );

builder.Services.AddPaywallService(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));

#region Payment

#region NonSecure Ödeme (2D)

app.MapPost("/payment/startDirect",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentRequest request) =>
        await payWallService.Payment.StartDirectAsync(request))
    .WithTags("Payment")
    .WithSummary("Direkt Ödeme (Non-Secure)")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/2.-direkt-odeme-non-secure\">Dökümantasyon</a>");

#endregion

#region Secure Ödeme (3D)

app.MapPost("/payment/startThreeD",
        async ([FromServices] PayWallService payWallService, [FromBody] Payment3DRequest request) =>
        await payWallService.Payment.StartThreeDAsync(request))
    .WithTags("Payment")
    .WithSummary("3D Ödeme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/3.-3d-odeme\">Dökümantasyon</a>");

#endregion

#region Provizyon

app.MapPost("/payment/provision",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentProvisionRequest request) =>
        await payWallService.Payment.ProvisionAsync(request))
    .WithTags("Payment")
    .WithSummary("Provizyon Kapatma")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/5.-provizyon-kapatma\">Dökümantasyon</a>");

app.MapPost("/payment/provision/cancel",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentProvisionCancelRequest request) =>
        await payWallService.Payment.ProvisionCancelAsync(request))
    .WithTags("Payment")
    .WithSummary("Provizyon İptal")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/6.-provizyon-iptal\">Dökümantasyon</a>");

#endregion

#region Installment

app.MapGet("/payment/installment", async ([FromServices] PayWallService payWallService, [FromHeader] string binNumber,
            [FromHeader] Currency currency, [FromHeader] decimal amount, [FromHeader] PaymentTerm endOfTheDay,
            [FromHeader] bool distinctDuplicates) =>
        {
            var request = new InstallmentRequest
            {
                BinNumber = binNumber,
                CurrencyId = currency,
                Amount = amount,
                EndOfTheDay = endOfTheDay,
                DistinctDuplicates = distinctDuplicates
            };
            return await payWallService.Payment.GetInstallmentAsync(request);
        }
    )
    .WithTags("Payment")
    .WithSummary("Taksit Sorgula")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/7.-taksit-sorgula\">Dökümantasyon</a>");

#endregion

#region BIN

app.MapGet("/payment/bin/inquiry",
        async ([FromServices] PayWallService payWallService, [FromHeader] string binNumber) =>
        await payWallService.Payment.GetBinInquiryAsync(binNumber))
    .WithTags("Payment")
    .WithSummary("Bin Sorgula")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/8.-bin-sorgula\">Dökümantasyon</a>");

#endregion

#region Checkout

app.MapPost("/checkout/generate",
        async ([FromServices] PayWallService payWallService, [FromBody] CheckoutRequest request) =>
        await payWallService.Payment.CheckoutGenerateAsync(request))
    .WithTags("Checkout")
    .WithSummary("Ortak Ödeme Sayfası Oluştur")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/ortak-odeme-sayfasi/1.-olustur\">Dökümantasyon</a>");

app.MapGet("/checkout/inquiry",
        async ([FromServices] PayWallService payWallService, [FromHeader] string id) =>
        await payWallService.Payment.GetCheckoutInquiry(id))
    .WithTags("Checkout")
    .WithSummary("Ortak Ödeme Sayfası Sorgulama")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/ortak-odeme-sayfasi/2.-odeme-sorgulama\">Dökümantasyon</a>");

#endregion

#region LinkQr

app.MapPost("/linkqr/generate",
        async ([FromServices] PayWallService payWallService, [FromBody] LinkRequest request) =>
        await payWallService.Payment.GenerateLinkAsync(request))
    .WithTags("LinkQr")
    .WithSummary("LinkQr Ödeme Emri Oluştur")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://https://developer.paywall.one/linkqr-servisi/1.-olustur\">Dökümantasyon</a>");

#endregion

#region PayOut

app.MapGet("/payout/balance",
        async ([FromServices] PayWallService payWallService, [FromHeader] string payoutconnectionid) =>
        await payWallService.Payment.GetBalanceAsync(payoutconnectionid))
    .WithTags("PayOut")
    .WithSummary("Bakiye Kontrol.")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/payout-servisi/1.-bakiye\">Dökümantasyon</a>");

app.MapGet("/payout/balance/main",
        async ([FromServices] PayWallService payWallService, [FromHeader] string currencyid) =>
        await payWallService.Payment.GetMainBalanceAsync(currencyid))
    .WithTags("PayOut")
    .WithSummary("Bakiye Kontrol (Ana Hesap)")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/payout-servisi/2.-bakiye-ana-hesap\">Dökümantasyon</a>");

app.MapPost("/payout/send/iban",
        async ([FromServices] PayWallService payWallService, [FromBody] PayOutToIbanRequest request) =>
        await payWallService.Payment.SendToIbanAsync(request))
    .WithTags("PayOut")
    .WithSummary("Iban'a Gönderme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/payout-servisi/3.-ibana\">Dökümantasyon</a>");

app.MapPost("/payout/send/member",
        async ([FromServices] PayWallService payWallService, [FromBody] PayOutToIbanWithMemberRequest request) =>
        await payWallService.Payment.SendToMemberIbanAsync(request))
    .WithTags("PayOut")
    .WithSummary("Kayıtlı Üye Iban'ına")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/payout-servisi/4.-kayitli-uye-iban-member\">Dökümantasyon</a>");

app.MapPost("/payout/send/account",
        async ([FromServices] PayWallService payWallService, [FromBody] PayOutToAccountRequest request) =>
        await payWallService.Payment.SendToAccountAsync(request))
    .WithTags("PayOut")
    .WithSummary("Hesaba")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/payout-servisi/5.-hesapa\">Dökümantasyon</a>");

app.MapGet("/payout/query",
        async ([FromServices] PayWallService payWallService, [FromHeader] string merchantuniquecode) =>
        await payWallService.Payment.GetPayOutQueryAsync(merchantuniquecode))
    .WithTags("PayOut")
    .WithSummary("İşlem Sorgulama")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/payout-servisi/6.-islem-sorgulama\">Dökümantasyon</a>");

app.MapGet("/payout/verify/account/identity",
        async ([FromServices] PayWallService payWallService, [FromHeader] string providerkey,
                [FromHeader] string currencyid, [FromHeader] string identity) =>
            await payWallService.Payment.GetPayOutVerifyAccountDetailAsync(providerkey, currencyid, identity))
    .WithTags("PayOut")
    .WithSummary("Hesap Sorgulama")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/payout-servisi/7.-hesap-sorgulama\">Dökümantasyon</a>");

#endregion


#region APM

app.MapPost("/apm/pay",
        async ([FromServices] PayWallService payWallService, [FromBody] ApmPayRequest request) =>
        await payWallService.Payment.ApmPayAsync(request))
    .WithTags("Apm")
    .WithSummary("Ödeme Başlat")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/directpay-tabanli/1.-odeme-baslat\">Dökümantasyon</a>");

app.MapPost("/apm/pay/confirm/otp",
        async ([FromServices] PayWallService payWallService, [FromBody] ApmPayConfirmOtpRequest request) =>
        await payWallService.Payment.ApmOtpConfirmAsync(request))
    .WithTags("Apm")
    .WithSummary("Ödeme Onayla / Otp Tabanlı")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/otp-tabanli/1.-odeme-onayla\">Dökümantasyon</a>");

app.MapPost("/apm/pay/qr/generate",
        async ([FromServices] PayWallService payWallService, [FromBody] ApmPayQrRequest request) =>
        await payWallService.Payment.ApmQrGenerateAsync(request))
    .WithTags("Apm")
    .WithSummary("Ödeme Başlat / QR Tabanlı")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/qr-tabanli/1.-odeme-olustur\">Dökümantasyon</a>");

app.MapPost("/apm/pay/byid",
        async ([FromServices] PayWallService payWallService, [FromBody] ApmCheckoutPayByIdRequest request) =>
        await payWallService.Payment.ApmCheckoutPayIdAsync(request))
    .WithTags("Apm")
    .WithSummary("Ödeme Başlat (Id) checkout")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/checkoutpage-tabanli/1.-odeme-baslat-id\">Dökümantasyon</a>");

app.MapPost("/apm/pay/bykey",
        async ([FromServices] PayWallService payWallService, [FromBody] ApmCheckoutPayByKeyRequest request) =>
        await payWallService.Payment.ApmCheckoutPayKeyAsync(request))
    .WithTags("Apm")
    .WithSummary("Ödeme Başlat (Key)")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/checkoutpage-tabanli/2.-odeme-baslat-key\">Dökümantasyon</a>");

app.MapGet("/apm/list",
        async ([FromServices] PayWallService payWallService, [FromHeader] string currencyid,
                [FromHeader] string? externalid, [FromHeader] string? focusedfeature,
                [FromHeader] string? distinctduplicates) =>
            await payWallService.Payment.GetApmListAsync(currencyid, externalid, focusedfeature, distinctduplicates))
    .WithTags("Apm")
    .WithSummary("APM'lerimi listele")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/1.-bagli-saglayici-liste\">Dökümantasyon</a>");

app.MapGet("/apm/query",
        async ([FromServices] PayWallService payWallService, [FromHeader] string merchantuniquecode) =>
            await payWallService.Payment.GetApmQueryAsync(merchantuniquecode))
    .WithTags("Apm")
    .WithSummary("Ödeme Sorgula")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/2.-odeme-sorgula\">Dökümantasyon</a>");

app.MapPost("/apm/refund",
        async ([FromServices] PayWallService payWallService, [FromBody] ApmRefundRequest request) =>
        await payWallService.Payment.ApmRefundAsync(request))
    .WithTags("Apm")
    .WithSummary("Ödeme İade İşlemi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/3.-iade\">Dökümantasyon</a>");

app.MapPost("/apm/refund/partial",
        async ([FromServices] PayWallService payWallService, [FromBody] ApmRefundPartialRequest request) =>
        await payWallService.Payment.ApmPartialRefundAsync(request))
    .WithTags("Apm")
    .WithSummary("Ödeme Kısmi İade İşlemi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/alternatif-odeme-apm/4.-kismi-iade\">Dökümantasyon</a>");

#endregion


#endregion

#region PaymentPrivate

#region Refund/Partial-Refund/Cancel

app.MapGet("/payment-private/query",
        async ([FromServices] PayWallService payWallService, [FromHeader] string merchantUniqueCode) =>
        await payWallService.PaymentPrivate.QueryAsync(merchantUniqueCode))
    .WithTags("PaymentPrivate")
    .WithSummary("Ödeme Sorgulama")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/12.-odeme-sorgulama\">Dökümantasyon</a>");

app.MapPost("/payment-private/refund",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentRefundRequest request) =>
        await payWallService.PaymentPrivate.RefundAsync(request))
    .WithTags("PaymentPrivate")
    .WithSummary("İade Servisi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/9.-iade\">Dökümantasyon</a>");

app.MapPost("/payment-private/refund/partial",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentRefundPartialRequest request) =>
        await payWallService.PaymentPrivate.RefundPartialAsync(request))
    .WithTags("PaymentPrivate")
    .WithSummary("Kısmi İade Servisi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/10.-kismi-iade\">Dökümantasyon</a>");

app.MapPost("/payment-private/refund/cancel",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentCancelRequest request) =>
        await payWallService.PaymentPrivate.CancelAsync(request))
    .WithTags("PaymentPrivate")
    .WithSummary("İptal Servisi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/11.-iptal\">Dökümantasyon</a>");

#endregion

#region VPosReconciliation

app.MapPost("/payment-private/vpos/reconciliation/reconcile",
        async ([FromServices] PayWallService payWallService, [FromBody] VPosReconcileRequest request) =>
        await payWallService.PaymentPrivate.ReconcileAsync(request))
    .WithTags("PaymentPrivate")
    .WithSummary("Mutabakat Yap")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/mutabakat-servisi/sanal-pos/1.-mutabakat-yap\">Dökümantasyon</a>");

app.MapGet("/payment-private/vpos/reconciliation",
        async ([FromServices] PayWallService payWallService, [FromHeader] string reconciliationdate) =>
        await payWallService.PaymentPrivate.GetReconcilliation(reconciliationdate))
    .WithTags("PaymentPrivate")
    .WithSummary("Mutabakat Getir")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/mutabakat-servisi/sanal-pos/2.-mutabakat-getir\">Dökümantasyon</a>");

app.MapGet("/payment-private/vpos/reconciliation/endofday",
        async ([FromServices] PayWallService payWallService, [FromHeader] string endofdaydate) =>
        await payWallService.PaymentPrivate.GetEndOfDay(endofdaydate))
    .WithTags("PaymentPrivate")
    .WithSummary("Gün Sonu Verileri")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/mutabakat-servisi/sanal-pos/3.-gun-sonu-verileri\">Dökümantasyon</a>");

app.MapGet("/payment-private/vpos/reconciliation/list",
        async ([FromServices] PayWallService payWallService, [FromHeader] string datefrom,
                [FromHeader] string dateto, [FromHeader] string start, [FromHeader] string length,
                [FromHeader] string sortvalue) =>
            await payWallService.PaymentPrivate.GetReconcilliationList(datefrom, dateto, start, length, sortvalue))
    .WithTags("PaymentPrivate")
    .WithSummary("Mutabakat Listesi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/mutabakat-servisi/sanal-pos/4.-mutabakat-listesi\">Dökümantasyon</a>");

#endregion

#endregion

#region CardWall

app.MapPost("/card",
        async ([FromServices] PayWallService payWallService, [FromBody] AddCardRequest request) =>
        await payWallService.CardWall.AddAsync(request))
    .WithTags("CardWall")
    .WithSummary("Yeni Kart Sakla")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/kart-saklama-servisi/1.-yeni-kart\">Dökümantasyon</a>");

app.MapGet("/card",
        async ([FromServices] PayWallService payWallService, [FromQuery] string relationalIdOne,
                [FromQuery] string? relationalIdTwo, [FromQuery] string? relationalIdTree,
                [FromQuery] bool? includeDetails) =>
            await payWallService.CardWall.GetAsync(relationalIdOne, relationalIdTwo, relationalIdTree, includeDetails))
    .WithTags("CardWall")
    .WithSummary("Kayıtlı Kart Listesi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/kart-saklama-servisi/2.-kayitli-kartlar\">Dökümantasyon</a>");

app.MapDelete("/card",
        async ([FromServices] PayWallService payWallService, [FromBody] DeleteCardRequest request) =>
        await payWallService.CardWall.DeleteAsync(request))
    .WithTags("CardWall")
    .WithSummary("Kayıtlı Kart Silme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/kart-saklama-servisi/3.-kart-sil\">Dökümantasyon</a>");

app.MapPut("/card",
        async ([FromServices] PayWallService payWallService, [FromBody] EditCardRequest request) =>
        await payWallService.CardWall.PutAsync(request))
    .WithTags("CardWall")
    .WithSummary("Kayıtlı Kart Güncelleme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/kart-saklama-servisi/4.-kart-guncelle\">Dökümantasyon</a>");

#endregion

#region Member

app.MapPost("/member",
        async ([FromServices] PayWallService payWallService, [FromBody] AddMemberRequest request) =>
        await payWallService.MemberClient.AddMemberAsync(request))
    .WithTags("Member")
    .WithSummary("Yeni Üye Oluştur")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-yonetimi/1.-uye-olustur\">Dökümantasyon</a>");

app.MapPut("/member",
        async ([FromServices] PayWallService payWallService, [FromBody] UpdateMemberRequest request) =>
        await payWallService.MemberClient.UpdateMemberAsync(request))
    .WithTags("Member")
    .WithSummary("Üye Güncelleme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-yonetimi/2.-uye-guncelle\">Dökümantasyon</a>");

app.MapDelete("/member",
        async ([FromServices] PayWallService payWallService, [FromBody] DeleteMemberRequest request) =>
        await payWallService.MemberClient.DeleteMemberAsync(request))
    .WithTags("Member")
    .WithSummary("Üye Silme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-yonetimi/3.-uye-sil\">Dökümantasyon</a>");

app.MapGet("/member",
        async ([FromServices] PayWallService payWallService, [FromQuery] string start,
                [FromQuery] string length) =>
            await payWallService.MemberClient.GetListMemberAsync(start, length))
    .WithTags("Member")
    .WithSummary("Üye Listeleme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-yonetimi/4.-uyeler\">Dökümantasyon</a>");

app.MapGet("/member/search",
        async ([FromServices] PayWallService payWallService, [FromQuery] string? memberid,
                [FromQuery] string? memberexternalid) =>
            await payWallService.MemberClient.GetMemberAsync(memberid, memberexternalid))
    .WithTags("Member")
    .WithSummary("Üye Arama")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-yonetimi/5.-uye-ara\">Dökümantasyon</a>");

#region MemberBankAccount

app.MapPost("/member/bankaccount",
        async ([FromServices] PayWallService payWallService, [FromBody] AddBankAccountRequest request) =>
        await payWallService.MemberClient.AddBankAccountAsync(request))
    .WithTags("MemberBankAccount")
    .WithSummary("Yeni Banka Hesabı Oluştur")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-banka-yonetimi/1.-banka-yontemi-ekle\">Dökümantasyon</a>");
app.MapPut("/member/bankaccount",
        async ([FromServices] PayWallService payWallService, [FromBody] UpdateBankAccountRequest request) =>
        await payWallService.MemberClient.UpdateBankAccountAsync(request))
    .WithTags("MemberBankAccount")
    .WithSummary("Banka Hesabı Güncelleme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-banka-yonetimi/2.-banka-yontemi-duzenle\">Dökümantasyon</a>");
app.MapDelete("/member/bankaccount",
        async ([FromServices] PayWallService payWallService, [FromBody] DeleteBankAccountRequest request) =>
        await payWallService.MemberClient.DeleteBankAccountAsync(request))
    .WithTags("MemberBankAccount")
    .WithSummary("Banka Hesabı Silme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-banka-yonetimi/3.-banka-yontemi-sil\">Dökümantasyon</a>");
app.MapGet("/member/bankaccount",
        async ([FromServices] PayWallService payWallService, [FromQuery] string memberid) =>
        await payWallService.MemberClient.GetBankAccountAsync(memberid))
    .WithTags("MemberBankAccount")
    .WithSummary("Banka Hesabı Arama")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-banka-yonetimi/4.-banka-yontemleri\">Dökümantasyon</a>");

#endregion

#region MemberValueDate

app.MapPost("/member/valuedate",
        async ([FromServices] PayWallService payWallService, [FromBody] AddMemberValueDateRequest request) =>
        await payWallService.MemberClient.AddMemberValueDateAsync(request))
    .WithTags("MemberValueDate")
    .WithSummary("Valör/Komisyon Ayarını Ekle (Var olanı da günceller)")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-valor-komisyon/2.-valor-komisyon-ekle\">Dökümantasyon</a>");

app.MapGet("/member/valuedate",
        async ([FromServices] PayWallService payWallService, [FromQuery] string memberid) =>
        await payWallService.MemberClient.GetMemberValueDateAsync(memberid))
    .WithTags("MemberValueDate")
    .WithSummary("Valör/Komisyon Sorgula")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/uye-servisi/uye-valor-komisyon/1.-valor-komisyon-getir\">Dökümantasyon</a>");

#endregion

#endregion

#region Error Handling

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error is JsonException jsonException)
        {
            var errorDetails = new
            {
                body = (object?)null,
                result = false,
                message = jsonException.Message,
                errorCode = 13
            };

            var jsonResponse = JsonSerializer.Serialize(errorDetails);
            await context.Response.WriteAsync(jsonResponse);
        }
        else
        {
            var errorDetails = new
            {
                body = (object?)null,
                result = false,
                message = exceptionHandlerPathFeature?.Error?.InnerException?.Message ??
                          exceptionHandlerPathFeature?.Error?.Message ?? "An unexpected error occurred",
                errorCode = 13
            };

            var jsonResponse = JsonSerializer.Serialize(errorDetails);
            await context.Response.WriteAsync(jsonResponse);
        }
    });
});

#endregion

app.Run();