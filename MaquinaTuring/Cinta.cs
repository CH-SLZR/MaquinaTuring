using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaTuring
{
    class Cinta
    {
        private StringBuilder cinta = new StringBuilder();
        private int pos;


        public void SetCinta(String c)
        {
            cinta.Clear();
            cinta.Append(c);
            pos = 0;
        }

        public String GetCinta()
        {
            while (cinta[0] == '_')
            {

                cinta.Remove(0, 1);
                pos--;
            }

            while (cinta[cinta.Length - 1] == '_')
            {

                cinta.Remove(cinta.Length - 1, 1);

            }
            return cinta.ToString();
        }
        public void Ejecutar(Transicion t)
        {
            if (t.SimboloSalida != '*')
            {
                cinta[pos] = t.SimboloSalida;
            }

                switch (t.Movimiento)
                {
                    case 'r':
                        Derecha();
                        break;
                    case 'l':
                        Izquierda();
                        break;
                }
            

        }
        public void Derecha()
        {
            if (pos >= cinta.Length - 1)
            {

                cinta.Append('_');
            }
            pos++;
        }
        public void Izquierda()
        {
            if (pos > 0)
            {
                pos--;

            }
            else
            {
                cinta.Insert(0, '_');

            }


        }
        public Char GetCharPos()
        {
            return cinta[pos];

        }

    }
}
