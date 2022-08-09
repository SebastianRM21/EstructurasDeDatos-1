using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : clsTADVectorial<Tipo>,iPila<Tipo> where Tipo : IComparable<Tipo>
    {
        
        #region Operaciones
        #region Constructores
        #region Por defecto
        public clsPilaVector()
        {
            this.atrCapacidad = 0;
            this.atrItems = new Tipo[this.atrCapacidad];
            ajustarFlexibilidad(true);
            
        }
        #endregion
        #region Con capacidad
        public clsPilaVector(int prmCapacidad)
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
        #region Con capacidad y flexibilidad
        public clsPilaVector(int prmCapacidad, bool prmFlexible)
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
        #region Con capacidad y factor de crecimiento
        public clsPilaVector(int prmCapacidad,int prmFactorCrecimiento)
        {
            if (validarCapacidad(prmCapacidad) && validarFactorCrecimiento(prmFactorCrecimiento))
            {
                
               
                if (this.atrEstadoCapacidad==1 &&  prmFactorCrecimiento!=0)
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
        
        #region CRUD
        
        public bool apilar(Tipo prmItem)
        {
            return insertarPrimero(prmItem);
        }
        
        public bool desapilar(ref Tipo prmItem)
        {
            return extraerPrimero(ref prmItem);
        }

        public bool revisar(ref Tipo prmItem)
        {
            return recuperarPrimero(ref prmItem);
        }




        #endregion

        
        #endregion
    }
}
