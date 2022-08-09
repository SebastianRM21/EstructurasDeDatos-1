using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsListaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>,ILista<Tipo> where Tipo : IComparable<Tipo>
    {
        
        #region Operaciones
        #region Constructores
        #region Constructor NO Parametrizado Por Defecto
        public clsListaDobleEnlazada()
        {
            this.atrLongitud = 0;
            this.atrPrimero = null;
            this.atrUltimo = null;
        }
        #endregion
        #endregion
        #region CRUD
        public bool agregar(Tipo prmItem)
        {
            return insertarUltimo(prmItem);
        }

        public bool insertar(int prmIndice, Tipo prmItem)
        {
            return insertarEn(prmIndice, prmItem);
        }

        public bool remover(int prmIndice, ref Tipo prmItem)
        {
            
            return extraerEn(prmIndice, ref prmItem);
            
            
        }

        public bool modificar(int prmIndice, Tipo prmItem)
        {
            return modificarEn(prmIndice, prmItem);
        }
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
            return recuperarEn(prmIndice, ref prmItem);
        }
        #endregion
        
        #endregion

    }
}
