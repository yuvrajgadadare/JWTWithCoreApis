using Microsoft.AspNetCore.Mvc.Testing;

namespace UnitTestingProject
{
    public class UnitTest1
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient client;
        public UnitTest1()
        {
            var factory = new WebApplicationFactory<Program>();
            _factory = factory;
            client = _factory.CreateClient();
        }


        [Fact]
        public async Task Test1()
        {
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("/api/product");
            int code = (int)response.StatusCode;

            //assert
            Assert.Equal(200, code);
        }
        [Fact]
        public async Task LoginTest()
        {
            var client = _factory.CreateClient();

            //act
            var response = await client.GetAsync("/api/product");
            int code = (int)response.StatusCode;

            //assert
            Assert.Equal(200, code);
        }
    }
}