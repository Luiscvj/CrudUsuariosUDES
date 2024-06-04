namespace CrudUdes.Api.DTOS.UserDTOS
{
    public class UserDtoUpdate
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string DocumentNumber { get; set; }
        public int DocumentTypeId { get; set; }
        public string UserName { get; set; }
    }
}
