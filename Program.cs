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
            PersonajesJson.GuardarPersonajes(ListaPersonajes,NombreJson);
        }else {
            ListaPersonajes = PersonajesJson.LeerPersonajes(NombreJson);
        }
        MostrarPersonajes(ListaPersonajes);
        
    }

    private static void MostrarPersonajes(List <Personaje> ListaPersonaje)
    {
        Console.WriteLine("\t[ PERSONAJES]\n");
        foreach (var personaje in ListaPersonaje)
        {
            Console.WriteLine("Nombre: " + personaje.Nombre);
            Console.WriteLine("Edad: " + personaje.Edad);
            Console.WriteLine("Tipo: " + personaje.Tipo);
            Console.WriteLine("Destreza: " + personaje.Destreza);
            Console.WriteLine("Armadura"+ personaje.Armadura);
            Console.WriteLine("Nivel: " + personaje.Nivel);
            Console.WriteLine("Salud: " + personaje.Salud);
            Console.WriteLine("Velocidad: "+personaje.Velocidad + "\n");
        }

    }
}