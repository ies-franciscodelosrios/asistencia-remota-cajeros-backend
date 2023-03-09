using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_BackEnd.Model
{
    public class CajeroModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string ip { get; set; }
        public string ubication { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        
    }
}
