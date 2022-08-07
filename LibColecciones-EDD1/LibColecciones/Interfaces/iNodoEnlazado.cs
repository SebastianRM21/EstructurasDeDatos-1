using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iNodoEnlazado<Tipo>: iNodo<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Accesores
        clsNodoEnlazado<Tipo> darSiguiente();
        #endregion

        #region Mutadores
        bool ponerSiguiente(clsNodoEnlazado<Tipo> prmSiguiente);
        #endregion
    }
}
