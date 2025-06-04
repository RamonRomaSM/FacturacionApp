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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        InitializePlaceHolders();
        CurrentScreen.Content = new GenerarControl(lineas);

    }
    private void InitializePlaceHolders()
    {
        Dictionary<string, string>  Propiedades = new Dictionary<string, string>();

        if (!File.Exists("facturante.properties"))
        {
            // Crear archivo por defecto si no existe
            File.WriteAllLines("facturante.properties", new[]
            {
                "Nombre=",
                "Direccion=",
                "CIF="
            });
        }

        // Leer el archivo línea por línea
        foreach (var linea in File.ReadAllLines("facturante.properties"))
        {
            if (string.IsNullOrWhiteSpace(linea) || linea.TrimStart().StartsWith("#"))
                continue;

            var partes = linea.Split('=', 2);
            if (partes.Length == 2)
            {
                var clave = partes[0].Trim();
                var valor = partes[1].Trim();
                Propiedades[clave] = valor;
            }
        }
        nombreFacturanteTxt.Text = Propiedades.GetValueOrDefault("Nombre","");
        domicilioFacturanteTxt.Text = Propiedades.GetValueOrDefault("Direccion", "");
        cifFacturanteTxt.Text = Propiedades.GetValueOrDefault("CIF", "");

    }
    private void generar(object sender, RoutedEventArgs e)
    {
        if (validaciones())
        {
            generaPdf();
        }
    }
    private bool validaciones()
    {
        if (lineas.Count > 0)
        {
            if (nombreFacturanteTxt.Text != "" && cifFacturanteTxt.Text != "" && domicilioFacturanteTxt.Text != ""
            && nombreFacturadoTxt.Text != "" && cifFacturadoTxt.Text != "" && domicilioFacturadoTxt.Text != "")
            {             
                return true;
            }
            else
            {
                MessageBox.Show("Faltan datos de facturante y/o facturado");
                return false; 
            }
        }
        else
        {
            MessageBox.Show("No hay lineas de factiración");
            return false;
        }
    }
    private bool generaPdf()
    {
        string num=compruebaFicheroNumFactura();
        double retencion = (retencionTxt.Text=="") ? 0 : Double.Parse(retencionTxt.Text);
        Factura factura = new Factura(num,nombreFacturanteTxt.Text,cifFacturanteTxt.Text,domicilioFacturanteTxt.Text,nombreFacturadoTxt.Text,cifFacturadoTxt.Text,domicilioFacturadoTxt.Text,retencion,lineas); 
        bool b = facturaController.generarPdf(factura,num+".pdf");
        if (b)
        {    
            lineas = new ObservableCollection<LineaFactura>();
            CurrentScreen.Content = new GenerarControl(lineas);
            //Guardamos placeholders facturante para el futuro

            File.WriteAllLines("facturante.properties", new[]
            {
            "Nombre="+nombreFacturanteTxt.Text,
            "Direccion="+domicilioFacturanteTxt.Text,
            "CIF="+cifFacturanteTxt.Text
            });
            
        }
        return b;
    }
    private string compruebaFicheroNumFactura()
    {
        string num;
        string fecha = DateTime.Now.ToString("yyyyMMdd");
        if (!File.Exists("numFact.txt"))
        {
            File.AppendAllText("numFact.txt", "1-" + fecha);
            num = ("1-" + fecha);
        }
        else
        {
            num = Encoding.UTF8.GetString(File.ReadAllBytes("numFact.txt"));
            if (!num.Substring(2).Equals(fecha))
            {
               
                File.WriteAllText("numFact.txt", string.Empty);
                File.AppendAllText("numFact.txt", "1-" + fecha);
                num = Encoding.UTF8.GetString(File.ReadAllBytes("numFact.txt"));
            }
            else
            {
               
                int numFact = int.Parse(num[0] + "");
                File.WriteAllText("numFact.txt", string.Empty);
                File.WriteAllText("numFact.txt", (numFact+1) + "-" + fecha);
                num = Encoding.UTF8.GetString(File.ReadAllBytes("numFact.txt"));
            }
        }
        return num;
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