using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.TopicModels;
using CMSPlus.Domain.Models.CommentModels;

using CMSPlus.Services.Interfaces;
using CMSPlus.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;

namespace CMSPlus.Presentation.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IValidator<CommentCreateModel> _createModelValidator;

        public CommentController(ICommentService commentService, IMapper mapper, IValidator<CommentCreateModel> createModelValidator)
        {
            _commentService = commentService;
            _mapper = mapper;
            _createModelValidator = createModelValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Comments(int topicId)
        {
            var comments = await _commentService.GetByTopicId(topicId);
            if (comments == null)
            {
                throw new ArgumentException($"Topic with id: {topicId} wasn't found!");
            }

            return (IActionResult)comments;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateModel comm)
        {
            var validationResult = await _createModelValidator.ValidateAsync(comm);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View(comm);
            }
            var commentEntity = _mapper.Map<CommentCreateModel, CommentEntity>(comm);
            await _commentService.Create(commentEntity);

            return RedirectToAction("/topics");
        }
    }
}
