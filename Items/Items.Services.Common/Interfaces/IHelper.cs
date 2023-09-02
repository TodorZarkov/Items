namespace Items.Services.Common.Interfaces
{
	using Items.Common.Enums;
	using System.Collections.Generic;
	using static Items.Common.Enums.DealStatus;
	public interface IHelper
	{
		HashSet<int> GetRandNUniqueOfM(int n, int m);

		DealStatus GetDealStatus(bool sellerOk, bool buyerOk, bool SellerReceived, bool BuyerReceived);

		Colors GetDealRowColor(bool sellerOk, bool buyerOk, bool SellerReceived, bool BuyerReceived, bool isSeller);


		string? Pluralize(string? name, string language = "en");
		IEnumerable<Criteria> GetAllowedCriteria(bool isAuthenticated, string? controllerName);
		IEnumerable<Sorting> GetAllowedSorting(bool isAuthenticated, string? controllerName);
	}
}
