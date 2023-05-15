using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaTuring
{
    class ProgramaTrans
    {

        private Dictionary<(int, char), Transicion> 
         trans= new Dictionary<(int, char), Transicion>();

        public void Add(Transicion t) {
            trans.Add((t.EstadoEntrada,t.SimboloEntrada),t);
        }

        public Transicion Buscar((int,char) tup) {
            try
            {
                return trans[tup];
            }
            catch(KeyNotFoundException x) {

                return trans[(tup.Item1, '*')];
            }
        }
        public void Limpiar() {
            trans.Clear();
           
        }

    }
}
