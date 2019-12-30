using System.Collections.Generic;
using System.Threading.Tasks;
using SMF_API.Models;

namespace SMF_API.EndPoints
{
    public class ForumEndPoint
    {
        public async Task<Forum> Get()
        {
            return await Task.FromResult(new Forum(new List<Category>()));
        }
    }
}
