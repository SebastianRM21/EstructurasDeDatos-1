using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaDobleEnlazada<Tipo> : iPila<Tipo> where Tipo : IComparable<Tipo>
    {

        #region Atributos
        #region Asociativos
        private clsNodoDobleEnlazado<Tipo> atrPrimero;
        private clsNodoDobleEnlazado<Tipo> atrUltimo;
        #endregion 
        private int atrLongitud;
        #endregion
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
            if (this.atrLongitud < int.MaxValue / 16)
            {
                clsNodoDobleEnlazado<Tipo> varNodo = new clsNodoDobleEnlazado<Tipo>();
                varNodo.modificarItem(prmItem);
                if (this.atrLongitud == 0)
                {
                    this.atrPrimero = varNodo;
                    this.atrUltimo = varNodo;
                }
                else
                {
                    this.atrPrimero.modificarAnterior(varNodo);
                    varNodo.modificarSiguiente(this.atrPrimero);
                    
                    this.atrPrimero = varNodo;
                }
                this.atrLongitud++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool desapilar(ref Tipo prmItem)
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
            clsNodoDobleEnlazado<Tipo> varNodo = this.darPrimero();
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

        public clsNodoDobleEnlazado<Tipo> darPrimero()
        {
            return this.atrPrimero;
        }

        public clsNodoDobleEnlazado<Tipo> darUltimo()
        {
            return this.atrUltimo;
        }
        #endregion
        #region Mutadores

        public bool ponerItems(Tipo[] prmItems)
        {
            if (prmItems.Length != 0 && prmItems.Length <= (int.MaxValue / 16))
            {
                clsNodoDobleEnlazado<Tipo> varNodo = new clsNodoDobleEnlazado<Tipo>();
                varNodo.modificarItem(prmItems[0]);
                this.atrPrimero = varNodo;
                this.atrLongitud++;
                for (int indice = 1; indice < prmItems.Length; indice++)
                {
                    clsNodoDobleEnlazado<Tipo> varSiguiente = new clsNodoDobleEnlazado<Tipo>();
                    varSiguiente.modificarItem(prmItems[indice]);
                    varSiguiente.modificarAnterior(varNodo);
                    varNodo.modificarSiguiente(varSiguiente);
                    varNodo = varSiguiente;
                    this.atrLongitud++;
                }
                this.atrUltimo = varNodo;
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
        #endregion
    }
}
