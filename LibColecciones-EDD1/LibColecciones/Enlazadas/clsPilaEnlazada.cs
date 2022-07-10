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
            Tipo[] varItems=null;
            int varIndice = 0;
            clsNodoEnlazado<Tipo> varNodo = this.darPrimero();
            if (varNodo!=null)
            {
                while (varNodo!=null)
                {
                    varItems[varIndice] = this.atrPrimero.darItem();
                    varIndice++;
                    varNodo = this.atrPrimero.darSiguiente();
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
            if (prmItems.Length!=0)
            {
                { 


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
