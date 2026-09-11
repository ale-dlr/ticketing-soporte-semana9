using System;
using System.Collections.Generic;

namespace TicketingConsole
{
    public abstract class Usuario
    {
        public string strId { get; set; }
        public string strNombre { get; set; }
        public string strEmail { get; set; }

        public Usuario(string id, string nombre, string email)
        {
            strId = id;
            strNombre = nombre;
            strEmail = email;
        }

        public abstract void mostrarInformacion();

        public string getNombre() { return strNombre; }
        public string getDepartamento() { return this is Solicitante s ? s.strDepartamento : ""; }
    }

    public class Tecnico : Usuario
    {
        public string strEspecialidad { get; set; }
        public int intNivel { get; set; }

        public Tecnico(string id, string nombre, string email, string especialidad, int nivel)
            : base(id, nombre, email)
        {
            strEspecialidad = especialidad;
            intNivel = nivel;
        }

        public override void mostrarInformacion()
        {
            Console.WriteLine($"[Técnico] ID: {strId} | Nombre: {strNombre} | Especialidad: {strEspecialidad} | Nivel: {intNivel}");
        }
    }

    public class Solicitante : Usuario
    {
        public string strDepartamento { get; set; }
        public string strAnexo { get; set; }

        public Solicitante(string id, string nombre, string email, string departamento, string anexo)
            : base(id, nombre, email)
        {
            strDepartamento = departamento;
            strAnexo = anexo;
        }

        public override void mostrarInformacion()
        {
            Console.WriteLine($"[Solicitante] ID: {strId} | Nombre: {strNombre} | Depto: {strDepartamento}");
        }
    }

    public class BitacoraItem
    {
        public string strTipo { get; set; }
        public string strDescripcion { get; set; }
        public string strImpacto { get; set; }
        public DateTime dtFecha { get; set; }

        public BitacoraItem(string tipo, string descripcion, string impacto)
        {
            strTipo = tipo;
            strDescripcion = descripcion;
            strImpacto = impacto;
            dtFecha = DateTime.Now;
        }
    }

    public class Ticket
    {
        public int intNumero { get; set; }
        public string strTitulo { get; set; }
        public string strDescripcion { get; set; }
        public string strPrioridad { get; set; }
        public string strEstado { get; set; }
        public int intTipoTicket { get; set; } // 1 = Incidente, 2 = Requerimiento
        public Solicitante objSolicitante { get; set; }
        public List<BitacoraItem> lstBitacora { get; set; }

        private static int contador = 1;

        public Ticket(string titulo, string descripcion, string prioridad, Solicitante solicitante, int tipoTicket)
        {
            intNumero = contador++;
            strTitulo = titulo;
            strDescripcion = descripcion;
            strPrioridad = prioridad;
            strEstado = "Abierto";
            objSolicitante = solicitante;
            intTipoTicket = tipoTicket;
            lstBitacora = new List<BitacoraItem>();
        }

        public void registrarError(string tipo, string descripcion, string impacto)
        {
            lstBitacora.Add(new BitacoraItem(tipo, descripcion, impacto));
            Console.WriteLine("Error registrado correctamente en la bitácora del ticket.");
        }

        public void resolver(string solucion)
        {
            strEstado = "Resuelto";
            lstBitacora.Add(new BitacoraItem("Solución", solucion, "N/A"));
            Console.WriteLine("Ticket resuelto correctamente.");
        }

        public void cerrar()
        {
            strEstado = "Cerrado";
        }

        public void mostrarResumen()
        {
            string tipoStr = intTipoTicket == 1 ? "Incidente" : "Requerimiento";
            Console.WriteLine($"\n--- TICKET #{intNumero} ---");
            Console.WriteLine($"Título: {strTitulo}");
            Console.WriteLine($"Tipo: {tipoStr} | Prioridad: {strPrioridad} | Estado: {strEstado}");
            Console.WriteLine($"Solicitante: {objSolicitante.strNombre} ({objSolicitante.strDepartamento})");
        }
    }

    public class GestorTickets
    {
        public List<Ticket> lstTickets { get; set; }
        public List<Tecnico> lstTecnicos { get; set; }
        public List<Solicitante> lstSolicitantes { get; set; }

        public GestorTickets()
        {
            lstTickets = new List<Ticket>();
            lstTecnicos = new List<Tecnico>();
            lstSolicitantes = new List<Solicitante>();
        }

        public Ticket crearTicket(string titulo, string descripcion, string prioridad, Solicitante solicitante, int tipoTicket)
        {
            Ticket nuevo = new Ticket(titulo, descripcion, prioridad, solicitante, tipoTicket);
            lstTickets.Add(nuevo);
            return nuevo;
        }

        public void mostrarTickets()
        {
            Console.WriteLine("\n=== LISTADO DE TICKETS ===");
            if (lstTickets.Count == 0)
            {
                Console.WriteLine("No hay tickets registrados.");
                return;
            }
            foreach (var t in lstTickets)
            {
                t.mostrarResumen();
            }
        }

        public Ticket buscarTicket(int numero)
        {
            return lstTickets.Find(t => t.intNumero == numero);
        }

        public void generarResumenControl()
        {
            Console.WriteLine("\n=== MÉTRICAS Y RESUMEN DE CONTROL ===");
            Console.WriteLine($"Total de Tickets en el Sistema: {lstTickets.Count}");
            int abiertos = lstTickets.FindAll(t => t.strEstado == "Abierto").Count;
            int resueltos = lstTickets.FindAll(t => t.strEstado == "Resuelto").Count;
            int cerrados = lstTickets.FindAll(t => t.strEstado == "Cerrado").Count;
            Console.WriteLine($"- Abiertos: {abiertos}");
            Console.WriteLine($"- Resueltos: {resueltos}");
            Console.WriteLine($"- Cerrados: {cerrados}");
        }
    }

    public class FlujoTicket
    {
        public void mostrarFlujo()
        {
            Console.WriteLine("\nFlujo de Estados: [Abierto] -> [Asignado] -> [Resuelto] -> [Cerrado]");
        }
    }

    internal class Simulador
    {
        static void Main(string[] args)
        {
            Scanner scanner = new Scanner();

            Tecnico objTecnicoSoftware = new Tecnico("T01", "Ana Lopez", "ana@empresa.com", "Software", 2);
            Tecnico objTecnicoHardware = new Tecnico("T02", "Carlos Mendez", "carlos@empresa.com", "Hardware", 2);
            Tecnico objTecnicoGeneral = new Tecnico("T03", "Maria Perez", "maria@empresa.com", "General", 3);

            Solicitante objSolicitanteContabilidad = new Solicitante("S01", "Luis Ramirez", "luis@empresa.com", "Contabilidad", "1201");
            Solicitante objSolicitanteVentas = new Solicitante("S02", "Karla Gomez", "karla@empresa.com", "Ventas", "1305");

            List<Usuario> lstUsuarios = new List<Usuario>();
            lstUsuarios.Add(objTecnicoSoftware);
            lstUsuarios.add(objTecnicoHardware);
            lstUsuarios.add(objTecnicoGeneral);
            lstUsuarios.add(objSolicitanteContabilidad);
            lstUsuarios.add(objSolicitanteVentas);

            GestorTickets objGestor = new GestorTickets();
            objGestor.lstTecnicos.Add(objTecnicoSoftware);
            objGestor.lstTecnicos.Add(objTecnicoHardware);
            objGestor.lstTecnicos.Add(objTecnicoGeneral);
            objGestor.lstSolicitantes.Add(objSolicitanteContabilidad);
            objGestor.lstSolicitantes.Add(objSolicitanteVentas);

            FlujoTicket objFlujoTicket = new FlujoTicket();
            bool blnContinuar = true;

            while (blnContinuar)
            {
                Console.WriteLine("\n=================================");
                Console.WriteLine(" SISTEMA DE TICKETS DE SOPORTE ");
                Console.WriteLine("===================================");
                Console.WriteLine(" 1. Ver usuarios del sistema");
                Console.WriteLine(" 2. Ver flujo de estados del ticket");
                Console.WriteLine(" 3. Crear ticket y asignar automaticamente");
                Console.WriteLine(" 4. Ver tickets");
                Console.WriteLine(" 5. Registrar error en ticket");
                Console.WriteLine(" 6. Resolver ticket");
                Console.WriteLine(" 7. Cerrar caso");
                Console.WriteLine(" 8. Crear metricas y resumen de control");
                Console.WriteLine(" 9. Escalar ticket");
                Console.WriteLine(" 10. Salir");
                Console.Write("\n Seleccione una opcion: ");

                try
                {
                    string strOpcion = scanner.nextLine().Trim();

                    switch (strOpcion)
                    {
                        case "1":
                            mostrarUsuariosPolimorfismo(lstUsuarios);
                            break;
                        case "2":
                            objFlujoTicket.mostrarFlujo();
                            break;
                        case "3":
                            crearTicket(objGestor, scanner);
                            break;
                        case "4":
                            objGestor.mostrarTickets();
                            break;
                        case "5":
                            registrarError(objGestor, scanner);
                            break;
                        case "6":
                            resolverTicket(objGestor, objFlujoTicket, scanner);
                            break;
                        case "7":
                            cerrarTicket(objGestor, objFlujoTicket, scanner);
                            break;
                        case "8":
                            objGestor.generarResumenControl();
                            break;
                        case "9":
                            escalarTicketRecursivo(objGestor, scanner);
                            break;
                        case "10":
                            blnContinuar = false;
                            Console.WriteLine("\nGracias por utilizar el sistema de soporte.");
                            break;
                        default:
                            Console.WriteLine("Opcion no valida. Ingrese un numero del 1 al 10.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error controlado por try/catch: " + ex.Message);
                }
            }
        }

        static void mostrarUsuariosPolimorfismo(List<Usuario> lstUsuarios)
        {
            Console.WriteLine("\n=== USUARIOS DEL SISTEMA ===");
            foreach (Usuario objUsuario in lstUsuarios)
            {
                objUsuario.mostrarInformacion();
            }
        }

        static void crearTicket(GestorTickets objGestor, Scanner scanner)
        {
            Console.WriteLine("\nSolicitantes disponibles:");
            for (int i = 0; i < objGestor.lstSolicitantes.Count; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + objGestor.lstSolicitantes[i].getNombre() + " - " + objGestor.lstSolicitantes[i].getDepartamento());
            }

            Console.Write("Seleccione solicitante: ");
            int intIndice = int.Parse(scanner.nextLine()) - 1;

            Console.Write("Titulo del problema: ");
            string strTitulo = scanner.nextLine();

            Console.Write("Descripcion: ");
            string strDescripcion = scanner.nextLine();

            Console.Write("Tipo de Ticket (1 = Incidente, 2 = Requerimiento): ");
            int tipoTicket = int.Parse(scanner.nextLine());

            Console.Write("Prioridad: ");
            string strPrioridad = scanner.nextLine();

            Ticket objTicket = objGestor.crearTicket(strTitulo, strDescripcion, strPrioridad, objGestor.lstSolicitantes[intIndice], tipoTicket);

            Console.WriteLine("\nTicket creado correctamente aplicando SLA.");
            objTicket.mostrarResumen();
        }

        static void registrarError(GestorTickets objGestor, Scanner scanner)
        {
            Ticket objTicket = solicitarTicket(objGestor, scanner);
            if (objTicket != null)
            {
                Console.Write("Tipo de error: ");
                string strTipo = scanner.nextLine();
                Console.Write("Descripcion del error: ");
                string strDescripcion = scanner.nextLine();
                Console.Write("Impacto: ");
                string strImpacto = scanner.nextLine();

                objTicket.registrarError(strTipo, strDescripcion, strImpacto);
            }
        }

        static void resolverTicket(GestorTickets objGestor, FlujoTicket objFlujoTicket, Scanner scanner)
        {
            Ticket objTicket = solicitarTicket(objGestor, scanner);
            if (objTicket != null)
            {
                Console.Write("Solucion aplicada: ");
                string strSolucion = scanner.nextLine();
                objTicket.resolver(strSolucion);
            }
        }

        static void cerrarTicket(GestorTickets objGestor, FlujoTicket objFlujoTicket, Scanner scanner)
        {
            Ticket objTicket = solicitarTicket(objGestor, scanner);
            if (objTicket != null)
            {
                objTicket.cerrar();
                Console.WriteLine("Caso cerrado correctamente.");
            }
        }

        static void escalarTicketRecursivo(GestorTickets objGestor, Scanner scanner)
        {
            Ticket objTicket = solicitarTicket(objGestor, scanner);
            if (objTicket != null)
            {
                Console.Write("Ingrese el nivel de escalamiento objetivo: ");
                int intNivelMeta = int.Parse(scanner.nextLine());
                int intNivelActual = 1;

                Console.WriteLine("\n--- Iniciando Proceso de Escalamiento Recursivo ---");
                EjecutarEscalamientoRecursivo(objTicket, intNivelActual, intNivelMeta);
                Console.WriteLine("--------------------------------------------------");
            }
        }

        static void EjecutarEscalamientoRecursivo(Ticket objTicket, int intNivelActual, int intNivelMeta)
        {
            if (intNivelActual >= intNivelMeta)
            {
                Console.WriteLine("[Éxito] El ticket ha sido escalado exitosamente al Nivel " + intNivelMeta + ".");
                return;
            }
            intNivelActual++;
            Console.WriteLine("--> Escalando ticket del Nivel " + (intNivelActual - 1) + " al Nivel " + intNivelActual + "...");
            EjecutarEscalamientoRecursivo(objTicket, intNivelActual, intNivelMeta);
        }

        static Ticket solicitarTicket(GestorTickets objGestor, Scanner scanner)
        {
            Console.Write("Ingrese numero de ticket: ");
            int intNumero = int.Parse(scanner.nextLine());
            Ticket t = objGestor.buscarTicket(intNumero);
            if (t == null)
            {
                Console.WriteLine("Ticket no encontrado.");
            }
            return t;
        }
    }

    // Clase auxiliar para simular el comportamiento de java.util.Scanner en C# con consola
    public class Scanner
    {
        public string nextLine()
        {
            return Console.ReadLine();
        }
    }
}