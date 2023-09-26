namespace Items.Services.Mapping
{
	using AutoMapper;
	using Items.Data.Models;
	using Items.Web.ViewModels.Bid;
	using Items.Web.ViewModels.Item;
	using Items.Web.ViewModels.Location;
	using Items.Web.ViewModels.Offer;
	using Items.Web.ViewModels.Place;
	using static Items.Common.FormatConstants.DateAndTime;
	public class ItemsProfile : Profile
	{
		public ItemsProfile()
		{
			//Location source , dest.
			CreateMap<Location, LocationFormModel>()
				.ForMember(d => d.Border,
					cfg => cfg.Ignore())
				.ForMember(d => d.GeoLocation,
					cfg => cfg.Ignore());

			CreateMap<LocationVisibility, LocationVisibilityFormModel>();

			CreateMap<LocationFormModel, Location>()
				.ForMember(d => d.Border,
					cfg => cfg.Ignore())
				.ForMember(d => d.GeoLocation,
					cfg => cfg.Ignore());
			CreateMap<LocationVisibilityFormModel, LocationVisibility>();

			//Place 
			CreateMap<PlaceFormModel, Place>();
			CreateMap<Place, PlaceFormModel>();

			//Offer
			CreateMap<AddBidFormModel, Offer>();
			CreateMap<Offer, AllOfferViewModel>()
				.ForMember(d => d.UserName,
					cfg => cfg.MapFrom(s => s.UseBuyerName ? s.Buyer.UserName : null))
				.ForMember(d => d.Email,
					cfg => cfg.MapFrom(s => s.UseBuyerEmail ? s.Buyer.Email : null))
				.ForMember(d => d.Phone,
					cfg => cfg.MapFrom(s => s.UseBuyerPhone && s.Buyer.PhoneNumberConfirmed ? s.Buyer.PhoneNumber : null))
				.ForMember(d => d.BarterUnit,
					cfg => cfg.MapFrom(s => s.BarterItem != null ? s.BarterItem.Unit.Symbol : null))
				.ForMember(d => d.BarterPictureUri,
					cfg => cfg.MapFrom(s => s.BarterItem != null ? s.BarterItem.MainPictureUri : null))
				.ForMember(d => d.BarterName,
					cfg => cfg.MapFrom(s => s.BarterItem != null ? s.BarterItem.Name : null))
				.ForMember(d => d.BarterDescription,
					cfg => cfg.MapFrom(s => s.BarterItem != null ? s.BarterItem.Description : null))
				.ForMember(d => d.BarterQuantity,
					cfg => cfg.MapFrom(s => s.BarterItem != null ? s.BarterItem.Quantity.ToString("G29") : null))
				.ForMember(d => d.CurrencySymbol,
					cfg => cfg.MapFrom(s => s.Currency.Symbol))
				.ForMember(d => d.UnitSymbol,
					cfg => cfg.MapFrom(s => s.Item.Unit.Symbol))
				.ForMember(d => d.Expires,
					cfg => cfg.MapFrom(s => s.Expires.ToString(BiddingLongUtcDateTime)));


			//Item
			CreateMap<Item, ItemOfferViewModel>()
				.ForMember(d => d.HighestBid,
					opt => opt.MapFrom(s => s.Offers.Max(so => so.Value)))
				.ForMember(d => d.BarterOffers,
					opt => opt.MapFrom(s => s.Offers.Count(so => so.BarterItem != null)))
				.ForMember(d => d.Country,
					opt => opt.MapFrom(s => s.Location.Country))
				.ForMember(d => d.Town,
					opt => opt.MapFrom(s => s.Location.Town))
				.ForMember(d => d.StartPrice,
					opt => opt.MapFrom(d => d.CurrentPrice))
				.ForMember(d => d.CurrencySymbol,
					opt => opt.MapFrom(s => s.Currency == null ? null : s.Currency.Symbol))
				.ForMember(d => d.QuantityLeft,
					opt => opt.MapFrom(s => s.Quantity))
				.ForMember(d => d.Unit,
					opt => opt.MapFrom(s => s.Unit.Symbol))
				.ForMember(d => d.EndSell,
					opt => opt.MapFrom(s => ((DateTime)(s.EndSell!)).ToString(BiddingLongUtcDateTime)));



		}
	}
}