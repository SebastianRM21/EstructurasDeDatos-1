using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo>,iNodoDobleEnlazado<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos 
        private clsNodoDobleEnlazado<Tipo> atrSiguiente;
        private clsNodoDobleEnlazado<Tipo> atrAnterior;
        #endregion
        #endregion


        #region Operaciones
        #region Mutadores
      
        public bool ponerAnterior(clsNodoDobleEnlazado<Tipo> prmAnterior)
        {
            this.atrAnterior = prmAnterior;
            return true;
        }

        public bool ponerSiguiente(clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            this.atrSiguiente = prmSiguiente;
            return true;
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
