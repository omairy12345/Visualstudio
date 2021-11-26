using System;
using System.Collections.Generic;

#nullable disable

namespace Newsapplibrary.Models
{
    public partial class Fuente
    {
        public Fuente()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int Idfuente { get; set; }
        public string Nombrefuente { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
