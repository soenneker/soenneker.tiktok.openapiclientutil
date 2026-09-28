using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.TikTok.HttpClients.Abstract;
using Soenneker.TikTok.OpenApiClientUtil.Abstract;
using Soenneker.TikTok.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.TikTok.OpenApiClientUtil;

///<inheritdoc cref="ITikTokOpenApiClientUtil"/>
public sealed class TikTokOpenApiClientUtil : ITikTokOpenApiClientUtil
{
    private readonly AsyncSingleton<TikTokOpenApiClient> _client;

    public TikTokOpenApiClientUtil(ITikTokOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<TikTokOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("TikTok:AccessToken");
            string authHeaderName = configuration["TikTok:AuthHeaderName"] ?? "Authorization";
            string authHeaderValueTemplate = configuration["TikTok:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerName: authHeaderName, headerValue: authHeaderValue),
                httpClient: httpClient);

            return new TikTokOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<TikTokOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
