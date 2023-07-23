//Genere una clase para poder crear personajes aleatorios que se llame facrica de personajes
//Debe tener un método que retorne un personaje con sus respetivos datos y características cargadas.
using Jugadores;
using Api;
namespace Fabrica
{
    public static class FabricaDePersonajes
    {
        public static Personaje crearPersonaje(string nombre, int id, string apodo) //metodo

        {
            var NuevoPersonaje = new Personaje();
        
            NuevoPersonaje.Nombre = nombre;
            NuevoPersonaje.FechaNac = new DateTime(NumeroAleatorio(1723,2024),NumeroAleatorio(1,13),NumeroAleatorio(1,31));
            NuevoPersonaje.Edad= edad(NuevoPersonaje.FechaNac.Year);
            NuevoPersonaje.Fuerza= NumeroAleatorio(1,11);
            NuevoPersonaje.Armadura=NumeroAleatorio(1,11);
            NuevoPersonaje.Destreza = NumeroAleatorio(1,6);
            NuevoPersonaje.Salud=100;
            NuevoPersonaje.Nivel = NumeroAleatorio(1,11);
            NuevoPersonaje.Velocidad = NumeroAleatorio(1,11);
            NuevoPersonaje.Apodo=apodo;

            if(id >= 1 && id <=9 || id >=12 && id <=14 )
            {
                NuevoPersonaje.Tipo = "Estudiante";
            } else {
                if (id >= 15 && id <=18 || id ==20)
                {
                    NuevoPersonaje.Tipo = "Profesor";
                } else {
                    if (id == 21 || id == 22)
                    {
                        NuevoPersonaje.Tipo = "Mago Tenebroso";
                    }else
                    {
                        NuevoPersonaje.Tipo ="Mago Bondadoso";
                    }
                }
            }
           
            return NuevoPersonaje;
        }
        
        public static int NumeroAleatorio(int a, int b) //metodo
        {
            Random ValorAletorio = new Random();
            return (ValorAletorio.Next(a,b));
        }
        public static int edad (int anioNac)
        {
            int anioActual = DateTime.Now.Year;

            return (anioActual-anioNac);
        } 



    }

   

}