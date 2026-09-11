public abstract class Ticket {
    protected int id;
    protected String prioridad;
    protected String estado;
    protected String titulo;
    
    public Ticket(int id, String prioridad, String estado, String titulo) {
        this.id = id;
        this.prioridad = prioridad;
        this.estado = estado;
        this.titulo = titulo;
    }

    public abstract void calcularSLA();

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }

    public void mostrarResumen() {
        System.out.println("Ticket #" + id + " | Título: " + titulo + " | Prioridad: " + prioridad + " | Estado: " + estado);
        calcularSLA();
    }

    public void registrarError(String tipo, String descripcion, String impacto) {
        System.out.println("Error registrado: [" + tipo + "] - " + descripcion + " (Impacto: " + impacto + ")");
    }

    public void resolver(String solucion) {
        this.estado = "Resuelto";
        System.out.println("Solución aplicada: " + solucion);
    }

    public void cerrar() {
        this.estado = "Cerrado";
    }

    public void mostrarBitacora() {
        System.out.println("Bitácora actualizada para el Ticket #" + id + " - Estado actual: " + estado);
    }
}