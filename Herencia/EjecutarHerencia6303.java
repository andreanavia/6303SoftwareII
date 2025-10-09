public class EjecutarHerencia6303 {
    public static void main(String[] args) {
        
        Trabajador objT1 = new Operario(1, "Klinger", 40);

        Trabajador objT2 = new Vendedor(2, "El abuelo", 1000, 0.2);

        System.out.println(objT1.pagar());

        System.out.println(objT2.pagar());

    }
}
