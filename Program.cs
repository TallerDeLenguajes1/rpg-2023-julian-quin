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
        string soundFilePath = "Song_Harry_Potter.mp3";
        using (var waveOut = new WaveOutEvent())
        {
            using (var audioFile = new AudioFileReader(soundFilePath))
            {
                waveOut.Init(audioFile);
                waveOut.Play();
                Console.Clear();
                Console.WriteLine(Textos.TextosJuego.logo); // muestro el logo del juego
                Console.WriteLine("Preciona una tecla para iniciar...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(Textos.TextosJuego.presentacion);
                Console.ReadKey();
                Console.Clear();

                const string NombreJson = "Personajes.json";
                const int octavos = 16;
                const int cuartos = 8;
                const int semifinal = 4;
                const int final = 2;
                var ListaPersonajes = new List<Personaje>();
                CargarJuego(NombreJson, ref ListaPersonajes);
                int flag = 0;
                string? NumTexto;
                do
                {
                    Console.WriteLine(Textos.TextosJuego.panelInicio);
                    NumTexto = Console.ReadLine();
                    int.TryParse(NumTexto, out flag);
                    Console.Clear();
                    switch (flag)
                    {
                        case 1:
                            Console.WriteLine("\t\t\t=====================\n\t\t\t   OCTAVOS DE FINAL\n\t\t\t=====================");
                            Pelea(ListaPersonajes, octavos);
                            Console.WriteLine("\nPresione un tecla para iniciar los CUARTOS de final...\n");
                            Console.ReadKey();
                            Console.WriteLine("\t\t\t=====================\n\t\t\t   CUARTOS DE FINAL\n\t\t\t=====================");
                            Pelea(ListaPersonajes, cuartos);
                            Console.WriteLine("\nPresione un tecla para iniciar la SEMIFINAL...\n");
                            Console.ReadKey();
                            Console.WriteLine("\t\t\t=====================\n\t\t\t      SEMIFINAL\n\t\t\t=====================");
                            Pelea(ListaPersonajes, semifinal);
                            Console.WriteLine("\nPresione un tecla para jugar la FINAL...\n");
                            Console.ReadKey();
                            Console.WriteLine("\t\t\t=====================\n\t\t\t\tFINAL\n\t\t\t=====================");
                            Pelea(ListaPersonajes, final);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\n\t¡¡ GANADOR " + ListaPersonajes[0].Nombre + " !!");
                            Console.ResetColor();
                            Console.Clear();
                            break;
                        case 2:
                            MostrarPersonajes(ListaPersonajes);
                        break;
                    }

                } while (flag ==1 || flag ==2);

            }
        }

    }

    /////////////////////////////// FIN MAIN ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private static void CargarJuego(string NombreJson, ref List<Personaje> ListaPersonajes)
    {
        Console.WriteLine("Cargando...");
        int IndiceNombre;
        var IndicesNombresUsados = new List<int>();
        const string nombreJson2 = @"JsonPersonajesAuxilio\PersonajesAuxilio.json";
        if (PersonajesJson.Existe(NombreJson) && File.ReadAllText(NombreJson).Length == 0) File.Delete(NombreJson);//elimino si existe el json y está vacio

        if (!PersonajesJson.Existe(NombreJson)) // si json no existe
        {
            var PersonajesHogw = RecursoApiWeb.GetListaPersonajes("https://harry-potter-api.onrender.com/personajes");
            if (PersonajesHogw != null && PersonajesHogw.Count != 0)
            {
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
                Console.WriteLine("\n¡se inicia con json de respaldo!");
                ListaPersonajes = PersonajesJson.LeerPersonajes(nombreJson2);
            }

        }
        else
        {
            ListaPersonajes = PersonajesJson.LeerPersonajes(NombreJson);
        }
        Console.Clear();
    }

    private static void Pelea(List<Personaje> ListaPersonajes, int cantParticipantes)
    {
        var IndicesPersonajesUsados = new List<int>();
        var IDsPersonajeEliminar = new List<int>();
        var Personaje1 = new Personaje();
        var Personaje2 = new Personaje();
        int DanioProvocado1=0;
        int DanioProvocado2=0;
        bool turno = true;

        var columnaInicial = Console.CursorLeft;
        Console.CursorVisible = false;

        while (IndicesPersonajesUsados.Count != cantParticipantes)
        {
            //determino los personaje 1 y personaje 2 sin repetir

            PersonajeAleatoreo(ListaPersonajes, IndicesPersonajesUsados, out Personaje1);
            PersonajeAleatoreo(ListaPersonajes, IndicesPersonajesUsados, out Personaje2);

            //comienza la batalla

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"\t\t{Personaje1.Nombre} |vs| {Personaje2.Nombre}\n");
            Console.ResetColor();
            int filaInformacion = Console.CursorTop;
            while (Personaje1.Salud > 0 && Personaje2.Salud > 0)
            {

                if (turno)
                {
                    DanioProvocado2 = Ataque(Personaje1, Personaje2); //personaje1 ataca y personaje2 se defiende
                    turno = false;
                }
                else
                {
                    DanioProvocado1 = Ataque(Personaje2, Personaje1); //viceverza
                    turno = true;
                }
                Console.SetCursorPosition(columnaInicial,Console.CursorTop);
                Console.Write($"\t| Salud P1 {Personaje1.Salud}% - Salud P2 {Personaje2.Salud}% | ==== | Daño P1 {DanioProvocado1}% - Daño P2 {DanioProvocado2}% |".PadRight(70));
                Thread.Sleep(150);
            }
            Recompenza_IdEliminados(Personaje1, Personaje2, IDsPersonajeEliminar);
            Console.ReadKey();
        }

        EliminacionPersonajes(ListaPersonajes, IDsPersonajeEliminar);
        MostrarGanadores(ListaPersonajes);

    }

    private static void MostrarGanadores(List<Personaje> ListaPersonajes)
    {
        if (ListaPersonajes.Count != 1) Console.WriteLine("\t\nPERSONAJES QUE PASAN A LA SIGUIENTE RONDA\n");
        foreach (var personaje in ListaPersonajes)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (ListaPersonajes.Count != 1) Console.WriteLine("\t" + personaje.Nombre + " - salud " + personaje.Salud + "%");
            Console.ResetColor();
        }
    }

    private static void EliminacionPersonajes(List<Personaje> ListaPersonajes, List<int> PersonajeEliminar)
    {
        int id;
        Personaje? PersonajeEncontrado = new Personaje();
        for (int i = 0; i < PersonajeEliminar.Count; i++)
        {
            id = PersonajeEliminar[i];
            PersonajeEncontrado = ListaPersonajes.Find(persona => persona.Id == id);
            if (PersonajeEncontrado != null)
            {
                ListaPersonajes.Remove(PersonajeEncontrado);
            }

        }
    }

    private static void PersonajeAleatoreo(List<Personaje> ListaPersonajes, List<int> IndicesPersonajesUsados, out Personaje Personaje1)
    {
        int indice;
        do
        {
            indice = FabricaDePersonajes.NumeroAleatorio(0, ListaPersonajes.Count);
        } while (IndicesPersonajesUsados.IndexOf(indice) != -1);
        Personaje1 = ListaPersonajes[indice];
        IndicesPersonajesUsados.Add(indice);
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
    private static int Ataque(Personaje PersonajeEnAtaque, Personaje PersonajeEnDefensa)
    {
        int ataque = PersonajeEnAtaque.Destreza * PersonajeEnAtaque.Fuerza * PersonajeEnAtaque.Nivel;
        int Efectividad = FabricaDePersonajes.NumeroAleatorio(1, 101);
        int defensa = PersonajeEnDefensa.Armadura * PersonajeEnDefensa.Velocidad;
        const int ajuste = 500;
        int Danio = ((ataque * Efectividad) - defensa) / ajuste;
        PersonajeEnDefensa.Salud -= Danio;
        if (PersonajeEnDefensa.Salud < 0) PersonajeEnDefensa.Salud = 0;
        return Danio;
    }
    private static void Recompenza_IdEliminados(Personaje Personaje1, Personaje Personaje2, List<int> IdPersonajesEliminar)
    {
        if (Personaje1.Salud > 0)
        {
            Console.WriteLine("\n\tPersonaje " + Personaje2.Nombre + " ¡Eliminado!\n");
            Personaje1.Salud += 10;
            IdPersonajesEliminar.Add(Personaje2.Id);
        }
        else
        {
            Console.WriteLine("\n\tPersonaje " + Personaje1.Nombre + " ¡Eliminado!\n");
            Personaje2.Salud += 10;
            IdPersonajesEliminar.Add(Personaje1.Id);
        }
    }
}