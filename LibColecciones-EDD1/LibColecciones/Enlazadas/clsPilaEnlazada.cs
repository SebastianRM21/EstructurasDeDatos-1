using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaEnlazada<Tipo> : iPila<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos

        #region Asociativos

        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;
        private int atrLongitud;
        private Tipo[] atrItems;


        #endregion

        #endregion
        #region Operaciones
        #region Constructores
        public clsPilaEnlazada()
        {

            this.atrLongitud = 0;


        }

        #endregion
        #region CRUD
        public bool apilar(Tipo prmItem)
        {
            throw new NotImplementedException();
        }

       

        public bool desapilar(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        

        

        public bool revisar(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Accesores

        public Tipo[] darItems()
        {
            clsNodoEnlazado<Tipo> varNodo = this.darPrimero();
            if (varNodo != null)
            {
                int varIndice = 0;
                
                while (varNodo!=null)
                {
                    varIndice++;
                    varNodo = varNodo.darSiguiente();
                }

                this.atrItems = new Tipo[varIndice];
                varIndice = 0;
                varNodo = this.darPrimero();
                while (varNodo!=null)
                {
                    this.atrItems[varIndice] = varNodo.darItem();
                    varIndice++;
                    varNodo = varNodo.darSiguiente();
                }
                return this.atrItems;
            }
            else
            {
                return this.atrItems;
            }

            
        }

        public int darLongitud()
        {
            return this.atrLongitud;
        }

        public clsNodoEnlazado<Tipo> darPrimero()
        {
            return this.atrPrimero;
        }

        public clsNodoEnlazado<Tipo> darUltimo()
        {
            return this.atrUltimo;
        }

        #endregion
        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            if (prmItems.Length!=0)
            {
                clsNodoEnlazado<Tipo> nodo = new clsNodoEnlazado<Tipo>();
                nodo.modificarItem(prmItems[0]);
                this.atrPrimero = nodo;
                this.atrLongitud++;
                for (int indice=1;indice<prmItems.Length;indice++)
                {
                    clsNodoEnlazado<Tipo> siguiente = new clsNodoEnlazado<Tipo>();
                    siguiente.modificarItem(prmItems[indice]);
                    nodo.modificarSiguiente(siguiente);
                    nodo = siguiente;
                    this.atrLongitud++;
                }
                this.atrUltimo = nodo;


                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion
        #region QUERY
        public bool contieneA(Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        public bool encontrarA(Tipo prmItem, int prmIndice)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Sorty
        public bool reversar()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
