using Jugadores;
using Fabrica;
using Json;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;

        Console.WriteLine("\t\t=====================\n\t\tBATALLA DE CEREBRITOS\n\t\t=====================");
        Console.ResetColor();

        string NombreJson = "Personajes.json";
        var ListaPersonajes = new List<Personaje>();

        if (!PersonajesJson.Existe(NombreJson))
        {
            for (int i = 0; i < 10; i++)
            {
                var NewPersonaje = FabricaDePersonajes.crearPersonaje();
                ListaPersonajes.Add(NewPersonaje);
            }
            PersonajesJson.GuardarPersonajes(ListaPersonajes, NombreJson);//guardo la lista en .json
        }
        else
        {
            ListaPersonajes = PersonajesJson.LeerPersonajes(NombreJson);
        }
        MostrarPersonajes(ListaPersonajes);
        Pelea(ListaPersonajes);
        int valorCambiante = 0;

        Console.Write("Valor cambiante: ");

    }

    private static void Pelea(List<Personaje> ListaPersonajes)
    {

        int indice = FabricaDePersonajes.NumeroAleatorio(0, 10);
        int indice2 = FabricaDePersonajes.NumeroAleatorio(0, 10);

        var Personaje1 = ListaPersonajes[indice];
        var Personaje2 = ListaPersonajes[indice2];
        bool turno = true;
        while (ListaPersonajes.Count > 1)
        {
            while (Personaje1.Salud > 0 && Personaje2.Salud > 0)
            {
                if (turno)
                {
                    Atack(Personaje1, Personaje2); //personaje1 ataca y personaje2 se defiende
                    Console.WriteLine($"salud P2 {Personaje2.Salud}%");
                    turno = false;
                }
                else
                {
                    Atack(Personaje2, Personaje1);
                    Console.WriteLine($"salud P1 {Personaje1.Salud}%");
                    turno = true;
                }
            }
            Recompenza(Personaje1,Personaje2, ListaPersonajes);
            if (Personaje1.Salud == 0) Personaje1 = ListaPersonajes[FabricaDePersonajes.NumeroAleatorio(0,ListaPersonajes.Count)];
            else Personaje2 = ListaPersonajes[FabricaDePersonajes.NumeroAleatorio(0,ListaPersonajes.Count)];
            Console.WriteLine("Tecla");
            Console.ReadKey();
        }


    }




    private static void MostrarPersonajes(List<Personaje> ListaPersonaje)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\t[============= PERSONAJES =============]\n");
        Console.ResetColor();
        foreach (var personaje in ListaPersonaje)
        {
            Console.WriteLine("Nombre: " + personaje.Nombre);
            Console.WriteLine("Edad: " + personaje.Edad);
            Console.WriteLine("Fecha de nacimiento: " + personaje.FechaNac.Day + "\\" + personaje.FechaNac.Month + "\\" + personaje.FechaNac.Year);
            Console.WriteLine("Tipo: " + personaje.Tipo);
            Console.WriteLine("Destreza: " + personaje.Destreza);
            Console.WriteLine("Armadura" + personaje.Armadura);
            Console.WriteLine("Nivel: " + personaje.Nivel);
            Console.WriteLine("Salud: " + personaje.Salud);
            Console.WriteLine("Fuerza: " + personaje.Fuerza);
            Console.WriteLine("Velocidad: " + personaje.Velocidad + "\n");

        }
    }
    private static void Atack(Personaje PersonajeEnAtaque, Personaje PersonajeEnDefensa)
    {
        int ataque = PersonajeEnAtaque.Destreza * PersonajeEnAtaque.Fuerza * PersonajeEnAtaque.Nivel;
        int Efectividad = FabricaDePersonajes.NumeroAleatorio(1, 101);
        int defensa = PersonajeEnDefensa.Armadura * PersonajeEnDefensa.Velocidad;
        const int ajuste = 500;
        int Danio = ((ataque * Efectividad) - defensa) / ajuste;
        PersonajeEnDefensa.Salud -= Danio;
        if (PersonajeEnDefensa.Salud < 0) PersonajeEnDefensa.Salud = 0;
    }
    private static void Recompenza(Personaje Personaje1, Personaje Personaje2, List<Personaje> ListaPersonaje)
    {
        if (Personaje1.Salud == 0) ListaPersonaje.Remove(Personaje1);
        else ListaPersonaje.Remove(Personaje2);
        if (Personaje1.Salud > 0)
        {
            Console.WriteLine($"Personaje {Personaje2.Nombre} Eliminado");
            Console.WriteLine("Salud = "+ Personaje2.Salud);
            Personaje1.Salud += 5;
        }
        else
        {
            Console.WriteLine($"Personaje {Personaje1.Nombre} Eliminado");
            Console.WriteLine("Salud = "+Personaje1.Salud);
            Personaje2.Salud += 5;
        }
    }
}