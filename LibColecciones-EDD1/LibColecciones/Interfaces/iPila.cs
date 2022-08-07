using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iPila<Tipo> where Tipo : IComparable<Tipo>
    {

        #region Operaciones
        #region CRUD
        bool apilar(Tipo prmItem);
        bool desapilar(ref Tipo prmItem);
        bool revisar(ref Tipo prmItem);
        #endregion
        #region Accesor
        #endregion
        #region Mutadores
        #endregion
        #region QUERY
        #endregion
        #region sorting
        #endregion
        #endregion


    }
}
