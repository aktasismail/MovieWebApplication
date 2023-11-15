using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenreManager : IGenreService
    {
        private readonly IRepositoryManager _manager;
        public GenreManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        public IEnumerable<Genres> GetAllGenres(bool trackChanges) 
        { 
            return _manager.genreRepository.GetAll(trackChanges);    
        }
             
        
    }
}
