﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AUTOCAR.Vistas
{
    /// <summary>
    /// Lógica de interacción para Tipo_Pago.xaml
    /// </summary>
    public partial class Tipo_Pago : Window
    {
        public Tipo_Pago()
        {
            InitializeComponent();
        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
