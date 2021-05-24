using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JimmyTestCMS.Api.Common.Model;
using JimmyTestCMS.Service.Articles;
using JimmyTestCMS.Service.Articles.Commands;
using JimmyTestCMS.Service.Articles.Queries;
using JimmyTestCMS.Service.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JimmyTestCMS.Api.Articles.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly ILogger<ArticlesController> logger;
        private readonly IMediator mediator;

        public ArticlesController(IMediator mediator, ILogger<ArticlesController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleDto>> List([FromQuery] ListQueryModel queryParams,
            CancellationToken cancellationToken)
        {
            var query = new GetArticlesQuery
            {
                Limit = queryParams?.Limit,
                Offset = queryParams?.Offset
            };
            if (queryParams?.SortBy != null) {
                query.Sorting = new Sorting
                {
                    Field = queryParams.SortBy,
                    Direction = queryParams.SortDescending ?? false
                        ? OrderingDirection.Descending
                        : OrderingDirection.Ascending
                };
            }

            return await mediator.Send(query, cancellationToken);
        }

        [HttpGet("{id:long}")]
        public async Task<ArticleDto> Get(long id, CancellationToken cancellationToken)
        {
            var query = new GetArticleQuery
            {
                Id = id
            };
            return await mediator.Send(query, cancellationToken);
        }

        [HttpDelete("{id:long}")]
        public async Task Remove(long id, CancellationToken cancellationToken)
        {
            var command = new RemoveArticleCommand()
            {
                Id = id
            };
            await mediator.Send(command, cancellationToken);
        }

        [HttpPut]
        public async Task Update(UpdateArticleCommand command)
        {
            await mediator.Send(command);
        }

        [HttpPost]
        public async Task<ArticleDto> Create(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            return await mediator.Send(command, cancellationToken);
        }
    }
}
