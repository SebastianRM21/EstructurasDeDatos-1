using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface iNodo<Tipo> where Tipo: IComparable<Tipo>
    {
        #region Accesores
        Tipo darItem();
        #endregion

        #region Mutadores
        bool ponerItem(Tipo prmItem);
        #endregion




    }
}
