using BusinessLayer.Abstract;
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
    public class CommentManager : RepositoryBase<Comments>, ICommentService
    {
        

        public CommentManager(MovieDbContext db) : base(db)
        {
            
        }
        public IEnumerable<Comments> GetAllComments(bool trackchages) =>
            GetAll(trackchages).ToList();
        public Comments GetComment(int id, bool trackchages) =>

            FindbyId(x => x.CommentId.Equals(id), trackchages).SingleOrDefault();
        public void CreateComment(Comments comments)
        {
            Add(comments);
            _db.SaveChanges();
        }
        public void DeleteComment(Comments comments)
        {
            Delete(comments);
            _db.SaveChanges();
        }
        public void UpdateComment(Comments comments)
        {
            Update(comments);
            _db.SaveChanges();
        }
    }
}
