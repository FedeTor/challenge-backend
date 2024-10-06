using CodingChallenge.Data.Classes;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class FormasGeometricasTests
{
    [TestCase]
    public void TestResumenListaVacia()
    {
        Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
            FormaGeometricaBase.Imprimir(new List<FormaGeometricaBase>(), "es"));
    }

    [TestCase]
    public void TestResumenListaVaciaFormasEnIngles()
    {
        Assert.AreEqual("<h1>Empty list of shapes!</h1>",
            FormaGeometricaBase.Imprimir(new List<FormaGeometricaBase>(), "en"));
    }

    [TestCase]
    public void TestResumenListaConUnCuadrado()
    {
        var cuadrados = new List<FormaGeometricaBase> { new Cuadrado(5) };

        var resumen = FormaGeometricaBase.Imprimir(cuadrados, "es");

        Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Área 25", resumen);
    }

    [TestCase]
    public void TestResumenListaConMasCuadrados()
    {
        var cuadrados = new List<FormaGeometricaBase>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

        var resumen = FormaGeometricaBase.Imprimir(cuadrados, "en");

        Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
    }

    [TestCase]
    public void TestResumenListaConMasTipos()
    {
        var formas = new List<FormaGeometricaBase>
            {
                new Cuadrado(5),
                new Circulo(3m),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

        var resumen = FormaGeometricaBase.Imprimir(formas, "en");

        Assert.AreEqual(
            "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52,03 | Perimeter 36,13 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 115,73 Area 130,67",
            resumen);
    }

    [TestCase]
    public void TestResumenListaConMasTiposEnCastellano()
    {
        var formas = new List<FormaGeometricaBase>
            {
                new Cuadrado(5),
                new Circulo(3m),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };

        var resumen = FormaGeometricaBase.Imprimir(formas, "es");

        Assert.AreEqual(
            "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 52,03 | Perímetro 36,13 <br/>3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 115,73 Área 130,67",
            resumen);
    }

    [TestCase]
    public void TestResumenListaConMasTiposEnFrances()
    {
        var formas = new List<FormaGeometricaBase>
        {
            new Cuadrado(5),
            new Circulo(3m),
            new TrianguloEquilatero(4),
            new Cuadrado(2),
            new TrianguloEquilatero(9),
            new Circulo(2.75m),
            new TrianguloEquilatero(4.2m)
        };

        var resumen = FormaGeometricaBase.Imprimir(formas, "fr");

        Assert.AreEqual(
            "<h1>Rapport des formes</h1>2 Carrés | Aire 29 | Périmètre 28 <br/>2 Cercles | Aire 52,03 | Périmètre 36,13 <br/>3 Triangles | Aire 49,64 | Périmètre 51,6 <br/>TOTAL:<br/>7 formes Périmètre 115,73 Aire 130,67",
            resumen);
    }


    [TestCase]
    public void TestResumenCuadradoRetornaReporteCorrecto()
    {
        var formas = new List<FormaGeometricaBase> { new Cuadrado(5) };

        var resumen = FormaGeometricaBase.Imprimir(formas, "es");

        Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Área 25", resumen);
    }

    [TestCase]
    public void TestResumenCirculoRetornaReporteCorrecto()
    {
        var formas = new List<FormaGeometricaBase> { new Circulo(3) };

        var resultado = FormaGeometricaBase.Imprimir(formas, "es");

        Assert.AreEqual("<h1>Reporte de Formas</h1>1 Círculo | Área 28,27 | Perímetro 18,85 <br/>TOTAL:<br/>1 formas Perímetro 18,85 Área 28,27", resultado);
    }

    [TestCase]
    public void TestResumenRectanguloRetornaReporteCorrecto()
    {
        var formas = new List<FormaGeometricaBase>{ new Rectangulo(4, 6) };

        var resumen = FormaGeometricaBase.Imprimir(formas, "es");

        Assert.AreEqual("<h1>Reporte de Formas</h1>1 Rectángulo | Área 24 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Área 24", resumen);
    }

    [TestCase]
    public void TestResumenTrapecioRetornaReporteCorrecto()
    {
        var baseMenor = 4m;
        var baseMayor = 6m;
        var altura = 5m;
        var lado1 = 3m;
        var lado2 = 4m;

        var trapecio = new Trapecio(baseMayor, baseMenor, altura, lado1, lado2);
        var formas = new List<FormaGeometricaBase> { trapecio };

        var resumen = FormaGeometricaBase.Imprimir(formas, "es");

        Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio | Área 25 | Perímetro 17 <br/>TOTAL:<br/>1 formas Perímetro 17 Área 25", resumen);
    }

    [TestCase]
    public void TestResumenTrianguloEquilateroRetornaReporteCorrecto()
    {
        var formas = new List<FormaGeometricaBase>{ new TrianguloEquilatero(6) };

        var resumen = FormaGeometricaBase.Imprimir(formas, "es");

        Assert.AreEqual("<h1>Reporte de Formas</h1>1 Triángulo | Área 15,59 | Perímetro 18 <br/>TOTAL:<br/>1 formas Perímetro 18 Área 15,59", resumen);
    }
}
