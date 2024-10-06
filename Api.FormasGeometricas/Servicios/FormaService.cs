using Api.FormasGeometricas.Modal.Respuesta;
using CodingChallenge.Data.Classes;

namespace Api.FormasGeometricas.Servicios
{
    public class FormaService : IFormaService
    {
        public RespuestaFinal CalcularArea(string tipoForma, params decimal[] dimensiones)
        {
            try
            {
                FormaGeometricaBase forma = CrearForma(tipoForma, dimensiones);
                decimal resultado = forma.CalcularArea();
                return new RespuestaFinal
                {
                    Exito = true,
                    Mensaje = $"Área del {tipoForma}: {resultado}"
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

        public RespuestaFinal CalcularPerimetro(string tipoForma, params decimal[] dimensiones)
        {
            try
            {
                FormaGeometricaBase forma = CrearForma(tipoForma, dimensiones);
                decimal resultado = forma.CalcularPerimetro();
                return new RespuestaFinal
                {
                    Exito = true,
                    Mensaje = $"Perímetro del {tipoForma}: {resultado}"
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
                "triangulo equilatero" => new TrianguloEquilatero(dimensiones[0]),
                _ => throw new ArgumentException("Tipo de forma no válido.")
            };
        }
    }
}
