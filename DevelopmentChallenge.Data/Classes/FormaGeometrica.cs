/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometrica
    {
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            var traductor = Traductor.Instancia;

            if (!formas.Any())
            {
                sb.Append(traductor.Traduccion("<h1>Lista vacía de formas!</h1>", idioma));
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(traductor.Traduccion("<h1>Reporte de Formas</h1>", idioma));

                var formasReporte = formas.GroupBy(x => x.Nombre)
                    .Select(gr => new
                    {
                        TipoForma = gr.Key,
                        Permiteros = gr.Sum(x => x.CalcularPerimetro()),
                        Areas = gr.Sum(x => x.CalcularArea()),
                        Formas = gr.Count()
                    }).ToList();
                    

                foreach(var forma in formasReporte)
                {
                    sb.Append(ObtenerLinea(forma.Formas, forma.Areas, forma.Permiteros, forma.TipoForma, idioma));
                }

                var totalFormas = formasReporte.Sum(x => x.Formas);
                var totalPerimetros = formasReporte.Sum(x => x.Permiteros);
                var totalAreas = formasReporte.Sum(x=> x.Areas);
                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(totalFormas + " " + traductor.Traduccion("formas",idioma) + " ");
                sb.Append($"{traductor.Traduccion("Perimetro", idioma)} " + (totalPerimetros).ToString("#.##") + " ");
                sb.Append("Area " + (totalAreas).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, string nombre, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Traductor.Castellano)
                    return $"{cantidad} {TraducirForma(nombre, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(nombre, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(string nombre, int cantidad, int idioma)
        {
            var traductor = Traductor.Instancia;

            return traductor.Traduccion(cantidad == 1 ? nombre : $"{nombre}s", idioma);
        }

        public virtual decimal CalcularArea()
        {
            throw new NotImplementedException(@"Forma desconocida");
        }
        public virtual decimal CalcularPerimetro()
        {
            throw new NotImplementedException(@"Forma deconocida");
        }
        public virtual string Nombre
        {
            get { throw new NotImplementedException(@"Forma desconocida"); }
        }
    }
}