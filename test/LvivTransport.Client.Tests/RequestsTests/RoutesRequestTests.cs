using LvivTransport.Client.Core.Request;
using Xunit;

namespace LvivTransport.Client.Tests.RequestsTests
{
    public class RoutesRequestTests
    {
        [Fact]
        public void RoutesRequest_ParameterNotSet_ReturnsNoParameter()
        {
            var request = CreateRoutesRequest();

            Assert.False(request.HasParameter);
        }

        [Fact]
        public void RoutesRequest_ParameterSet_ReturnsHasParameter()
        {
            var request = CreateRoutesRequest(int.MaxValue);

            Assert.True(request.HasParameter);
        }

        private static RoutesRequest CreateRoutesRequest(int? param = null)
        {
            return new RoutesRequest(param);
        }
    }
}
