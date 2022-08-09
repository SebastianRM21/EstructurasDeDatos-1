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
