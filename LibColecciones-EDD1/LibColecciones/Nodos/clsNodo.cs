using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo> where Tipo : IComparable<Tipo>
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

        public void modificarItem(Tipo prmItem)
        {
            this.atrItem = prmItem;
        }

        #endregion
        #endregion

    }
}
