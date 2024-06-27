using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Entities
{
    public class Blog : Entity
    {
        public Blog()
        {
            Posts = new List<Post>();
        }

        public string Url { get; set; }
        public bool IsPublic { get; set; }
        public List<Post> Posts { get; set; }
        public Guid BlogTypeId { get; set; }
        public BlogType BlogType { get; set; }
    }
}
