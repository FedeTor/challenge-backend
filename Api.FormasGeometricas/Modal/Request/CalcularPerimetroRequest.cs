namespace Api.FormasGeometricas.Modal.Request
{
    public class CalcularPerimetroRequest
    {
        public string TipoForma { get; set; }
        public decimal[] Dimensiones { get; set; }
        public string Idioma { get; set; }
    }
}
