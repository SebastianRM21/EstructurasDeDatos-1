using Servicios.Colecciones.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsListaEnlazada<Tipo> : ILista<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private Servicios.Colecciones.Nodos.clsNodoEnlazado<Tipo> atrPrimero;
        private Servicios.Colecciones.Nodos.clsNodoEnlazado<Tipo> atrUltimo;
        #endregion

        #endregion
        #region Operaciones

        #region CRUD
        public bool agregar(Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        public bool insertar(int prmIndice, Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        public bool extraer(int prmIndice, ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        public bool modificar(int prmIndice, Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region QUERY

        public int encontrar(Tipo prmItem)
        {
            throw new NotImplementedException();
        }


        public bool contiene(Tipo prmItem)
        {
            throw new NotImplementedException();
        }


        #endregion
        #region Accesores

        public int darLongitud()
        {
            throw new NotImplementedException();
        }

        public Tipo[] darItems()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Sorting

        public bool reversar()
        {
            throw new NotImplementedException();
        }

        #endregion
        #endregion
    }
}
