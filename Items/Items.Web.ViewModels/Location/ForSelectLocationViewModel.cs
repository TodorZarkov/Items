﻿namespace Items.Web.ViewModels.Location
{
	using Items.Web.ViewModels.Place;

	public class ForSelectLocationViewModel
	{
        public Guid LocationId { get; set; }

        public string LocationName { get; set; } = null!;


        public int PlaceId { get; set; }// todo: filter available places over client(ajax) or go supDropdown
		public IEnumerable<ForSelectPlaceViewModel> AvailablePlaces { get; set; } = null!; // todo: filter available places over client(ajax) or go supDropdown
    }
}
