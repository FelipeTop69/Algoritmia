using System.Text;

namespace EjerciciosAlgoritmia
{
    public class SolucionesAlgoritmia
    {
        // 11. Verificar Número Autocompuesto - Complejo
        public static bool NumCompuesto(int num)
        {
            List<int> divisores = [];
            for(int i = 0; i < num; i++)
            {
                if(num % i == 0)
                    divisores.Add(i);
            }


            for(int i = 0; i < divisores.Count; i++)
            {
                for(int z = i +1 ; z < divisores.Count; i++)
                {
                    string numString = divisores[i].ToString() + divisores[z].ToString();
                    if(int.Parse(numString) == num)
                        return true;
                }
            }

            return false;
        }

        // 12. Detector de Números Vampiro - Complejo
        public static bool NumVampiro(int num)
        {
            if (num < 1000 || num > 9999) return false;

            string numStr = num.ToString();
            for(int i = 10;  i <= 99 ; i++)
            {
                if(num % i == 0)
                {
                    int factor = num / i;
                    if(factor >= 10 && factor <= 99)
                    {
                        string factores = i.ToString() + factor.ToString();
                    }
                }
            }

            return false;
        }

        // 13. Verificar Sudoku Parcial

        // 14. Simulador de Crecimiento Poblacional

        // 15. Detector de Subcadenas Repetitivas - Complejo
        public static string FindSubcadena(string texto)
        {
            for(int longitud = 1; longitud < texto.Length / 2; longitud++)
            {
                string subCadena = texto.Substring(0, longitud);
                string repetida = "";

                for(int i = 0; i < texto.Length / longitud; i++)
                {
                    repetida += subCadena;
                }

                if(repetida == texto)
                {
                    return subCadena;
                }
            }

            return texto;
        }

        // 16. Simulador de Juego de Dados Múltiples - Complejo
        public static Dictionary<int, int> ProbabilidadDados(int numDados, int numLanzamientos)
        {
            Random random = new Random();
            Dictionary<int, int> resultados = new Dictionary<int, int>();

            for(int i = 0; i < numLanzamientos; i++)
            {
                int suma = 0;
                for(int z = 0; z < numDados; z++)
                {
                    suma += random.Next(1,7);
                }

                if(resultados.ContainsKey(suma))
                    resultados[suma]++;
                else
                    resultados[suma] = 1;
            }

            return resultados;
        }

        // 17. Simulador de Sistema de Calificaciones Ponderadas

        // 18. Contador de Ensambles Válidos de Fichas

        // 19. Simulador de Parpadeo Alternante

        // 20. Contador de Giros Equilibrados

        // 21. Agrupador por Dígito Final

        // 22. Detector de Cambios Bruscos

        // 23. Verificador de Encaje de Fichas

        // 24. Contador de Zonas Oscuras

        // 25. Medidor de Progreso del Cubo

        // 26. Analizador de Racha Ganadora

        // 27. Filtro de suma numérico

        // 28. Orden de densidad numérica - Complejo


        // 29. Validador de Valor según posición

        // 30. Ajustador de Arreglos por Mitades - Complejo
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIOS DE ALGORITMIA ===\n");

            Console.WriteLine("16. Simulación de Dados (2 dados, 100 lanzamientos):");
            var resultadosDados = SolucionesAlgoritmia.ProbabilidadDados(2, 1000);
            foreach (var kvp in resultadosDados.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Suma {kvp.Key}: {kvp.Value} veces");
            }

            Console.WriteLine("\n=== FIN DE LAS PRUEBAS ===");
            Console.ReadKey();
        }
    }

}