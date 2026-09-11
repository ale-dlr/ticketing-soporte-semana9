# 🎫 Sistema de Tickets de Soporte Técnico Corporativo

Sistema de consola desarrollado en **Java** (**BlueJ**) y **C#** (**.NET** / **VS Code**) diseñado para la gestión, control y ciclo de vida de tickets de soporte técnico corporativo. Implementa los pilares de la Programación Orientada a Objetos (POO), manejo de colecciones, polimorfismo y algoritmos recursivos.

---

## 📋 Descripción del Caso

El sistema simula las operaciones clave de un departamento de soporte técnico corporativo, facilitando la interacción entre dos tipos de usuarios:
* **Solicitantes:** Empleados pertenecientes a diferentes departamentos (como Contabilidad o Ventas) que reportan incidentes o requerimientos.
* **Técnicos:** Personal especializado clasificado por áreas (Software, Hardware, General) y niveles de experiencia.

### Funcionalidades principales:
1. **Gestión de Usuarios:** Visualización y polimorfismo aplicado en los perfiles del sistema.
2. **Ciclo de Vida de los Tickets:** Creación de tickets (incidentes o requerimientos), asignación de prioridades y control de estados.
3. **Bitácora de Errores:** Registro detallado de incidencias técnicas asociadas a cada ticket con su respectivo impacto.
4. **Escalamiento Recursivo:** Simulación de transferencia de niveles de soporte mediante funciones recursivas.
5. **Métricas y Control:** Generación de un resumen cuantitativo del estado actual de los casos (Abiertos, Resueltos, Cerrados).

---

## 📊 Diagramas del Sistema

### Flujo de Estados del Ticket
```mermaid
stateDiagram-v2
    [*] --> Abierto: Creación del Ticket
    Abierto --> Asignado: Asignación a Técnico
    Asignado --> Resuelto: Aplicación de Solución
    Resuelto --> Cerrado: Validación de Cierre
    Cerrado --> [*]
