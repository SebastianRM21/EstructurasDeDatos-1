using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsColaEnlazada<Tipo> : iCola<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;

        #endregion
        private int atrLongitud;
        #endregion


        #region Constructores
        #region Constructor NO Parametrizado Por Defecto
        public clsColaEnlazada()
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
            if (this.atrLongitud != 0)
            {
                if (this.atrLongitud == 1)
                {
                    prmItem = this.atrPrimero.darItem();
                    this.atrPrimero = null;
                    this.atrUltimo = null;
                    this.atrLongitud--;
                }
                else
                {
                    prmItem = this.atrPrimero.darItem();
                    this.atrPrimero = this.atrPrimero.darSiguiente();
                    this.atrLongitud--;
                }
                return true;
            }
            else
            {
                prmItem = default(Tipo);
                return false;
            }
        }

        public bool encolar(Tipo prmItem)
        {
            if (this.atrLongitud < int.MaxValue / 16)
            {
                clsNodoEnlazado<Tipo> varNodo = new clsNodoEnlazado<Tipo>();
                varNodo.modificarItem(prmItem);
                if (this.atrLongitud == 0)
                {
                    this.atrPrimero = varNodo;
                    this.atrUltimo = varNodo;
                }
                else
                {
                    this.atrUltimo.modificarSiguiente(varNodo);
                    this.atrUltimo = varNodo;
                }
                this.atrLongitud++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool revisar(ref Tipo prmItem)
        {
            if (this.atrLongitud != 0)
            {
                prmItem = this.atrPrimero.darItem();
                return true;
            }
            else
            {
                prmItem = default(Tipo);
                return false;
            }
        }
        #endregion
        #region Accesores

        public Tipo[] darItems()
        {
            clsNodoEnlazado<Tipo> varNodo = this.darPrimero();
            Tipo[] varItems = null;
            if (varNodo != null)
            {
                int varIndice = 0;
                varItems = new Tipo[this.atrLongitud];
                while (varNodo != null)
                {
                    varItems[varIndice] = varNodo.darItem();
                    varIndice++;
                    varNodo = varNodo.darSiguiente();
                }
                return varItems;
            }
            else
            {
                return varItems;
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
            if (prmItems.Length != 0 && prmItems.Length <= (int.MaxValue / 16))
            {
                clsNodoEnlazado<Tipo> nodo = new clsNodoEnlazado<Tipo>();
                nodo.modificarItem(prmItems[0]);
                this.atrPrimero = nodo;
                this.atrLongitud++;
                for (int indice = 1; indice < prmItems.Length; indice++)
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
        #region Sorting


        public bool reversar()
        {
            if (this.atrLongitud != 0)
            {
                Tipo[] varTempItems = new Tipo[this.atrLongitud];
                Tipo[] varItems = darItems();
                for (int indice = 0; indice < this.atrLongitud; indice++)
                {
                    varTempItems[indice] = varItems[(this.atrLongitud - 1) - indice];
                }
                this.atrLongitud = 0;
                ponerItems(varTempItems);

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
