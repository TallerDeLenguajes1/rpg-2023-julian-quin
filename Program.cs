using Jugadores;
using Fabrica;
using Json;
using HelperApi;
using Api;
using NAudio.Wave;
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
                Console.WriteLine(@"
                                         _ __
        ___                             | '  \
   ___  \ /  ___         ,'\_           | .-. \        /|
   \ /  | |,'__ \  ,'\_  |   \          | | | |      ,' |_   /|
 _ | |  | |\/  \ \ |   \ | |\_|    _    | |_| |   _ '-. .-',' |_   _
// | |  | |____| | | |\_|| |__    //    |     | ,'_`. | | '-. .-',' `. ,'\_
\\_| |_,' .-, _  | | |   | |\ \  //    .| |\_/ | / \ || |   | | / |\  \|   \
 `-. .-'| |/ / | | | |   | | \ \//     |  |    | | | || |   | | | |_\ || |\_|
   | |  | || \_| | | |   /_\  \ /      | |`    | | | || |   | | | .---'| |
   | |  | |\___,_\ /_\ _      //       | |     | \_/ || |   | | | |  /\| |
   /_\  | |           //_____//       .||`  _   `._,' | |   | | \ `-' /| |
        /_\           `------'        \ |  /-\ND _     `.\  | |  `._,' /_\
                                       \|        |HE         `.\
                                      __        _           _   __  _
                                     /   |__|  /_\  |\  /| |_) |_  |_)
                                     \__ |  | /   \ | \/ | |_) |__ | \
                                             _  _   _   __  _  _   __ ___ _
                                            (_)|-  (_` |_  /  |_) |_   | (_`
                                                   ._) |__ \_ | \ |__  | ._)
");
                Console.WriteLine("Presione un tecla para iniciar...");
                Console.ReadKey();
                Console.WriteLine("La batalla comienza en 3,2,1...");
                Console.ReadKey();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("\t\t=====================\n\t\t        FIGTH...\n\t\t=====================");
                Console.ResetColor();

                const string NombreJson = "Personajes.json";
                var ListaPersonajes = new List<Personaje>();
                var NombresUsados = new List<int>();
                int IndiceNombre = 0;

                if (!PersonajesJson.Existe(NombreJson))
                {
                    var PersonajesHogw = new List<PersonajesHogwarts>();
                    PersonajesHogw = RecursoApiWeb.GetApi("https://harry-potter-api.onrender.com/personajes");
                    for (int i = 0; i < 10; i++)
                    {
                        do
                        {
                            IndiceNombre = FabricaDePersonajes.NumeroAleatorio(0, PersonajesHogw.Count);  // para que no se repita en el cargado de los 10 personajes
                        } while (NombresUsados.Contains(IndiceNombre));
                        NombresUsados.Add(IndiceNombre);
                        var NewPersonaje = FabricaDePersonajes.crearPersonaje(PersonajesHogw[IndiceNombre].Personaje,PersonajesHogw[IndiceNombre].Id,PersonajesHogw[IndiceNombre].Apodo);
                        ListaPersonajes.Add(NewPersonaje);
                    }
                    PersonajesJson.GuardarPersonajes(ListaPersonajes, NombreJson);//guardo la lista en .json
                }
                else
                {
                    ListaPersonajes = PersonajesJson.LeerPersonajes(NombreJson);
                }
                MostrarPersonajes(ListaPersonajes);
                Console.ReadKey();
                Pelea(ListaPersonajes);
                
                Console.ReadKey();
            }
        }

    }

    private static void Pelea(List<Personaje> ListaPersonajes)
    {
        int indice;
        int indice2;

        do
        {
            indice = FabricaDePersonajes.NumeroAleatorio(0, 10);
            indice2 = FabricaDePersonajes.NumeroAleatorio(0, 10);
        } while (indice == indice2);

        var Personaje1 = ListaPersonajes[indice];
        var Personaje2 = ListaPersonajes[indice2];
        bool turno = true;

        var columnaInicial = Console.CursorLeft;
        int longitudTexto = "Salud: ".Length;

        while (ListaPersonajes.Count > 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"\t{Personaje1.Nombre} |vs| {Personaje2.Nombre}\n");
            Console.ResetColor();

            while (Personaje1.Salud > 0 && Personaje2.Salud > 0)
            {

                if (turno)
                {
                    Atack(Personaje1, Personaje2); //personaje1 ataca y personaje2 se defiende
                    turno = false;
                }
                else
                {
                    Atack(Personaje2, Personaje1); //viceverza
                    turno = true;
                }
                Console.SetCursorPosition(columnaInicial + longitudTexto, Console.CursorTop);
                Console.Write($"\tSalud P1 {Personaje1.Salud}% - Salud P2 {Personaje2.Salud}% ".PadRight(12));
                Thread.Sleep(150);

            }
            Recompenza_Eliminacion(Personaje1, Personaje2, ListaPersonajes);

            if (Personaje1.Salud == 0)
            {
                do
                {
                    indice = FabricaDePersonajes.NumeroAleatorio(0, ListaPersonajes.Count);
                    Personaje1 = ListaPersonajes[indice];
                } while ((ListaPersonajes.IndexOf(Personaje2) == indice) && ListaPersonajes.Count > 1);

            }
            else
            {
                do
                {
                    indice = FabricaDePersonajes.NumeroAleatorio(0, ListaPersonajes.Count);
                    Personaje2 = ListaPersonajes[indice];
                } while ((ListaPersonajes.IndexOf(Personaje1) == indice) && ListaPersonajes.Count > 1);
            }


            Console.WriteLine("\tTecla");
            Console.ReadKey();

        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\t¡¡¡¡¡¡¡GANADOR!!!!!!");
        Console.WriteLine("\tESTADISTICAS:\n");
        Console.WriteLine("\tNOMBRE "+ListaPersonajes[0].Nombre);
        Console.WriteLine("\tSALUD " + ListaPersonajes[0].Salud+"%");
        Console.ResetColor();


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
    private static void Recompenza_Eliminacion(Personaje Personaje1, Personaje Personaje2, List<Personaje> ListaPersonaje)
    {
        if (Personaje1.Salud == 0) ListaPersonaje.Remove(Personaje1);
        else ListaPersonaje.Remove(Personaje2);
        if (Personaje1.Salud > 0)
        {
            Console.WriteLine("\n\tPersonaje " + Personaje2.Nombre + " ¡Eliminado!");
            Personaje1.Salud += 10;
        }
        else
        {
            Console.WriteLine("\n\tPersonaje " + Personaje1.Nombre + " ¡Eliminado!");
            Personaje2.Salud += 10;
        }
    }
}