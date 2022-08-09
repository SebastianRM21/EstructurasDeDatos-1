using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Tads
{
    public class clsTAD<Tipo> : iTAD<Tipo> where Tipo : IComparable<Tipo>
    {

        #region Atributos
        protected int atrLongitud;
        #endregion

        #region Operaciones
        #region Accesores
        public virtual Tipo[] darItems()
        {
            throw new NotImplementedException();
        }

        public  int darLongitud()
        {
            return this.atrLongitud;
        }
        #endregion
        #region Mutadores
        public virtual bool ponerItems(Tipo[] prmVector)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Sorting
        public virtual bool reversar()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Query
        public virtual bool contiene(Tipo prmItem)
        {
            throw new NotImplementedException();
        }



        public  int encontrar(Tipo prmItem)
        {
            if (irPrimero())
            {
                for (int indice=0;indice<atrLongitud;indice++)
                {
                    if (atrItemActual.CompareTo(prmItem)==0)
                    {
                        return indice;
                    }
                    irSiguiente();
                }
            }
            return -1;
        }
        #endregion
        #region CRUDS
        #region Insercion

        protected virtual  bool insertarPrimero(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        protected virtual bool insertarUltimo(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        protected virtual bool insertarEnMedio(int prmIndice,Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        protected virtual bool insertarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice == 0) return insertarPrimero( prmItem);
            if (prmIndice == atrLongitud) return insertarUltimo( prmItem);
            if (esValido(prmIndice)) return insertarEnMedio(prmIndice,  prmItem);
            return false;
        }
        #endregion
        #region Extraccion

        protected virtual bool extraerPrimero(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        protected virtual bool extraerUltimo(ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        protected virtual bool extraerEnMedio(int prmIndice,ref Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        protected virtual bool extraerEn(int prmIndice,ref Tipo prmItem)
        {
            if (prmIndice == 0) return extraerPrimero(ref prmItem);
            if (prmIndice == atrLongitud-1) return extraerUltimo(ref prmItem);
            if (esValido(prmIndice)) return extraerEnMedio(prmIndice,ref prmItem);
            return false;
        }
        #endregion
        #region Modificacion
        protected bool modificarPrimero(Tipo prmItem)
        {
            if (irPrimero())
            {
                ponerItemActual(prmItem);
                return true;
            }
            return false;
        }
        protected bool modificarUltimo(Tipo prmItem)
        {
            if (irUltimo())
            {
                ponerItemActual(prmItem);
                return true;
            }
            return false;
        }
        protected bool modificarEnMedio(int prmIndice, Tipo prmItem)
        {
            if (irIndice(prmIndice))
            {
                ponerItemActual(prmItem);
                return true;
            }
            return false;
        }
        public bool modificarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice == 0) return modificarPrimero(prmItem);
            if (prmIndice == atrLongitud-1) return modificarUltimo(prmItem);
            if (esValido(prmIndice)) return modificarEnMedio(prmIndice, prmItem);
            return false;

        }
        #endregion
        #region Revision


        public bool revisarEn(int indice, Tipo item)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recuperadores
        protected  bool recuperarPrimero(ref Tipo prmItem)
        {
            if (irPrimero())
            {
                prmItem = atrItemActual;
                return true;
            }
            prmItem = default(Tipo);
            return false;
        }
        protected  bool recuperarUltimo(ref Tipo prmItem)
        {
            if (irUltimo())
            {
                prmItem = atrItemActual;
                return true;
            }
            prmItem = default(Tipo);
            return false;
        }
        protected  bool recuperarEnMedio(int prmIndice ,ref Tipo prmItem)
        {
            if (irIndice(prmIndice))
            {
                prmItem = atrItemActual;
                return true;
            }
            prmItem = default(Tipo);
            return false;
        }

        protected bool recuperarEn(int prmIndice, ref Tipo prmItem)
        {
            if (prmIndice == 0) return recuperarPrimero(ref prmItem);
            if (prmIndice == atrLongitud - 1) return recuperarUltimo(ref prmItem);
            if (esValido(prmIndice)) return recuperarEnMedio(prmIndice, ref prmItem);
            return false;
        }
        #endregion
        #region Patron Iterador
        #region Atributos
        protected int atrIndiceActual;
        protected Tipo atrItemActual;
        #endregion
        #region Operaciones
        #region Accesores
        public int darIndiceActual()
        {
            return atrIndiceActual;
        }
        public Tipo darItemActual()
        {
            return atrItemActual;
        }


        #endregion
        #region Mutadores
        public virtual void ponerItemActual(Tipo prmItem)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Posicionadores
        public virtual bool irPrimero()
        {
            throw new NotImplementedException();
        }
        public virtual bool irUltimo()
        {
            throw new NotImplementedException();
        }

        public bool irAnterior()
        {
            if (hayAnterior())
            
                return retrocederItem();
            return false;
        }
        public bool irSiguiente()
        {
            if (haySiguiente())

                return avanzarItem();
            return false;
        }
        public virtual bool irIndice(int prmIndice)
        {

            if (prmIndice == 0) return irPrimero();
            if (prmIndice == atrLongitud - 1) return irUltimo();
            if (esValido(prmIndice))
            {
                irPrimero();
                while (atrIndiceActual<prmIndice)
                    irSiguiente();
                return true;
            }
            return false;
        }
        protected virtual bool avanzarItem()
        {
            throw new NotImplementedException();
        }
        protected virtual bool retrocederItem()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Consultores
        public bool hayAnterior()
        {
            return (estaVacia() == false && atrIndiceActual > 0);
        }
        public bool haySiguiente()
        {
            return (estaVacia() == false && (atrIndiceActual < atrLongitud-1));
        }
        public bool estaVacia()
        {
            if (atrLongitud==0)
            {
                return true;
            }
            return false;
        }
        public bool esValido(int prmIndice)
        {
            if (prmIndice>=0 && prmIndice<=atrLongitud - 1)
            {
                return true;
            }
            return false;
        }
        #endregion
        #endregion
        #endregion



        public virtual bool limpiar()
        {
            throw new NotImplementedException();
        }
        #endregion


        #endregion

        

       

        

        
    }
}
