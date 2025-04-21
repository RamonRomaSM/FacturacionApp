using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionApp.Model
{
    public class LineaFactura
    {
        public string cliente { get; set; }
        public string concepto { get; set; }
        public double importeBruto { get; set; }
        public double importeNeto { get; set; }
        public double iva { get; set; }

        public int idLinea { get; set; }

        public LineaFactura(int idLinea, string concepto, double importeBruto, double iva, string cliente)
        {
            this.concepto = concepto;
            this.importeBruto = importeBruto;
            this.importeNeto = importeBruto + (importeBruto * (iva / 100));
            this.iva = iva;
            this.cliente = cliente;
            this.idLinea = idLinea;
        }

        public override bool Equals(object obj)
        {
            var item = obj as LineaFactura;

            if (item == null)
            {
                return false;
            }

            return this.idLinea == item.idLinea;
        }

    }
}
