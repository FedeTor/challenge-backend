using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CodingChallenge.Data.Classes
{
    public class AdministrarIdioma
    {
        private readonly Dictionary<string, dynamic> _translations;

        private string filePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "CodingChallenge.Data", "traducciones.json"));

        public AdministrarIdioma()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Archivo no encontrado: {filePath}");
                throw new FileNotFoundException($"No se encontró el archivo de traducción en la ruta: {filePath}");
            }

            try
            {
                var json = File.ReadAllText(filePath);
                _translations = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);

                if (_translations == null)
                {
                    Console.WriteLine("El archivo de traducción no se deserializó correctamente.");
                    throw new InvalidOperationException("Error en la deserialización del archivo de traducción.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer o deserializar el archivo de traducción: {ex.Message}");
                throw;
            }
        }

        public dynamic GetTranslations(string idioma)
        {
            if (_translations.ContainsKey(idioma))
            {
                return _translations[idioma];
            }
            throw new ArgumentException("Idioma no soportado.");
        }

    }
}
