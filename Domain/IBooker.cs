using System;

namespace RoomBook.Domain
{
    interface IBooker : IDataEntitybase
    {
        string Name { get; set; }
    }
}