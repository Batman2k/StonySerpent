namespace StonySerpent.Core.Models
{
    public class CustomerInformation
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public string StreetAddress { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string PhoneHomeNumber { get; set; }

        public string PhoneCellNumber { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public void Update(CustomerInformation customerInformation)
        {
            FirstName = customerInformation.FirstName;
            LastName = customerInformation.LastName;
            SocialSecurityNumber = customerInformation.SocialSecurityNumber;
            StreetAddress = customerInformation.StreetAddress;
            ZipCode = customerInformation.ZipCode;
            City = customerInformation.City;
            PhoneHomeNumber = customerInformation.PhoneHomeNumber;
            PhoneCellNumber = customerInformation.PhoneCellNumber;
        }

        public CustomerInformation SetUserId(string userId)
        {
            UserId = userId;

            return this;
        }
    }
}