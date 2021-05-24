using MediatR;

namespace JimmyTestCMS.Service.Articles.Commands
{
    public class CreateArticleCommand: IRequest<ArticleDto>
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
