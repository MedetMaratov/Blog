using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;

namespace BlogEngineApplication.Blogs.Commands.EditBlog
{
    public class EditBlogCommandHandler : IRequestHandler<EditBlogCommand>
    {
        private readonly IBlogDbContext _dbContext;

        public EditBlogCommandHandler(IBlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(EditBlogCommand request, CancellationToken cancellationToken)
        {
            var blogForEdit = await _dbContext.Blogs
                .FindAsync(new object[] { request.BlogId }, cancellationToken);
            if (blogForEdit == null)
            {
                throw new NotFoundException(nameof(blogForEdit), request.BlogId);
            }
            if (blogForEdit.CreatorId != request.UserId)
            {
                throw new NotPermissionException("You do not have permission to perform this action.");
            }
            blogForEdit.Edit(request.Name, request.Description, request.Image, request.Categories);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
