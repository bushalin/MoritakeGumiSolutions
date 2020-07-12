namespace MG.Doko.Domain.DTOs
{
    public class UpdateUserInfoDto
    {
        public string ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string PermanentAddress { get; set; }
    }
}