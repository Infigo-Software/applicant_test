using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMSPlus.Services.Services
{
    public class CommentService:ICommentService
    {

        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<CommentEntity>> GetByTopicId(int topicId)
        {
            return await _repository.GetByTopicId(topicId);
        }

        public async Task<IEnumerable<CommentEntity>> GetByFullName(string fullName)
        {
            return await _repository.GetByFullName(fullName);
        }

        public async Task Create(CommentEntity entity)
        {
            await _repository.Create(entity);
        }

    }
}
