namespace Items.Services.Data.Models.User
{

    public class AllUserServiceModel
    {
        public Guid id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
