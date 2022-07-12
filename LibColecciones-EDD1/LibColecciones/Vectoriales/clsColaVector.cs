using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsColaVector<Tipo> : iCola<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        private int atrLongitud;
        private Tipo[] atrItems;
        private int atrCapacidad;
        private bool atrFlexible = true;
        private int atrFactorCrecimiento = 1000;
        private int atrEstadoCapacidad;
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
        #region validadores
        public bool validarCapacidad(int prmCapacidad)
        {

            if (prmCapacidad >= 0 && prmCapacidad <= (int.MaxValue / 16))
            {

                if (prmCapacidad == 0)
                {
                    this.atrEstadoCapacidad = 0;
                }
                else if (prmCapacidad == (int.MaxValue / 16))
                {
                    this.atrEstadoCapacidad = 1;
                }
                else
                {
                    this.atrEstadoCapacidad = 2;
                }

                return true;
            }
            else
            {
                this.atrEstadoCapacidad = 3;
                return false;

            }
        }
        public bool validarFactorCrecimiento(int prmFactorCrecimiento)
        {
            if (prmFactorCrecimiento >= 0 && prmFactorCrecimiento <= (int.MaxValue / 16))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Mutadores

        public bool ponerItems(Tipo[] prmItems)
        {
            bool varBandera = false;

            if (validarCapacidad(prmItems.Length))
            {
                this.atrItems = prmItems;
                this.atrCapacidad = prmItems.Length;
                this.atrLongitud = prmItems.Length;
                ajustarFlexibilidad(true);
                
                varBandera = true;
            }
            else
            {
                this.atrCapacidad = 0;
                this.atrLongitud = 0;
                this.atrItems = new Tipo[this.atrCapacidad];
                ajustarFlexibilidad(true);
                
                varBandera = false;
            }
            return varBandera;
        }

        
        public bool ajustarFactorCrecimiento(int prmFactorCrecimiento)
        {

            bool varBandera = false;
            if (this.atrFlexible)
            {
                if (prmFactorCrecimiento == 0)
                {
                    this.atrFactorCrecimiento = 1000;
                }
                else
                {
                    this.atrFactorCrecimiento = prmFactorCrecimiento;
                    varBandera = true;
                }

            }
            else
            {
                this.atrFactorCrecimiento = 0;
            }
            return varBandera;
        }
       
        public bool ajustarFlexibilidad(bool prmFlexible)
        {
            bool varBandera = false;
            if (this.atrEstadoCapacidad == 0 || this.atrEstadoCapacidad == 3)
            {
                this.atrFlexible = true;

            }
            else if (this.atrEstadoCapacidad == 1)
            {
                this.atrFlexible = false;

            }
            else if (this.atrFactorCrecimiento == 0)
            {
                this.atrFlexible = false;
            }
            else
            {
                this.atrFlexible = prmFlexible;
                varBandera = true;
            }
            ajustarFactorCrecimiento(1000);
            return varBandera;
        }
        public void aumentarCapacidad()
        {
            this.atrCapacidad = this.atrItems.Length + this.atrFactorCrecimiento;
            Array.Resize(ref this.atrItems, this.atrCapacidad);

        }
        #endregion
        #region Accesores
        public int darLongitud()
        {
            return atrLongitud;
        }
        public Tipo[] darItems()
        {
            return atrItems;
        }

        public int darCapacidad()
        {
            return atrCapacidad;
        }
        public bool esFlexible()
        {
            return atrFlexible;
        }
        public int darFactorCrecimiento()
        {
            return atrFactorCrecimiento;
        }

        #endregion
        #region CRUDs
        public bool encolar(Tipo prmItem)
        {
            validarCapacidad(this.atrCapacidad);
            ajustarFlexibilidad(true);
            

            if (this.atrCapacidad == 0 || this.atrLongitud == this.atrCapacidad)
            {
                if (this.atrFlexible)
                {
                    aumentarCapacidad();
                }
                else
                {
                    return false;
                }

            }

            if (this.atrLongitud == 0)
            {
                this.atrItems[0] = prmItem;
            }
            else
            {
                this.atrItems[atrLongitud] = prmItem;
            }

            this.atrLongitud++;
            return true;

            /*
            if (this.atrCapacidad > 0 && this.atrLongitud != this.atrCapacidad)
            {

                if (this.atrLongitud == 0)
                {
                    this.atrItems[0] = prmItem;
                }
                else
                {

                    this.atrItems[atrLongitud] = prmItem;
                }

                this.atrLongitud++;

                return true;
            }
            else if (this.atrFlexible)
            {

                aumentarCapacidad();
                return encolar(prmItem);
            }
            else
            {
                return false;

            }*/
        }
        public bool desencolar(ref Tipo prmItem)
        {
            if (this.atrLongitud != 0)
            {
                prmItem = this.atrItems[0];
                for (int indice = 0; indice < this.atrLongitud - 1; indice++)
                {
                    this.atrItems[indice] = this.atrItems[indice + 1];
                }
                this.atrLongitud--;

                return true;
            }
            else
            {
                prmItem = default(Tipo);
                return false;
            }
        }

        public bool revisar(ref Tipo prmItem)
        {
            if (this.atrLongitud != 0)
            {

                prmItem = this.atrItems[0];

                return true;
            }
            else
            {
                prmItem = default(Tipo);
                return false;
            }
        }
        public bool reversar()
        {
            if (this.atrLongitud != 0)
            {
                Tipo[] varTempItems = new Tipo[this.atrCapacidad];
                for (int indice = 0; indice < this.atrLongitud; indice++)
                {
                    varTempItems[indice] = this.atrItems[(this.atrLongitud - 1) - indice];
                }

                this.atrItems = varTempItems;
                return true;
            }
            else
            {
                return false;
            }
            /*if (this.atrLongitud != 0)
            {
                Tipo[] varTempItems = new Tipo[this.atrLongitud];
                int iterar = this.atrLongitud;
                for (int indice = 0; indice < iterar; indice++)
                {
                    desencolar(ref varTempItems[indice]);
                }

                for (int indice = varTempItems.Length-1; indice >=0 ; indice--)
                {
                    encolar(varTempItems[indice]);
                }
                return true;
            }
            else
            {
                return false;
            }*/

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
