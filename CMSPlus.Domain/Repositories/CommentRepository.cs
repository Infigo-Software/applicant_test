using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CMSPlus.Domain.Repositories;

public class CommentRepository : Repository<CommentEntity>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CommentEntity?>> GetByTopicId(int topicId)
    {
        var result = await GetAll();

        return result.Where(c => c.TopicId == topicId);
    }

    public Task<IEnumerable<CommentEntity?>> GetByTopicId(string topicId)
    {
        throw new NotImplementedException();
    }


    public async Task<IEnumerable<CommentEntity?>> GetByFullName(string fullName)
    {
        var result = await _dbSet.FirstOrDefaultAsync(comments => comments.FullName == fullName);
        return result as IEnumerable<CommentEntity?>;
    }
}