namespace Items.Services.Common
{
	using Interfaces;
	using Items.Common.Enums;


	using System;
	using System.Collections.Generic;

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


		public string? Pluralize(string? name, string language = "en")
		{
			if (language != "en")
			{
				throw new NotImplementedException();
			}


			if (string.IsNullOrEmpty(name))
			{
				return null;
			}

			if (name.EndsWith("y"))
			{
				name = name.Remove(name.Length - 1) + "ie";
			}

			name += "s";

			return name;
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

		public IEnumerable<Criteria> GetAllowedCriteria(
			bool isAuthenticated, string? controllerName, string? actionName = null)
		{
			List<Criteria> result = new List<Criteria>();

			

			if (controllerName == "Item" )
			{
				result.AddRange(new[] { Criteria.Auctions, Criteria.OnSale });
			}



			if (isAuthenticated)
			{
				if (controllerName == "Deal")
				{
					result.Add(Criteria.Sold);
					result.Add(Criteria.Bought);
					return result;
				}

				if (controllerName == "Item" && actionName == "All")
				{
					result.AddRange(new[] { Criteria.Mine, Criteria.NotMine });
				}
				else if (controllerName == "Sell" && actionName == "Offers")
				{
					result.AddRange(new[] { Criteria.Bids
											, Criteria.Barters 
					});
				}
				else if (controllerName == "Sell")
				{
					result.AddRange(new[] { Criteria.Auctions, Criteria.OnSale });
				}
			}

			return result;
		}

		public IEnumerable<Sorting> GetAllowedSorting(bool isAuthenticated
													, string? controllerName
													, string? actionName = null
			)
		{
			List<Sorting> result = new List<Sorting>();


			if (controllerName == "Item" || controllerName == "Category")
			{
				result.AddRange(new[] { Sorting.Name
										, Sorting.PriceDec
										, Sorting.PriceAsc
										, Sorting.Latest 
				});
			}

			if (isAuthenticated)
			{
				if (controllerName == "Location" || controllerName == "Place")
				{
					result.AddRange(new[] { Sorting.Name
											, Sorting.Country
											, Sorting.Town 
					});
				}
				else if (controllerName == "Bid" || controllerName == "Deal")
				{
					result.AddRange(new[] { Sorting.Name
											, Sorting.PriceDec
											, Sorting.PriceAsc 
					});
				}

				if (controllerName == "Bid")
				{
					result.AddRange(new[] { Sorting.Latest
											, Sorting.EndDate
											, Sorting.StartDate 
					});
				}
				else if (controllerName == "Sell" && actionName == "Offers")
				{
					result.AddRange(new[] { 
											  Sorting.PriceDec
											, Sorting.PriceAsc
											, Sorting.UserName
											, Sorting.Email
											, Sorting.Phone
											, Sorting.BarterName
											, Sorting.EndDate
											, Sorting.Country
											, Sorting.Town
					});
				}
				else if (controllerName == "Sell")
				{
					result.AddRange(new[] { Sorting.Name
											, Sorting.PriceDec
											, Sorting.PriceAsc
											, Sorting.Latest
											, Sorting.Type
											, Sorting.EndDate
											, Sorting.StartDate 
					});
				}
				else if (controllerName == "Deal")
				{
					result.AddRange(new[] { Sorting.Latest
											, Sorting.Status
											, Sorting.SendDate
											, Sorting.DeliveryDate
					});
				}
			}

			return result;
		}
	}
}
