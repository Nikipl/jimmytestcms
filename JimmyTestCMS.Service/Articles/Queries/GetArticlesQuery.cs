using System.Collections.Generic;
using JimmyTestCMS.Service.Common;
using MediatR;

namespace JimmyTestCMS.Service.Articles.Queries
{
    public class GetArticlesQuery: IRequest<IEnumerable<ArticleDto>>
    {
        public int? Offset { get; set; }
        public int? Limit { get; set; }
        public Sorting? Sorting { get; set; }
    }
}
