using System.IO;
using System.Net; //para api
using System.Text.Json;
using EspacioClaseApi;
namespace EspacioHelperApi
{
    class RecursoApiWeb
    {
        public static List<PersonajesHogwarts>? GetListaPersonajes(string URL)
        {
            var url = URL;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            List<PersonajesHogwarts>? personajes = null;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                personajes = JsonSerializer.Deserialize<List<PersonajesHogwarts>>(responseBody);
                            }

                        }

                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API "+ ex.Message);
                return personajes;
            }
            return personajes;
        }
    }
}