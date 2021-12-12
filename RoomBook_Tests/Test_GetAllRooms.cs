using Application.Interfaces;
using Application.Shared.DTO;
using Autofac.Extras.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RoomBook_OA.Tests;
public class Test_GetAllRooms
{
    [Fact]
    public Task GetAllRooms_ValidCall()
    {
        //Arrange
        using (var mock = AutoMock.GetLoose())
        {
            var RoomRepository = mock.Mock<IRoomRepository>();

            //RoomRepository
            //.Setup(x => x.GetAllRoomsAsync)
            //.Returns(GetSampleRooms);


            // Act
            //Assert
            //RoomRepository.Object.GetAllRoomsAsync(1,cancellationToken);
        }
        //throw new NotImplementedException();
        return Task.CompletedTask;
    }

    private Task<List<RoomDto>> GetSampleRooms()
    {
        List<RoomDto> output = new List<RoomDto>
        {
            new RoomDto
            {
                ID = Guid.NewGuid(),
                Name = "Toronto"
            },
            new RoomDto
            {
                ID = Guid.NewGuid(),
                Name = "London"
            },
            new RoomDto
            {
                ID = Guid.NewGuid(),
                Name = "The Swamp"
            }
        };
        return Task.FromResult(output);
        
    }
}

//Tests (integration tests?)
// TODO Test001.1 - Get a User/Booker
// TODO Test001.2 - Get All Users/Bookers
// TODO Test002 - Create a User/Booker
// TODO Test003 - Update a User/Booker
// TODO Test004 - Delete a User/Booker
// TODO Test005.1 - Get a Room
// TODO Test005.2 - Get All Rooms
// TODO Test006 - Create a Room
// TODO Test007 - Update a Room
// TODO Test008 - Delete a Room
// TODO Test009.1 - Get a TimeSlot
// TODO Test009.2 - Get All TimeSlots
// TODO Test010 - Create a TimeSlot
// TODO Test011 - Update a TimeSlot
// TODO Test012 - Delete a TimeSlot
