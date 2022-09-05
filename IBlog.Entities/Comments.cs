using IBlog.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Entities
{
    public class Comments : IEntity
    {
        public Guid Id { get; set; }
        public string Commenter { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public Guid BlogId { get; set; }
        public Blogs Blog { get; set; }
    }
}
