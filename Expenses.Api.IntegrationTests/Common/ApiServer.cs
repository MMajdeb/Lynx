using Expenses.Api.IntegrationTests.Helpers;
using Expenses.Api.Models.Login;
using Expenses.Api.Models.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace Expenses.Api.IntegrationTests.Common
{
    public class ApiServer : IDisposable
    {
        public const string Username = "admin";
        public const string Password = "password";

        private IConfigurationRoot _config;

        public HttpClient Client { get; private set; }
        public TestServer Server { get; private set; }
        public ApiServer()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            Server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = GetAuthentificatedClient(Username, Password);
        }

        public HttpClient GetAuthentificatedClient(string username, string password)
        {
            var client = Server.CreateClient();
            var response = client.PostAsync("/api/Login/Authenticate",
                new JsonContent(new LoginModel { Username = username, Password = password })).Result;

            response.EnsureSuccessStatusCode();

            var data = JsonConvert.DeserializeObject<UserWithTokenModel>(response.Content.ReadAsStringAsync().Result);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer" + data.Token);
            return client;
        }

        public void Dispose()
        {
            if (Client != null)
            {
                Client.Dispose();
                Client = null;
            }

            if (Server != null)
            {
                Server.Dispose();
                Server = null;
            }
        }
    }
}
