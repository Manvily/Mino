using System.Collections.Generic;
using Mino.Core.Models;

namespace Mino.Core.Repositories
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetUserTags(string userId);
        Tag GetUserTag(string userId, int id);
        void Add(Tag tag);
        void Remove(Tag tag);
    }
}