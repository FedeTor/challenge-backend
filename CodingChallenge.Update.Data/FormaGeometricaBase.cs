using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Update.Data
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
                var tipoForma = ObtenerTipoForma(tipo);
                var nombreForma = TraducirForma(tipoForma, cantidad, translations);
                return $"{cantidad} {nombreForma} | {translations.area} {area:#.##} | {translations.perimetro} {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static TipoForma ObtenerTipoForma(Type tipo)
        {
            return tipo.Name.ToLower() switch
            {
                "cuadrado" => TipoForma.Cuadrado,
                "circulo" => TipoForma.Circulo,
                "trianguloequilatero" => TipoForma.TrianguloEquilatero,
                "rectangulo" => TipoForma.Rectangulo,
                "trapecio" => TipoForma.Trapecio,
                _ => throw new ArgumentOutOfRangeException(nameof(tipo), "Forma desconocida")
            };
        }
        private static string TraducirForma(TipoForma tipoForma, int cantidad, dynamic translations)
        {
            return tipoForma switch
            {
                TipoForma.Cuadrado => cantidad == 1 ? translations.cuadrado.singular : translations.cuadrado.plural,
                TipoForma.Circulo => cantidad == 1 ? translations.circulo.singular : translations.circulo.plural,
                TipoForma.TrianguloEquilatero => cantidad == 1 ? translations.triangulo.singular : translations.triangulo.plural,
                TipoForma.Rectangulo => cantidad == 1 ? translations.rectangulo.singular : translations.rectangulo.plural,
                TipoForma.Trapecio => cantidad == 1 ? translations.trapecio.singular : translations.trapecio.plural,
                _ => throw new ArgumentOutOfRangeException(nameof(tipoForma), "Forma desconocida")
            };
        }
    }
}
