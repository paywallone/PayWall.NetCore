#region Using Directives

using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayWall.NetCore.Configuration;
using PayWall.NetCore.Implementations;
using PayWall.NetCore.Services;

#endregion

namespace PayWall.NetCore
{
    public static class ServiceCollectionExtensions
    {
        #region Public Properties

        public static string PaymentClientName => "PaymentApiClient";
        public static string PaymentPrivateClientName => "PaymentPrivateApiClient";
        public static string CardWallClientName => "CardWallApiClient";
        public static string MemberClientName => "MemberApiClient";

        #endregion

        #region Private Properties

        private static Uri ProdPaymentApiUrl => new("https://payment-api.itspaywall.com/api/paywall/");
        private static Uri TestPaymentApiUrl => new("https://dev-payment-api.itspaywall.com/api/paywall/");
        private static Uri ProdPaymentPrivateApiUrl => new("https://payment-private-api.itspaywall.com/api/paywall/");
        private static Uri TestPaymentPrivateApiUrl => new("https://dev-payment-private-api.itspaywall.com/api/paywall/");
        private static Uri ProdCardWallApiUrl => new("https://card-api.itspaywall.com/paywall/");
        private static Uri TestCardWallApiUrl => new("https://dev-card-api.itspaywall.com/paywall/");
        private static Uri ProdMemberApiUrl => new("https://member-api.itspaywall.com/api/paywall/");
        private static Uri TestMemberApiUrl => new("https://dev-member-api.itspaywall.com/api/paywall/");

        #endregion

        #region Public Methods

        public static void AddPaywallService(this IServiceCollection services, IConfiguration config,
            params Func<IServiceProvider, DelegatingHandler>[] handlerFactories)
        {
            var payWallOptions = new PayWallOptions();

            config.GetSection("PayWall").Bind(payWallOptions);

            services
                .AddPaymentApiClient(payWallOptions, handlerFactories)
                .AddPaymentPrivateApiClient(payWallOptions, handlerFactories)
                .AddCardWallApiClient(payWallOptions, handlerFactories)
                .AddMemberApiClient(payWallOptions, handlerFactories)
                .AddTransient<PayWallService>();
        }

        #endregion

        #region Private Methods

        private static IServiceCollection AddPaymentApiClient(this IServiceCollection services,
            PayWallOptions payWallOptions, params Func<IServiceProvider, DelegatingHandler>[] handlerFactories)
        {
            if (payWallOptions == null) throw new ArgumentNullException(nameof(payWallOptions));

            var baseAddress = payWallOptions.Prod ? ProdPaymentApiUrl : TestPaymentApiUrl;

            services.AddHttpClient(PaymentClientName, httpClient =>
            {
                httpClient.BaseAddress = baseAddress;
                httpClient.DefaultRequestHeaders.Add("apikeypublic", payWallOptions.PublicKey);
                httpClient.DefaultRequestHeaders.Add("apiclientpublic", payWallOptions.PublicClient);
                httpClient.DefaultRequestHeaders.Add("apikeyprivate", payWallOptions.PrivateKey);
                httpClient.DefaultRequestHeaders.Add("apiclientprivate", payWallOptions.PrivateClient);
            }).AddMultipleHttpMessageHandlers(handlerFactories);

            services.AddTransient<PaymentApiClient>();

            return services;
        }

        private static IServiceCollection AddPaymentPrivateApiClient(this IServiceCollection services,
            PayWallOptions payWallOptions, params Func<IServiceProvider, DelegatingHandler>[] handlerFactories)
        {
            if (payWallOptions == null) throw new ArgumentNullException(nameof(payWallOptions));

            var baseAddress = payWallOptions.Prod ? ProdPaymentPrivateApiUrl : TestPaymentPrivateApiUrl;

            services.AddHttpClient(PaymentPrivateClientName, httpClient =>
            {
                httpClient.BaseAddress = baseAddress;
                httpClient.DefaultRequestHeaders.Add("apikeyprivate", payWallOptions.PrivateKey);
                httpClient.DefaultRequestHeaders.Add("apiclientprivate", payWallOptions.PrivateClient);
            }).AddMultipleHttpMessageHandlers(handlerFactories);

            services.AddTransient<PaymentPrivateApiClient>();

            return services;
        }

        private static IServiceCollection AddCardWallApiClient(this IServiceCollection services,
            PayWallOptions payWallOptions, params Func<IServiceProvider, DelegatingHandler>[] handlerFactories)
        {
            if (payWallOptions == null) throw new ArgumentNullException(nameof(payWallOptions));

            var baseAddress = payWallOptions.Prod ? ProdCardWallApiUrl : TestCardWallApiUrl;

            services.AddHttpClient(CardWallClientName, httpClient =>
            {
                httpClient.BaseAddress = baseAddress;
                httpClient.DefaultRequestHeaders.Add("apikeyprivate", payWallOptions.PrivateKey);
                httpClient.DefaultRequestHeaders.Add("apiclientprivate", payWallOptions.PrivateClient);
            }).AddMultipleHttpMessageHandlers(handlerFactories);

            services.AddTransient<CardWallApiClient>();

            return services;
        }

        private static IServiceCollection AddMemberApiClient(this IServiceCollection services,
            PayWallOptions payWallOptions, params Func<IServiceProvider, DelegatingHandler>[] handlerFactories)
        {
            if (payWallOptions == null) throw new ArgumentNullException(nameof(payWallOptions));

            var baseAddress = payWallOptions.Prod ? ProdMemberApiUrl : TestMemberApiUrl;

            services.AddHttpClient(MemberClientName, httpClient =>
                {
                    httpClient.BaseAddress = baseAddress;
                    httpClient.DefaultRequestHeaders.Add("apikeypublic", payWallOptions.PublicKey);
                    httpClient.DefaultRequestHeaders.Add("apiclientpublic", payWallOptions.PublicClient);
                })
                .AddMultipleHttpMessageHandlers(handlerFactories);

            services.AddTransient<MemberApiClient>();

            return services;
        }

        private static void AddMultipleHttpMessageHandlers(this IHttpClientBuilder httpClientBuilder,
            params Func<IServiceProvider, DelegatingHandler>[] handlerFactories)
        {
            if (handlerFactories == null)
            {
                return;
            }
            
            foreach (var handlerFactory in handlerFactories)
            {
                if (handlerFactory == null)
                {
                    continue;
                }
                
                httpClientBuilder.AddHttpMessageHandler(handlerFactory);
            }
        }

        #endregion
    }
}