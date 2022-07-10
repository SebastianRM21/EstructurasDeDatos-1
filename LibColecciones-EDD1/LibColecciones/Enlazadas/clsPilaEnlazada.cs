﻿using Servicios.Colecciones.Interfaces;
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

        #endregion

        #endregion
        #region Operaciones
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
            throw new NotImplementedException();
        }

        public int darLongitud()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Mutadores
        public bool ponerItems(Tipo[] prmItems)
        {
            throw new NotImplementedException();
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