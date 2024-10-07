namespace Api.FormasGeometricas.Modal.Request
{
    public class CalcularAreaRequest
    {
        public string TipoForma { get; set; }
        public decimal[] Dimensiones { get; set; }
        public string Idioma { get; set; }
    }
}
