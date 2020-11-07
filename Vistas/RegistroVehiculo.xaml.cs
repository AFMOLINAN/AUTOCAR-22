using AUTOCAR.Data;
using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace AUTOCAR.Vistas
{
        public partial class RegistroVehiculo : Window
    {
        
        public RegistroVehiculo()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
