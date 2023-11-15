using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly MovieDbContext _db;
        private readonly Lazy<IMovieRepository> _movieRepository;
        private readonly Lazy<IGenreRepository> _genreRepository;
        public RepositoryManager(MovieDbContext db)
        {
            _db = db;
            _movieRepository = new Lazy<IMovieRepository>(()=> new MovieRepository(_db));
            _genreRepository = new Lazy<IGenreRepository> (()=> new GenreRepository(_db));
        }
        public IMovieRepository movieRepository => _movieRepository.Value;
        public IGenreRepository genreRepository => _genreRepository.Value;


        public void SaveChanges()
        {
             _db.SaveChanges();
        }
    }
}
