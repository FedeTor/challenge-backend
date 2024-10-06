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

    [HttpGet("area/{tipoForma}")]
    public ActionResult<RespuestaFinal> CalcularArea(string tipoForma, [FromQuery] decimal[] dimensiones)
    {
        var respuesta = _formaService.CalcularArea(tipoForma, dimensiones);
        return respuesta.Exito ? Ok(respuesta) : BadRequest(respuesta);
    }

    [HttpGet("perimetro/{tipoForma}")]
    public ActionResult<RespuestaFinal> CalcularPerimetro(string tipoForma, [FromQuery] decimal[] dimensiones)
    {
        var respuesta = _formaService.CalcularPerimetro(tipoForma, dimensiones);
        return respuesta.Exito ? Ok(respuesta) : BadRequest(respuesta);
    }
}

