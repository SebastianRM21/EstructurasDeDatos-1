using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsColaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>,iCola<Tipo> where Tipo : IComparable<Tipo>
    {
        
        #region Constructores
        #region Constructor NO Parametrizado Por Defecto
        public clsColaDobleEnlazada()
        {
            this.atrLongitud = 0;
            this.atrPrimero = null;
            this.atrUltimo = null;
        }
        #endregion
        #endregion
        #region CRUD
        public bool desencolar(ref Tipo prmItem)
        {
            return extraerPrimero(ref prmItem);
        }

        public bool encolar(Tipo prmItem)
        {
            return insertarUltimo(prmItem);
        }

        public bool revisar(ref Tipo prmItem)
        {
            return recuperarPrimero(ref prmItem);
        }
        #endregion
    
    }
}
