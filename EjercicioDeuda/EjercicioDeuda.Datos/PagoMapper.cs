using EjercicioDeuda.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioDeuda.Datos
{
    public class PagoMapper
    {
        public List<Pago> Get(string registro)
        {
            string json2 = WebHelper.Get("/pago/" + registro);
            List<Pago> resultado = MapList(json2);
            return resultado;
        }

        public TransactionResult Insert(Pago pago)
        {
            NameValueCollection obj = ReverseMap(pago);

            string result = WebHelper.Post("/pago/", obj);

            TransactionResult resultadoTransaccion = MapResultado(result);

            return resultadoTransaccion;
        }

        private List<Pago> MapList(string json)
        {
            List<Pago> lst = JsonConvert.DeserializeObject<List<Pago>>(json);
            return lst;
        }

        private NameValueCollection ReverseMap(Pago pago)
        {
            NameValueCollection n = new NameValueCollection();
            n.Add("id", pago.Id.ToString());
            n.Add("idServicio", pago.IdServicio.ToString());
            n.Add("idCliente", pago.IdCliente.ToString());
            n.Add("FechaVencimiento", pago.FechaVencimiento.ToString());
            n.Add("FechaPago", pago.FechaPago.ToString());
            n.Add("ImporteAdeudado", pago.ImporteAdeudado.ToString("0.00"));
            n.Add("InteresPunitorio", pago.InteresPunitorio.ToString("0.00"));
            n.Add("Usuario", pago.Usuario);

            return n;
        }

        private TransactionResult MapResultado(string json)
        {
            TransactionResult lst = JsonConvert.DeserializeObject<TransactionResult>(json);
            return lst;
        }
    }
}
