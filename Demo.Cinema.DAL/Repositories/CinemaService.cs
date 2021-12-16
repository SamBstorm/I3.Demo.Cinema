using System;
using System.Collections.Generic;
using System.Text;
using e = Demo.Cinema.DAL.Entities;

namespace Demo.Cinema.DAL.Repositories
{
    public class CinemaService : IRepository<e.Cinema, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<e.Cinema> Get()
        {
            throw new NotImplementedException();
        }

        public e.Cinema Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(e.Cinema entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, e.Cinema entity)
        {
            throw new NotImplementedException();
        }
    }
}
