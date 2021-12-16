using System;

namespace Demo.Cinema.DAL.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime DateSortie { get; set; }
    }
}
