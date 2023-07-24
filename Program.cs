using Jugadores;
using Fabrica;
using Json;
using HelperApi;
using Api;
using NAudio.Wave;
using Textos;
internal class Program
{
    private static void Main(string[] args)
    {
        string soundFilePath = "X2Download.app - harry potter musica (256 kbps).mp3";
        using (var waveOut = new WaveOutEvent())
        {
            using (var audioFile = new AudioFileReader(soundFilePath))
            {
                waveOut.Init(audioFile);
                waveOut.Play();
                Console.WriteLine(Textos.TextosJuego.logo); // muestro el logo del juego
                Console.WriteLine("Iniciar...");
                Console.ReadKey();
                Console.Clear();

                const string NombreJson = "Personajes.json";
                const int octavos = 16;
                const int cuartos = 8;
                const int semifinal = 4;
                const int final = 2;
                var ListaPersonajes = new List<Personaje>();
                var IndicesNombresUsados = new List<int>();
                int IndiceNombre = 0;

                if (!PersonajesJson.Existe(NombreJson)) // si json no existe
                {
                    var PersonajesHogw = new List<PersonajesHogwarts>();
                    PersonajesHogw = RecursoApiWeb.GetApi("https://harry-potter-api.onrender.com/personajes");
                    for (int i = 0; i < 16; i++)
                    {
                        do
                        {
                            IndiceNombre = FabricaDePersonajes.NumeroAleatorio(0, PersonajesHogw.Count);  // para que no se repita en el cargado de los 10 personajes
                        } while (IndicesNombresUsados.Contains(IndiceNombre));
                        IndicesNombresUsados.Add(IndiceNombre);
                        var NewPersonaje = FabricaDePersonajes.crearPersonaje(PersonajesHogw[IndiceNombre].Personaje, PersonajesHogw[IndiceNombre].Id, PersonajesHogw[IndiceNombre].Apodo);
                        ListaPersonajes.Add(NewPersonaje);
                    }
                    PersonajesJson.GuardarPersonajes(ListaPersonajes, NombreJson);//guardo la lista en .json
                }
                else
                {
                    ListaPersonajes = PersonajesJson.LeerPersonajes(NombreJson); //si json existe
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ResetColor();
                Console.WriteLine("\nPresione un tecla para iniciar los octavos de final...\n");
                Console.ReadKey();
                Console.WriteLine("\t\t=====================\n\t\t\tFIGTH...\n\t\t=====================");
                Pelea(ListaPersonajes,octavos);
                Console.WriteLine("\nPresione un tecla para iniciar los cuartos de final...\n");
                Console.ReadKey();
                Console.WriteLine("\t\t=====================\n\t\t\tFIGTH...\n\t\t=====================");
                Pelea(ListaPersonajes,cuartos);
                Console.WriteLine("\nPresione un tecla para iniciar la semifinal...\n");
                Console.ReadKey();
                Console.WriteLine("\t\t=====================\n\t\t\tFIGTH...\n\t\t=====================");
                Pelea(ListaPersonajes,semifinal);
                Console.WriteLine("\nPresione un tecla para jugar la FINAL...\n");
                Console.ReadKey();
                Console.WriteLine("\t\t=====================\n\t\t\tFIGTH...\n\t\t=====================");
                Pelea(ListaPersonajes,final);
                Console.WriteLine("\n¡¡ GANADOR " + ListaPersonajes[0].Nombre+ " !!");
                Console.ReadKey();
            }
        }

    }
    private static void Pelea(List<Personaje> ListaPersonajes, int cantParticipantes)
    {
        int indice;
        int indice2;
        var IndicesNombresUsados = new List<int>();
        var PersonajeEliminar  = new List<int>();
        var Personaje1 = new Personaje ();
        var Personaje2 = new Personaje ();
        bool turno = true;

        var columnaInicial = Console.CursorLeft;
        int longitudTexto = "Salud: ".Length;

        while (IndicesNombresUsados.Count != cantParticipantes )
        {
            //determino los personaje 1 y personaje 2 sin repetir
            do
            {
                indice = FabricaDePersonajes.NumeroAleatorio(0, ListaPersonajes.Count);
            } while (IndicesNombresUsados.IndexOf(indice) != -1);
            Personaje1 = ListaPersonajes[indice];
            IndicesNombresUsados.Add(indice);

            do
            {
                indice2 = FabricaDePersonajes.NumeroAleatorio(0, ListaPersonajes.Count);
            } while (IndicesNombresUsados.IndexOf(indice2) != -1);
            Personaje2 = ListaPersonajes[indice2];
            IndicesNombresUsados.Add(indice2);

            //comienza la batalla

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"\t{Personaje1.Nombre} |vs| {Personaje2.Nombre}\n");
            Console.ResetColor();

            while (Personaje1.Salud > 0 && Personaje2.Salud > 0)
            {

                if (turno)
                {
                    Ataque(Personaje1, Personaje2); //personaje1 ataca y personaje2 se defiende
                    turno = false;
                }
                else
                {
                    Ataque(Personaje2, Personaje1); //viceverza
                    turno = true;
                }
                Console.SetCursorPosition(columnaInicial + longitudTexto, Console.CursorTop);
                Console.Write($"\tSalud P1 {Personaje1.Salud}% - Salud P2 {Personaje2.Salud}% ".PadRight(12));
                Thread.Sleep(100);

            }
            Recompenza_Eliminacion(Personaje1, Personaje2, ListaPersonajes,PersonajeEliminar);
            Console.ReadKey();

        }

        int id;
        Personaje? PersonajeEncontrado = new Personaje();
        for (int i = 0; i < PersonajeEliminar .Count; i++)
        {
            id = PersonajeEliminar [i]; 
            PersonajeEncontrado = ListaPersonajes.Find(persona => persona.Id == id);
            if (PersonajeEncontrado != null)
            {
                ListaPersonajes.Remove(PersonajeEncontrado);
            }
         
        }
        PersonajeEliminar.Clear();
        if(ListaPersonajes.Count !=1) Console.WriteLine("\t\nPERSONAJES QUE PASAN A LA SIGUIENTE RONDA\n");
        foreach (var personaje in ListaPersonajes)
        {
           if(ListaPersonajes.Count !=1) Console.WriteLine(personaje.Nombre + " - salud " + personaje.Salud + "%");
        }

    }




    private static void MostrarPersonajes(List<Personaje> ListaPersonaje)
    {

        foreach (var personaje in ListaPersonaje)
        {
            Console.WriteLine("Nombre: " + personaje.Nombre);
            Console.WriteLine("Apodo: " + personaje.Apodo);
            Console.WriteLine("Edad: " + personaje.Edad);
            Console.WriteLine("Fecha de nacimiento: " + personaje.FechaNac.Day + "\\" + personaje.FechaNac.Month + "\\" + personaje.FechaNac.Year);
            Console.WriteLine("Tipo: " + personaje.Tipo);
            Console.WriteLine("Destreza: " + personaje.Destreza);
            Console.WriteLine("Armadura: " + personaje.Armadura);
            Console.WriteLine("Nivel: " + personaje.Nivel);
            Console.WriteLine("Salud: " + personaje.Salud);
            Console.WriteLine("Fuerza: " + personaje.Fuerza);
            Console.WriteLine("Velocidad: " + personaje.Velocidad + "\n");

        }
    }
    private static void Ataque(Personaje PersonajeEnAtaque, Personaje PersonajeEnDefensa)
    {
        int ataque = PersonajeEnAtaque.Destreza * PersonajeEnAtaque.Fuerza * PersonajeEnAtaque.Nivel;
        int Efectividad = FabricaDePersonajes.NumeroAleatorio(1, 101);
        int defensa = PersonajeEnDefensa.Armadura * PersonajeEnDefensa.Velocidad;
        const int ajuste = 500;
        int Danio = ((ataque * Efectividad) - defensa) / ajuste;
        PersonajeEnDefensa.Salud -= Danio;
        if (PersonajeEnDefensa.Salud < 0) PersonajeEnDefensa.Salud = 0;
    }
    private static void Recompenza_Eliminacion(Personaje Personaje1, Personaje Personaje2, List<Personaje> ListaPersonaje, List<int> IdPersonajes_A_Eliminar )
    {
        if (Personaje1.Salud > 0)
        {
            Console.WriteLine("\n\tPersonaje " + Personaje2.Nombre + " ¡Eliminado!\n");
            Personaje1.Salud += 10;
            IdPersonajes_A_Eliminar.Add(Personaje2.Id);
        }
        else
        {
            Console.WriteLine("\n\tPersonaje " + Personaje1.Nombre + " ¡Eliminado!\n");
            Personaje2.Salud += 10;
            IdPersonajes_A_Eliminar.Add(Personaje1.Id);
        }
    }
}