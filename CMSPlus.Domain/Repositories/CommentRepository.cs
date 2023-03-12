using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CMSPlus.Domain.Repositories;

public class CommentRepository : Repository<CommentEntity>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CommentEntity?>> GetByTopicId(int topicId)
    {
        var result = await _dbSet.SingleOrDefaultAsync(comments => comments.TopicId == topicId);
        return result as IEnumerable<CommentEntity?>;
    }

    public Task<IEnumerable<CommentEntity?>> GetByTopicId(string topicId)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<CommentEntity?>> GetByFullName(string fullName)
    {
        var result = await _dbSet.SingleOrDefaultAsync(comments => comments.FullName == fullName);
        return result as IEnumerable<CommentEntity?>;
    }
}