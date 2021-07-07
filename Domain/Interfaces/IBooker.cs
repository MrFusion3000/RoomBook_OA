using System;
using Domain.Common;

namespace Domain.Interfaces
{
    interface IBooker : IDataEntitybase
    {
        string Name { get; set; }
    }
}