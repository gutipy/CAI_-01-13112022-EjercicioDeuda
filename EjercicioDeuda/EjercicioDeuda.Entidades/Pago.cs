using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioDeuda.Entidades
{
    public class Pago
    {
        //Atributos
        private int _id;
        private int _idServicio;
        private int _idCliente;
        private DateTime _fechaVencimiento;
        private DateTime _fechaPago;
        private double _importeAdeudado;
        private string _usuario;
        private Servicio _servicio;

        //Constructores
        public Pago(Servicio servicio, DateTime fechaVencimiento, DateTime fechaPago, double importeAdeudado, string usuario)
        {
            _servicio = servicio;
            _idServicio = servicio.Id;
            _fechaVencimiento = fechaVencimiento;
            _fechaPago = fechaPago;
            _importeAdeudado = importeAdeudado;
            _usuario = usuario;
        }

        //Propiedades
        public int Id { get => _id; set => _id = value; }
        public int IdServicio { get => _idServicio; set => _idServicio = value; }
        public int IdCliente { get => _idCliente; set => _idCliente = value; }
        public DateTime FechaVencimiento { get => _fechaVencimiento; set => _fechaVencimiento = value; }
        public DateTime FechaPago { get => _fechaPago; set => _fechaPago = value; }
        public double ImporteAdeudado { get => _importeAdeudado; set => _importeAdeudado = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public Servicio Servicio { get => _servicio; set => _servicio = value; }
        public double InteresPunitorio { get => (FechaPago - FechaVencimiento).Days * Servicio.PunitorioDiario; }
        public double ImporteTotal { get => ImporteAdeudado + InteresPunitorio; }

        //Funciones-Métodos
        public override string ToString()
        {
            //(Formato ejemplo: {id}) {Servicio} - [importeTotal] ([atraso] días))
            return $"{Id}) {Servicio.Nombre} - [{ImporteTotal}] ({(FechaPago - FechaVencimiento).Days / 365} días)";
        }
    }
}
