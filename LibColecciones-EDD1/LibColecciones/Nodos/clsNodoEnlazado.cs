using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable<Tipo>
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
        public void modificarSiguiente(clsNodoEnlazado<Tipo> prmSiguiente)
        {
            this.atrSiguiente = prmSiguiente;
        }
        #endregion
        #endregion
    }
}
