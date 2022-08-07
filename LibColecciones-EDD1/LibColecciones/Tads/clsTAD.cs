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

        #region Insecion
        public bool insertarEn(int indice, Tipo item)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Extraccion
        public bool extraerEn()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Modificacion
        public bool modificarEn(int indice,Tipo item)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Revision
        public bool revisarEn(int indice,Tipo item)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        public virtual bool contiene(Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        public virtual Tipo[] darItems()
        {
            throw new NotImplementedException();
        }

        public virtual int darLongitud()
        {
            throw new NotImplementedException();
        }

        public virtual int encontrar(Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        public virtual bool limpiar()
        {
            throw new NotImplementedException();
        }

        public virtual bool ponerItems(Tipo[] prmVector)
        {
            throw new NotImplementedException();
        }

        public virtual bool reversar()
        {
            throw new NotImplementedException();
        }
    }
}
