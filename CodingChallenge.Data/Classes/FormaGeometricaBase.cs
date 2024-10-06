using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public abstract class FormaGeometricaBase
    {
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();

        public static AdministrarIdioma AdministrarIdioma { get; set; }

        public static string Imprimir(List<FormaGeometricaBase> formas, string idioma)
        {
            var sb = new StringBuilder();
            AdministrarIdioma = new AdministrarIdioma();
            var translations = AdministrarIdioma.GetTranslations(idioma);

            if (!formas.Any())
            {
                sb.Append($"<h1>{translations.lista_vacia}</h1>");
            }
            else
            {
                sb.Append($"<h1>{translations.reporte.singular}</h1>");

                var resumenFormas = formas
                    .GroupBy(f => f.GetType())
                    .Select(g => new
                    {
                        Tipo = g.Key,
                        Cantidad = g.Count(),
                        AreaTotal = g.Sum(f => f.CalcularArea()),
                        PerimetroTotal = g.Sum(f => f.CalcularPerimetro())
                    });

                foreach (var forma in resumenFormas)
                {
                    sb.Append(ObtenerLinea(forma.Cantidad, forma.AreaTotal, forma.PerimetroTotal, forma.Tipo, translations));
                }

                sb.Append($"{translations.total}:<br/>");
                sb.Append($"{formas.Count} {translations.formas} ");
                sb.Append($"{translations.perimetro} {formas.Sum(f => f.CalcularPerimetro()):#.##} ");
                sb.Append($"{translations.area} {formas.Sum(f => f.CalcularArea()):#.##}");
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Type tipo, dynamic translations)
        {
            if (cantidad > 0)
            {
                var nombreForma = TraducirForma(tipo, cantidad, translations);
                return $"{cantidad} {nombreForma} | {translations.area} {area:#.##} | {translations.perimetro} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(Type tipo, int cantidad, dynamic translations)
        {
            switch (tipo.Name.ToLower())
            {
                case "cuadrado":
                    return cantidad == 1 ? translations.cuadrado.singular : translations.cuadrado.plural;
                case "circulo":
                    return cantidad == 1 ? translations.circulo.singular : translations.circulo.plural;
                case "trianguloequilatero":
                    return cantidad == 1 ? translations.triangulo.singular : translations.triangulo.plural;
                case "rectangulo":
                    return cantidad == 1 ? translations.rectangulo.singular : translations.rectangulo.plural;
                case "trapecio":
                    return cantidad == 1 ? translations.trapecio.singular : translations.trapecio.plural;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tipo), "Forma desconocida");
            }
        }
    }
}
