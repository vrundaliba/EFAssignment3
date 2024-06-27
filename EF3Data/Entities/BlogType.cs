using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF3Data.Entities
{
    public class BlogType : BaseType
    {
        public BlogType()
        {
            Blogs = new List<Blog>();
        }

        public virtual List<Blog> Blogs { get; set; }
    }
}
