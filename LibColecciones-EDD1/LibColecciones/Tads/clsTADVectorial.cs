using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Tads
{
    public class clsTADVectorial<Tipo> : clsTAD<Tipo>, iTADVectorial<Tipo> where Tipo :IComparable<Tipo>
    {
        #region Atributos
        protected int atrCapacidad;
        protected int atrFactorCrecimiento=1000;
        protected bool atrFlexible=true;
        protected Tipo[] atrItems;
        protected int atrEstadoCapacidad;
        #endregion



        public virtual bool ajustarFlexibilidad(bool prmValor)
        {
            throw new NotImplementedException();
        }

        public virtual int darCapacidad()
        {
            throw new NotImplementedException();
        }

        public virtual int darFactorCrecimiento()
        {
            throw new NotImplementedException();
        }

        public virtual bool esFlexible()
        {
            throw new NotImplementedException();
        }

        public virtual bool ponerCapacidad(int prmValor)
        {
            throw new NotImplementedException();
        }

        public virtual bool ponerFactorCrecimiento(int prmValor)
        {
            throw new NotImplementedException();
        }
    }
}
