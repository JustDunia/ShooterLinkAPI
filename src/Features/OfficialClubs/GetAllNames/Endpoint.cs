using System.Text.Json;
using FastEndpoints;
using ShooterLink.Utilities.GlobalSettings;

namespace ShooterLink.Features.OfficialClubs.GetAllNames;

public class Endpoint : EndpointWithoutRequest<Response>
{
    /// <summary>
    /// The url used by pzss.org.pl to fetch clubs data
    /// </summary>
    private const string _pzssClubsUrl = "https://soz.pzss.org.pl/Clubs/IndexDataAjax?name=&address=&alsoDeleted=false";

    public override void Configure()
    {
        Get("official-clubs/all-names");
        AllowAnonymous();
        Options(x => x.CacheOutput(x => x
        .Expire(TimeSpan.FromDays(1))));
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var client = new HttpClient();

        var response = await client.PostAsync(_pzssClubsUrl, null, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            ThrowError("Failed to get data from PZSS");
        }

        var resultString = await response.Content.ReadAsStringAsync(cancellationToken);

        var responseObject = JsonSerializer.Deserialize<ResponseObject>(resultString, Json.DefaultSerializerOptions);

        var result = responseObject?.Data.Select(x => x.FullName).ToList() ?? [];

        await SendAsync(new() { ClubNames = result });
    }

    #region Third party response objects definitions
    private class ResponseObject
    {
        public Datum[] Data { get; set; } = [];
    }

    private class Datum
    {
        public int ID { get; set; }
        public string ShortName { get; set; } = "";
        public string FullName { get; set; } = "";
        public object Created { get; set; } = "";
        public string VovoidershipName { get; set; } = "";
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public string HouseNumber { get; set; } = "";
        public string AppartmentNumber { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public object www { get; set; } = "";
        public string WZSS { get; set; } = "";
        public int ActiveMembers { get; set; }
        public int MemberStatus { get; set; }
    }
    #endregion
}


