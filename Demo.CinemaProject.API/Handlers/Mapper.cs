namespace Demo.CinemaProject.API.Handlers
{
    public static class Mapper
    {
        public static Models.Film ToAPI(this BLL.Entities.Film entity)
        {
            if(entity == null) return null;
            return new Models.Film { 
                Id = entity.Id,
                Titre = entity.Titre,
                DateSortie = entity.DateSortie
            };
        }

        public static BLL.Entities.Film ToBLL(this Models.FilmPost entity)
        {
            if(entity ==null) return null;
            return new BLL.Entities.Film(default(int), entity.Titre, entity.DateSortie);
        }
    }
}
