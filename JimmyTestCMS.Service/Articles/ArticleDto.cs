using System;

namespace JimmyTestCMS.Service.Articles
{
    public class ArticleDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
