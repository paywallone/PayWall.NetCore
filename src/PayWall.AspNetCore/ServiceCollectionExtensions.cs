#region Using Directives

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayWall.AspNetCore.Configuration;
using PayWall.AspNetCore.Extensions;
using PayWall.AspNetCore.Implementations;

#endregion

namespace PayWall.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        #region Public Properties

        public static string PaymentClientName => "PaymentApiClient";
        public static string PaymentPrivateClientName => "PaymentPrivateApiClient";
        public static string CardWallClientName => "CardWallApiClient";

        #endregion

        #region Private Properties

        private static Uri ProdPaymentApiUrl => new("https://payment-api.itspaywall.com/api/paywall/");
        private static Uri TestPaymentApiUrl => new("https://dev-payment-api.itspaywall.com/api/paywall/");
        private static Uri ProdPaymentPrivateApiUrl => new("https://payment-private-api.itspaywall.com/api/paywall/");
        private static Uri TestPaymentPrivateApiUrl => new("https://dev-payment-private-api.itspaywall.com/api/paywall/");
        private static Uri ProdCardWallApiUrl => new("https://card-api.itspaywall.com/paywall/");
        private static Uri TestCardWallApiUrl => new("https://dev-card-api.itspaywall.com/paywall/");

        #endregion

        #region Public Methods

        public static void AddPaywallService(this IServiceCollection services, IConfiguration config)
        {
            var payWallOptions = new PayWallOptions();

            config.GetSection("PayWall").Bind(payWallOptions);

            services
                .AddPaymentApiClient(payWallOptions)
                .AddPaymentPrivateApiClient(payWallOptions)
                .AddCardWallApiClient(payWallOptions)
                .AddTransient<PayWallService>();
        }

        #endregion

        #region Private Methods

        private static IServiceCollection AddPaymentApiClient(this IServiceCollection services, PayWallOptions payWallOptions)
        {
            if (payWallOptions == null) throw new ArgumentNullException(nameof(payWallOptions));

            var baseAddress = payWallOptions.Prod ? ProdPaymentApiUrl : TestPaymentApiUrl;

            services.AddHttpClient(PaymentClientName, httpClient =>
            {
                httpClient.BaseAddress = baseAddress;
                httpClient.DefaultRequestHeaders.Add("apikeypublic", payWallOptions.PublicKey);
                httpClient.DefaultRequestHeaders.Add("apiclientpublic", payWallOptions.PublicClient);
            });

            services.AddTransient<PaymentApiClient>();
            
            return services; 
        }
        private static IServiceCollection AddPaymentPrivateApiClient(this IServiceCollection services, PayWallOptions payWallOptions)
        {
            if (payWallOptions == null) throw new ArgumentNullException(nameof(payWallOptions));

            var baseAddress = payWallOptions.Prod ? ProdPaymentPrivateApiUrl : TestPaymentPrivateApiUrl;

            services.AddHttpClient(PaymentPrivateClientName, httpClient =>
            {
                httpClient.BaseAddress = baseAddress;
                httpClient.DefaultRequestHeaders.Add("apikeyprivate", payWallOptions.PrivateKey);
                httpClient.DefaultRequestHeaders.Add("apiclientprivate", payWallOptions.PrivateClient);
            });

            services.AddTransient<PaymentPrivateApiClient>();
            
            return services; 
        }
        private static IServiceCollection AddCardWallApiClient(this IServiceCollection services, PayWallOptions payWallOptions)
        {
            if (payWallOptions == null) throw new ArgumentNullException(nameof(payWallOptions));

            var baseAddress = payWallOptions.Prod ? ProdCardWallApiUrl : TestCardWallApiUrl;

            services.AddHttpClient(CardWallClientName, httpClient =>
            {
                httpClient.BaseAddress = baseAddress;
                httpClient.DefaultRequestHeaders.Add("apikeyprivate", payWallOptions.PrivateKey);
                httpClient.DefaultRequestHeaders.Add("apiclientprivate", payWallOptions.PrivateClient);
            });

            services.AddTransient<CardWallApiClient>();
            
            return services; 
        }

        #endregion
    }
}