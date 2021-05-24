using System.Threading;
using System.Threading.Tasks;
using JimmyTestCMS.Common.Utils;
using JimmyTestCMS.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JimmyTestCMS.Service.Articles.Commands
{
    public class UpdateArticleHandler: IRequestHandler<UpdateArticleCommand, ArticleDto>
    {
        private readonly ApplicationContext applicationContext;
        private readonly IClock clock;

        public async Task<ArticleDto> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await applicationContext.Articles
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            article.Title = request.Title;
            article.Body = request.Body;
            article.UpdatedOn = clock.GetUtc();
            await applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return article.Adapt<ArticleDto>();
        }

        public UpdateArticleHandler(ApplicationContext applicationContext, IClock clock)
        {
            this.applicationContext = applicationContext;
            this.clock = clock;
        }
    }
}
