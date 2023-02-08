using Microsoft.AspNetCore.Identity;


namespace Domain.Entities.Membership
{
    public class AppUser :IdentityUser<int>
    {
        public string Name { get; set; } = null!;
        public string SurName { get; set; } = null!;
        public int ConfirmCode { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
