using Api.FormasGeometricas.Modal.Request;
using Api.FormasGeometricas.Modal.Respuesta;
using Api.FormasGeometricas.Servicios;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FormasController : ControllerBase
{
    private readonly IFormaService _formaService;

    public FormasController(IFormaService formaService)
    {
        _formaService = formaService;
    }

    [HttpPost("calcular-area")]
    public ActionResult<RespuestaFinal> CalcularArea([FromBody] CalcularAreaRequest request)
    {
        var respuesta = _formaService.CalcularArea(request.TipoForma, request.Dimensiones, request.Idioma);
        return Ok(respuesta);
    }

    [HttpPost("calcular-perimetro")]
    public ActionResult<RespuestaFinal> CalcularPerimetro([FromBody] CalcularPerimetroRequest request)
    {
        var respuesta = _formaService.CalcularPerimetro(request.TipoForma, request.Dimensiones, request.Idioma);
        return Ok(respuesta);
    }
}