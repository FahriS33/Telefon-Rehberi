using Telefon_Rehberi.Models.Entities;

namespace Telefon_Rehberi.Models.KisiModel
{
    public class KisiGuncelleModelView
    {
        public Kisiler Kisi {  get; set; }
        public List<İletisim> Sehirler { get; set; }
    }
}
