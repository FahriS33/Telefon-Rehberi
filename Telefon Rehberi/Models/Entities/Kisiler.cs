
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telefon_Rehberi.Models.Entities
{
    [Table("kisiler")]
    public class Kisiler
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Soyad { get; set; }

        public string Firma { get; set; }
        [DisplayName("Telefon No.")]
        public string Telefon { get; set; }
        [DisplayName("E-mail Adresi")]
        public string Email { get; set; }
        [DisplayName("Şehir")]
        public int İletisimId { get; set; }

        public İletisim Konum {  get; set; }



       
        

    }
}
