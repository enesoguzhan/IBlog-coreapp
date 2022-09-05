using IBlog.Business.Abstract;
using IBlog.Core.Results;
using IBlog.DataAccess.UnitOfWorks;
using IBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBlog.Business.Concrete
{
    public class ImagesService : IImagesService
    {
        private readonly IUnitOfWork unitOfWork;

        public ImagesService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IResult> AddAsync(string name, Guid blogId)
        {
            Images data = new Images
            {
                Id = Guid.NewGuid(),
                Name = name,
                BlogId = blogId
            };
            return await unitOfWork.imagesRepo.AsyncAdd(data).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            return await unitOfWork.imagesRepo.AsyncDelete(s => s.Id == id).ContinueWith(s => unitOfWork.SaveChanges()).Result;
        }
    }
}
