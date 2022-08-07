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
