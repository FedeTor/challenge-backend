using Api.FormasGeometricas.Modal.Respuesta;
using CodingChallenge.Update.Data;

namespace Api.FormasGeometricas.Servicios
{
    public class FormaService : IFormaService
    {
        private readonly AdministrarIdioma _administrarIdioma;

        public FormaService(AdministrarIdioma administrarIdioma)
        {
            _administrarIdioma = administrarIdioma;
        }

        public RespuestaFinal CalcularArea(string tipoForma, decimal[] dimensiones, string idioma)
        {
            try
            {
                FormaGeometricaBase forma = CrearForma(tipoForma, dimensiones);
                decimal resultado = forma.CalcularArea();
                bool esSingular = DeterminarSiEsSingular(tipoForma);
                string tipoFormaTraducido = ObtenerMensajePorIdioma(tipoForma, idioma, esSingular);
                string mensajeArea = _administrarIdioma.GetTranslations(idioma).area;
                return new RespuestaFinal
                {
                    Exito = true,
                    Mensaje = $"{mensajeArea} {tipoFormaTraducido}: {resultado}"
                };
            }
            catch (Exception ex)
            {
                return new RespuestaFinal
                {
                    Exito = false,
                    Mensaje = ex.Message
                };
            }
        }

        public RespuestaFinal CalcularPerimetro(string tipoForma, decimal[] dimensiones, string idioma)
        {
            try
            {
                FormaGeometricaBase forma = CrearForma(tipoForma, dimensiones);
                decimal resultado = forma.CalcularPerimetro();
                bool esSingular = DeterminarSiEsSingular(tipoForma);
                string tipoFormaTraducido = ObtenerMensajePorIdioma(tipoForma, idioma, esSingular);
                string mensajePerimetro = _administrarIdioma.GetTranslations(idioma).perimetro;
                return new RespuestaFinal
                {
                    Exito = true,
                    Mensaje = $"{mensajePerimetro} {tipoFormaTraducido}: {resultado}"
                };
            }
            catch (Exception ex)
            {
                return new RespuestaFinal
                {
                    Exito = false,
                    Mensaje = ex.Message
                };
            }
        }

        private FormaGeometricaBase CrearForma(string tipoForma, decimal[] dimensiones)
        {
            return tipoForma.ToLower() switch
            {
                "cuadrado" => new Cuadrado(dimensiones[0]),
                "circulo" => new Circulo(dimensiones[0]),
                "rectangulo" => new Rectangulo(dimensiones[0], dimensiones[1]),
                "trapecio" => new Trapecio(dimensiones[0], dimensiones[1], dimensiones[2], dimensiones[3], dimensiones[4]),
                "triangulo" => new TrianguloEquilatero(dimensiones[0]),
                _ => throw new ArgumentException("Tipo de forma no válido.")
            };
        }

        private string ObtenerMensajePorIdioma(string tipoForma, string idioma, bool esSingular)
        {
            try
            {
                var traducciones = _administrarIdioma.GetTranslations(idioma);
                string tipoFormaTraducido = traducciones[tipoForma][esSingular ? "singular" : "plural"];
                return tipoFormaTraducido;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la traducción para el idioma {idioma}: {ex.Message}");
            }
        }

        private bool DeterminarSiEsSingular(string tipoForma)
        {
            return !tipoForma.EndsWith("s", StringComparison.OrdinalIgnoreCase);
        }
    }
}
