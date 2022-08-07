using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo>:iNodo<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Atributos
        protected Tipo atrItem;
        #endregion

        #region Operaciones
        #region Accesores
        public Tipo darItem()
        {
            return this.atrItem;
        }
        #endregion
        #region Mutadores

       

        public bool ponerItem(Tipo prmItem)
        {
            this.atrItem = prmItem;


            return true;
        }

        #endregion
        #endregion

    }
}
