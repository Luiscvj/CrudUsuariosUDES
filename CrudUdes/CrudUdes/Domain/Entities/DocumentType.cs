using System.ComponentModel.DataAnnotations;

namespace CrudUdes.Domain.Entities
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeId { get; set; }
        public string type { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();    
    }
}
