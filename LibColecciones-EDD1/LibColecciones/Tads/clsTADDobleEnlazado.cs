using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Tads
{
    public class clsTADDobleEnlazado<Tipo> : clsTAD<Tipo>, iTADDobleEnlazado<Tipo> where Tipo : IComparable<Tipo>
    {

        protected clsNodoDobleEnlazado<Tipo> atrPrimero;
        protected clsNodoDobleEnlazado<Tipo> atrUltimo;

        #region Operaciones
        #region CRUDS
        #region Insercion

        protected override bool insertarPrimero(Tipo prmItem)
        {
            if (this.atrLongitud < int.MaxValue / 16)
            {
                clsNodoDobleEnlazado<Tipo> varNodo = new clsNodoDobleEnlazado<Tipo>();
                varNodo.ponerItem(prmItem);
                if (this.atrLongitud == 0)
                {
                    this.atrPrimero = varNodo;
                    this.atrUltimo = varNodo;
                }
                else
                {
                    this.atrPrimero.ponerAnterior(varNodo);
                    varNodo.ponerSiguiente(this.atrPrimero);

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
        protected override bool insertarUltimo(Tipo prmItem)
        {
            if (this.atrLongitud < int.MaxValue / 16)
            {
                clsNodoDobleEnlazado<Tipo> varNodo = new clsNodoDobleEnlazado<Tipo>();
                varNodo.ponerItem(prmItem);
                if (this.atrLongitud == 0)
                {
                    this.atrPrimero = varNodo;
                    this.atrUltimo = varNodo;
                }
                else
                {
                    varNodo.ponerAnterior(this.atrUltimo);
                    this.atrUltimo.ponerSiguiente(varNodo);
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
        protected override bool insertarEnMedio(int prmIndice, Tipo prmItem)
        {
            if (prmIndice >= 0 && prmIndice <= this.atrLongitud)
            {
                clsNodoDobleEnlazado<Tipo> varNodo = new clsNodoDobleEnlazado<Tipo>();
                varNodo.ponerItem(prmItem);
                if (prmIndice == 0)
                {
                    if (this.atrLongitud == 0)
                    {
                        this.atrPrimero = varNodo;
                        this.atrUltimo = varNodo;
                    }
                    else
                    {

                        this.atrPrimero.ponerAnterior(varNodo);
                        varNodo.ponerSiguiente(this.atrPrimero);
                        this.atrPrimero = varNodo;
                    }
                }
                else if (prmIndice == this.atrLongitud)
                {
                    varNodo.ponerAnterior(this.atrUltimo);
                    this.atrUltimo.ponerSiguiente(varNodo);
                    this.atrUltimo = varNodo;
                }
                else
                {
                    clsNodoDobleEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                    int varIndice = 0;
                    while (varNodoTemp != null)
                    {

                        if (varIndice == prmIndice - 1)
                        {

                            varNodo.ponerSiguiente(varNodoTemp.darSiguiente());
                            varNodoTemp.darSiguiente().ponerAnterior(varNodo);

                            varNodoTemp.ponerSiguiente(varNodo);
                            varNodo.ponerAnterior(varNodoTemp);
                        }

                        varIndice++;
                        varNodoTemp = varNodoTemp.darSiguiente();
                    }

                }

                this.atrLongitud++;

                return true;
            }
            else
            {
                return false;
            }
        }

        protected override bool insertarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice == 0) return insertarPrimero(prmItem);
            if (prmIndice == atrLongitud) return insertarUltimo(prmItem);
            if (esValido(prmIndice)) return insertarEnMedio(prmIndice, prmItem);
            return false;
        }
        #endregion
        #region Extraccion

        protected override bool extraerPrimero(ref Tipo prmItem)
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

        protected override bool extraerUltimo(ref Tipo prmItem)
        {
            if ((atrLongitud-1) >= 0 && (atrLongitud - 1) < this.atrLongitud && this.atrLongitud != 0)
            {
                prmItem = this.atrUltimo.darItem();

                clsNodoDobleEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                int varIndice = 0;
                while (varNodoTemp != null)
                {
                    if (varIndice == (this.atrLongitud - 1) - 1)
                    {
                        varNodoTemp.ponerSiguiente(null);
                        this.atrUltimo = varNodoTemp;
                    }
                    varIndice++;
                    varNodoTemp = varNodoTemp.darSiguiente();
                }
                atrLongitud--;
                return true;
            }
            else
            {
                prmItem = default(Tipo);
                return false;
            }
                
        }
        protected override bool extraerEnMedio(int prmIndice, ref Tipo prmItem)
        {
            if (prmIndice >= 0 && prmIndice < this.atrLongitud && this.atrLongitud != 0)
            {
                if (this.atrLongitud == 1)
                {
                    prmItem = this.atrPrimero.darItem();
                    this.atrPrimero = null;
                    this.atrUltimo = null;
                }
                else
                {
                    if (prmIndice == 0)
                    {
                        prmItem = this.atrPrimero.darItem();

                        this.atrPrimero = this.atrPrimero.darSiguiente();
                        this.atrPrimero.ponerAnterior(null);
                    }
                    else if (prmIndice == this.atrLongitud - 1)
                    {
                        prmItem = this.atrUltimo.darItem();

                        clsNodoDobleEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                        int varIndice = 0;
                        while (varNodoTemp != null)
                        {
                            if (varIndice == prmIndice - 1)
                            {
                                varNodoTemp.ponerSiguiente(null);
                                this.atrUltimo = varNodoTemp;
                            }
                            varIndice++;
                            varNodoTemp = varNodoTemp.darSiguiente();
                        }
                    }
                    else
                    {
                        clsNodoDobleEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                        int varIndice = 0;
                        while (varNodoTemp != null)
                        {

                            if (varIndice == prmIndice - 1)
                            {
                                prmItem = varNodoTemp.darSiguiente().darItem();
                                varNodoTemp.ponerSiguiente(varNodoTemp.darSiguiente().darSiguiente());
                                varNodoTemp.darSiguiente().darSiguiente().ponerAnterior(varNodoTemp);
                            }

                            varIndice++;
                            varNodoTemp = varNodoTemp.darSiguiente();
                        }
                    }
                }
                this.atrLongitud--;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (prmIndice == 0) return extraerPrimero(ref prmItem);
            if (prmIndice == atrLongitud - 1) return extraerUltimo(ref prmItem);
            if (esValido(prmIndice)) return extraerEnMedio(prmIndice, ref prmItem);
            return false;
        }
        #endregion
        #endregion
        #region Sorting
        public override bool reversar()
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
        #region Query
        public override bool contiene(Tipo prmItem)
        {
            bool varBandera = false;
            clsNodoDobleEnlazado<Tipo> varNodoTemp = this.atrPrimero;
            while (varNodoTemp != null)
            {
                if (prmItem.Equals(varNodoTemp.darItem()))
                {
                    varBandera = true;
                }
                varNodoTemp = varNodoTemp.darSiguiente();
            }
            return varBandera;
        }
        #endregion
        #region Accesores
        public override Tipo[] darItems()
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
        public override bool ponerItems(Tipo[] prmItems)
        {
            if (prmItems.Length != 0 && prmItems.Length <= (int.MaxValue / 16))
            {
                clsNodoDobleEnlazado<Tipo> varNodo = new clsNodoDobleEnlazado<Tipo>();
                varNodo.ponerItem(prmItems[0]);
                this.atrPrimero = varNodo;
                this.atrLongitud++;
                for (int indice = 1; indice < prmItems.Length; indice++)
                {
                    clsNodoDobleEnlazado<Tipo> varSiguiente = new clsNodoDobleEnlazado<Tipo>();
                    varSiguiente.ponerItem(prmItems[indice]);
                    varSiguiente.ponerAnterior(varNodo);
                    varNodo.ponerSiguiente(varSiguiente);
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
        #region Patron Iterador
        #region Atributos
        private clsNodoDobleEnlazado<Tipo> atrNodoActual;
        #endregion
        #region Operaciones
        #region Mutadores
        public override void ponerItemActual(Tipo prmItem)
        {
            atrItemActual = prmItem;
            atrNodoActual.ponerItem(atrItemActual);
        }
        #endregion
        #region Posicionadores
        public override bool irPrimero()
        {
            if (!estaVacia())
            {
                atrNodoActual = atrPrimero;
                atrItemActual = atrNodoActual.darItem();
                atrIndiceActual = 0;
                return true;
            }
            atrNodoActual = null;
            atrItemActual = default(Tipo);
            atrIndiceActual = -1;
            return false;
        }
        public override bool irUltimo()
        {
            if (!estaVacia())
            {
                atrNodoActual = atrUltimo;
                atrItemActual = atrNodoActual.darItem();
                atrIndiceActual = atrLongitud - 1;
                return true;
            }
            atrNodoActual = null;
            atrItemActual = default(Tipo);
            atrIndiceActual = -1;
            return false;
        }
        protected override bool avanzarItem()
        {
            atrNodoActual = atrNodoActual.darSiguiente();
            atrItemActual = atrNodoActual.darItem();
            atrIndiceActual++;
            return true;
        }
        protected override bool retrocederItem()
        {
            atrNodoActual = atrNodoActual.darAnterior();
            atrItemActual = atrNodoActual.darItem();
            atrIndiceActual--;
            return true; 
        }
        #endregion
        #endregion
        #endregion
        #endregion


    }
}
