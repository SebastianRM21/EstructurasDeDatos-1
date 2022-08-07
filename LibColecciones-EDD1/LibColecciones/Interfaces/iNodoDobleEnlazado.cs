using Servicios.Colecciones.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface iNodoDobleEnlazado<Tipo> :iNodo<Tipo> where Tipo:IComparable<Tipo>
    {

        #region Accesores
        clsNodoDobleEnlazado<Tipo> darAnterior();
        clsNodoDobleEnlazado<Tipo> darSiguiente();
        #endregion
        #region Mutadores
        bool ponerAnterior(clsNodoDobleEnlazado<Tipo> prmAnterior);
        bool ponerSiguiente(clsNodoDobleEnlazado<Tipo> prmSiguiente);

        #endregion

    }
}
