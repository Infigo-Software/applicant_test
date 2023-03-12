using System.IO.Enumeration;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Interfaces;
using CMSPlus.Domain.Models.CommentModels;
using FluentValidation;

namespace CMSPlus.Presentation.Validations;

public class CommentCreateModelValidator : AbstractValidator<CommentCreateModel>
{
    private readonly CommentValidatorHelpers _commentValidatorHelpers;
    public CommentCreateModelValidator(CommentValidatorHelpers CommentValidatorHelpers)
    {
        _commentValidatorHelpers = CommentValidatorHelpers;
        RuleFor(comment => comment.FullName)
            .MustAsync(_commentValidatorHelpers.IsFullNameUnique).WithMessage("FullName must be unique");
    }
}