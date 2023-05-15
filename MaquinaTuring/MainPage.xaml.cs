using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace MaquinaTuring
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        Turing maq;
        public MainPage()
        {
            this.InitializeComponent();
            maq = new Turing();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            maq.Datos = TextEntrada.Text;
            char[] m = { 'r', 'l', '*' };
            Transicion p = new Transicion();
            string[] alg;
            alg = Algoritmo.Text.Split('\r');
            maq.LimpiarProgram();

            foreach (string l in alg)
            {
                try
                {
                   
                    if (l.Trim().Length != 5)
                    {
                        txtSalida.Text = $"La instruccion {l.Trim()} no tiene la longitud requerida";
                        return;

                    }

                    p = new Transicion();
                    p.EstadoEntrada = int.Parse(l[0].ToString());
                    p.SimboloEntrada = l[1];
                    p.SimboloSalida = l[2];
                    if (!m.Contains(l[3]))
                    {

                        txtSalida.Text = $"El movimiento es invalido en {l}";
                        return;

                    }
                    else
                    {

                        p.Movimiento = l[3];

                    }






                    if (l[4] == '!')
                    {
                        p.Final = true;
                    }
                    else
                    {
                        p.Final = false;
                        p.EstadoSalida = int.Parse(l[4].ToString());

                    }


                    //010r2¡


                    maq.Instruccion = p;

                }
                catch (FormatException x)
                {
                    txtSalida.Text = $"el estado tiene que ser numerico en {l}";
                    return;
                };
            }

            try
            {
                maq.Ejecutar();

            }
            catch (KeyNotFoundException) {
                txtSalida.Text = $"No existe una instrucccon para ({p.EstadoEntrada},{p.SimboloEntrada})";
                return;
            }
            txtSalida.Text = maq.Datos;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextEntrada.Text = "";
            txtSalida.Text = "";

        }
    }



}
