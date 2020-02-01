namespace Omnistack.Models.User
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Url { get; set; }
        public string Bio { get; set; }
        public string Linkedin { get; set; }
        public string Location { get; set; }
    }
}