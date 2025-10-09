public class Vendedor extends Trabajador {

    private double comision;

    public Vendedor(int id, String nombre, double base, double comision) {
        super(id, nombre); 
        this.comision = (base * comision) + base;
    }

    public double pagar() { 
        return comision;
    }
}
