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
        public string numeroFactura { get; set; }

        public string nombreFacturante { get; set; }
        public string cifFacturante { get; set; }
        public string domicilioFacturante { get; set; }

        public string nombreFacturado { get; set; }
        public string cifFacturado { get; set; }
        public string domicilioFacturado { get; set; }

        public double totalBruto { get; set; }
        public double totalNeto { get; set; }
        public double retencion { get; set; }
        public double totalRetencion { get; set; }
        public ObservableCollection<LineaFactura> lineas { get; set; }

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
