using System.Collections.Generic;
using Mino.Core.Models;

namespace Mino.Core.ViewModels
{
    public class TagsViewModel
    {
        public IEnumerable<Tag> Tags;

        public TagsViewModel(IEnumerable<Tag> tags)
        {
            Tags = tags;
        }
    }
}