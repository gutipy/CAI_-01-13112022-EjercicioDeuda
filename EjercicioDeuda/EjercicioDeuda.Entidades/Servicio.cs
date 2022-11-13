using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioDeuda.Entidades
{
    public class Servicio
    {
        //Atributos
        private int id;
        private double punitorioDiario;
        private string nombre;

        //Constructores
        public Servicio(int _id, double _punitorioDiario, string _nombre)
        {
            id = _id;
            punitorioDiario = _punitorioDiario;
            nombre = _nombre;
        }

        //Propiedades
        public string Nombre { get => nombre; set => nombre = value; }
        public double PunitorioDiario { get => punitorioDiario; set => punitorioDiario = value; }
        public int Id { get => id; set => id = value; }

        //Funciones-Métodos
        public override string ToString()
        {
            return $"{Id} - {Nombre} - {PunitorioDiario}";
        }
    }
}
