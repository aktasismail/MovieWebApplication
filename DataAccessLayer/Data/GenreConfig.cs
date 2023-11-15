using EntityLayer;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class GenreConfig : IEntityTypeConfiguration<Genres>
    {
        public void Configure(EntityTypeBuilder<Genres> builder)
        {
            builder.HasKey(x => x.GenreId);
            builder.Property(x => x.MovieGenre);
         

            builder.HasData(
                new Genres() { GenreId=1,MovieGenre="Dram" }
            );
        }
    }
}
