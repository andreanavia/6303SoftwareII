public class EjecutarHerencia6303 {
    public static void main(String[] args) {
        
        //Forma1
        /*
        Trabajador objT1 = new Operario(1, "Klinger", 40);
        Trabajador objT2 = new Vendedor(2, "El abuelo", 1000, 0.2);
        Trabajador objT3 = new Vendedor(3, "Alan", 800, 0.3);

        System.out.println(objT1.pagar());
        System.out.println(objT2.pagar());
        System.out.println(objT3.pagar());
        */

        //forma2
        Trabajador[] t =  new Trabajador[3];
        t[0] = new Operario(1, "Klinger", 40);
        t[1] = new Vendedor(2, "El abuelo", 1000, 0.2);
        t[2] = new Vendedor(3, "Alan", 800, 0.3);

        for(int i = 0; i < t.length; i++){
            System.out.println(t[i].pagar());
        }
    }
}