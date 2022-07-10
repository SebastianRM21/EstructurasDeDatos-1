using Servicios.Colecciones.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        protected Tipo atrItem;
        #endregion


    }
}
