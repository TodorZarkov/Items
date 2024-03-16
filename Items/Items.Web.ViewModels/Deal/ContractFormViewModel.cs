namespace Items.Web.ViewModels.Deal
{
	using Items.Web.Validators.Attributes;
	using static Common.EntityValidationConstants.Contract;
	using static Common.EntityValidationConstants.User;
	using static Common.EntityValidationErrorMessages.Contract;

	using System.ComponentModel.DataAnnotations;

	public class ContractFormViewModel
	{
        public Guid? Id { get; set; }
        public bool? IsSeller { get; set; }

		//to view and to confirm that nothing has changed in the period between confirmations, in the considering item ---------------------
		[StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
        public string? SellerName { get; set; } // permission from  the Item visibility
		[EmailAddress]
		[StringLength(UserEmailMaxLength, MinimumLength = UserEmailMinLength)]
		public string? SellerEmail { get; set; }// permission from  the Item visibility
		[Phone]
		[StringLength(UserPhoneMaxLength, MinimumLength = UserPhoneMinLength)]
		public string? SellerPhone { get; set; }// permission from  the Item visibility

		public string? BuyerName { get; set; }// permission from  Form user consent     - got from db
		public string? BuyerEmail { get; set; }// permission from  Form user consent    - got from db
		public string? BuyerPhone { get; set; }// permission from  Form user consent    - got from db


		[RequiredIfPresent("BarterUnitSymbol", "BarterQuantity", "BarterDescription", "BarterPictureId", "BarterId", ErrorMessage = BarterItemRequiredIfPresentAnyBarterProperty)]
		public string? BarterName { get; set; } = null!;


		[RequiredIfPresent("BarterUnitSymbol", "BarterQuantity", "BarterDescription", "BarterName", "BarterId", ErrorMessage = BarterItemRequiredIfPresentAnyBarterProperty)]
        public Guid? BarterPictureId { get; set; }


        [RequiredIfPresent("BarterUnitSymbol", "BarterQuantity", "BarterPictureId", "BarterName", "BarterId", ErrorMessage = BarterItemRequiredIfPresentAnyBarterProperty)]
		public string? BarterDescription { get; set; }


		[RequiredIfPresent("BarterUnitSymbol", "BarterDescription", "BarterPictureId", "BarterName", "BarterId", ErrorMessage = BarterItemRequiredIfPresentAnyBarterProperty)]
		public decimal? BarterQuantity { get; set; }


		[RequiredIfPresent("BarterQuantity", "BarterDescription", "BarterPictureId", "BarterName", "BarterId", ErrorMessage = BarterItemRequiredIfPresentAnyBarterProperty)]
		public string? BarterUnitSymbol { get; set; }


		[RequiredIfPresent("BarterQuantity", "BarterDescription", "BarterPictureId", "BarterName", "BarterUnitSymbol", ErrorMessage = BarterItemRequiredIfPresentAnyBarterProperty)]
		public Guid? BarterId { get; set; }


		public Guid? OfferId { get; set; }




		public Guid ItemId { get; set; }

        [Range(ValueMinValue, ValueMaxValue)]
        public decimal Price { get; set; }

		[Required]
		public string CurrencySymbol { get; set; } = null!;

		[Required]
		public string UnitSymbol { get; set; } = null!;

		[Required]
		public string ItemName { get; set; } = null!;


		[Required]
        public Guid ItemPictureId { get; set; }



        public string? ItemDescription { get; set; }


        public string? TotalPrice { get; set; }

//------------------------------------------------------------------------


// to form ---------------------------------------------------------------
        [Required]
		public bool ConsentBuyerInfo { get; set; }


		[Required]
		[Range(QuantityMinValue, QuantityMaxValue)]
		public decimal Quantity { get; set; }


		[DateBefore("DeliverDue", ErrorMessage = CannotBeDeliveredBeforeSent)]
		[AfterOrEqualCurrentDate]
		public DateTime SendDue { get; set; }// seller set after reads the address of the buyer, NEGOTIABLE

		public DateTime DeliverDue { get; set; }//seller default - 1 day after contract createdOn, NEGOTIABLE 


		[StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
		public string? SellerComment { get; set; } // seller default comment


		[StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
		public string? BuyerComment { get; set; }


		[StringLength(DeliveryAddressMaxLength, MinimumLength = DeliveryAddressMinLength)]
		public string DeliveryAddress { get; set; } = null!;

//-----------------------------------------------------------------------------------------------------------------
		public override bool Equals(object? contractViewModel)
		{
			ContractViewModel toCompare;
			try
			{
				toCompare = (ContractViewModel)contractViewModel!;
			}
			catch (Exception)
			{

				return false;
			}

			if (SendDue == toCompare.SendDue &&
				DeliverDue == toCompare.DeliverDue &&
				DeliveryAddress == toCompare.DeliveryAddress &&
				(SellerComment??string.Empty).Trim() == (toCompare.SellerComment??string.Empty).Trim() &&
				BuyerComment == toCompare.BuyerComment)
			{
				return true;
			}

			return false;
		}
	}
}
