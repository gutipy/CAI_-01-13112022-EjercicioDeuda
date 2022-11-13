using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioDeuda.Entidades;

namespace EjercicioDeuda.Negocio
{
    public static class ServicioFactory
    {
        private static List<Servicio> _tipos;

        static ServicioFactory()
        {
            _tipos = new List<Servicio>();
            _tipos.Add(new Servicio(1, 8.45, "Edenor"));
            _tipos.Add(new Servicio(2, 5.20, "Expensas"));
            _tipos.Add(new Servicio(3, 2.21, "Telecom"));
        }

        public static List<Servicio> Get()
        {
            return _tipos;
        }

        public static Servicio Get(int id)
        {
            return _tipos.SingleOrDefault(x => x.Id == id);
        }


    }
}
