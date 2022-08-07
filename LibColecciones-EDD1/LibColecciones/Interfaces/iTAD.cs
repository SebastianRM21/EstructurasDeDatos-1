using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTAD<Tipo> where Tipo : IComparable<Tipo>
    {


        #region Accesores
        int darLongitud();
        Tipo[] darItems();

        #endregion
        #region Mutadores
        bool ponerItems(Tipo[] prmVector);

        #endregion
        #region Sorting
        bool reversar();

        #endregion
        #region Query
        int encontrar(Tipo prmItem);
        bool contiene(Tipo prmItem);

        #endregion
        #region CRUD
        bool limpiar();
        #endregion

    }
}
