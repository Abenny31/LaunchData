using LaunchData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LaunchData.Models
{
    public class LaunchModel
    {
        [Key]
        public string? Id { get; set; }

        [JsonPropertyName("fairings")]
        public Fairings? Fairings { get; set; }

        [JsonPropertyName("links")]
        public Links? Links { get; set; }

        [JsonPropertyName("static_fire_date_utc")]
        public DateTime? StaticFireDateUtc { get; set; }

        [JsonPropertyName("static_fire_date_unix")]
        public long? StaticFireDateUnix { get; set; }

        [JsonPropertyName("net")]
        public bool? Net { get; set; }

        [JsonPropertyName("window")]
        public int? Window { get; set; }

        [JsonPropertyName("rocket")]
        public string? Rocket { get; set; }

        [JsonPropertyName("success")]
        public bool? Success { get; set; }

        [JsonPropertyName("details")]
        public string? Details { get; set; }

        [JsonPropertyName("launchpad")]
        public string? Launchpad { get; set; }

        [JsonPropertyName("flight_number")]
        public int? FlightNumber { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("date_utc")]
        public DateTime? DateUtc { get; set; }

        [JsonPropertyName("date_unix")]
        public long? DateUnix { get; set; }

        [JsonPropertyName("date_local")]
        public string? DateLocal { get; set; }

        [JsonPropertyName("date_precision")]
        public string? DatePrecision { get; set; }

        [JsonPropertyName("upcoming")]
        public bool? Upcoming { get; set; }

        [JsonPropertyName("auto_update")]
        public bool? AutoUpdate { get; set; }

        [JsonPropertyName("tbd")]
        public bool? Tbd { get; set; }

        [JsonPropertyName("launch_library_id")]
        public string? LaunchLibraryId { get; set; }

        [JsonPropertyName("failures")]
        public List<Failure>? Failures { get; set; } = new();

        [JsonPropertyName("cores")]
        public List<Core>? Cores { get; set; } = new();

        [JsonPropertyName("crew")]
        public List<CrewMember>? Crew { get; set; } = new();

        [JsonPropertyName("ships")]
        public List<string>? Ships { get; set; } = new();

        [JsonPropertyName("capsules")]
        public List<string>? Capsules { get; set; } = new();

        [JsonPropertyName("payloads")]
        public List<string>? PayloadIds { get; set; }


    }
}