
using ShortStack.Core.Testing;

namespace Gw2Api.Core.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using EndPoints;
    using EndPoints.AccountBank;

    using Gw2Api.Core.EndPoints.Items;

    using Newtonsoft.Json;
    using Xunit.Abstractions;

    using Xunit;

    public class GetItemDescriptionsTests : BaseIntegrationTest<IGw2ApiEndPoint<List<ItemDescription>>>
    {
        private readonly ITestOutputHelper output;
        
        private readonly List<string> testParams = new List<string> { "24502", "24501" };

        public GetItemDescriptionsTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetItemDescriptionsWorks()
        {
            var expectedCount = this.testParams.Count;

            var actual = this.SystemUnderTest.HandleRequest(this.testParams);

            Assert.Equal(expectedCount, actual.Count);

            var json = JsonConvert.SerializeObject(actual);

            this.output.WriteLine("Items Json: {0}", json);
        }

        [Fact]
        public void GetItemDescriptionsWorksWithManyIds()
        {
            var ids = new List<string>();

            // make MANY ids
            for (int i = 0; i < 1000; i++)
            {
                ids.Add(i.ToString());
            }
            
            var actual = this.SystemUnderTest.HandleRequest(ids);
            
            Assert.NotEmpty(actual);
            Assert.True(actual.Count > 200);

            var json = JsonConvert.SerializeObject(actual);

            this.output.WriteLine("Items Json: {0}", json);
        }
    }
}
