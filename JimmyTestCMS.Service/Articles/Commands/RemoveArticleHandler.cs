using System.Threading;
using System.Threading.Tasks;
using JimmyTestCMS.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JimmyTestCMS.Service.Articles.Commands
{
    public class RemoveArticleHandler: IRequestHandler<RemoveArticleCommand>
    {
        private readonly ApplicationContext applicationContext;

        public async Task<Unit> Handle(RemoveArticleCommand request, CancellationToken cancellationToken)
        {
            var toRemove = await applicationContext.Articles
                .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            toRemove.Active = false;
            await applicationContext.SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            return Unit.Value;
        }

        public RemoveArticleHandler(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
    }
}
