namespace Jugadores
{

    public class Constantes
    {
        //primer grupo
        public static string[,] nombresTipo = {
        {"Fibonacci","Devil-Matematico"},{"Euclides","Devil-Matematico"},
        {"Pythagoras","Devil-Matematico"},{"Archimedes","Devil-Matematico"},
        {"Pascal","Devil-Matematico"},{"Gauss","Devil-Matematico"},
        {"Newton","Devil-Matematico"},{"Hilbert","Devil-Matematico"},
        {"Turing","Devil-Matematico"},{"Fermat","Devil-Matematico"},
        {"Euler","Devil-Matematico"},{"Ramanujan","Devil-Matematico"},
        {"Descartes","Devil-Matematico"},{"Galois","Devil-Matematico"},
        {"Cantor","Devil-Matematico"},{"Bernoulli","Devil-Matematico"},
        {"Laplace","Devil-Matematico"},{"Leibniz","Devil-Matematico"},
        {"Mobius","Devil-Matematico"}, {"Curie","Demon-Quimico"},
        {"Mendeleev","Demon-Quimico"},{"Lavoisier","Demon-Quimico"},
        {"Boyle","Demon-Quimico"},{"Franklin","Demon-Quimico"},
        {"Haber","Demon-Quimico"},{"Seaborg","Demon-Quimico"},
        {"Arrhenius","Demon-Quimico"},{"Elion","Demon-Quimico"},
        {"Calvin","Demon-Quimico"}, {"Modrich","Demon-Quimico"},
        {"Domagk","Demon-Quimico"},{"Hodgkin","Demon-Quimico"},
        {"Urey","Demon-Quimico"}, {"Olah","Demon-Quimico"},
        {"Dalton","Demon-Quimico"},{"Rutherford","Demon-Quimico"},
        {"Avogadro","Demon-Quimico"},{"Faraday","Demon-Quimico"},
        {"Pasteur","Demon-Quimico"}
        };

    }

    public class Personaje
    {

        // datos
        private string? tipo;
        private string? nombre;
        private DateTime fechaNac;
        //private string? apodo;
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
        //public string Apodo { get => apodo; set => apodo = value; }
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