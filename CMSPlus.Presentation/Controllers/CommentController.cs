using AutoMapper;
using CMSPlus.Domain.Entities;
using CMSPlus.Domain.Models.TopicModels;
using CMSPlus.Domain.Models.CommentModels;

using CMSPlus.Services.Interfaces;
using CMSPlus.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Primitives;

namespace CMSPlus.Presentation.Controllers
{
    [Route("[Controller]/[Action]/{id?}")]
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


        public async Task<IActionResult> All(int id)
        {
            var comments = await _commentService.GetByTopicId(id);
            if (comments == null)
            {
                throw new ArgumentException($"Topic with id: {id} wasn't found!");
            }

            return (IActionResult)comments;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CommentCreateModel comm, string id)
        {
            var validationResult = await _createModelValidator.ValidateAsync(comm);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);
                return View(comm);
            }
            var commentEntity = _mapper.Map<CommentCreateModel, CommentEntity>(comm);
            await _commentService.Create(commentEntity);

            var routeValues = new RouteValueDictionary {
              { "systemname", id }
            };

            return RedirectToAction("Details", "Topic", routeValues);
        }
    }
}
