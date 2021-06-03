using System;

namespace Domain.Entities
{
    interface IBooker : IDataEntitybase
    {
        string Name { get; set; }
    }
}