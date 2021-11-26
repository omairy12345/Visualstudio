using System;
using System.Collections.Generic;

#nullable disable

namespace Newsapplibrary.Models
{
    public partial class Paise
    {
        public Paise()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int Idpais { get; set; }
        public string Nombrepais { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
