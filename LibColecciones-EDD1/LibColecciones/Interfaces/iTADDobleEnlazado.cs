using Servicios.Colecciones.Nodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTADDobleEnlazado<Tipo> where Tipo: IComparable<Tipo>
    {


        #region Accesores

        clsNodoDobleEnlazado<Tipo> darPrimero();
        clsNodoDobleEnlazado<Tipo> darUltimo();


        #endregion


    }
}
