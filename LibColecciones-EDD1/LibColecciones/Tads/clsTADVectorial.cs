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

        #region Operacciones
        #region Accesores
        public int darCapacidad()
        {
            return atrCapacidad;
        }

        public int darFactorCrecimiento()
        {
            return atrFactorCrecimiento;
        }
        
        public override Tipo[] darItems()
        {
            return atrItems;
        }

        #endregion
        #region Mutadores
        

        public override bool ponerItems(Tipo[] prmItems)
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

        public virtual bool ponerCapacidad(int prmValor)
        {
            throw new NotImplementedException();
        }
        public void aumentarCapacidad()
        {
            this.atrCapacidad = this.atrItems.Length + this.atrFactorCrecimiento;
            Array.Resize(ref this.atrItems, this.atrCapacidad);

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
        #endregion
        #region Query
        public  bool esFlexible()
        {
            return atrFlexible;
        }
        public override bool contiene(Tipo prmItem)
        {
            if (this.atrLongitud != 0)
            {

                for (int i = 0; i < this.atrLongitud; i++)
                {
                    if (this.atrItems[i].Equals(prmItem))
                    {
                        return true;

                    }

                }

                return false;

            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Sorting
        public override bool reversar()
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
        }
        #endregion
        #region Validadores
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
        #region CRUDS
        #region Insercion
        protected override bool insertarPrimero(Tipo prmItem)
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
                for (int indice = this.atrLongitud; indice > 0; indice--)
                {
                    this.atrItems[indice] = this.atrItems[indice - 1];

                }
                this.atrItems[0] = prmItem;
            }

            this.atrLongitud++;

            return true;
        }

        protected override bool insertarUltimo(Tipo prmItem)
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

        }

        protected override bool insertarEnMedio(int prmIndice, Tipo prmItem)
        {
            validarCapacidad(this.atrCapacidad);
            ajustarFlexibilidad(true);


            if (prmIndice >= 0 && prmIndice <= this.atrLongitud)
            {
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
                    for (int indice = this.atrLongitud; indice > prmIndice; indice--)
                    {
                        this.atrItems[indice] = this.atrItems[indice - 1];

                    }
                    this.atrItems[prmIndice] = prmItem;
                }

                this.atrLongitud++;
                return true;

            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Extraccion
        protected override bool extraerPrimero(ref Tipo prmItem)
        {
            if (this.atrLongitud != 0)
            {
                prmItem = this.atrItems[0];
                for (int i = 0; i < this.atrLongitud - 1; i++)
                {
                    this.atrItems[i] = this.atrItems[i + 1];
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

        protected override bool extraerUltimo(ref Tipo prmItem)
        {
            if ((atrLongitud - 1) >= 0 && (atrLongitud - 1) < this.atrLongitud)
            {
                prmItem = this.atrItems[(atrLongitud - 1)];
                
                this.atrLongitud--;
                return true;
            }
            else
            {
                prmItem = default(Tipo);
                return false;
            }
        }
        protected override bool extraerEnMedio(int prmIndice, ref Tipo prmItem)
        {
            validarCapacidad(this.atrCapacidad);
            ajustarFlexibilidad(true);


            if (prmIndice >= 0 && prmIndice < this.atrLongitud)
            {
                if (this.atrLongitud == 0)
                {
                    return false;
                }
                else
                {
                    prmItem = this.atrItems[prmIndice];
                    for (int i = prmIndice; i < this.atrLongitud - 1; i++)
                    {
                        this.atrItems[i] = this.atrItems[i + 1];

                    }
                    this.atrLongitud--;
                    return true;
                }
            }
            else
            {
                return false;
            }
        } 
        #endregion
        #endregion
        #region Patron Iterador
        #region Operaciones
        #region Mutadores
        public override void ponerItemActual(Tipo prmItem)
        {
            atrItems[atrIndiceActual] = prmItem; 
        }
        #endregion
        #region Posicionadores
        public override bool irPrimero()
        {
            if (!estaVacia())
            {
                atrIndiceActual = 0;
                atrItemActual = atrItems[atrIndiceActual];
                return true;
            }
            atrItemActual = default(Tipo);
            atrIndiceActual = -1;
            return false;
        }
        public override bool irUltimo()
        {
            if (!estaVacia())
            {
                atrIndiceActual = atrLongitud-1;
                atrItemActual = atrItems[atrIndiceActual];
                return true;
            }
            atrItemActual = default(Tipo);
            atrIndiceActual = -1;
            return false;
        }
        protected override bool avanzarItem()
        {
            atrIndiceActual++;
            atrItemActual = atrItems [atrIndiceActual];
            return true;
        }
        protected override bool retrocederItem()
        {
            atrIndiceActual--;
            atrItemActual = atrItems[atrIndiceActual];
            return true;
        }
        public override bool irIndice(int prmIndice)
        {

            if (esValido(prmIndice))
            {
                atrIndiceActual = prmIndice;
                atrItemActual = atrItems[atrIndiceActual];
                return true;
            }
            return false;

        }
        #endregion
        #endregion
        #endregion
        #region Metodos de Ordenamiento
        public void OrdenarBurbujaSimple(bool prmOrden)
        {
            Tipo varAuxiliar;

            if (prmOrden == false)
            {
                for (int indice = 0; indice < atrLongitud - 1; indice++)
                {
                    for (int indicej = atrLongitud - 1; indicej > indice; indicej--)
                    {
                        if (atrItems[indicej - 1].CompareTo(atrItems[indicej]) > 0)
                        {
                            varAuxiliar = atrItems[indicej - 1];
                            atrItems[indicej - 1] = atrItems[indicej];
                            atrItems[indicej] = varAuxiliar;
                        }
                    }
                }
            }
            else
            {
                for (int indice = 0; indice < atrLongitud - 1; indice++)
                {
                    for (int indicej = atrLongitud - 1; indicej > indice; indicej--)
                    {
                        if (atrItems[indicej - 1].CompareTo(atrItems[indicej]) < 0)
                        {
                            varAuxiliar = atrItems[indicej - 1];
                            atrItems[indicej - 1] = atrItems[indicej];
                            atrItems[indicej] = varAuxiliar;
                        }
                    }
                }
            }
        }
        public void OrdenarBurbujaMejorado(bool prmOrden)
        {
            bool varBandera = false;
            int varIndice = 1;
            int varTamanioVec = atrLongitud;
            Tipo varAuxiliar;
            if (prmOrden == false)
            {
                while ((varIndice <= varTamanioVec - 1) && (varBandera == false))
                {
                    varBandera = true;
                    for (int indicej = 0; indicej < varTamanioVec - 1; indicej++)
                    {
                        if (atrItems[indicej].CompareTo(atrItems[indicej + 1]) > 0)
                        {
                            varAuxiliar = atrItems[indicej];
                            atrItems[indicej] = atrItems[indicej + 1];
                            atrItems[indicej + 1] = varAuxiliar;
                            varBandera = false;
                        }
                    }
                    varIndice++;
                }
            }
            else
            {
                while ((varIndice <= varTamanioVec - 1) && (varBandera == false))
                {
                    varBandera = true;
                    for (int indicej = 0; indicej < varTamanioVec - 1; indicej++)
                    {
                        if (atrItems[indicej].CompareTo(atrItems[indicej + 1]) < 0)
                        {
                            varAuxiliar = atrItems[indicej];
                            atrItems[indicej] = atrItems[indicej + 1];
                            atrItems[indicej + 1] = varAuxiliar;
                            varBandera = false;
                        }
                    }
                    varIndice++;
                }
            }
        }
        public void OrdenarBurbujaBiDireccional(bool prmOrden)
        {
            int varDerecha = 0;
            int varIzquierda = 0;
            Tipo varAuxiliar = default(Tipo);
            varDerecha = atrLongitud - 1;
            if (prmOrden == false)
            {
                do
                {
                    for (int indice = varIzquierda; indice < varDerecha; indice++)
                    {

                        if (atrItems[indice].CompareTo(atrItems[indice + 1]) > 0)
                        {
                            varAuxiliar = atrItems[indice];
                            atrItems[indice] = atrItems[indice + 1];
                            atrItems[indice + 1] = varAuxiliar;
                        }
                    }
                    for (int indicej = varDerecha; indicej > varIzquierda; indicej--)
                    {

                        if (atrItems[indicej].CompareTo(atrItems[indicej - 1]) < 0)
                        {

                            varAuxiliar = atrItems[indicej];
                            atrItems[indicej] = atrItems[indicej - 1];
                            atrItems[indicej - 1] = varAuxiliar;
                        }
                    }
                    varIzquierda++;
                    varDerecha--;
                } while (varIzquierda < varDerecha);
            }
            else
            {
                do
                {
                    for (int indice = varIzquierda; indice < varDerecha; indice++)
                    {

                        if (atrItems[indice].CompareTo(atrItems[indice + 1]) < 0)
                        {
                            varAuxiliar = atrItems[indice];
                            atrItems[indice] = atrItems[indice + 1];
                            atrItems[indice + 1] = varAuxiliar;
                        }
                    }
                    for (int indicej = varDerecha; indicej > varIzquierda; indicej--)
                    {

                        if (atrItems[indicej].CompareTo(atrItems[indicej - 1]) > 0)
                        {

                            varAuxiliar = atrItems[indicej];
                            atrItems[indicej] = atrItems[indicej - 1];
                            atrItems[indicej - 1] = varAuxiliar;
                        }
                    }
                    varIzquierda++;
                    varDerecha--;
                } while (varIzquierda < varDerecha);
            }
        }
        public void OrdenarInsercion(bool prmOrden)
        {
            int indicej = 0;
            int varTamanioVec = atrLongitud;
            Tipo varAuxiliar = default(Tipo);

            if (prmOrden == false)
            {
                for (int indice = 1; indice <= varTamanioVec - 1; indice++)
                {
                    varAuxiliar = atrItems[indice];
                    indicej = indice - 1;
                    while ((indicej >= 0) && (varAuxiliar.CompareTo(atrItems[indicej]) < 0))
                    {
                        atrItems[indicej + 1] = atrItems[indicej];
                        indicej = indicej - 1;
                    }
                    atrItems[indicej + 1] = varAuxiliar;
                }
            }
            else
            {
                for (int indice = 1; indice <= varTamanioVec - 1; indice++)
                {
                    varAuxiliar = atrItems[indice];
                    indicej = indice - 1;
                    while ((indicej >= 0) && (varAuxiliar.CompareTo(atrItems[indicej]) > 0))
                    {
                        atrItems[indicej + 1] = atrItems[indicej];
                        indicej = indicej - 1;
                    }
                    atrItems[indicej + 1] = varAuxiliar;
                }
            }

        }
        public void OrdenarSeleccion(bool prmOrden)
        {
            Tipo varMenor = default(Tipo);
            Tipo varMayor = default(Tipo);
            int indicek = 0;
            int varTamanioVec = atrLongitud;
            if (prmOrden == false)
            {
                for (int indice = 0; indice <= varTamanioVec - 2; indice++)
                {
                    varMenor = atrItems[indice];
                    indicek = indice;
                    for (int indicej = indice + 1; indicej <= varTamanioVec - 1; indicej++)
                    {
                        if (atrItems[indicej].CompareTo(varMenor) < 0)
                        {
                            varMenor = atrItems[indicej];
                            indicek = indicej;
                        }
                    }
                    atrItems[indicek] = atrItems[indice];
                    atrItems[indice] = varMenor;
                }
            }
            else
            {
                for (int indice = 0; indice <= varTamanioVec - 2; indice++)
                {
                    varMayor = atrItems[indice];
                    indicek = indice;
                    for (int indicej = indice + 1; indicej <= varTamanioVec - 1; indicej++)
                    {
                        if (atrItems[indicej].CompareTo(varMayor) > 0)
                        {
                            varMayor = atrItems[indicej];
                            indicek = indicej;
                        }
                    }
                    atrItems[indicek] = atrItems[indice];
                    atrItems[indice] = varMayor;
                }
            }
        }
        public void OrdenarQuickSort(bool prmOrden)
        {
            if (prmOrden == false)
            {
                QuickSortAscendente(atrItems, 0, atrLongitud - 1);
            }
            else
            {
                QuickSortDescendente(atrItems, 0, atrLongitud - 1);
            }
        }
        public void QuickSortAscendente(Tipo[] prmArreglo, int prmInicio, int prmFinal)
        {
            int varIndice;
            int varIndicej;
            int varCentral;
            Tipo varPivote;
            varCentral = (prmInicio + prmFinal) / 2;
            varPivote = prmArreglo[varCentral];
            varIndice = prmInicio;
            varIndicej = prmFinal;
            do
            {
                while (prmArreglo[varIndice].CompareTo(varPivote) < 0) varIndice++;
                while (prmArreglo[varIndicej].CompareTo(varPivote) > 0) varIndicej--;
                if (varIndice <= varIndicej)
                {
                    Tipo varTemporal;
                    varTemporal = prmArreglo[varIndice];
                    prmArreglo[varIndice] = prmArreglo[varIndicej];
                    prmArreglo[varIndicej] = varTemporal;
                    varIndice++;
                    varIndicej--;
                }
            } while (varIndice <= varIndicej);

            if (prmInicio < varIndicej)
            {
                QuickSortAscendente(prmArreglo, prmInicio, varIndicej);
            }
            if (varIndice < prmFinal)
            {
                QuickSortAscendente(prmArreglo, varIndice, prmFinal);
            }
        }
        public void QuickSortDescendente(Tipo[] prmArreglo, int prmInicial, int prmFinal)
        {
            int varIndice;
            int varIndicej;
            int varCentral;
            Tipo varPivote;
            varCentral = (prmInicial + prmFinal) / 2;
            varPivote = prmArreglo[varCentral];
            varIndice = prmInicial;
            varIndicej = prmFinal;
            do
            {
                while (prmArreglo[varIndice].CompareTo(varPivote) > 0) varIndice++;
                while (prmArreglo[varIndicej].CompareTo(varPivote) < 0) varIndicej--;

                if (varIndice <= varIndicej)
                {
                    Tipo varTemporal;
                    varTemporal = prmArreglo[varIndice];
                    prmArreglo[varIndice] = prmArreglo[varIndicej];
                    prmArreglo[varIndicej] = varTemporal;
                    varIndice++;
                    varIndicej--;
                }
            } while (varIndice <= varIndicej);

            if (prmInicial < varIndicej)
            {
                QuickSortDescendente(prmArreglo, prmInicial, varIndicej);
            }
            if (varIndice < prmFinal)
            {
                QuickSortDescendente(prmArreglo, varIndice, prmFinal);
            }
        }
        #endregion
        #endregion








    }
}
