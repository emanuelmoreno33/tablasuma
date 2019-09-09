using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace detectar_texto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btndetectar_Click(object sender, EventArgs e)
        {
            limpiar();
            string texto = txttexto.Text;
            var palabras = texto.Split((string[])null,StringSplitOptions.RemoveEmptyEntries);
            int totalpalabras = palabras.Count();
            
                if (totalpalabras == 7)
                {
                foreach (var palabra in palabras)
                {
                    verificar(palabra);
                }
                }
                else if (totalpalabras < 7)
                {
                    MessageBox.Show("Faltan palabras");
                }
                else
                {
                    MessageBox.Show("Hay mas palabras de las debidas");
                }
            
        }

        int? numero1 = null;
        int? numero2 = null;
        int? total = null;
        int contador = 0;
        string operacion = "";
        string comprobacion = "";

        string[] numeros = new string[] { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
        string[] operaciones = new string[] { "sumara", "restara", "multiplicarcon", "dividirentre" };

        private void verificar(string palabra)
        {
            contador++;

            if (contador == 1 || contador == 4)
            {
                bool numeroencontrado = false;
                int numero = 0;
                foreach (string item in numeros)
                {
                    if (item == palabra)
                    {
                        if (numero1 == null)
                        {
                            numero1 = numero;
                            numeroencontrado = true;
                            break;
                        }
                        else if (numero2 == null)
                        {
                            numero2 = numero;
                            numeroencontrado = true;
                            break;
                        }
                        else
                        {
                            MessageBox.Show("error asignacion de numero");
                            break;
                        }
                    }
                    numero++;
                }
                if (numeroencontrado == false)
                {
                    MessageBox.Show("Numero no valido:" + palabra);

                }
                bool operacionvalida = false;
                if (contador == 4)
                {
                    if (numero1 != null && numero2 != null)
                    {
                        foreach (string item in operaciones)
                        {
                            if (operacion == item)
                            {
                                switch (operacion)
                                {
                                    case "sumara":
                                        total = numero1 + numero2;
                                        operacionvalida = true;
                                        break;
                                    case "restara":
                                        total = numero2 - numero1;
                                        operacionvalida = true;
                                        break;
                                    case "multiplicarcon":
                                        total = numero1 * numero2;
                                        operacionvalida = true;
                                        break;
                                    case "dividirentre":
                                        total = numero1 / numero2;
                                        operacionvalida = true;
                                        break;
                                }
                            }
                        }

                    }
                    if (operacionvalida == false)
                    {
                        MessageBox.Show("Operacion no valida " + operacion);
                    }
                }
                
            }

            else if (contador > 1 && contador < 8)
            {
                if (contador == 2 || contador == 3)
                {
                    operacion = operacion + palabra;
                }
                
                if (contador > 4 && contador < 8)
                {
                    comprobacion = comprobacion + palabra;
                    if (contador == 7)
                    {
                        if (comprobacion == "esiguala")
                        {
                            label1.Text = total.ToString();
                        }
                        else
                        {
                            MessageBox.Show("No hay fin de resultado");
                        }
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Hay palabras no validas: " + palabra);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            txttexto.Clear();
            label1.Text = "";
        }

        private void limpiar()
        {
            operacion = "";
            comprobacion = "";
            numero1 = null;
            numero2 = null;
            total = null;
            contador = 0;
        }
    }
}
