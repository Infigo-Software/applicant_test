using CMSPlus.Services.Interfaces;

namespace CMSPlus.Presentation.Validations;

public class CommentValidatorHelpers
{
    private readonly ICommentService _commentService;

    public CommentValidatorHelpers(ICommentService commentService)
    {
        _commentService = commentService;

        
    }


    public async Task<bool> IsFullNameUnique(string fullName, CancellationToken token)
    {
        var topic = await _commentService.GetByFullName(fullName);
        return topic == null;
    }
}