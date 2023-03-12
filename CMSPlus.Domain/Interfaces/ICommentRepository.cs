using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;

namespace CMSPlus.Domain.Interfaces;
public interface ICommentRepository : IRepository<CommentEntity?>
{
    public Task<IEnumerable<CommentEntity?>> GetByTopicId(int topicId);
    public Task<IEnumerable<CommentEntity?>> GetByFullName(string fullName);

}