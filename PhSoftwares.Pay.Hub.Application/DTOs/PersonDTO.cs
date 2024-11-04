namespace PhSoftwares.Pay.Hub.Application.DTOs
{
    public class PersonDTO
    {
        public Guid? Id { get; set; }
        public required string FullName { get; set; }
        public required string EmailAddress { get; set; }
        public required string DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDTO Adress { get; set; }
        public Guid? CreationUserId { get; private set; }
        public void SetId(Guid id)
        {
            Id = id;
        }
        public void SetCreationUserId(Guid userId)
        {
            CreationUserId = userId;
        }
    }
}
