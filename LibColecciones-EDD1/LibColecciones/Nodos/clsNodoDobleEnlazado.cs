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
    }
}
