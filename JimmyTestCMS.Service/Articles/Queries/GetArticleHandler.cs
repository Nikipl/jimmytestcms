using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JimmyTestCMS.Data;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JimmyTestCMS.Service.Articles.Queries
{
    public class GetArticleQueryHandler: IRequestHandler<GetArticleQuery, ArticleDto>
    {
        private readonly ApplicationContext applicationContext;

        public Task<ArticleDto> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            return applicationContext.Articles
                .Where(ar => ar.Id == request.Id)
                .ProjectToType<ArticleDto>()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public GetArticleQueryHandler(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
    }
}
