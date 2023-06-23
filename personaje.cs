namespace Jugadores
{

    public class Constantes
    {
        //primer grupo
        public static string[] nombres1 = {"Fibonacci","Euclides","Pythagoras","Archimedes","Pascal","Gauss",
        "Newton","Hilbert","Turing","Fermat","Euler","Ramanujan","Descartes","Galois","Cantor","Bernoulli",
        "Laplace","Leibniz","Mobius"};
        //segundo grupo
        public static string[] nombres2 = {"Curie","Mendeleev","Lavoisier","Boyle","Franklin","Haber","Seaborg",
        "Arrhenius","Elion","Calvin","Modrich","Domagk","Hodgkin","Urey","Olah","Dalton","Rutherford","Avogadro","Faraday","Pasteur"};
        public static string[] tipo = { "Matematico","Quimico" };

    }

    public class Personaje
    {

        // datos
        private string? tipo;
        private string? nombre;
        private DateTime fechaNac;
        private string? apodo;
        private int edad; //entre 0 y 300
        public static int prueba;

        //caracteristicas
        private int velocidad; // 1 a 10
        private int destreza; // 1 a 5
        private int fuerza;  // 1 a 10
        private int nivel;   // 1 a 10
        private int salud;    // 1 a 10
        private int armadura;  // 100


        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public string? Tipo { get => tipo; set => tipo = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        //public static int Prueba { get => prueba; set => prueba = value; }
    }


}