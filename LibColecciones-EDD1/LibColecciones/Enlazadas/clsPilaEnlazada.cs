using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using System;

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
        //Revisaaaar
        public bool apilar(Tipo prmItem)
        {
            clsNodoEnlazado<Tipo> varNodo = new clsNodoEnlazado<Tipo>();
            varNodo.modificarItem(prmItem);
            if (this.atrLongitud!=0)
            {
                this.atrPrimero = varNodo;
                this.atrUltimo = varNodo;
                
            }
            else
            {
                varNodo.modificarSiguiente(this.atrPrimero);
                this.atrPrimero = varNodo;
            }
            this.atrLongitud++;

            this.atrItems = new Tipo[this.atrLongitud];
            return true;

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
        //peligro, revisar
        public Tipo[] darItems()
        {
            clsNodoEnlazado<Tipo> varNodo = this.darPrimero();
            if (varNodo != null)
            {
                int varIndice = 0;
                
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
        //peligro, revisar
        public bool ponerItems(Tipo[] prmItems)
        {
            if (prmItems.Length!=0 && prmItems.Length<=(int.MaxValue/16))
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
                this.atrItems = prmItems;
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
