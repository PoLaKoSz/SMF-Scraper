using System.Collections.Generic;

namespace SMF_API.Models
{
    public class Forum
    {
        public Forum(List<Category> categories)
        {
            Categories = categories;
        }

        public IReadOnlyCollection<Category> Categories { get; }
    }
}
