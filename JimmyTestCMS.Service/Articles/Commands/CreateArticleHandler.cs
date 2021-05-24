using System.Threading;
using System.Threading.Tasks;
using JimmyTestCMS.Common.Utils;
using JimmyTestCMS.Data;
using Mapster;
using MediatR;

namespace JimmyTestCMS.Service.Articles.Commands
{
    public class CreateArticleHandler: IRequestHandler<CreateArticleCommand, ArticleDto>
    {
        private readonly ApplicationContext context;
        private readonly IClock clock;

        public async Task<ArticleDto> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = request.Adapt<Article>();
            article.CreatedOn = clock.GetUtc();
            article.UpdatedOn = clock.GetUtc();
            article.Active = true;
            context.Articles.Add(article);
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return article.Adapt<ArticleDto>();
        }

        public CreateArticleHandler(ApplicationContext context, IClock clock)
        {
            this.context = context;
            this.clock = clock;
        }
    }
}
