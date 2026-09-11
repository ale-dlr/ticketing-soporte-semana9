# 🎫 Sistema de Tickets de Soporte Técnico Corporativo

Sistema desarrollado en Java y C# para la gestión, control y ciclo de vida de tickets de soporte técnico corporativo, implementando Programación Orientada a Objetos (POO), colecciones, polimorfismo y algoritmos recursivos.

---

## 📋 Descripción del Caso

El sistema permite simular las operaciones clave de un departamento de soporte técnico, facilitando la interacción entre **Solicitantes** (empleados de diferentes departamentos) y **Técnicos** (especializados por áreas y niveles). 

Sus funcionalidades principales incluyen:
* **Gestión de Usuarios:** Registro de técnicos y solicitantes mediante jerarquía de clases y polimorfismo.
* **Ciclo de Vida de Tickets:** Creación, asignación automática, registro de errores en bitácora, resolución y cierre de casos.
* **Escalamiento Recursivo:** Simulación de transferencia de niveles de soporte mediante algoritmos recursivos.
* **Métricas y Control:** Generación de resúmenes de control y conteo de estados de los tickets (Abiertos, Resueltos, Cerrados).

---

## 🔄 Flujo de Estados del Ticket

El sistema valida el avance de cada caso según el siguiente flujo de estados:

```mermaid
stateDiagram-v2
    [*] --> Abierto: Creación del Ticket
    Abierto --> Asignado: Asignación a Técnico / SLA
    Asignado --> Resuelto: Aplicación de Solución
    Resuelto --> Cerrado: Validación y Customer Experience
    Cerrado --> [*]

**BlueJ (Java)**
Abre la aplicación BlueJ en tu computadora.

Selecciona Proyecto > Abrir proyecto (Project > Open Project).

Navega y selecciona la carpeta del proyecto que contiene los archivos .java.

Si las clases aparecen con líneas rayadas (sin compilar), haz clic derecho en el botón Compile (o presiona Ctrl + K) para compilar todas las clases del proyecto.

Haz clic derecho sobre la clase principal (Simulador), selecciona la opción void main(String[] args) y haz clic en Aceptar para iniciar la ejecución en la terminal interactiva.

**Visual Studio Code (C# / .NET)**
Asegúrate de tener instalado el .NET SDK y la extensión de C# en VS Code.

Abre Visual Studio Code, ve a Archivo > Abrir carpeta (File > Open Folder) y selecciona la carpeta raíz de tu proyecto en C#.

Abre la terminal integrada en VS Code presionando las teclas Ctrl + ` (o ve al menú superior Ver > Terminal).

Escribe el siguiente comando para compilar y ejecutar el programa en tiempo real:

dotnet run
Interactúa con las opciones del menú de la consola directamente desde la terminal de VS Code.
