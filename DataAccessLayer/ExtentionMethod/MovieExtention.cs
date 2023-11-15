using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ExtentionMethod
{
    public static class MovieExtention
    {
        public static IQueryable<Movies> GetByGenres(this IQueryable<Movies> movies, int? genreId)
        {
            if (genreId is null)
                return movies;
            return movies.Where(x => x.GenreId.Equals(genreId));
        }
        public static IQueryable<Movies> FilterByRate(this IQueryable<Movies> movies,
            uint minRate, uint maxRate) 
        { 
            var filtermovie = movies.Where(movie =>
                movie.ImdbRate >= minRate && movie.ImdbRate <= maxRate);
            return filtermovie;
        }
        public static IQueryable<Movies> ToPaginate(this IQueryable<Movies> movies,
            int pageNumber, int pageSize)
        {

            return movies
                .Skip(((pageNumber - 1) * pageSize))
                .Take(pageSize);
        }
        public static IQueryable<Movies> Search(this IQueryable<Movies> books,
           string searchKey)
        {
            if (string.IsNullOrWhiteSpace(searchKey))
                return books;

            var lowerCaseTerm = searchKey.Trim().ToLower();
            return books
                .Where(b => b.Moviename
                .ToLower()
                .Contains(searchKey));
        }

    }
}
