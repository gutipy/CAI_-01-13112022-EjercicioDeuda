using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioDeuda.Entidades
{
    public class Operador
    {
        //Atributos
        private List<Pago> _pagos;

        //Constructores
        public Operador(List<Prestamo> lst)
        {
            _prestamos = lst;
        }

        //Propiedades
        public List<Prestamo> Prestamos { get => _prestamos; }
        public double ComisionTotal
        {
            get
            {
                double comisionTotal = 0;

                foreach (Prestamo p in _prestamos)
                {
                    comisionTotal = comisionTotal + (p.CuotaInteres * PorcentajeComision);
                }

                return comisionTotal;
            }
        }

        public double PorcentajeComision { get => 0.15; }

        public double MontoTotal
        {
            get
            {
                //Declaración de variables
                double montoTotal = 0;

                foreach (Prestamo p in _prestamos)
                {
                    montoTotal = montoTotal + (p.Monto);
                }

                return montoTotal;
            }
        }

        //Funciones-Métodos
    }
}
