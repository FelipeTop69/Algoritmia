using System.Text;

namespace EjerciciosAlgoritmia
{
    public class SolucionesAlgoritmia
    {
        // 1. Verificar Número Autocompuesto
        public static bool NumCompuesto(int num)
        { 
            List<int> divisores = [];
            for (int i = 1; i < num; i++)
            {
                if(num % i == 0)
                {
                    divisores.Add(i);
                }
            }

            for (int i = 1; i < divisores.Count; i++)
            {
                for(int z = i + 1; i < divisores.Count; i++)
                {
                    string cadenaNum = divisores[i].ToString() + divisores[z].ToString();
                    if (int.Parse(cadenaNum) == num)
                        return true;
                }
            }

            return false;
        }

        // 2. Calculadora de Distancia Manhattan

        // 3. Generador de Secuencia Tribonacci
        public static List<long> Tribonacci(int num)
        {
            List<long> secuencia = [];
            if (num >= 1) secuencia.Add(0);
            if (num >= 2) secuencia.Add(0);
            if (num >= 3) secuencia.Add(1);

            for (int i = 3; i < num; i++)
            {
                long siguiente = secuencia[i - 1] + secuencia[i - 2] + secuencia[i - 3];
                secuencia.Add(siguiente);
            }

            return secuencia;
        }

        // 4. Detector de Números Vampiro
        public static bool NumVampiro (int num)
        {
            if (num < 1000 || num > 9999) return false;

            string numStr = num.ToString();
            for (int i = 10; i <= 99; i++)
            {
                if(num % i == 0)
                {
                    int factor = num / i;
                    if (factor >= 10 && factor <= 99)
                    {
                        string factores = i.ToString() + factor.ToString();
                        if (TienenMismosDigitos(numStr, factores))
                            return true;
                    }
                }
            }

            return false;
        }
        private static bool TienenMismosDigitos(string str1, string str2)
        {
            return string.Concat(str1.OrderBy(c => c)) == string.Concat(str2.OrderBy(c => c));
        }

        // 5. Cifrado César 
        public static string CifradoCesar(string texto, int desplazamiento)
        {
            StringBuilder resultado = new StringBuilder();
            desplazamiento = desplazamiento % 26;

            foreach (char c in texto)
            {
                if (char.IsLetter(c))
                {
                    int charBase = char.IsUpper(c) ? 'A' : 'a';
                    int posicion = c - charBase;
                    int nuevaPosicion = (posicion + desplazamiento) % 26;
                    if (nuevaPosicion < 0)
                        nuevaPosicion += 26;
                    resultado.Append((char)(charBase + nuevaPosicion));
                }
                else
                {
                    resultado.Append(c);
                }
            }

            return resultado.ToString();
        }

        // 6. Calculadora de Resistencias en Serie/Paralelo

        // 7. Verificar Sudoku Parcial
        public static bool SudokuParcial(List<int> nums)
        {
            HashSet<int> vistos = new HashSet<int>();

            foreach(int num in nums)
            {
                if (num != 0)
                {
                    if(num < 1 || num > 9 || vistos.Contains(num))
                        return false;

                    vistos.Add(num);
                }
            }

            return true;
        }

        // 8. Simulador de Crecimiento Poblacional

        // 10. Calculadora de Índice de Masa Corporal (IMC)

        // 11. Generador de Patrones ASCII

        // 12. Simulador de Lanzamiento de Proyectil

        // 13. Verificador de Formato de Email Básico

        // 14. Calculadora de Interés Compuesto

        // 15. Detector de Subcadenas Repetitivas
        public static string StringRepeat(string text)
        {
            for (int longitud = 1; longitud < text.Length / 2; longitud++)
            {
                string subString = text.Substring(0, longitud);
                string repetir = "";

                for (int i = 0; i < text.Length / longitud; i++)
                {
                    repetir += subString;
                }

                if(repetir == text)
                {
                    return subString;
                }
            }

            return text;
        }

        // 16. Simulador de Juego de Dados Múltiples
        public static Dictionary<int, int> LanzarDados(int numLanzamientos, int numDados)
        {
            Random random = new Random();
            Dictionary<int, int> resultados = new Dictionary<int, int>();

            for (int i = 0; i < numLanzamientos; i++)
            {
                int sum = 0;
                for (int z = 0; z < numDados; z++)
                {
                    sum += random.Next(1, 7); // 1 a 6 inclusive
                }

                if (resultados.ContainsKey(sum))
                    resultados[sum]++;
                else
                    resultados[sum] = 1;
            }

            return resultados;
        }

        // 17. Conversor de Tiempo Unix

        // 18. Calculadora de Área de Polígonos Regulares

        // 19. Detector de Anagramas Multi-palabra

        // 20. Simulador de Sistema de Calificaciones Ponderadas
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIOS DE ALGORITMIA ===\n");

            Console.WriteLine("5. Cifrado César:");
            Console.WriteLine($"'HOLA' con desplazamiento 3: {SolucionesAlgoritmia.CifradoCesar("KROD", -3)}");
            Console.WriteLine();

            Console.WriteLine("\n=== FIN DE LAS PRUEBAS ===");
            Console.ReadKey();
        }
    }

}