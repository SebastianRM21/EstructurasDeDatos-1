using System;

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


        #region Operaciones
        #region Mutadores
        public void modificarSiguiente(clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            this.atrSiguiente = prmSiguiente;
        }
        public void modificarAnterior(clsNodoDobleEnlazado<Tipo> prmAnterior)
        {
            this.atrAnterior=prmAnterior;
        }
        #endregion
        #region Accesores

        public clsNodoDobleEnlazado<Tipo> darSiguiente()
        {
            return this.atrSiguiente;
        }
        public clsNodoDobleEnlazado<Tipo> darAnterior()
        {
            return this.atrAnterior;
        }

        #endregion
        #endregion
    }
}
