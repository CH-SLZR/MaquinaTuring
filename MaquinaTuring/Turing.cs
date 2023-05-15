using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaTuring
{
    class Turing
    {
        private Cinta cnt;
        private ProgramaTrans prog;
        private int Estado;

        public Turing()
        {
            cnt = new Cinta();
            prog = new ProgramaTrans();
            Estado = 0;
        }
        public Transicion Instruccion
        {
            set
            {

                prog.Add(value);

            }
        }

        public String Datos { get { return cnt.GetCinta(); } set { cnt.SetCinta(value); Estado = 0; } }

        public void Ejecutar()
        {
            Transicion b;
            b = prog.Buscar((Estado, cnt.GetCharPos()));
            while (!b.Final)
            {
                cnt.Ejecutar(b);
                Estado = b.EstadoSalida;
                b = prog.Buscar((Estado, cnt.GetCharPos()));
            }



        }
        public void LimpiarProgram()
        {
            prog.Limpiar();

        }
    }
}
