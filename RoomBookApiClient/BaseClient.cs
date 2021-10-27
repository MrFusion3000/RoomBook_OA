using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace RoomBookApiClient
{
    public abstract class BaseClient
    {
        protected Url GetClient()
        {
            return "https://localhost:44315/".AppendPathSegment("api").AppendPathSegment("v1");
        }
    }
}
