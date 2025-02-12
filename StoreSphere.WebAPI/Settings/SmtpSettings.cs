namespace StoreSphere.WebAPI.Settings
{
    public class SmtpSettings
    {
        public string Server { get; set; } // SMTP server address (e.g., smtp.office365.com)
        public int Port { get; set; } // SMTP port (e.g., 587)
        public string Username { get; set; } // Your email address (e.g., jaafar.serhan@outlook.com)
        public string Password { get; set; } // Your email password or app-specific password
        public string FromEmail { get; set; } // The email address to show in the "From" field
        public string FromName { get; set; } // The name to show in the "From" field
        public bool EnableSsl { get; set; } // Whether to enable SSL (true for most providers)
    }
}