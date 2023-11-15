﻿using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentRepository : IRepository<Comments>
    {
        IEnumerable<Comments> GetAllComments(bool trackchages);
        Comments GetComment(int id, bool trackchages);
        void CreateComment(Comments comments);
        void UpdateComment(Comments comments);
        void DeleteComment(Comments comments);
    }
}
