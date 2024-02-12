using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gui_condicional02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_nota1.Clear();
            txt_nota2.Clear();
            txt_nota3.Clear();
            txt_nota4.Clear();
            txt_promedio.Clear();
            txt_nota_completiva.Clear();
            txt_promedio_completivo.Clear();
            txt_situacion.Clear();
            txt_nota_completivo_calculada.Clear();
            txt_promedio_completivo.Clear();
            txt_total_completivo.Clear();


        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            double nota1, nota2, nota3, nota4, promedio, total, Nota_Completiva;
            string situacion;

            // Obtener las notas ingresadas por el usuario
            nota1 = double.Parse(txt_nota1.Text);
            nota2 = double.Parse(txt_nota2.Text);
            nota3 = double.Parse(txt_nota3.Text);
            nota4 = double.Parse(txt_nota4.Text);

            promedio = (nota1 + nota2 + nota3 + nota4) / 4;

            if (promedio >= 70)
            {
                situacion = "Aprobado";
                txt_promedio.Text = promedio.ToString();
                txt_situacion.Text = situacion;
                txt_promedio.ForeColor = Color.Green;
                txt_situacion.ForeColor = Color.Green;
            }
            else
            {
                situacion = " Reprobado";
                txt_promedio.Text = promedio.ToString();
                txt_situacion.Text = situacion;
                txt_promedio.ForeColor = Color.Red;
                txt_situacion.ForeColor = Color.Red;
            }

            bool aprobo = promedio >= 70;

            // Mostrar el promedio y la condición (aprobado o reprobado)
            txt_promedio.Text = promedio.ToString();
            txt_situacion.Text = aprobo ? "Aprobado" : "Reprobado";

            // Calcular la nota completiva si el promedio es menor a 70
            if (!aprobo)
            {
                // Habilitar el cuadro de texto para ingresar la nota de la prueba completiva
                txt_nota_completiva.Enabled = true;
            }
            else
            {
                // Si el promedio es mayor o igual a 70, deshabilitar los campos relacionados con la nota completiva
                txt_nota_completiva.Enabled = false;
                txt_nota_completiva.Text = "";
                txt_prueba_completiva.Text = "";
                txt_nota_completivo_calculada.Text = "";
                txt_total_completivo.Text = "";
                txt_promedio_completivo.Text = "";
            }
        }

        private void btn_calcular_completivo_Click(object sender, EventArgs e)
        {
            double notaCompletiva = Convert.ToDouble(txt_nota_completiva.Text);

            // Calcular la nota completiva 
            double notaCompletivaCalculada = notaCompletiva * 0.5;
            double promedioCompletivo = (Convert.ToDouble(txt_promedio.Text) + notaCompletivaCalculada) / 2;
            double totalCompletivo = Convert.ToDouble(txt_promedio.Text) + notaCompletivaCalculada;

            // Mostrar los resultados en los cuadros de texto correspondientes
            txt_nota_completivo_calculada.Text = notaCompletivaCalculada.ToString();
            txt_promedio_completivo.Text = promedioCompletivo.ToString();
            txt_total_completivo.Text = totalCompletivo.ToString();
            txt_prueba_completiva.Text = notaCompletiva.ToString();

            // Determinar si el estudiante aprobó o reprobó el completivo
            if (totalCompletivo >= 70)
            {
                txt_total_completivo.Text = "Aprobado";
                txt_total_completivo.ForeColor = Color.Green;
            }
            else
            {
                txt_total_completivo.Text = "Reprobado";
                txt_total_completivo.ForeColor = Color.Red;
            }

            // Habilitar o deshabilitar el campo de la nota de completivo según corresponda
            if (totalCompletivo < 70)
            {
                txt_nota_completiva.Enabled = true;
            }
            else
            {
                txt_nota_completiva.Enabled = false;
            }
        }

     
    }
}