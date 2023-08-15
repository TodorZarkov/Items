namespace Items.Web.ViewModels.Item
{
	using Items.Common.Enums;

	public class ItemFormVisibilityModel
	{
		public ItemFormVisibilityModel()
		{
			Description = AccessModifier.Public;
			CurrentPrice = AccessModifier.Public;

			Location = AccessModifier.Private;
			Offers = AccessModifier.Private;
			AddedOn = AccessModifier.Private;
			ModifiedOn = AccessModifier.Private;

			Quantity = AccessModifier.Private;
			AcquiredPrice = AccessModifier.Private;
			AcquiredDate = AccessModifier.Private;
			AcquireDocument = AccessModifier.Private;
			Owner = AccessModifier.Private;
		}
		public AccessModifier Quantity { get; set; }

		public AccessModifier Description { get; set; }

		public AccessModifier AcquiredPrice { get; set; }

		public AccessModifier CurrentPrice { get; set; }

		public AccessModifier AcquiredDate { get; set; }

		public AccessModifier AcquireDocument { get; set; }

		public AccessModifier Owner { get; set; }

		public AccessModifier Location { get; set; }

		public AccessModifier Offers { get; set; }

		public AccessModifier AddedOn { get; set; }

        public AccessModifier ModifiedOn { get; set; }
    }
}
