#region Using Directives

using PayWall.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using PayWall.AspNetCore;
using PayWall.AspNetCore.Models.Abstraction;
using PayWall.AspNetCore.Models.Request.CardWall;
using PayWall.AspNetCore.Models.Request.Payment;
using PayWall.AspNetCore.Models.Request.PrivatePayment;

#endregion

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1",
                new Microsoft.OpenApi.Models.OpenApiInfo
                    { Version = "1", Description = "PayWalll API C# Nuget Sample", Title = "PayWalll API" });
        }
    );

builder.Services.AddPaywallService(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));

#region Payment

app.MapPost("/payment/startDirect",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentRequest request) =>
        await payWallService.Payment.StartDirectAsync(request))
    .WithTags("Payment")
    .WithSummary("Direkt Ödeme (Non-Secure)")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/2.-direkt-odeme-non-secure\">Dökümanyasyon</a>");

app.MapPost("/payment/startThreeD",
        async ([FromServices] PayWallService payWallService, [FromBody] Payment3DRequest request) =>
        await payWallService.Payment.StartThreeDAsync(request))
    .WithTags("Payment")
    .WithSummary("3D Ödeme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/3.-3d-odeme\">Dökümanyasyon</a>");

app.MapPost("/payment/provision",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentProvisionRequest request) =>
        await payWallService.Payment.ProvisionAsync(request))
    .WithTags("Payment")
    .WithSummary("Provizyon Kapatma")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/5.-provizyon-kapatma\">Dökümanyasyon</a>");

app.MapPost("/payment/provision/cancel",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentProvisionCancelRequest request) =>
        await payWallService.Payment.ProvisionCancelAsync(request))
    .WithTags("Payment")
    .WithSummary("Provizyon İptal")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/6.-provizyon-iptal\">Dökümanyasyon</a>");

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
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/7.-taksit-sorgula\">Dökümanyasyon</a>");

app.MapGet("/payment/bin/inquiry",
        async ([FromServices] PayWallService payWallService, [FromHeader] string binNumber) =>
        await payWallService.Payment.GetBinInquiryAsync(binNumber))
    .WithTags("Payment")
    .WithSummary("Bin Sorgula")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/8.-bin-sorgula\">Dökümanyasyon</a>");

#endregion

#region PaymentPrivate

app.MapGet("/paymentPrivate/query",
        async ([FromServices] PayWallService payWallService, [FromHeader] string merchantUniqueCode) =>
        await payWallService.PaymentPrivate.QueryAsync(merchantUniqueCode))
    .WithTags("PaymentPrivate")
    .WithSummary("Ödeme Sorgulama")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/12.-odeme-sorgulama\">Dökümanyasyon</a>");

app.MapPost("paymentPrivate/refund",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentRefundRequest request) =>
        await payWallService.PaymentPrivate.RefundAsync(request))
    .WithTags("PaymentPrivate")
    .WithSummary("İade Servisi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/9.-iade\">Dökümanyasyon</a>");

app.MapPost("/paymentPrivate/refund/partial",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentRefundPartialRequest request) =>
        await payWallService.PaymentPrivate.RefundPartialAsync(request))
    .WithTags("PaymentPrivate")
    .WithSummary("Kısmi İade Servisi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/10.-kismi-iade\">Dökümanyasyon</a>");

app.MapPost("/paymentPrivate/refund/cancel",
        async ([FromServices] PayWallService payWallService, [FromBody] PaymentCancelRequest request) =>
        await payWallService.PaymentPrivate.CancelAsync(request))
    .WithTags("PaymentPrivate")
    .WithSummary("İptal Servisi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/odeme-servisi/11.-iptal\">Dökümanyasyon</a>");
#endregion

#region CardWall

app.MapPost("/Card",
        async ([FromServices] PayWallService payWallService, [FromBody] AddCardRequest request) =>
        await payWallService.CardWall.AddAsync(request))
    .WithTags("CardWall")
    .WithSummary("Yeni Kart Sakla")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/kart-saklama-servisi/1.-yeni-kart\">Dökümanyasyon</a>");

app.MapGet("/Card",
        async ([FromServices] PayWallService payWallService, [FromQuery] string relationalIdOne,
                [FromQuery] string? relationalIdTwo, [FromQuery] string? relationalIdTree) =>
            await payWallService.CardWall.GetAsync(relationalIdOne, relationalIdTwo, relationalIdTree))
    .WithTags("CardWall")
    .WithSummary("Kayıtlı Kart Listesi")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/kart-saklama-servisi/2.-kayitli-kartlar\">Dökümanyasyon</a>");

app.MapDelete("/Card",
        async ([FromServices] PayWallService payWallService, [FromBody] DeleteCardRequest request) =>
        await payWallService.CardWall.DeleteAsync(request))
    .WithTags("CardWall")
    .WithSummary("Kayıtlı Kart Silme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/kart-saklama-servisi/3.-kart-sil\">Dökümanyasyon</a>");

app.MapPut("/Card",
        async ([FromServices] PayWallService payWallService, [FromBody] EditCardRequest request) =>
        await payWallService.CardWall.PutAsync(request))
    .WithTags("CardWall")
    .WithSummary("Kayıtlı Kart Güncelleme")
    .WithDescription(
        "<a target=\"_blank\" href=\"https://developer.paywall.one/kart-saklama-servisi/4.-kart-guncelle\">Dökümanyasyon</a>");

#endregion

app.Run();