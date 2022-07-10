using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface iCola<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Operaciones

        #region CRUD
        bool encolar(Tipo prmItem);

        bool desencolar(ref Tipo prmItem);

        bool revisar(ref Tipo prmItem);

        #endregion
        #region Accesor
        int darLongitud();
        Tipo[] darItems();

        #endregion
        #region Mutadores
        bool ponerItems(Tipo[] prmItems);

        #endregion
        #region QUERY
        bool encontrarA(Tipo prmItem, int prmIndice);
        bool contieneA(Tipo prmItem);
        #endregion
        #region sorting
        bool reversar();
        #endregion
        #endregion    
    }
}
