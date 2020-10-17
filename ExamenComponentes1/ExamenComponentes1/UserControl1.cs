using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenComponentes1
{
    public partial class UserControl1: UserControl
    {
        int contIntenton = 8;
        string colores = "ARBNVM";
        char []codigoRandom=new char[4];
        public UserControl1()
        {
            InitializeComponent();
            panel3.Visible = false;
            textBox6.Visible = false;
            label26.Visible = false;
            label27.Visible = false;

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            panel3.Visible = true;
            generarCodigo();
        }
        public void generarCodigo()
        {
            var random = new Random();
            for (var i = 0; i < codigoRandom.Length; i++)
            {
                codigoRandom[i] = colores[random.Next(0, colores.Length)];
            }
            //textBox5.Text = codigoRandom[0] + " " + codigoRandom[1]
                //+" "+ codigoRandom[2]+" "+ codigoRandom[3];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.TextLength> 4)
            {
                textBox5.Text = "Digite solo 4 letras";
            }
            else
            {
                textBox4.CharacterCasing = CharacterCasing.Upper;
                char[] cIngresado = textBox4.Text.ToCharArray();
                int coincidencias = 0;
                int totales = 0;
                if (contIntenton == 0)
                {
                    textBox5.Text = "Lo siento tus intentos se acabaron :(";
                    volverJugar("Perdiste");
                }
                else
                {
                    //pego el codigo
                    if (cIngresado.SequenceEqual(codigoRandom))
                    {
                        textBox5.Text = "Ganaste";
                        volverJugar("Ganaste");
                    }
                    //tal vez posicion o nada :(
                    else
                    {
                        coincidencias = cIngresado.Intersect(codigoRandom).Count();
                        textBox5.Text = "Todavia no :(";
                        contIntenton--;
                        label23.Text = coincidencias.ToString();
                        label24.Text = contIntenton.ToString();
                        for (int i = 0; i < 4; i++)
                        {
                            if (cIngresado[i] == codigoRandom[i])
                            {
                                totales++;
                            }
                        }
                        label25.Text = totales.ToString();
                    }
                } 
            }


         }
        private void volverJugar(String mensaje)
        {
            panel3.Visible = false;
            button2.Visible = true;
            textBox6.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            contIntenton = 8;
            label23.Text = " "; 
            label25.Text = " ";
            label24.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = codigoRandom[0] + " " + codigoRandom[1]
                + " " + codigoRandom[2] + " " + codigoRandom[3];
            label26.Text = mensaje;

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
