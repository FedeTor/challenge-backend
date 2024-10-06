using Api.FormasGeometricas.Modal.Respuesta;

namespace Api.FormasGeometricas.Servicios
{
    public interface IFormaService
    {
        RespuestaFinal CalcularArea(string tipoForma, params decimal[] dimensiones);
        RespuestaFinal CalcularPerimetro(string tipoForma, params decimal[] dimensiones);
    }
}
