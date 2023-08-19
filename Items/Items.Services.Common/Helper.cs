namespace Items.Services.Common
{
	using Interfaces;
	using Items.Common.Enums;

	public class Helper : IHelper
	{
		public Colors GetDealRowColor(bool sellerOk, bool buyerOk, bool sellerReceived, bool buyerReceived, bool isSeller)
		{
			if (!(sellerOk && buyerOk))
			{
				if (sellerOk && !buyerOk)
				{
					if (isSeller)
					{
						return Colors.warning;
					}
					else
					{
						return Colors.danger;
					}
				}
				else if (!sellerOk && buyerOk)
				{
					if (isSeller)
					{
						return Colors.danger;
					}
					else
					{
						return Colors.warning;
					}
				}
				else
				{
					return Colors.secondary;
				}
			}
			else
			{
				if (!sellerReceived && !buyerReceived)
				{
					return Colors.success;
				}
				else if (!sellerReceived && buyerReceived)
				{
					if (isSeller)
					{
						return Colors.danger;
					}
					else
					{
						return Colors.warning;
					}
				}
				else if (sellerReceived && !buyerReceived)
				{
					if (isSeller)
					{
						return Colors.warning;
					}
					else
					{
						return Colors.danger;
					}
				}
				else
				{
					return Colors.primary;
				}
			}
		}

		public DealStatus GetDealStatus(bool sellerOk, bool buyerOk, bool sellerReceived, bool buyerReceived)
		{
			if (!(sellerOk && buyerOk))
			{
				if (sellerOk && !buyerOk)
				{
					return DealStatus.BuyerAttention;
				}
				else if (!sellerOk && buyerOk)
				{
					return DealStatus.SellerAttention;
				}
				else
				{
					return DealStatus.Off;
				}
			}
			else 
			{
				if (!sellerReceived && !buyerReceived)
				{
					return DealStatus.OnDelivery;
				}
				else if (!sellerReceived && buyerReceived)
				{
					return DealStatus.SellerAwaits;
				}
				else if (sellerReceived && !buyerReceived)
				{
					return DealStatus.BuyerAwaits;
				}
				else
				{
					return DealStatus.Fulfilled;
				}
			}
		}

		public HashSet<int> GetRandNUniqueOfM(int n, int m)
		{
			if (n > m)
			{
				n = m;
			}
			HashSet<int> rands = new HashSet<int>(n);
			var rnd = new Random(DateTime.UtcNow.Ticks.GetHashCode());
			while (rands.Count < n)
			{
				rands.Add(rnd.Next(m));
			}

			return rands;
		}
	}
}
