using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOL;
using DAL;
using OfficeOpenXml;

namespace veterinariaDesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALHistorial.listaAtencion();

            var filename = "exel1"+DateTime.Now.ToString("yyyy-MM-dd")+".xlsx";
            String path = @"C:\Users\acer\source\repos\veterinariaDesk\excel\";

            var file = new FileInfo(path + filename);

            using (var pack = new ExcelPackage(file))
            {

                ExcelWorksheet ews = pack.Workbook.Worksheets.Add("muestras");

                ews.Cells[1, 1].Value = "Codigo atencion";
                ews.Cells[1, 2].Value = "fecha";
                ews.Cells[1, 3].Value = "codigo mascota";
                ews.Cells[1, 4].Value = "titulo visita";
                ews.Cells[1, 5].Value = "tema visita";
                ews.Cells[1, 6].Value = "codigo veterinaria";
                ews.Cells[1, 6].Value = "nombre veterinaria";


                int x = 2;
                foreach (Historial h in DALHistorial.listaAtencion())
                { 

                        ews.Cells[x, 1].Value = h.codigo_historial;
                        ews.Cells[x, 2].Value = h.fecha_visita;
                        ews.Cells[x, 3].Value = h.codigo_mascota;
                        ews.Cells[x, 4].Value = h.titulo_visita;
                        ews.Cells[x, 5].Value = h.tema_visita;
                        ews.Cells[x, 6].Value = h.codigo_veterinaria;
                        ews.Cells[x, 6].Value = h.veterinario_visita;

                    x++;
                }
                ews.Column(1).AutoFit();
                ews.Column(2).AutoFit();
                ews.Column(3).AutoFit();
                ews.Column(4).AutoFit();
                ews.Column(5).AutoFit();
                ews.Column(6).AutoFit();
                ews.Column(7).AutoFit();

                pack.Save();
                

            }
        

        }
    }
}
