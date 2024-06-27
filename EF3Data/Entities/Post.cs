using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid PostTypeId { get; set; }
        public PostType PostType { get; set; }
        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
