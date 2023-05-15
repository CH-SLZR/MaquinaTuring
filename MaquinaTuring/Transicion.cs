using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaTuring
{
    class Transicion
    {
        
        public int EstadoEntrada { get; set; }
        public char SimboloEntrada { get; set; }
        public char SimboloSalida { get; set; }
        public char Movimiento { get; set; }
        public int EstadoSalida { get; set; }
        public bool Final { get; set; }


    }
}
