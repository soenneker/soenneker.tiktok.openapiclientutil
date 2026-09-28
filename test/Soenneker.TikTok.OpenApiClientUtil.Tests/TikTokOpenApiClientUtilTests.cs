using Soenneker.TikTok.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.TikTok.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TikTokOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ITikTokOpenApiClientUtil _openapiclientutil;

    public TikTokOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ITikTokOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
