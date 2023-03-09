using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Proyecto_BackEnd.Model
{
    public class CallModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string p2p { get; set; }
        public Estado estado { get; set; }
        public DateTime date { get; set; }
        public int CajeroId { get; set; }
        public int? UserId { get; set; }
    }
}
