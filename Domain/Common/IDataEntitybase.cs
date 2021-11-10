using System;

namespace Domain.Common;
    public interface IDataEntitybase
    {
        Guid ID { get; set; }
        DateTime CreatedUTC { get; set; }
    }