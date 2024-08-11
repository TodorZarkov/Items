namespace Items.Services.Data.Models.Ticket
{
    public class TicketUserState
    {
        public bool isUser { get; set; }

        public bool isAdmin { get; set; }

        public bool isCreator { get; set; }

        public bool isSuperAdmin { get; set; }

        public bool isAssigner { get; set; }

        public bool isAssignee { get; set; }

        public bool isTicketAssigned { get; set; }

        public bool anyWithSameProblem { get; set; }
    }
}
