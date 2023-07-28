using System.Text.Json.Serialization;

namespace EspacioClaseApi
{
    public class PersonajesHogwarts
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("personaje")]
        public string? Personaje { get; set; }

        [JsonPropertyName("apodo")]
        public string? Apodo { get; set; }

        [JsonPropertyName("estudianteDeHogwarts")]
        public bool EstudianteDeHogwarts { get; set; }

        [JsonPropertyName("casaDeHogwarts")]
        public string? CasaDeHogwarts { get; set; }

        [JsonPropertyName("interpretado_por")]
        public string? Interpretado_por { get; set; }

        [JsonPropertyName("hijos")]
        public List<string>? Hijos { get; set; }

        [JsonPropertyName("imagen")]
        public string? Imagen { get; set; }
    }

}
