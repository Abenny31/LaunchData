using LaunchData.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class LaunchModel
{
    public Fairings Fairings { get; set; }
    public Links Links { get; set; }

    [JsonPropertyName("static_fire_date_utc")]
    public DateTime? StaticFireDateUtc { get; set; }

    [JsonPropertyName("static_fire_date_unix")]
    public long? StaticFireDateUnix { get; set; }

    public bool? Net { get; set; }
    public int? Window { get; set; }
    public string Rocket { get; set; }
    public bool? Success { get; set; }
    public List<Failure> Failures { get; set; }
    public string Details { get; set; }
    public List<string> Crew { get; set; }
    public List<string> Ships { get; set; }
    public List<string> Capsules { get; set; }
    public List<string> Payloads { get; set; }

    [JsonPropertyName("launchpad")]
    public string Launchpad { get; set; }

    [JsonPropertyName("flight_number")]
    public int FlightNumber { get; set; }

    public string Name { get; set; }

    [JsonPropertyName("date_utc")]
    public DateTime DateUtc { get; set; }

    [JsonPropertyName("date_unix")]
    public long DateUnix { get; set; }

    [JsonPropertyName("date_local")]
    public string DateLocal { get; set; }

    [JsonPropertyName("date_precision")]
    public string DatePrecision { get; set; }

    public bool Upcoming { get; set; }

    public List<Core> Cores { get; set; }

    [JsonPropertyName("auto_update")]
    public bool AutoUpdate { get; set; }

    public bool Tbd { get; set; }

    [JsonPropertyName("launch_library_id")]
    public string LaunchLibraryId { get; set; }

    public string Id { get; set; }
}