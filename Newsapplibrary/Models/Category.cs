using System;
using System.Collections.Generic;

#nullable disable

namespace Newsapplibrary.Models
{
    public partial class Category
    {
        public Category()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int Idcategory { get; set; }
        public string Nombrecategory { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}
