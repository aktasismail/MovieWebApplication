using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenreRepository : RepositoryBase<Genres>, IGenreRepository
    {
        public GenreRepository(MovieDbContext db) : base(db)
        {
        }
    }
}
