namespace Items.Web.ViewModels.Base
{
	using Items.Common.Enums;
	using System.ComponentModel.DataAnnotations;
	using static Common.EntityValidationConstants.QueryFilter;
    using static Common.GeneralConstants;
	public class QueryFilterModel
    {
        public QueryFilterModel()
        {
            HitsPerPage = DefaultHitsPerPage;
            CurrentPage = DefaultCurrentPage;

        }

        [StringLength(SearchTermMax, MinimumLength = SearchTermMin)]
        public string? SearchTerm { get; set; }


        // todo: async check with db
        public int[]? CategoryIds { get; set; }

        public Criteria[]? Criteria { get; set; }


        [Range(HitsPerPageMin, HitsPerPageMax)]
        public int HitsPerPage { get; set; }

		// todo: async check with db (calc. max page from Hits and hits per page
		public int CurrentPage { get; set; }

        public Sorting SortBy { get; set; }
    }
}
