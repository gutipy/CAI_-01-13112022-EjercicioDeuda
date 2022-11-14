using EjercicioDeuda.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioDeuda.Negocio;

namespace EjercicioDeuda.Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PagoNegocio pagoNegocio = new PagoNegocio();

                bool consolaActiva = true;

                while (consolaActiva)
                {
                    DesplegarOpcionesMenu();
                    string opcionMenu = Console.ReadLine();
                    switch (opcionMenu)
                    {
                        case "1":
                            ListarP(PagoNegocio);
                            break;
                        case "2":
                            AltaP(PagoNegocio);
                            break;
                        case "3":
                            Reportes(PagoNegocio);
                            break;
                        case "X":
                            consolaActiva = false;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                Console.ReadKey();
            }
        }

        public static void DesplegarOpcionesMenu()
        {
            Console.WriteLine("1) Listar Pagos");
            Console.WriteLine("2) Alta de Pago");
            Console.WriteLine("3) Reportes");
            Console.WriteLine("X: Terminar");
        }

        public static void ListarP(PagoNegocio pagoNegocio)
        {
            //Declaración de variables
            //------------------------------------------
            List<Pago> _listadoPagos = new List<Pago>();
            string _acumulador = "";
            //------------------------------------------

            _listadoPagos = pagoNegocio.GetListaPagos("888086");

            if (_listadoPagos.Count == 0 || _listadoPagos == null)
            {
                Console.WriteLine("Lo siento, pero el listado de pagos se encuentra vacío. Presione Enter para elegir otra opción");

                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                foreach (Pago p in _listadoPagos)
                {
                    _acumulador +=
                        Environment.NewLine +
                        p.ToString() +
                        Environment.NewLine
                        ;
                }

                Console.WriteLine("El listado de todos los pagos con número de registro 888.086 es: " + Environment.NewLine + _acumulador + Environment.NewLine);

                Console.WriteLine("Presione Enter para elegir otra opción");

                Console.ReadKey();
                Console.Clear();
            }
            
            
        }

        public static void AltaP(Pago pagoNegocio)
        {
            //Declaración de variables
            //---------------------------------------------------------
            bool _flag;
            string _tipoPrestamo = "";
            string _plazoEnDias;
            int _plazoEnDiasValidado = 0;
            string _capitalInicial;
            double _capitalInicialValidado = 0;
            string _registro = "888086";
            string _acuerdo;
            //---------------------------------------------------------        

            ValidacionesInputHelper.FuncionValidacionTipoPrestamo(ref _tipoPrestamo);

            TipoPrestamo _tipoSeleccionado = TipoPrestamoFactory.Get(int.Parse(_tipoPrestamo));

            do
            {
                Console.WriteLine("Ingrese el plazo (en días) del préstamo a agregar");
                _plazoEnDias = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionNumeroNatural(_plazoEnDias, ref _plazoEnDiasValidado, "Plazo");

            } while (_flag == false);

            do
            {
                Console.WriteLine("Ingrese el capital inicial del préstamo a agregar");
                _capitalInicial = Console.ReadLine();
                _flag = ValidacionesInputHelper.FuncionValidacionNumeroEnteroYNatural(_capitalInicial, ref _capitalInicialValidado, "Capital Inicial");

            } while (_flag == false);

            Prestamo nuevoPrestamo = new Prestamo //Instancio la clase 'Prestamo' y le asigno todos los inputs validados que ingresó el usuario
                (
                _tipoSeleccionado,
                _plazoEnDiasValidado,
                _capitalInicialValidado,
                _registro
                )
                ;

            Console.WriteLine($"El valor de la cuota del préstamo es: {nuevoPrestamo.Cuota}");

            Console.WriteLine("Está de acuerdo con el alta? (S/N) ");
            _acuerdo = Console.ReadLine();

            if (_acuerdo == "S")
            {
                prestamoNegocio.AgregarPrestamo(nuevoPrestamo); //Invoco a la función 'AgregarPrestamo' de la capa de negocio y le indico que agregue el prestamo con los datos que puso el usuario

                Console.WriteLine("El prestamo fue agregado exitosamente al sistema, presione Enter para elegir otra opción.");

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void Reportes(PrestamoNegocio prestamoNegocio)
        {
            //Declaración de variables
            //----------------------------------
            string _opcion = "";
            List<Prestamo> _listadoPrestamos = new List<Prestamo>();
            //----------------------------------

            _listadoPrestamos = prestamoNegocio.GetListaPrestamos("888086"); //Traigo el listado de prestamos de la capa de negocio que a su vez lo trae de la capa de datos

            ValidacionesInputHelper.FuncionValidacionOpcionReportes(ref _opcion);

            if (_opcion == "1")
            {
                Operador o = new Operador(_listadoPrestamos);

                Console.WriteLine("El monto total de los préstamos es: $" + o.MontoTotal);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }

            else if (_opcion == "2")
            {
                Operador o = new Operador(_listadoPrestamos);

                Console.WriteLine("La comisión total del operador es de: $" + o.ComisionTotal);

                Console.WriteLine("Presione Enter para elegir otra opción");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
