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
        public Operador(List<Pago> lst)
        {
            _pagos = lst;
        }

        //Propiedades
        public List<Pago> Pagos { get => _pagos; }
        public int PromedioDiasAtraso
        {
            get
            {
                //Declaración de variables
                //----------------------
                int _diasAtrasoTotal = 0;
                int _promedioDiasAtraso;
                int _acumulador = 0;
                //----------------------

                foreach (Pago p in _pagos)
                {
                    _diasAtrasoTotal = _diasAtrasoTotal + (p.FechaPago - p.FechaVencimiento).Days;

                    _acumulador++;
                }

                _promedioDiasAtraso = _diasAtrasoTotal / _acumulador;

                return _promedioDiasAtraso;
            }
        }

        public double PromedioInteresPunitorio
        {
            get
            {
                //Declaración de variables
                //----------------------
                double _interesPunitorioTotal = 0;
                double _promedioInteresPunitorio;
                int _acumulador = 0;

                foreach (Pago p in _pagos)
                {
                    _interesPunitorioTotal = _interesPunitorioTotal + (p.InteresPunitorio);

                    _acumulador++;
                }

                _promedioInteresPunitorio = _interesPunitorioTotal / _acumulador;

                return _promedioInteresPunitorio;
            }
        }

        //Funciones-Métodos
    }
}
