using MediatR;

namespace JimmyTestCMS.Service.Articles.Commands
{
    public class RemoveArticleCommand: IRequest
    {
        public long Id { get; set; }
    }
}
