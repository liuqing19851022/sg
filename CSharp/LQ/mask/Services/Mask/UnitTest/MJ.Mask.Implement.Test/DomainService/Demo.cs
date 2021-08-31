using Orleans;
using Xunit;
using Xunit.Abstractions;

namespace MJ.Mask.Implement.Test.DomainService
{
    [Collection(ClusterCollection.Name)]
    public class DeviceGrainTest
    {
        private readonly IGrainFactory GrainFactory;
        private readonly ITestOutputHelper Output;

        public DeviceGrainTest(ClusterFixture fixture,ITestOutputHelper output)
        {
            this.GrainFactory = fixture.Cluster.GrainFactory;
            this.Output = output;

        }
		
		
        [Theory]
        [InlineData("test123456")]
		[InlineData("欢迎使用测试用例")]
        
        public void TestCase1(string source) {

            var a = source[5..];
            var b = source.Substring(5);

            Assert.Equal(a, b);

        }

		/*
        [Fact]
        public async Task TestCase2() {
			
            var grain = this.GrainFactory.GetGrain<xxx>(1);

        }
		*/


  

    }
}
