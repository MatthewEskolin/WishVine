using System.Net;

namespace WishVine.Shared.GeneralLib;

public class GuidContent : HttpContent
{
    private readonly Guid _guid;

    public GuidContent(Guid guid)
    {
        _guid = guid;
        Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
    }

    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        await stream.WriteAsync(_guid.ToByteArray(), 0, 16);
    }

    protected override bool TryComputeLength(out long length)
    {
        length = 16; // GUID size in bytes
        return true;
    }
}