using System.IO;
using System.Net; //para api
using System.Text.Json;
using Api;
namespace HelperApi
{
    class RecursoApiWeb
    {
    public static List<PersonajesHogwarts> GetApi(string URL)
    {
        var url = URL;
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        List<PersonajesHogwarts>? personajes = new List<PersonajesHogwarts>();
        try
        {
            using (WebResponse response = request.GetResponse())
            {
                using (Stream strReader = response.GetResponseStream())
                {
                    if (strReader != null)
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
            Console.WriteLine("Problemas de acceso a la API");
        }

        return personajes;
    }  
    }
}