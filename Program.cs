﻿using EspacioPersonaje;
using EspacioFabrica;
using EspacioJson;
using EspacioHelperApi;
using EspacioTextos;
using NAudio.Wave;
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
                Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m",TextosJuego.logo); // muestro el logo del juego
                Console.WriteLine("Preciona una tecla para iniciar...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\u001b[38;2;255;253;208m{0}\u001b[0m",TextosJuego.presentacion1);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\u001b[38;2;255;253;208m{0}\u001b[0m",TextosJuego.presentacion2);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\u001b[38;2;255;253;208m{0}\u001b[0m",TextosJuego.presentacion3);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\u001b[38;2;255;253;208m{0}\u001b[0m",TextosJuego.presentacion4);
                Console.ReadKey();
                Console.Clear();

                const string NombreJson = "Personajes.json";
                const int octavos = 16;
                const int cuartos = 8;
                const int semifinal = 4;
                const int final = 2;
                const int CantMaxApuestas = 3;
                var ListaPersonajes = new List<Personaje>();
                CargarJuego(NombreJson, ref ListaPersonajes);
                int flag = 0;
                string? NumTexto;
                int Apostante1 = 0, Apostante2 = 0, Apostante3 = 0;
                bool flagApuesta = false; //no hay apuestas por defecto
                bool menu = true; //para tratar dos diferentes menues (por defecto menú 1)
                do
                {
                    if (menu) Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m", EspacioTextos.TextosJuego.panelInicio1);
                    else Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m", EspacioTextos.TextosJuego.panelInicio2);
                    NumTexto = Console.ReadLine();
                    int.TryParse(NumTexto, out flag);
                    Console.Clear();
                    switch (flag)
                    {
                        case 1:
                            if (ListaPersonajes.Count == 1) // ¿jugó al menos una vez?
                            {
                                ListaPersonajes.Clear();
                                CargarJuego(NombreJson, ref ListaPersonajes);
                                menu = true; //llamo al menú 1
                                flagApuesta = false; //indico nuevamente que no hay apuestas
                                Console.Clear();
                                break;
                            }
                            IniciarBatallas(octavos, cuartos, semifinal, final, ListaPersonajes);
                            menu = false; //indico que al finalizar se debe mostrar el menú 2
                        break;
                        case 2:
                            MostrarPersonajes(ListaPersonajes);
                        break;
                        case 3:
                            Apuestas(CantMaxApuestas, ListaPersonajes, ref Apostante1, ref Apostante2, ref Apostante3, ref flagApuesta);
                            Console.Clear();
                        break;
                    }

                } while (flag !=4 );

            }
        }

    }

/////////////////////////////// FIN MAIN ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////






    private static void IniciarBatallas(int octavos, int cuartos, int semifinal, int final, List<Personaje> ListaPersonajes)
    {
        Console.WriteLine("Nota: Luego de que un personaje fue eliminado, si lo deseas podrás precionar K");
        Console.WriteLine( "para ver en detalle cada ataque realizado. Luego continua con cualquie tecla.\n");
        Console.ReadKey();
        MostrarMensajeIA("EL TORNEO DE LOS MAGOS COMIENZA EN 3 2 1...\n");
        Console.WriteLine(TextosJuego.OctavosDeFinal);
        Pelea(ListaPersonajes, octavos);
        Console.WriteLine("\nPresione un tecla para iniciar los CUARTOS de final...\n");
        Console.ReadKey();
        Console.WriteLine(TextosJuego.CuartosDFinal);
        Pelea(ListaPersonajes, cuartos);
        Console.WriteLine("\nPresione un tecla para iniciar la SEMIFINAL...\n");
        Console.ReadKey();
        Console.WriteLine(TextosJuego.Semifinales);
        Pelea(ListaPersonajes, semifinal);
        Console.WriteLine("\nPresione un tecla para jugar la FINAL...\n");
        Console.ReadKey();
        Console.WriteLine(TextosJuego.Final);
        Pelea(ListaPersonajes, final);
        Console.WriteLine("\u001b[38;2;255;255;0m{0}\u001b[0m",TextosJuego.Ganador);
        Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m","\n\t" + ListaPersonajes[0].Nombre);
        ListaPersonajes[0].EstadisticasPersonaje();
        Console.WriteLine("teclea para continuar");
        Console.ReadKey();
        Console.Clear();
    }

    private static void Apuestas(int CantMaxApuestas, List<Personaje> ListaPersonajes, ref int Apostante1, ref int Apostante2, ref int Apostante3, ref bool flagApuesta)
    {
        int eleccion;

        Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m", "\tBienvenido a la seccion de APUESTAS\n\n");
        if (!flagApuesta && ListaPersonajes.Count != 1)
        {
            MostradoCortoPersonajes(ListaPersonajes);
            Console.WriteLine("\n\tApostar(espacio)");
            Console.WriteLine("\n\tTeclea para salir");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key != ConsoleKey.Spacebar)return;
            
            for (int i = 0; i < CantMaxApuestas; i++)
            {
                Console.WriteLine($"\n\tApostante ({i + 1}), apueste por un personje\n");
                do
                {
                    Console.WriteLine("\tDigite un valor valido");
                    int.TryParse(Console.ReadLine(), out eleccion);
                } while (eleccion < 0 || eleccion > 15); //porque son 15 elementos desde el cero 

                if (i == 0) Apostante1 = ListaPersonajes[eleccion].Id;
                else
                if (i == 1) Apostante2 = ListaPersonajes[eleccion].Id;
                else Apostante3 = ListaPersonajes[eleccion].Id;
            }
            flagApuesta = true; // se informa que se hicieron apuestas
        }
        else
        {
            int apostante1Local = Apostante1;
            int apostante2Local = Apostante2;
            int apostante3Local = Apostante3;

            if (ListaPersonajes.Count != 1) // luego de la apuesta, si se sale y vuelve a entrar (en opc 3) se muestra por lo que se apostó
                                            //uso ese if, pues porque tambien al finalizar toda la batalla quiero ver los resultados  
            {
                Console.WriteLine("\t¡Hay apuestas realizadas!");
                Console.WriteLine("\tApostante 1 => " + ListaPersonajes.Find(persona => persona.Id == apostante1Local).Nombre);
                Console.WriteLine("\tApostante 2 => " + ListaPersonajes.Find(persona => persona.Id == apostante2Local).Nombre);
                Console.WriteLine("\tApostante 3 => " + ListaPersonajes.Find(persona => persona.Id == apostante3Local).Nombre);
            }
            else
            {
                Console.WriteLine("\tResultados:"); //esto se muestra si se apostó por alguien o por nadie 

                if (ListaPersonajes[0].Id == Apostante1) Console.WriteLine("\t¡Gana Apostante 1!"); //comparo id con id
                else
                  if (ListaPersonajes[0].Id == Apostante2) Console.WriteLine("\t¡Gana Apostante 2!");
                else
                  if (ListaPersonajes[0].Id == Apostante3) Console.WriteLine("\t¡Gana Apostante 3!");
                else Console.WriteLine("\t¡Todos los apostandores perdieron o no se realizaron apuestas!");
             
            }

        }
        Console.WriteLine("\nteclea para salir");
        Console.ReadKey();
        Console.Clear();
    }


    private static void CargarJuego(string NombreJson, ref List<Personaje> ListaPersonajes)
    {
        Console.WriteLine("Cargando...");
        int Indice;
        var IndicesPersonajesUsados = new List<int>();
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
                        Indice = FabricaDePersonajes.NumeroAleatorio(0, PersonajesHogw.Count);  // para que no se repita en el cargado de los 16 personajes
                    } while (IndicesPersonajesUsados.Contains(Indice)); // si está devuelve true
                    IndicesPersonajesUsados.Add(Indice);
                    var NewPersonaje = FabricaDePersonajes.crearPersonaje(PersonajesHogw[Indice].Personaje, PersonajesHogw[Indice].Id, PersonajesHogw[Indice].Apodo);
                    ListaPersonajes.Add(NewPersonaje); //voy cargando la lista 
                }
                PersonajesJson.GuardarPersonajes(ListaPersonajes, NombreJson);//guardo la lista en .json

            }
            else //en el caso de que la lista que traigo apartir de la API es null o está vacia
            {
                Console.WriteLine("\n¡se inicia con json de respaldo!");
                ListaPersonajes = PersonajesJson.LeerPersonajes(nombreJson2);
            }

        }
        else
        {
            ListaPersonajes = PersonajesJson.LeerPersonajes(NombreJson); // en el caso de que json exista (solo leo)
        }
        Console.Clear();
    }

    private static void Pelea(List<Personaje> ListaPersonajes, int cantParticipantes)
    {
        var IndicesPersonajesUsados = new List<int>(); // para evitar repeticiones en los personajes
        var IDsPersonajeEliminar = new List<int>(); // me permite hace delete de los perdedores
        var Personaje1 = new Personaje();
        var Personaje2 = new Personaje();
        int DanioProvocado1 = 0;
        int DanioProvocado2 = 0;
        var EstadisticaAtaques=new List<string>();// para guardar los ataques 
        string TextoEstadistica;
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
            Console.WriteLine($"\t\t( {Personaje1.Nombre} |vs| {Personaje2.Nombre} )\n");
            Console.ResetColor();
            int filaInformacion = Console.CursorTop;
            while (Personaje1.Salud > 0 && Personaje2.Salud > 0)
            {

                if (turno)
                {
                    DanioProvocado2 = Ataque(Personaje1, Personaje2); //personaje1 ataca y personaje2 se defiende
                    turno = false;
                    TextoEstadistica = "P1 ataca y realiza " +DanioProvocado2+"% de daño";
                    EstadisticaAtaques.Add(TextoEstadistica); //guardo porcentaje de daño

                }
                else
                {
                    DanioProvocado1 = Ataque(Personaje2, Personaje1); //personaje2 ataca y personaje1 se defiende
                    turno = true;
                    TextoEstadistica = "P2 ataca y realiza " +DanioProvocado1+"% de daño";
                    EstadisticaAtaques.Add(TextoEstadistica); //guardo porcentaje de daño
                }
                Console.SetCursorPosition(columnaInicial, Console.CursorTop);
                Console.Write("\u001b[38;2;173;255;47m{0}\u001b[0m", $"\t| Salud P1 {Personaje1.Salud}% - Salud P2 {Personaje2.Salud}% | ==== | Daño P1 {DanioProvocado1}% - Daño P2 {DanioProvocado2}% |".PadRight(70));
                Thread.Sleep(200);
            }
            Recompenza_IdsEliminar(Personaje1, Personaje2, IDsPersonajeEliminar);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.KeyChar == 'k') mostradoEstadistica(EstadisticaAtaques);
            EstadisticaAtaques.Clear();
        }

        EliminacionPersonajes(ListaPersonajes, IDsPersonajeEliminar);
        if (ListaPersonajes.Count != 1) {
            Console.WriteLine("\t\nPERSONAJES QUE PASAN A LA SIGUIENTE RONDA\n"); // if, xq el ganador no pasa de ronda
            MostradoCortoPersonajes(ListaPersonajes);
        }

       
       
        void mostradoEstadistica(List<string> EstadisticasAtaques)
        {
            bool flag = true;//para que intercambie de color (estadistica)
            foreach (var dato in EstadisticaAtaques)
            {
                if(flag){
                    Console.WriteLine("\u001b[38;2;0;100;0m{0}\u001b[0m","\t"+dato);
                    flag = false;
                } else {
                    Console.WriteLine("\t"+dato);
                    flag = true;
                }
            }
            Console.WriteLine("\n");
            Console.ReadKey();
        }

    }

    private static void MostradoCortoPersonajes(List<Personaje> ListaPersonajes)
    {
        int i = 0;
        foreach (var personaje in ListaPersonajes)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (ListaPersonajes.Count == 16) Console.WriteLine("\t" + $"({i}) " + personaje.Nombre);//sirve para apuestas(opcion 3)
            else Console.WriteLine("\t"+personaje.Nombre + " - salud " + personaje.Salud + "%");//sirve para los que pasan de ronda (en convate)
            Console.ResetColor();
            i++;
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
            if (PersonajeEncontrado != null)ListaPersonajes.Remove(PersonajeEncontrado);

        }
    }

    private static void PersonajeAleatoreo(List<Personaje> ListaPersonajes, List<int> IndicesPersonajesUsados, out Personaje Personaje1)
    {
        int indice;
        do
        {
            indice = FabricaDePersonajes.NumeroAleatorio(0, ListaPersonajes.Count);
        } while (IndicesPersonajesUsados.Contains(indice));
        Personaje1 = ListaPersonajes[indice];
        IndicesPersonajesUsados.Add(indice);
    }

    private static void MostrarPersonajes(List<Personaje> ListaPersonaje)
    {
        if(ListaPersonaje.Count==1)Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m", "\tGANADOR"); //Para el segundo cartel (opcion 2 ver ganador)
        else Console.WriteLine("\u001b[38;2;173;255;47m{0}\u001b[0m", "\tLista de Personajes");// para el primer cartel (opcion 2 mostrar personajes)
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
        Console.WriteLine("Teclea para salir");
        Console.ReadKey();
        Console.Clear();
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
    private static void Recompenza_IdsEliminar(Personaje Personaje1, Personaje Personaje2, List<int> IdPersonajesEliminar)
    {
        if (Personaje1.Salud > 0)
        {
            string eliminado = "\n\tPersonaje2 " + Personaje2.Nombre + " ¡Eliminado!\n";
            MostrarMensajeIA(eliminado);
            Console.WriteLine("\u001b[38;2;255;255;0m{0}\u001b[0m","\tP1 => +10 en salud\n");
            Personaje1.Salud += 10;
            IdPersonajesEliminar.Add(Personaje2.Id); //guardo su id para eliminarlo despues
        }
        else
        {
            string eliminado = "\n\tPersonaje1 " + Personaje1.Nombre + " ¡Eliminado!\n";
            MostrarMensajeIA(eliminado);
            Console.WriteLine("\u001b[38;2;255;255;0m{0}\u001b[0m","\tP2 => +10 en salud\n");
            Personaje2.Salud += 10;
            IdPersonajesEliminar.Add(Personaje1.Id);//guardo su id para eliminarlo despues
        }
    }

    private static void MostrarMensajeIA(string eliminado)
    {
        foreach (char letra in eliminado)
        {
            Console.Write(letra);
            Thread.Sleep(15);
        }
    }
}