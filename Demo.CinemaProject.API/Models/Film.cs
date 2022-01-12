using System;
using System.Text.Json.Serialization;

namespace Demo.CinemaProject.API.Models
{
    public class Film
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime DateSortie { get; set; }

        public string Reference { get { return $"{Id}-{Titre}"; } }
    }
}
