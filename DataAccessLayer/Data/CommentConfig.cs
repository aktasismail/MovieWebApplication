using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class CommentConfig : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(x => x.CommentId);
            builder.Property(x => x.Tittle);
            builder.Property(x => x.CommentText);


            builder.HasData(
                new Comments() { CommentId = 1, CommentText = "sgsgr", Tittle = "ekgfmwegk", MovieId = 1,UserId= "07217690-eb89-47c0-a1bb-2b51f0bd0c55" }
            );
        }
    }
}
