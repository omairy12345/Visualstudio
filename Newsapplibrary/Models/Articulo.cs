using System;
using System.Collections.Generic;

#nullable disable

namespace Newsapplibrary.Models
{
    public partial class Articulo
    {
        public int Idarticulo { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public string ImagenUrl { get; set; }
        public string Descripcion { get; set; }
        public string Autor { get; set; }
        public DateTime? Fechapublicacion { get; set; }
        public int? Idcategory { get; set; }
        public int? Idpais { get; set; }
        public int? Idfuente { get; set; }

        public virtual Category IdcategoryNavigation { get; set; }
        public virtual Fuente IdfuenteNavigation { get; set; }
        public virtual Paise IdpaisNavigation { get; set; }
    }
}
