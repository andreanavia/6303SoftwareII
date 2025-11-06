public class NotificacionEmail implements INotificacion {
    @Override
    public void enviar(String mensaje) {
        System.out.println("[Base] Enviando Email: " + mensaje);
    }
}