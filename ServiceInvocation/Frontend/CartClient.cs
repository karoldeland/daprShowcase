using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

using IdentityModel.Client;

namespace Frontend
{
    public class CartClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public CartClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
            
            _client.BaseAddress = new Uri("http://cart");
        }

        private async Task SetBearerToken()
        {
            var client = new HttpClient();
            // discover endpoints from metadata
            var disco = await client.GetDiscoveryDocumentAsync(_configuration.GetValue<string>("IdentityEndpoint"));
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest()
            {
                Address = disco.TokenEndpoint,

                ClientId = "frontend",
                ClientSecret = "secret",
                Scope = "cartApi"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            _client.SetBearerToken(tokenResponse.AccessToken);

        }

        public async void AddToCart(string productName)
        {
            //await SetBearerToken();

            await _client.PostAsJsonAsync("cart/add", productName);
        }
    }
}
