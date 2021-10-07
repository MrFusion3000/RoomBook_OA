using Domain.Entities;
using System;
using Xunit;
using System.Threading.Tasks;
using System.Net.Http;

namespace RoomBook_OA.Tests
{
    public class GetRoomByIdTests
    {
        [Fact]
        public async Task GetPublicHealthEndpoint()
        {
            var apiClient = new HttpClient();

            var apiResponse = await apiClient.GetAsync($"https://localhost:44315/api/v1/health");

            Assert.True(apiResponse.IsSuccessStatusCode);

            var stringResponse = await apiResponse.Content.ReadAsStringAsync();

            Assert.Equal("Healthy", stringResponse);
        }
    }
}
