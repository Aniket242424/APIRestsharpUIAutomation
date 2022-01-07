using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowProject1.API.DTO
{
    public partial class ListOfCasesDTO 
    { 
    [JsonProperty("confirmed")]
    public Confirmed Confirmed { get; set; }

    [JsonProperty("recovered")]
    public Confirmed Recovered { get; set; }

    [JsonProperty("deaths")]
    public Confirmed Deaths { get; set; }

    [JsonProperty("dailySummary")]
    public Uri DailySummary { get; set; }

    [JsonProperty("dailyTimeSeries")]
    public CountryDetail DailyTimeSeries { get; set; }

    [JsonProperty("image")]
    public Uri Image { get; set; }

    [JsonProperty("source")]
    public Uri Source { get; set; }

    [JsonProperty("countries")]
    public Uri Countries { get; set; }

    [JsonProperty("countryDetail")]
    public CountryDetail CountryDetail { get; set; }

    [JsonProperty("lastUpdate")]
    public DateTimeOffset LastUpdate { get; set; }
}

public partial class Confirmed
{
    [JsonProperty("value")]
    public long Value { get; set; }

    [JsonProperty("detail")]
    public Uri Detail { get; set; }
}

public partial class CountryDetail
{
    [JsonProperty("pattern")]
    public Uri Pattern { get; set; }

    [JsonProperty("example")]
    public Uri Example { get; set; }
}

}
