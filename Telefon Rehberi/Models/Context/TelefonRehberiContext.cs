using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Telefon_Rehberi.Models.Entities;

namespace Telefon_Rehberi.Models.Context
{
    public class TelefonRehberiContext:DbContext
    {
        public TelefonRehberiContext() : base("server=FAHRI\\SQLEXPRESS;Database=TelefonRehberDB;Trusted_Connection=true")
        {

        }

        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<İletisim> iletisimbil { get; set; }
    }
}
