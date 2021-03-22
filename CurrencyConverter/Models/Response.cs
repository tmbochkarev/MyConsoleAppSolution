using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CurrencyConverter.Models
{
    internal class Response
    {
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("PreviousDate")]
        public DateTime PreviousDate { get; set; }

        [JsonPropertyName("PreviousURL")]
        public string PreviousURL { get; set; }

        [JsonPropertyName("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("Valute")]
        public Dictionary<string, Valute> Valutes { get; set; }
    }
}
