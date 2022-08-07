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

        public bool insertar(int prmIndice, Tipo prmItem)
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

        public bool remover(int prmIndice, ref Tipo prmItem)
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

        public bool modificar(int prmIndice, Tipo prmItem)
        {
            if (prmIndice >= 0 && prmIndice < this.atrLongitud && this.atrLongitud != 0)
            {
                clsNodoDobleEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                int varIndice = 0;
                while (varNodoTemp != null)
                {
                    if (prmIndice == varIndice)
                    {
                        varNodoTemp.ponerItem(prmItem);

                    }

                    varIndice++;
                    varNodoTemp = varNodoTemp.darSiguiente();
                }


                return true;
            }
            else
            {
                return false;
            }
        }
        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
            if (prmIndice >= 0 && prmIndice < this.atrLongitud && this.atrLongitud != 0)
            {
                clsNodoDobleEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                int varIndice = 0;
                while (varNodoTemp != null)
                {
                    if (prmIndice == varIndice)
                    {
                        prmItem = varNodoTemp.darItem();
                    }

                    varIndice++;
                    varNodoTemp = varNodoTemp.darSiguiente();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region QUERY
        override
        public int encontrar(Tipo prmItem)
        {
            int varIndice = -1;
            if (this.atrLongitud != 0)
            {
                clsNodoDobleEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                int varContador = 0;
                while (varNodoTemp != null)
                {
                    if (prmItem.Equals(varNodoTemp.darItem()))
                    {
                        varIndice = varContador;
                        return varIndice;
                    }
                    varContador++;
                    varNodoTemp = varNodoTemp.darSiguiente();
                }
                return varIndice;
            }
            else
            {
                return varIndice;
            }
        }

        override
        public bool contiene(Tipo prmItem)
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
        override
        public int darLongitud()
        {
            return this.atrLongitud;
        }
        override
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
        
        #endregion
        #region Mutadores
        override
        public bool ponerItems(Tipo[] prmItems)
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
        #region Sorting
        override
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
