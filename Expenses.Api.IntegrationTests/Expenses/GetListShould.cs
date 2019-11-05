using Expenses.Api.IntegrationTests.Common;
using Expenses.Api.Models.Common;
using Expenses.Api.Models.Expenses;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Expenses.Api.IntegrationTests.Expenses
{
    [Collection("ApiCollection")]
    public class GetListShould
    {
        private readonly HttpClient _client;
        private readonly ApiServer _server;

        public GetListShould(ApiServer server)
        {
            _server = server;
            _client = server.Client;
        }

        public async Task<DataResult<ExpenseModel>> Get(HttpClient client)
        {
            var response = await client.GetAsync($"api/Expenses");
            response.EnsureSuccessStatusCode();
            
            var responseText = await response.Content.ReadAsStringAsync();
            var items = JsonConvert.DeserializeObject<DataResult<ExpenseModel>>(responseText);

            return items;
        }

        [Fact]
        public async Task ReturnAnyList()
        {
            var items = await Get(_client);
            items.Should().NotBeNull();
        }
    }
}
