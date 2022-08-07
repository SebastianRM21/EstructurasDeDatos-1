using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface ILista<Tipo> where Tipo : IComparable<Tipo>
    {
        #region Operaciones
        #region CRUD
        bool agregar(Tipo prmItem);

        bool insertar(int prmIndice, Tipo prmItem);

        bool remover(int prmIndice, ref Tipo prmItem);

        bool modificar(int prmIndice, Tipo prmItem);

        bool recuperar(int prmIndice, ref Tipo prmItem);
        #endregion
        #region QUERY
       
        #endregion
        #region Accesor
      

        #endregion
        #region sorting

        #endregion
        #region Mutadores

        #endregion
        #endregion
    }
}
