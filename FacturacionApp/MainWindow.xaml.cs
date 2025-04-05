using FacturacionApp.Controllers;
using FacturacionApp.Model;
using FacturacionApp.View;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FacturacionApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    ObservableCollection<LineaFactura> lineas = new ObservableCollection<LineaFactura>();
    FacturaController facturaController = new FacturaController();
    
    public MainWindow()
    {
        InitializeComponent();
       
        CurrentScreen.Content = new GenerarControl(lineas);

    }

    private void generar(object sender, RoutedEventArgs e)
    {

        if (validaciones())
        {
            generaPdf();
        }
        else
        {
            MessageBox.Show("No hay lineas de facturacion");
        }
    }
    private bool validaciones()
    {
        if (lineas.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
            
        }
    }
    private bool generaPdf()
    {
        String num;
        string fecha = DateTime.Now.ToString("ddMMyyyy");
        if (!File.Exists("numFact.txt"))
        {
            File.AppendAllText("numFact.txt", "1"+fecha);
            num =("1" + fecha);
        }
        else
        {
            num = Encoding.UTF8.GetString(File.ReadAllBytes("numFact.txt"));
            if (!num.Substring(1).Equals(fecha))
            {
                File.AppendAllText("numFact.txt", "1" + fecha);
                num = Encoding.UTF8.GetString(File.ReadAllBytes("numFact.txt"));
            }
            else
            {
                int numFact = int.Parse(num[0]+"");
                File.WriteAllText("numFact.txt", string.Empty);
                File.WriteAllText("numFact.txt", (numFact+1) + fecha);
                num = Encoding.UTF8.GetString(File.ReadAllBytes("numFact.txt"));
            }
        }
        
        Factura factura = new Factura(num,nombreFacturanteTxt.Text,cifFacturanteTxt.Text,domicilioFacturanteTxt.Text,nombreFacturadoTxt.Text,cifFacturadoTxt.Text,domicilioFacturadoTxt.Text,retencionTxt.Text,lineas); 
        MessageBox.Show(num);
        return facturaController.generarPdf(factura);
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
}