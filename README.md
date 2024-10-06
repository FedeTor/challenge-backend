# WAYNI CHALLENGE

### ¡Hola Tech, bienvenido!

Primero queremos agradecerte por aceptar realizar un challenge para nosotros, dejando tu tiempo para poderte conocer cómo escribes y cómo piensas según el código de entregas.
Después de múltiples procesos de selección, llegamos a la conclusión de que el código habla por sí mismo.Con lo cual si te sientes dispuesto a afrontar el desafío, por favor tomate un rato para jugar con el problema y resolverlo.Valoramos mucho este esfuerzo más allá del resultado de tu Challenge.

### ¿Cómo participar en el proceso?

Lo primero que debes hacer es un Fork del Repositorio del Challenge. Cuando consideres que está resuelto, debes realizar un commit final a tu repositorio en la rama default elegida (main, master, etc).
También enviá un mail a [Challenge Tech](mailto:challenges+tech@waynimovil.com?subject=[GitHub]%20Challenge%20Tech) con el link al repositorio tuyo, y si tenés algún comentario sobre tu implementación, también podés agregarlo en el README.md que puedes rescribirlo completamente.

### El problema

Tenemos un método que genera un reporte en base a una colección de formas geométricas, procesando algunos datos para presentar información extra. La firma del método es:

```csharp
public static string Imprimir(List<FormaGeometrica> formas, int idioma)
```

Al mismo tiempo, encontramos muy difícil el poder agregar o bien una nueva forma geométrica, o imprimir el reporte en otro idioma. Nos gustaría poder dar soporte para que el usuario pueda agregar otros tipos de formas u obtener el reporte en otros idiomas, pero extender la funcionalidad del código es muy doloroso. ¿Nos podrías dar una mano a refactorizar la clase FormaGeometrica? Dentro del código encontrarás un **TODO** con nuevos requerimientos a satisfacer una vez completada la refactorización.

Acompañando al proyecto encontrarás una serie de tests unitarios (librería NUnit) que describen el comportamiento del método Imprimir. **Se puede modificar cualquier cosa del código y de los tests, con la única condición que los tests deben pasar correctamente al entregar la solución.**

De último momento nos llegó un requerimiento de la dirección donde nos piden adicionalmente a lo antes mencionado exponer el método de CalcularPerimetro y CalcularArea en un Endpoint público a consumir. No es necesario desarrollarlo pero si es necesario documentar cómo se consumiría estos dos métodos y cómo sería el llama y el retorno de la API.

### Cómo funciona

Lo que te encontrás al levantar la .sln es una librería con el objeto de negocio FormaGeometrica, y un pequeño proyecto con test unitarios sobre el método de impresión de reporte.

La resolución es libre y cómo encarar el problema queda en el criterio de quien lo resuelva!

**¡¡Éxitos padawan!!**



Buenos dias, envio algunos comentarios sobre los cambios hechos:

- Refactorizacion de la clase FormaGeometrica:
Utilice un enfoque de abstraccion, haciendo foco en los principios de programación orientada a objetos, como Herencia, encapsulamiento, polimorfismo.
Utilice principios SOLID, como el principio de responsabilidad unica y el principio abierto cerrado.

- Se agregó un proyecto web api q contiene los endpoint para calcular el perimetro y area reutilizando las clases existentes de las formas geometricas, se agrega también su respectiva documentación en la carpeta Documentacion dentro del proyecto web api.
  Utilice .net 8 y le di un enfoque diferente, utilizando interfaces y servicios.

Sin mas, saludos!
