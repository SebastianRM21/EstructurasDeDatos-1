using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoEnlazado<Tipo> : clsNodo<Tipo>,iNodoEnlazado<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos Propios
        private clsNodoEnlazado<Tipo> atrSiguiente;
        #endregion
        #region Operaciones
        #region Accesores
        public clsNodoEnlazado<Tipo> darSiguiente()
        {
            return atrSiguiente;

        }
        #endregion
        #region Mutadores
        

        public bool ponerSiguiente(clsNodoEnlazado<Tipo> prmSiguiente)
        {
            this.atrSiguiente = prmSiguiente;
            return true;
        }
        #endregion
        #endregion
    }
}
