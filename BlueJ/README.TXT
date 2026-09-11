------------------------------------------------------------------------
PROYECTO: Sistema de Ticketing de Soporte
CURSO: Programacion II - UMG Portales
AUTOR: Catedra de Programacion II
VERSION: 1.0 (Modulo 2)
------------------------------------------------------------------------
DESCRIPCION DEL PROYECTO:
Sistema automatizado para la asignación, resolución, control de errores y 
escalamiento de tickets de soporte de sistemas de TI corporativos. Diferencia 
entre incidentes críticos y requerimientos mediante el uso de Programación 
Orientada a Objetos (POO), aplicando herencia, polimorfismo y reglas de SLA.

OBJETOS INCLUIDOS:
1. Usuario: Superclase abstracta base con datos de identificación corporativa.
2. Tecnico: Subclase de Usuario que modela al personal técnico con especialidad y nivel.
3. Solicitante: Subclase de Usuario que modela al cliente interno con departamento y extensión.
4. Ticket: Superclase abstracta base con atributos y métodos comunes para la gestión de casos.
5. TicketIncidente: Subclase de Ticket para fallas críticas con SLA de atención inmediata.
6. TicketRequerimiento: Subclase de Ticket para solicitudes generales con SLA programado.
7. GestorTickets: Administra las colecciones de usuarios, técnicos y el repositorio global de tickets.
8. FlujoTicket: Controla la coherencia y el ciclo de vida de los estados del ticket.
9. Simulador: Interfaz de consola interactiva basada en menús para la ejecución y pruebas del sistema.

 NOTA TECNICA:
Implementa diseño estructural en BlueJ con relaciones de herencia, métodos abstractos 
para polimorfismo en el cálculo de SLA y lógica recursiva para el escalamiento de casos.
------------------------------------------------------------------------