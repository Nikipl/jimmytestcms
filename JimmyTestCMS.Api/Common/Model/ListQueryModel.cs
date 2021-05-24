using Microsoft.AspNetCore.Mvc;

namespace JimmyTestCMS.Api.Common.Model
{
    public class ListQueryModel
    {
        [FromQuery(Name = "offset")]
        public int? Offset { get; set; }

        [FromQuery(Name = "limit")]
        public int? Limit { get; set; }

        [FromQuery(Name = "sort_by")]
        public string? SortBy { get; set; }

        [FromQuery(Name = "sort_desc")]
        public bool? SortDescending { get; set; }
    }
}
