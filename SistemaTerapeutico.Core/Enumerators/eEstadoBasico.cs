namespace SistemaTerapeutico.Core.Enumerators
{
    public static class EEstadoBasico

    {
        public static int Activo = 2;
        public static int Inactivo = 3;
        public static int Anulado = 4;
    }

    public static class EUbigeo
    {
        public static int Tacna = 230101;
    }

    public static class ESexo
    {
        public static int Masculino = 33;
        public static int Femenino = 34;
    }

    public static class EEstadoCivil
    {
        public static int Soltero = 36;
        public static int Casado = 37;
    }

    public static class EPais
    {
        public static int Peru = 173;
    }

    public static class ETipoPersona
    {
        public static int Padre = 23;
        public static int Participante = 24;
        public static int Terapeuta = 25;
        public static int Coordinador = 26;
        public static int Proveedor = 27;
        public static int ServicioLimpieza = 28;
        public static int Practicante = 29;
        public static int Apoyo = 30;
        public static int Jefe = 31;
    }

    public static class ETipoDireccion
    {
        public static int Domicilio = 39;
        public static int Negocio = 40;
        public static int Trabajo = 41;
    }
    public static class ETipoContacto
    {
        public static int CelularClaro = 13;
        public static int CelularMovistar = 14;
        public static int CelularBitel = 15;
        public static int CelularEntel = 16;
        public static int Correo = 17;
        public static int TelefonoFijo = 18;
        public static int CuentaFacebook = 19;
        public static int CuentaInstagram = 20;
        public static int CuentaTwitter = 21;
    }
    public static class ETipoVinculo
    {
        public static int Padre = 43;
        public static int Madre = 44;
        public static int Hijo = 45;
        public static int Tio = 46;
        public static int Sobrino = 47;
        public static int Abuelo = 48;
    }
    public static class ETipoTerapia
    {
        public static int Individual = 50;
        public static int Grupal = 51;
        public static int Fisica = 52;
    }
    public static class ETipoCargoTerapeuta
    {
        public static int Titular = 54;
        public static int Apoyo = 55;
        public static int Asistente = 56;
        public static int Auxiliar = 57;
    }
    public static class ETipoAsistenciaSesion
    {
        public static int Normal = 59;
        public static int Tarde = 60;
        public static int Inasistencia = 61;
    }
}
