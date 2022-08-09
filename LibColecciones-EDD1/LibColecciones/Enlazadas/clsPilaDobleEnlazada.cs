using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>,iPila<Tipo> where Tipo : IComparable<Tipo>
    {

        
        #region Operaciones
        #region Constructores
        #region Constructor NO Parametrizado Por Defecto
        public clsPilaDobleEnlazada()
        {
            this.atrPrimero = null;
            this.atrUltimo = null;
            this.atrLongitud = 0;
        }
        #endregion
        #endregion
        #region CRUD
        public bool apilar(Tipo prmItem)
        {
            return insertarPrimero(prmItem);
        }

        public bool desapilar(ref Tipo prmItem)
        {
            return extraerPrimero(ref prmItem);
        }

        
        public bool revisar(ref Tipo prmItem)
        {
            return recuperarPrimero(ref prmItem);
        }
        #endregion
        
        
        
        #endregion
    }
}
