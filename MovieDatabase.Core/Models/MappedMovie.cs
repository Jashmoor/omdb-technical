using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieDatabase.Core.Models
{
    public class MappedMovie : Movie
    {


        [JsonIgnore]
        public override string? Title { get => base.Title; set => base.Title = value; }
        [JsonPropertyName("Title")]
        public string? Name { get; set; }

        [JsonIgnore]
        public override string? Country { get => base.Country; set => base.Country = value; }
        [JsonPropertyName("Country")]
        public string? CountryReleased { get; set; }

        [JsonPropertyName("Ratings")]
        public new RatingMapped[]? Ratings { get; set; }
    }

    public class RatingMapped : Rating
    {

        [JsonIgnore]
        public override string? Source { get => base.Source; set => base.Source = value; }
        [JsonPropertyName("Source")]
        public string? RatingSource { get; set; }

        [JsonIgnore]
        public override string? Value { get => base.Value; set => base.Value = value; }
        [JsonPropertyName("Value")]
        public string? Score { get; set; }
    }
}
