using System;

namespace Demo.CinemaProject.BLL.Entities
{
    public class Film
    {
        public int Id { get; set; }
        private string _titre;
        public string Titre { 
            get { return _titre; }
            set { 
                string newTitre = value.Trim();
                if (string.IsNullOrEmpty(newTitre)) throw new ArgumentNullException(nameof(newTitre));
                if(newTitre.Length > 128) throw new ArgumentOutOfRangeException(nameof(newTitre));
                _titre = newTitre;
            }
        }
        public DateTime DateSortie { get; set; }
        public Film(int id, string titre, DateTime dateSortie)
        {
            Id = id;
            Titre = titre;
            DateSortie = dateSortie;
        }
        public void ReportMovieRelease(DateTime newDate)
        {
            DateSortie = newDate;
        }
    }
}