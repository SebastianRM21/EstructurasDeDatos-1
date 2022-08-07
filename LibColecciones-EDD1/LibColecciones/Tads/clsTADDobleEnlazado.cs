using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Tads
{
    public class clsTADDobleEnlazado<Tipo> : clsTAD<Tipo>, iTADDobleEnlazado<Tipo> where Tipo : IComparable<Tipo>
    {

        protected clsNodoDobleEnlazado<Tipo> atrPrimero;
        protected clsNodoDobleEnlazado<Tipo> atrUltimo;

        public clsNodoDobleEnlazado<Tipo> darPrimero()
        {
            return this.atrPrimero;
        }

        public clsNodoDobleEnlazado<Tipo> darUltimo()
        {
            return this.atrUltimo;
        }
    }
}
