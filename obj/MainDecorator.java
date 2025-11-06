import java.time.LocalDateTime;

abstract class NotificacionBaseDecorator implements INotificacion {
    
    protected INotificacion notificacion;

    public NotificacionBaseDecorator(INotificacion notificacion) {
        this.notificacion = notificacion;
    }

    @Override
    public void enviar(String mensaje) {
        this.notificacion.enviar(mensaje);
    }
}

class RegistroDecorator extends NotificacionBaseDecorator {

    public RegistroDecorator(INotificacion notificacion) {
        super(notificacion);
    }

    @Override
    public void enviar(String mensaje) {
        System.out.println("[Registro] Registrando envío: " + LocalDateTime.now());
        super.enviar(mensaje); 
        System.out.println("[Registro] Envío finalizado.");
    }
}

class CifradoDecorator extends NotificacionBaseDecorator {

    public CifradoDecorator(INotificacion notificacion) {
        super(notificacion);
    }

    @Override
    public void enviar(String mensaje) {
        System.out.println("[Cifrado] Aplicando lógica de cifrado...");
        String mensajeCifrado = " Cifrado Aplicado (Longitud: " + mensaje.length() + " chars) ";
        super.enviar(mensajeCifrado); 
    }
}

public class MainDecorator {

    public static void main(String[] args) {
        System.out.println(" Solución 1: Demostración del Patrón Decorador \n");

        System.out.println(" Escenario 1: Notificación Base (Email) ");
        INotificacion notificacionBase = new NotificacionEmail();
        notificacionBase.enviar("Informe de resultados del Q3");

        System.out.println("\n-----------------------------------------------------\n");

        System.out.println(" Escenario 2: Email con Cifrado Y Registro ");

        INotificacion notificacionAvanzada = new RegistroDecorator(
            new CifradoDecorator(
                new NotificacionEmail() 
            ) 
        );

        notificacionAvanzada.enviar("Contrato de alta dirección para revisión");
    }
}