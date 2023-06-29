using Jugadores;
using Fabrica;
using Json;
internal class Program
{
    private static void Main(string[] args)
    { 
        //--------------------BATALLA DE CEREBRITOS--------------------
        
        string NombreJson = "Personajes.json";
        var ListaPersonajes = new List <Personaje> ();

        if (!PersonajesJson.Existe(NombreJson))
        {
            for (int i = 0; i < 10; i++)
            {
                var NewPersonaje = FabricaDePersonajes.crearPersonaje();
                ListaPersonajes.Add(NewPersonaje);
            }
            PersonajesJson.GuardarPersonajes(ListaPersonajes,NombreJson);//guardo la lista en .json
        }else {
            ListaPersonajes = PersonajesJson.LeerPersonajes(NombreJson);
        }
        ListaPersonajes[3].Fuerza = -1;
        MostrarPersonajes(ListaPersonajes);
        
    }

    private static void MostrarPersonajes(List <Personaje> ListaPersonaje)
    {
        Console.WriteLine("\t[ PERSONAJES]\n");
        foreach (var personaje in ListaPersonaje)
        {
            Console.WriteLine("Nombre: " + personaje.Nombre);
            Console.WriteLine("Edad: " + personaje.Edad);
            Console.WriteLine("Fecha de nacimiento: " + personaje.FechaNac.Day +"\\" + personaje.FechaNac.Month +"\\"+personaje.FechaNac.Year);
            Console.WriteLine("Tipo: " + personaje.Tipo);
            Console.WriteLine("Destreza: " + personaje.Destreza);
            Console.WriteLine("Armadura"+ personaje.Armadura);
            Console.WriteLine("Nivel: " + personaje.Nivel);
            Console.WriteLine("Salud: " + personaje.Salud);
            Console.WriteLine("Fuerza: " + personaje.Fuerza);
            Console.WriteLine("Velocidad: "+personaje.Velocidad + "\n");
            Console.WriteLine("Velocidad: "+personaje.Velocidad + "\n");

        }

    }
}