namespace StoreSphere.WebAPI.Models
{ 
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string ProfilePictureURL { get; set; }

        // Navigation property for Stores
        public ICollection<Store> Stores { get; set; }
    }
}