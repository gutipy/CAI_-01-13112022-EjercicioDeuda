using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EjercicioDeuda.Datos;
using EjercicioDeuda.Entidades;

namespace EjercicioDeuda.Negocio
{
    public class PagoNegocio
    {
        //Atributos
        private PagoMapper _pagoMapper;

        //Constructores
        public PagoNegocio()
        {
            _pagoMapper = new PagoMapper();
        }

        //Funciones-Métodos
        public List<Pago> GetListaPagos(string registro)
        {
            //Declaración de variables
            List<Pago> _totalPagos = new List<Pago>();

            _totalPagos = _pagoMapper.Get(registro);

            foreach (Pago p in _totalPagos)
            {
                p.Servicio = ServicioFactory.Get(p.IdServicio);
            }

            return _totalPagos;
        }

        public void AgregarPago(Pago nuevoPago)
        {
            //Declaración de variables
            List<Pago> _totalPagos = new List<Pago>();

            _totalPagos = _pagoMapper.Get("888086");

            if (nuevoPago == null)
            {
                throw new ObjetoInvalidoException();
            }

            else if (_totalPagos.Find(reg => reg.Id == nuevoPago.Id) != null)
            {
                throw new ObjetoExistenteException("Pago", nuevoPago.Id);
            }

            else
            {
                TransactionResult transaction = _pagoMapper.Insert(nuevoPago); //Agrego el pago al repositorio de datos

                if (!transaction.IsOk) //Si la transacción no se pudo completar le comunico el error al usuario mediante una excepción
                {
                    throw new Exception(transaction.Error);
                }
            }
        }
    }
    
}
