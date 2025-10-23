public class Operario extends Trabajador {

    private final double VALOR_HORA = 250.0;
    private double horas;

    public Operario(int id, String nombre, double horas){
        super(id, nombre);
        this.horas = horas * VALOR_HORA;
    }

    public double pagar(){
        return horas;
    }
}
