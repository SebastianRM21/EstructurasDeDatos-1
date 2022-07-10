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

        bool extraer(int prmIndice, ref Tipo prmItem);

        bool modificar(int prmIndice, Tipo prmItem);

        #endregion
        #region QUERY
        int encontrar(Tipo prmItem);
        bool contiene(Tipo prmItem);
        #endregion
        #region Accesor
        int darLongitud();
        Tipo[] darItems();

        #endregion
        #region sorting
        bool reversar();
        #endregion
        #region Mutadores
        bool ponerItems(Tipo[] prmItems);

        #endregion
        #endregion
    }
}
