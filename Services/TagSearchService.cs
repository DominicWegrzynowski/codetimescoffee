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

        public IQueryable<Post> Search(string tag)
        {
            var posts = _context.Posts.Where(p => p.ReadyStatus == ReadyStatus.ProductionReady).AsQueryable();

            if (tag is not null)
            {
                var thing = _context.Tags.AsQueryable();

                var tags = _context.Tags.Where(t => t.Text.ToLower().Replace("", string.Empty) == tag).AsQueryable();

                var tagResult = tags.Single();
                
                posts = posts.Where(p => p.Id == tagResult.PostId);
            }

            return posts.OrderByDescending(p => p.Created);
        }

    }
}
