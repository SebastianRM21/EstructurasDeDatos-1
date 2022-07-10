using Servicios.Colecciones.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos 
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;
        private clsNodoDobleEnlazado<Tipo> atrAnterior;

        #endregion
        #endregion
    }
}
