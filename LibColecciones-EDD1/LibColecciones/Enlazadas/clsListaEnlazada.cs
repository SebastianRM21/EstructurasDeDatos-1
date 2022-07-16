using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsListaEnlazada<Tipo> : ILista<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        #region Asociativos
        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;
        #endregion
        private int atrLongitud;
        #endregion
        #region Operaciones
        #region Constructores
        #region Constructor NO Parametrizado Por Defecto
        public clsListaEnlazada()
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

        public bool insertar(int prmIndice, Tipo prmItem)
        {
            if (prmIndice>=0 && prmIndice<=this.atrLongitud)
            {
                clsNodoEnlazado<Tipo> varNodo = new clsNodoEnlazado<Tipo>();
                varNodo.modificarItem(prmItem);
                if (prmIndice==0)
                {
                    if (this.atrLongitud==0)
                    {
                        this.atrPrimero = varNodo;
                        this.atrUltimo = varNodo;
                    }
                    else
                    {
                        varNodo.modificarSiguiente(this.atrPrimero);
                        this.atrPrimero = varNodo;
                    }
                }else if (prmIndice==this.atrLongitud)
                {
                    this.atrUltimo.modificarSiguiente(varNodo);
                    this.atrUltimo = varNodo;
                }
                else
                {
                    clsNodoEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                    int varIndice = 0;
                    while (varNodoTemp!=null)
                    {

                        if (varIndice==prmIndice-1)
                        {
                            varNodo.modificarSiguiente(varNodoTemp.darSiguiente());
                            varNodoTemp.modificarSiguiente(varNodo);
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

        public bool extraer(int prmIndice, ref Tipo prmItem)
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
                    }
                    else if (prmIndice == this.atrLongitud - 1)
                    {
                        prmItem = this.atrUltimo.darItem();

                        clsNodoEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                        int varIndice = 0;
                        while (varNodoTemp != null)
                        {
                            if (varIndice == prmIndice - 1)
                            {
                                varNodoTemp.modificarSiguiente(null);
                                this.atrUltimo = varNodoTemp;
                            }
                            varIndice++;
                            varNodoTemp = varNodoTemp.darSiguiente();
                        }
                    }
                    else
                    {
                        clsNodoEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                        int varIndice = 0;
                        while (varNodoTemp != null)
                        {

                            if (varIndice == prmIndice - 1)
                            {
                                prmItem = varNodoTemp.darSiguiente().darItem();
                                varNodoTemp.modificarSiguiente(varNodoTemp.darSiguiente().darSiguiente());
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
                clsNodoEnlazado<Tipo> varNodoTemp = this.atrPrimero;
                int varIndice = 0;
                while (varNodoTemp != null)
                {
                    if (prmIndice==varIndice)
                    {
                        varNodoTemp.modificarItem(prmItem);

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
                clsNodoEnlazado<Tipo> varNodoTemp = this.atrPrimero;
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

        public int encontrar(Tipo prmItem)
        {
            int varIndice = -1;
            if (this.atrLongitud!=0)
            {
                clsNodoEnlazado<Tipo> varNodoTemp = this.atrPrimero;
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


        public bool contiene(Tipo prmItem)
        {
            bool varBandera=false;
            clsNodoEnlazado<Tipo> varNodoTemp = this.atrPrimero;
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

        public int darLongitud()
        {
            return this.atrLongitud;
        }

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
                clsNodoEnlazado<Tipo> varNodo = new clsNodoEnlazado<Tipo>();
                varNodo.modificarItem(prmItems[0]);
                this.atrPrimero = varNodo;
                this.atrLongitud++;
                for (int indice = 1; indice < prmItems.Length; indice++)
                {
                    clsNodoEnlazado<Tipo> siguiente = new clsNodoEnlazado<Tipo>();
                    siguiente.modificarItem(prmItems[indice]);
                    varNodo.modificarSiguiente(siguiente);
                    varNodo = siguiente;
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
