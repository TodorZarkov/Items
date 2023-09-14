namespace Items.Services.Mapping
{
	using AutoMapper;
	using Items.Data.Models;
	using Items.Web.ViewModels.Location;
	using Items.Web.ViewModels.Place;

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
        }
    }
}