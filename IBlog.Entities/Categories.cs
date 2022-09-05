using IBlog.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Entities
{
    public class Categories : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Blogs> Blogs { get; set; }
    }
}
