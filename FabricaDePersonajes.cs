//Genere una clase para poder crear personajes aleatorios que se llame facrica de personajes
//Debe tener un método que retorne un personaje con sus respetivos datos y características cargadas.
using Jugadores;
namespace Fabrica
{
    
    public class FabricaDePersonajes
    {
        public static Personaje crearPersonaje() //metodo
        {
            var NuevoPersonaje = new Personaje();
            NuevoPersonaje.Nombre = Constantes.nombres1[NumeroAleatorio(0,20)];
            NuevoPersonaje.Tipo = Constantes.tipo[NumeroAleatorio(0,2)];
            NuevoPersonaje.Edad= NumeroAleatorio(0,301);
            NuevoPersonaje.Fuerza= NumeroAleatorio(1,11);
            NuevoPersonaje.Armadura=NumeroAleatorio(1,11);
            NuevoPersonaje.Destreza = NumeroAleatorio(1,6);
            NuevoPersonaje.Salud=100;
            NuevoPersonaje.Nivel = NumeroAleatorio(1,11);
            NuevoPersonaje.Velocidad = NumeroAleatorio(1,11);
            return NuevoPersonaje;
        }
        
        public static int NumeroAleatorio(int a, int b) //metodo
        {
            Random ValorAletorio = new Random();
            return (ValorAletorio.Next(a,b));
        }



    }

   

}