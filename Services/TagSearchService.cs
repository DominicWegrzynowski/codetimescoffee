using BlogProject.Enums;
using BlogProject.Data;
using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Services
{
    public class TagSearchService
    {
        private readonly ApplicationDbContext _context;
        public TagSearchService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Post> SearchTag(string tag)
        {
            var posts = _context.Posts.Where(p => p.ReadyStatus == ReadyStatus.ProductionReady).AsQueryable();

            if(tag is not null)
            {
                foreach (var post in posts)
                {
                    foreach(var postTag in post.Tags)
                    {
                        if(postTag.Text.ToLower().Replace("", string.Empty) == tag.ToLower().Replace("", string.Empty))
                        {
                            posts = posts.Where(p => p.Id == postTag.Id);
                        }
                    }
                }
            }

            return posts.OrderByDescending(p => p.Created);
        }
    }
}
