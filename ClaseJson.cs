using Jugadores;
using System.Text.Json;
namespace Json
{
    public class PersonajesJson
    {
        //Crear un método llamado GuardarPersonajes que reciba una lista de personajes, el
        //nombre del archivo y lo guarde en formato Json. 

        public static void GuardarPersonajes (List<Personaje>listaPersonajes, string nombreArchivo)
        {
            String formatoJson = JsonSerializer.Serialize(listaPersonajes);
            File.WriteAllText(nombreArchivo, formatoJson);
        }

        //Crear un método llamado LeerPersonajes que reciba un nombre de archivo y retorne
        //la lista de personajes incluidos en el Json.

        public static List<Personaje> LeerPersonajes (string nombreArchivo)
        {
            var listado = new List<Personaje>();
            string JsonAtexto = File.ReadAllText(nombreArchivo);
            listado = JsonSerializer.Deserialize<List<Personaje>>(JsonAtexto);
            return listado; // retorno la lista recuperada
        }

        //Crear un método llamado Existe que reciba un nombre de archivo y que retorne un
        //True si existe y tiene datos o False en caso contrario.

        public static bool Existe(string nombreArchivo)
        {
            if (File.Exists(nombreArchivo))
            {
                return true;
            }
            return false;

        }
    }
}