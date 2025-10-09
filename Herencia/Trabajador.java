public class Trabajador {

    private int id;
    private String nombre;

    public Trabajador(int id, String nombre) {
        this.id = id;
        this.nombre = nombre;
    }

    public String getNombre(){
        return nombre;
    }
    
    public double pagar() {
        return 0.0;
    }
}
