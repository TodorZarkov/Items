namespace Items.Services.Data.Models.Ticket
{
	using static Items.Common.EntityValidationConstants;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.ComponentModel.DataAnnotations;

	public class AllTicketServiceModel
	{
		public Guid Id { get; set; }

		public string Title { get; set; } = null!;

		public string Type { get; set; } = null!;

		public string Status { get; set; } = null!;

        public byte[]? snapShot { get; set; }

		public string Created { get; set; } = null!;

        public int Severity { get; set; }

        public long WithSameProblem { get; set; }
    }
}
