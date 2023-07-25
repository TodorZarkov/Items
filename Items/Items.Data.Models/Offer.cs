﻿namespace Items.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Offer;

    public class Offer
    {
        [Key]
        public Guid Id { get; set; }


        [MaxLength(MessageMaxLength)]
        public string? Message { get; set; }


        [Required]
        [ForeignKey(nameof(Buyer))]
        public Guid BuyerId { get; set; }

        [Required]
        public ApplicationUser Buyer { get; set; } = null!;


        [Required]
        [ForeignKey(nameof(Item))]
        public Guid ItemId { get; set; }

        [Required]
        public Item Item { get; set; } = null!;


        
        [Precision(ValuePrecision, ValueScale)]
        public decimal Value { get; set; }


        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; } = null!;



        [ForeignKey(nameof(BuyerLocation))]
        public Guid? LocationId { get; set; }

        public Location? BuyerLocation { get; set; }

    }
}
