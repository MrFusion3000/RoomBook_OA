using Domain.Entities;
using System;
using Xunit;
using System.Threading.Tasks;
using System.Net.Http;
using RoomBook_OA;
using Persistance.Repositories.Bookers;

namespace RoomBook_OA.Tests
{
    public class GetRoomById
    {
        [Fact]
        public async Task GetPublicHealthEndpoint()
        {
            //var apiClient = new HttpClient();

            //var apiResponse = await apiClient.GetAsync($"https://localhost:44315/api/v1/Booker");

            //Assert.True(apiResponse.IsSuccessStatusCode);

            //var stringResponse = await apiResponse.Content.ReadAsStringAsync();

            //Assert.Equal("Healthy", stringResponse);

            //Arange
            string expected = "ID: 00000000-0000-0000-0000-000000000000";

            // Act
            //string actual = BookerRepository.

            //Assert

        }
    }
}
