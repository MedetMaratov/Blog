using BlogEngineApplication.Common.Exeptions;
using BlogEngineApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            blogForEdit.Name = request.Title;
            blogForEdit.Description = request.Description;
            blogForEdit.Image = request.Image;
            blogForEdit.Edited = DateTime.Now;
            blogForEdit.Categories = request.Categories;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
