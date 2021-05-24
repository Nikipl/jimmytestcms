using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using JimmyTestCMS.Data;
using JimmyTestCMS.Service.Common;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JimmyTestCMS.Service.Articles.Queries
{
    public class GetArticlesHandler: IRequestHandler<GetArticlesQuery, IEnumerable<ArticleDto>>
    {
        private readonly ApplicationContext applicationContext;

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var query = applicationContext.Articles.Where(a => a.Active);
            if (request.Sorting != null) {
                query = query.Sort(request.Sorting);
            }

            if (request.Offset != null) {
                query = query.Skip(request.Offset.Value);
            }

            if (request.Limit != null) {
                query = query.Take(request.Limit.Value);
            }

            IEnumerable<ArticleDto> result = await query.ProjectToType<ArticleDto>()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
            return result;
        }

        public GetArticlesHandler(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
    }
}
