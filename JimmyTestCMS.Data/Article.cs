using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace JimmyTestCMS.Data
{
    [Index(nameof(Title))]
    [Index(nameof(CreatedOn))]
    [Index(nameof(UpdatedOn))]
    public class Article
    {
        public const int TitleMaxLength = 2000;

        [Key]
        public long Id { get; set; }

        [StringLength(TitleMaxLength)]
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool Active { get; set; }
    }
}
