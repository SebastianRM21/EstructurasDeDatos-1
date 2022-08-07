using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTADVectorial<Tipo> where Tipo: IComparable<Tipo>
    {

        #region Accesores
        int darFactorCrecimiento();
        int darCapacidad();

        #endregion
        #region Mutadores
        bool ponerCapacidad(int prmValor);
        bool ponerFactorCrecimiento(int prmValor);
        bool ajustarFlexibilidad(bool prmValor);

        #endregion
        #region Query
        bool esFlexible();
        #endregion

    }
}
