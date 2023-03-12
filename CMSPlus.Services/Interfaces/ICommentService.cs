using CMSPlus.Domain.Entities;

namespace CMSPlus.Services.Interfaces;

public interface ICommentService
{
    public Task<IEnumerable<CommentEntity?>> GetByTopicId(int topicId);
    public Task<IEnumerable<CommentEntity?>> GetByFullName(string fullName);

    public Task Create(CommentEntity? entity);
}

