
using System.ComponentModel.DataAnnotations.Schema;

namespace Telefon_Rehberi.Models.Entities
{
    [Table("Şehirler")]
    public class İletisim
    {
        
        public int Id { get; set; }

        public string Konum { get; set; }

        

        
    }


}
