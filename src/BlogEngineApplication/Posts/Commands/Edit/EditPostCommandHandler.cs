﻿using BlogEngine.Domain.Entities;
using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;

namespace BlogEngineApplication.Posts.Commands.Edit
{
    public class EditPostCommandHandler : IRequestHandler<EditPostCommand>
    {
        private readonly IBlogDbContext _dbContext;
        private readonly ITagService _tagService;

        public EditPostCommandHandler(IBlogDbContext dbContext, ITagService tagService)
        {
            _dbContext = dbContext;
            _tagService = tagService;
        }

        public async Task Handle(EditPostCommand request, CancellationToken cancellationToken)
        {
            var postToEdit = await _dbContext.Posts.FindAsync(request.PostId, cancellationToken);
            if (postToEdit == null)
            {
                throw new NotFoundException(nameof(postToEdit), request.PostId);
            }
            if (postToEdit.CreatorId != request.UserID)
            {
                throw new NotPermissionException("You do not have permission to perform this action.");
            }
            postToEdit.Edit(request.Title, request.Content);
            postToEdit.Tags = new List<Tag>();
            await _tagService.AddTags(postToEdit, request.Tags);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}