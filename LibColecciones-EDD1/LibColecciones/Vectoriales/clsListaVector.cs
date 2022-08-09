using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsListaVector<Tipo> : clsTADVectorial<Tipo>, ILista<Tipo> where Tipo : IComparable<Tipo>
    {
        

        #region Operaciones
        #region Constructores
        #region Constructor No Parametrizado Por Defecto
        public clsListaVector()
        {
            this.atrCapacidad = 0;
            this.atrLongitud = 0;
            this.atrFactorCrecimiento = 1000;
            this.atrFlexible = true;
            this.atrItems = new Tipo[this.atrCapacidad];
        }
        #endregion
        #region Constructor con Capacidad
        public clsListaVector(int prmCapacidad)
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
        public clsListaVector(int prmCapacidad, bool prmFlexible)
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
        public clsListaVector(int prmCapacidad, int prmFactorCrecimiento)
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
        
        #region CRUD
        public bool agregar(Tipo prmItem)
        {
            return insertarUltimo(prmItem);
        }

        public bool insertar(int prmIndice, Tipo prmItem)
        {
            return insertarEn(prmIndice,prmItem);
        }

        public bool remover(int prmIndice, ref Tipo prmItem)
        {
            return extraerEn(prmIndice, ref prmItem);
        }

        public bool modificar(int prmIndice, Tipo prmItem)
        {
            return modificarEn(prmIndice,prmItem);
        }

        public bool recuperar(int prmIndice, ref Tipo prmItem)
        {
            return recuperarEn(prmIndice, ref prmItem);
        }

        #endregion
        
      
        #endregion
    }
}
