namespace Items.Web.ViewModels.Deal
{
	using Items.Web.Validators.Attributes;
	using static Common.EntityValidationConstants.Contract;
	using static Common.EntityValidationErrorMessages.Contract;

	using System.ComponentModel.DataAnnotations;
	public class ContractFormViewModel
	{
        public Guid? Id { get; set; }
        public bool? IsSeller { get; set; }

        //to view and to confirm that nothing has changed in the period between confirmations, in the considering item
        public string? SellerName { get; set; } // permission from  the Item visibility
		public string? SellerEmail { get; set; }// permission from  the Item visibility
		public string? SellerPhone { get; set; }// permission from  the Item visibility

		public string? BuyerName { get; set; }// permission from  Form user consent     - got from db
		public string? BuyerEmail { get; set; }// permission from  Form user consent    - got from db
		public string? BuyerPhone { get; set; }// permission from  Form user consent    - got from db


		
        public Guid? ItemId { get; set; }

        [Range(ValueMinValue, ValueMaxValue)]
        public decimal Price { get; set; }

		[Required]
		public string CurrencySymbol { get; set; } = null!;

		[Required]
		public string UnitSymbol { get; set; } = null!;

		[Required]
		public string ItemName { get; set; } = null!;

		[Required]
		public string ItemPictureUri { get; set; } = null!;

		public string? ItemDescription { get; set; }


        public string? TotalPrice { get; set; }




        // to form
        [Required]
		public bool ConsentBuyerInfo { get; set; }


		[Required]
		[Range(QuantityMinValue, QuantityMaxValue)]
		//todo: asynchronous quantity check with the remaining quantity of the item
		public decimal Quantity { get; set; }


		[DateTimeBefore("DeliverDue", ErrorMessage = CannotBeDeliveredBeforeSent)]
		[AfterOrEqualCurrentDate]
		public DateTime SendDue { get; set; }// seller set after reads the address of the buyer, NEGOTIABLE

		public DateTime DeliverDue { get; set; }//seller default - 1 day after contract createdOn, NEGOTIABLE 


		[StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
		public string? SellerComment { get; set; } // seller default comment


		[StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
		public string? BuyerComment { get; set; }


		[StringLength(DeliveryAddressMaxLength, MinimumLength = DeliveryAddressMinLength)]
		public string DeliveryAddress { get; set; } = null!;
	}
}
