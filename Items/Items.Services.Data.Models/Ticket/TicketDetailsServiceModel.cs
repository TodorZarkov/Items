namespace Items.Services.Data.Models.Ticket
{
	public class TicketDetailsServiceModel
	{
		public string TicketType { get; set; } = null!;


		public string Title { get; set; } = null!;


		public string? Description { get; set; }

		//formfile?
		public byte[]? SnapShot { get; set; }


		
		public string TicketStatus { get; set; } = null!;


		public Guid AuthorId { get; set; }
		public string AuthorName { get; set; } = null!;



		public Guid? AssignerId { get; set; }
		public string? AssignerName { get; set; }


		public Guid? AssigneeId { get; set; }
		public string? AssigneeName { get; set; }

        public Guid? SnapshotId { get; set; }

        public string Created { get; set; } = null!;

        public int Severity { get; set; }

        public long WithSameProblem { get; set; }

        public bool IHaveSameProblem { get; set; }

		public string Modified { get; set; } = null!;

        public long Subscribers { get; set; }

        public bool Subscribed { get; set; }
    }
}
