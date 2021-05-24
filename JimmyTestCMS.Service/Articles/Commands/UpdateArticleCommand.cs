using MediatR;

namespace JimmyTestCMS.Service.Articles.Commands
{
    public class UpdateArticleCommand: IRequest<ArticleDto>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
