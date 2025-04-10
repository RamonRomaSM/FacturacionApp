using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Model
{
    public class Factura
    {
        string numeroFactura { get; set; }

        string nombreFacturante { get; set; }
        string cifFacturante { get; set; }
        string domicilioFacturante { get; set; }

        string nombreFacturado { get; set; }
        string cifFacturado { get; set; }
        string domicilioFacturado { get; set; }

        double totalBruto { get; set; }
        double totalNeto { get; set; }
        double retencion { get; set; }
        double totalRetencion { get; set; }
        ObservableCollection<LineaFactura> lineas { get; set; }

        public Factura(string numeroFactura, string nombreFacturante, string cifFacturante, string domicilioFacturante, string nombreFacturado, string cifFacturado, string domicilioFacturado, double retencion, ObservableCollection<LineaFactura> lineas)
        {
            this.numeroFactura = numeroFactura;

            this.nombreFacturante = nombreFacturante;
            this.cifFacturante = cifFacturante;
            this.domicilioFacturante = domicilioFacturante;

            this.nombreFacturado = nombreFacturado;
            this.cifFacturado = cifFacturado;
            this.domicilioFacturado = domicilioFacturado;
            
            this.retencion = retencion;
            this.lineas = lineas;
        
            foreach(LineaFactura act in lineas)
            {
                this.totalBruto += act.importeBruto;
                this.totalNeto = act.importeNeto;
            }
            this.totalRetencion=(retencion/100)*totalBruto;
        }
    }
}
