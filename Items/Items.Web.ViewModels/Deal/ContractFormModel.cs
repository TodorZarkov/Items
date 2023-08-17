namespace Items.Web.ViewModels.Deal
{
	using Items.Data.Models;
	using static Common.EntityValidationConstants.Contract;

	using Microsoft.EntityFrameworkCore;

	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;
	using Items.Web.ViewModels.User;

	public class ContractFormModel
	{
		//for view
		public UserViewModel Buyer { get; set; } = null!;

		public UserViewModel Seller { get; set; } = null!;

		public string? Price { get; set; } = null!;

		public string? Currency { get; set; } = null!;
 
		//public Item Item { get; set; } = null!;

		public string? Unit { get; set; } = null!;




		
		public decimal Quantity { get; set; }



		public DateTime SendDue { get; set; }

		public DateTime DeliverDue { get; set; }

		public DateTime ContractDate { get; set; }

		

		[MaxLength(CommentMaxLength)]
		public string? SellerComment { get; set; }

		[MaxLength(CommentMaxLength)]
		public string? BuyerComment { get; set; }


		[MaxLength(DeliveryAddressMaxLength)]
		public string DeliveryAddress { get; set; } = null!;



		public bool SellerOk { get; set; }

		public bool BuyerOk { get; set; }

		public bool? BuyerConfirm { get; set; }

		public bool Fulfilled { get; set; }

	}
}
