using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Tads
{
    public class clsTADEnlazado<Tipo> : clsTAD<Tipo>, iTADEnlazado<Tipo> where Tipo : IComparable<Tipo>
    {

        #region Atributos
        protected clsNodoEnlazado<Tipo> atrPrimero;
        protected clsNodoEnlazado<Tipo> atrUltimo;

        #endregion

        public clsNodoEnlazado<Tipo> darPrimero()
        {
            return this.atrPrimero;
        }

        public clsNodoEnlazado<Tipo> darUltimo()
        {
            return this.atrUltimo;
        }
    }
}
