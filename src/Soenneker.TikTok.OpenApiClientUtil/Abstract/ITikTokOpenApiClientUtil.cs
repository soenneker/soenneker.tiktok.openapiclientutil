using Soenneker.TikTok.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.TikTok.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ITikTokOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<TikTokOpenApiClient> Get(CancellationToken cancellationToken = default);
}
