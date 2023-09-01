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

namespace Practica_Racursividad_C__forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            // Limpiar la lista antes de comenzar una nueva búsqueda
            listBoxArchivos.Items.Clear();

            string escritorioPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ListarArchivosRecursivamente(escritorioPath);
        }
        private void ListarArchivosRecursivamente(string directorio)
        {
            try
            {
                // Obtener la lista de archivos en el directorio actual
                string[] archivos = Directory.GetFiles(directorio);

                // Agregar los archivos a la lista
                foreach (string archivo in archivos)
                {
                    listBoxArchivos.Items.Add(Path.GetFileName(archivo) + " (" + Path.GetExtension(archivo) + ")");
                }

                // Recursivamente listar archivos en subdirectorios
                string[] subdirectorios = Directory.GetDirectories(directorio);
                foreach (string subdirectorio in subdirectorios)
                {
                    ListarArchivosRecursivamente(subdirectorio);
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores si es necesario
                listBoxArchivos.Items.Add("Error al listar archivos: " + ex.Message);
            }
        }

        private void listBoxArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

    
