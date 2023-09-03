namespace Items.Web.ViewModels.Base
{
	using Items.Common.Enums;
	using Items.Web.ViewModels.Category;
	using static Common.GeneralConstants;

	public class QueryFilterViewModel
	{
        public QueryFilterViewModel()
        {
			MyAvailableCategories = new List<ForSelectCategoryViewModel>();
			AllAvailableCategories = new List<ForSelectCategoryViewModel>();

			AvailableCriteria = new List<Criteria>();
			AvailableSorting = new List<Sorting>();

			CategoryIds = new List<int>();
			Criteria = new List<string?>();

			HitsPerPage = DefaultHitsPerPage;
			CurrentPage = DefaultCurrentPage;
			LastPage = CurrentPage;
		}
		public int Hits { get; set; }

		public IEnumerable<ForSelectCategoryViewModel> MyAvailableCategories { get; set; }
		public IEnumerable<ForSelectCategoryViewModel> AllAvailableCategories { get; set; }
		public ICollection<Criteria> AvailableCriteria { get; set; }
        public ICollection<Sorting> AvailableSorting { get; set; }
        

        public List<int> CategoryIds { get; set; }
        public List<string?> Criteria { get; set; }
        public string? Sorting { get; set; }


        public string? SearchTerm { get; set; }
        public string? SearchPlaceHolder { get; set; }

        public int HitsPerPage { get; set; }
		public int CurrentPage { get; set; }

        public int LastPage { get; set; }

    }
}
