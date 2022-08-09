using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsColaVector<Tipo> : clsTADVectorial<Tipo>, iCola<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
       
        
        #endregion

        #region Operaciones
        #region Constructores
        #region Constructor No Parametrizado Por Defecto
        public clsColaVector()
        {
            this.atrCapacidad = 0;
            this.atrLongitud = 0;
            this.atrFactorCrecimiento = 1000;
            this.atrFlexible = true;
            this.atrItems = new Tipo[this.atrCapacidad];
        }

        #endregion
        #region Constructor con capacidad
        public clsColaVector(int prmCapacidad)
        {
            if (validarCapacidad(prmCapacidad))
            {
                this.atrCapacidad = prmCapacidad;
            }
            else
            {
                this.atrCapacidad = 0;

            }
            ajustarFlexibilidad(true);
            
            this.atrItems = new Tipo[this.atrCapacidad];
        }
        #endregion
        #region Constructor con Capacidad y Tipo de Flexibilidad
        public clsColaVector(int prmCapacidad, bool prmFlexible)
        {
            if (validarCapacidad(prmCapacidad))
            {

                this.atrCapacidad = prmCapacidad;

            }
            else
            {
                this.atrCapacidad = 0;

            }
            ajustarFlexibilidad(prmFlexible);

            this.atrItems = new Tipo[this.atrCapacidad];
        }
        #endregion
        #region Constructor con Capacidad y Factor de Crecimiento
        public clsColaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            if (validarCapacidad(prmCapacidad) && validarFactorCrecimiento(prmFactorCrecimiento))
            {

                if (this.atrEstadoCapacidad == 1 && prmFactorCrecimiento != 0)
                {
                    this.atrCapacidad = 0;
                    this.atrFactorCrecimiento = 1000;
                    this.atrEstadoCapacidad = 0;
                    ajustarFlexibilidad(true);
                }
                else
                {
                    this.atrFactorCrecimiento = prmFactorCrecimiento;
                    this.atrCapacidad = prmCapacidad;
                    ajustarFlexibilidad(true);
                    ajustarFactorCrecimiento(prmFactorCrecimiento);
                }
            }
            else
            {
                this.atrCapacidad = 0;
                this.atrFactorCrecimiento = 1000;
                this.atrEstadoCapacidad = 0;
                ajustarFlexibilidad(true);
            }

            this.atrItems = new Tipo[this.atrCapacidad];
        }
        #endregion
        #endregion
        
        #region CRUDs
        public bool encolar(Tipo prmItem)
        {
            return insertarUltimo(prmItem);

        }
        public bool desencolar(ref Tipo prmItem)
        {
            return extraerPrimero(ref prmItem);
        }

        public bool revisar(ref Tipo prmItem)
        {
            return recuperarPrimero(ref prmItem);
        }
        
        


        #endregion
        #region QUERY

        public bool encontrarA(Tipo prmItem, int prmIndice)
        {
            throw new NotImplementedException();
        }

        public bool contieneA(Tipo prmItem)
        {
            throw new NotImplementedException();
        }



        #endregion
        #endregion
    }
}
