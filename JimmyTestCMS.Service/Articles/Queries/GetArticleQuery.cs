using MediatR;

namespace JimmyTestCMS.Service.Articles.Queries
{
    public class GetArticleQuery: IRequest<ArticleDto>
    {
        public long Id { get; set; }
    }
}
