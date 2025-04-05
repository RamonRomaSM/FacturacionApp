using FacturacionApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FacturacionApp.View
{
    /// <summary>
    /// Lógica de interacción para GenerarControl.xaml
    /// </summary>
    public partial class GenerarControl : UserControl
    {
        ObservableCollection<LineaFactura> lineas;
        
        public GenerarControl(ObservableCollection<LineaFactura> lineas)
        {
            this.lineas = lineas;
            InitializeComponent();
            lineasListView.ItemsSource = lineas;
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValidDecimal(e.Text, ((TextBox)sender).Text);
        }

        private bool IsValidDecimal(string newText, string currentText)
        {
            string fullText = currentText + newText;

            // Permitir solo números y un solo punto decimal en cualquier posición
            return Regex.IsMatch(fullText, @"^\d*\.?\d*$");
        }
        private void ListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scrollViewer = FindParent<ScrollViewer>(sender as DependencyObject);
            if (scrollViewer != null)
            {
                // Mueve el scroll manualmente
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 3);
                e.Handled = true; // Evita que el ListView intercepte el evento
            }
        }

        // Método genérico para encontrar el `ScrollViewer` más cercano
        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as T;
        }

        private void addLinea(object sender, RoutedEventArgs e)
        {          
            if(clienteTxt.Text != "" && descTxt.Text != "" && importeTxt.Text != "" && ivaTxt.Text != "")
            {
                lineas.Add(new LineaFactura(descTxt.Text, Double.Parse(importeTxt.Text), Double.Parse(ivaTxt.Text), clienteTxt.Text));
                clienteTxt.Text = "";
                descTxt.Text = "";
                importeTxt.Text = "";
                ivaTxt.Text = "";
            }
            else
            {
                MessageBox.Show("Debes rellenar todos los campos");
            }
        }
       
    }
}
