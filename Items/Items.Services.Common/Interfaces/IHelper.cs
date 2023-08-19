namespace Items.Services.Common.Interfaces
{
	using Items.Common.Enums;
	using static Items.Common.Enums.DealStatus;
	public interface IHelper
	{
		HashSet<int> GetRandNUniqueOfM(int n, int m);

		DealStatus GetDealStatus(bool sellerOk, bool buyerOk, bool SellerReceived, bool BuyerReceived);

		Colors GetDealRowColor(bool sellerOk, bool buyerOk, bool SellerReceived, bool BuyerReceived, bool isSeller);
	}
}
