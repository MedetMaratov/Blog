# REST API for a blog on ASP.NET Core
This is an ASP.NET Core REST API project that provides functionality for creating and managing blogs. The API supports creating blogs with categories, writing posts inside blogs using tags, searching for posts by tags, subscribing to blogs etc. The project implemented integration with Swagger and a logging mechanism through the Serilog
## Used technologies
<ul>
  <li>Asp.net core</li>
  <li>SQL Server</li>
  <li>Entity Framework Core</li>
  <li>Swagger</li>
  <li>Serilog</li>
  <li>XUnit</li>
  <li>AutoMapper</li>
  <li>MediatR</li>
  <li>AutoFixture</li>
</ul>

## Actions
### Blog

    URL                                        HTTP Method        Operation
    
    /api/Blog/GetAll                           GET                Get all blogs
    /api/Blog/GetByName/{blogName}             GET                Get blogs by name
    /api/Blog/GetSubscribed                    GET                Get subscribed blogs
    /api/Blog/GetByCreator/{CreatorId}         GET                Get blogs by creator
    /api/Blog/GetByCategory                    GET                Get blogs by category
    /api/Blog/GetDetails/{id}                  GET                Get blog details
    /api/Blog/Create                           POST               Create a new blog
    /api/Blog/Update                           PUT                Update blog
    /api/Blog/Delete/{id}                      DELETE             Delete blog


### Post
    URL                                        HTTP Method        Operation

    /api/Post/{id}                             GET                Get post details
    /api/Post/GetAllByBlogId/{blogId}          GET                Get all posts by blog id
    /api/Post/GetSubscribed                    GET                Get posts from subscribed blogs
    /api/Post/GetByTags                        GET                Get posts by tags
    /api/Post/Create/{blogId}                  POST               Create a new blog post
    /api/Post/Edit/{blogId}/{postId}           PUT                Edit post
    /api/Post/Delete/{blogId}/{postId}         DELETE             Delete post


### Comment
    URL                                        HTTP Method        Operation

    /api/Comment/Create/{postId}               POST               Create a new comment on a post
    /api/Comment/Delete/{postId}/{commentId}   DELETE             Delete a comment on a post
    /api/comment/getall/{postId}               Get                Gets all comments for a specific post

### Subscription
    URL                                        HTTP Method        Operation

    /api/Subscription/Subscribe/{blogId}       POST               Subscribe to blog
    /api/Subscription/Unsubscribe/{blogId}     POST               Unsubscribe blog

### Category
    URL                                        HTTP Method        Operation

    /api/Category/Create                       POST               Create a new category
    /api/Category/Get                          GET                Get all categories