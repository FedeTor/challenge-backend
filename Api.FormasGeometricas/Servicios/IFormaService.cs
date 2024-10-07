using Api.FormasGeometricas.Modal.Respuesta;

namespace Api.FormasGeometricas.Servicios
{
    public interface IFormaService
    {
        RespuestaFinal CalcularArea(string tipoForma, decimal[] dimensiones, string idioma);
        RespuestaFinal CalcularPerimetro(string tipoForma, decimal[] dimensiones, string idioma);
    }
}
