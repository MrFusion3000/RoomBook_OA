using Flurl;
using Flurl.Http;

namespace RoomBookApiClient;
public abstract class BaseClient
{
    protected static Url GetClient()
    {
        return "https://localhost:44315/".AppendPathSegment("api").AppendPathSegment("v1");
    }
}