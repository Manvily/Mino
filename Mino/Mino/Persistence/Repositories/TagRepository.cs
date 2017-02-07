using System.Collections.Generic;
using System.Linq;
using Mino.Core.Models;
using Mino.Core.Repositories;

namespace Mino.Persistence.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tag> GetUserTags(string userId)
        {
            return _context.Tags
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public Tag GetUserTag(string userId, int id)
        {
            return _context.Tags.Single(x =>
            x.UserId == userId &&
            x.Id == id);
        }

        public void Add(Tag tag)
        {
            _context.Tags.Add(tag);
        }

        public void Remove(Tag tag)
        {
            _context.Tags.Remove(tag);
        }
    }
}