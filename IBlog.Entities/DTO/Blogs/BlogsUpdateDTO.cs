using IBlog.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Entities.DTO.Blogs
{
    public class BlogsUpdateDTO : IDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishDateTime { get; set; }
        public string Explanation { get; set; }  
        public Guid CategoryId { get; set; }
        public bool Status { get; set; }     
    }
}
