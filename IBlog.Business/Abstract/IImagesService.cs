using IBlog.Core.Results;
using IBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Business.Abstract
{
    public interface IImagesService
    {
        public Task<IResult> AddAsync(string name,Guid blogId);
        public Task<IResult> DeleteAsync(Guid id);
    }
}
