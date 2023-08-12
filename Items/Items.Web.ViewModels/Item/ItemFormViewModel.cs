namespace Items.Web.ViewModels.Item
{
	using Items.Common.Enums;
	using static Items.Common.EntityValidationConstants.Item;

	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	public class ItemFormViewModel
	{



		public AccessModifier Access { get; set; } = AccessModifier.Private;//todo: remove Access from Item 


		//[Required]
		//public ItemVisibility ItemVisibility { get; set; } = null!;


		[Required]
		[StringLength(NameMaxLength, MinimumLength = NameMinLength)]
		public string Name { get; set; } = null!;


		[Required]
		[Range(QuantityMinValue, QuantityMaxValue)]
		public decimal Quantity { get; set; }



		[Required] //todo: asynchronous validation with db
		public string Unit { get; set; } = null!;



		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
		public string? Description { get; set; }


		
		[Range(ValueMinValue, ValueMaxValue)]
		public decimal? AcquiredPrice { get; set; }


		//todo: my dateTime? valid attribute also may check is it after now
		public DateTime? AcquiredDate { get; set; }



		//public Document? AcquireDocument { get; set; }



		[Required]
		//todo: asynchronous validation with db
		public string[] Categories { get; set; } = null!;




		//[Required]
		//public Place Place { get; set; } = null!;



		//[Required]
		//public Location Location { get; set; } = null!;


		//public ICollection<Picture> Pictures { get; set; }

		//[Required]
		//[MaxLength(UriMaxLength)]
		//public string MainPictureUri { get; set; } = null!;



		
		[Range(ValueMinValue, ValueMaxValue)]
		public decimal? CurrentPrice { get; set; }


		//todo: asynchronous validation with db
		//todo: validate if any price is set to be required
		public string? Currency { get; set; }


		//todo: my dateTime? valid attribute also may check is it after now
		public DateTime? StartSell { get; set; }

		//todo: my dateTime? valid attribute also may check is it after StartSell, gets Required after StartDate is present
		public DateTime? EndSell { get; set; }


		//todo: gets Required after StartSell is present
		public bool? IsAuction { get; set; }


	}
}
