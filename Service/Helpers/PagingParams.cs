namespace Service.Helpers
{
    public class PagingParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }
        public string Keyword { get; set; }
        public string SortValue { get; set; }
        public string SortKey { get; set; }
        public string SearchValue { get; set; }
        public string SearchKey { get; set; }

        public string LanguageId { get; set; }
    }
}
