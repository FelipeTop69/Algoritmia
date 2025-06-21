using System.Text;

namespace EjerciciosAlgoritmia
{
    public class SolucionesAlgoritmia
    {
        // 1. Verificar Número Autocompuesto - Complejo 
        public static bool EsNumeroAutocompuesto(int numero)
        {
            List<int> divisores = [];
            for (int i = 1; i < numero; i++)
            {
                if (numero % i == 0)    
                    divisores.Add(i);
            }

            for (int i = 0; i < divisores.Count; i++)
            {
                for (int j = i + 1; j < divisores.Count; j++)
                {
                    string concatenacion = divisores[i].ToString() + divisores[j].ToString();
                    if (int.Parse(concatenacion) == numero)
                        return true;
                }
            }
            return false;
        }

        // 2. Calculadora de Distancia Manhattan - Facil
        public static int DistanciaManhattan(int x1, int y1, int x2, int y2)
        {
            int valorAbsX = Math.Abs(x1 - x2);
            int valorAbsY = Math.Abs(y1 - y2);
            int distManhattan = valorAbsX + valorAbsY;
            return distManhattan;
        }

        // 4. Detector de Números Vampiro - Complejo
        public static bool EsNumeroVampiro(int numero)
        {
            if (numero < 1000 || numero > 9999) return false;

            string numeroStr = numero.ToString();
            for (int i = 10; i <= 99; i++)
            {
                if (numero % i == 0)
                {
                    int factor = numero / i;
                    if (factor >= 10 && factor <= 99)
                    {
                        string factores = i.ToString() + factor.ToString();
                        if (TienenMismosDigitos(numeroStr, factores))
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

        // 6. Calculadora de Resistencias en Serie/Paralelo - Facil
        public static double CalcularResistencia(double[] resistencias, bool enSerie)
        {
            if (enSerie)
            {
                return resistencias.Sum();
            }
            else
            {
                double suma = 0;
                foreach (double r in resistencias)
                {
                    if (r != 0) suma += 1.0 / r;
                }
                return suma != 0 ? 1.0 / suma : 0;
            }
        }

        // 7. Verificar Sudoku Parcial - Complejo
        public static bool VerificarSudokuParcial(int[] numeros)
        {
            HashSet<int> vistos = new HashSet<int>();
            foreach (int num in numeros)
            {
                if (num != 0)
                {
                    if (num < 1 || num > 9 || vistos.Contains(num))
                        return false;
                    vistos.Add(num);
                }
            }
            return true;
        }

        // 8. Simulador de Crecimiento Poblacional - Complejo
        public static double CalcularCrecimientoPoblacional(double poblacionInicial,
            double tasaNatalidad, double tasaMortalidad, int años)
        {
            double poblacion = poblacionInicial;
            double tasaCrecimiento = (tasaNatalidad - tasaMortalidad) / 100.0;

            for (int i = 0; i < años; i++)
            {
                poblacion += poblacion * tasaCrecimiento;
            }
            return Math.Round(poblacion, 2);
        }

        // 10. Calculadora de Índice de Masa Corporal (IMC) - Facil
        public static (double imc, string clasificacion) CalcularIMC(double peso, double altura)
        {
            double imc = peso / (altura * altura);
            string clasificacion;

            if (imc < 18.5) clasificacion = "Bajo peso";
            else if (imc < 25) clasificacion = "Normal";
            else if (imc < 30) clasificacion = "Sobrepeso";
            else clasificacion = "Obesidad";

            return (Math.Round(imc, 2), clasificacion);
        }

        // 12. Simulador de Lanzamiento de Proyectil - Facil
        public static (double alcance, double alturaMaxima) CalcularProyectil(
            double velocidadInicial, double angulo)
        {
            double anguloRad = angulo * Math.PI / 180;
            double g = 9.81; // gravedad

            double alcance = (velocidadInicial * velocidadInicial * Math.Sin(2 * anguloRad)) / g;
            double alturaMaxima = (velocidadInicial * velocidadInicial *
                Math.Sin(anguloRad) * Math.Sin(anguloRad)) / (2 * g);

            return (Math.Round(alcance, 2), Math.Round(alturaMaxima, 2));
        }

        // 13. Verificador de Formato de Email Básico - Facil
        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            int arrobaIndex = email.IndexOf('@');
            if (arrobaIndex <= 0 || arrobaIndex == email.Length - 1) return false;

            string dominio = email.Substring(arrobaIndex + 1);
            if (!dominio.Contains('.')) return false;

            if (dominio.StartsWith(".") || dominio.EndsWith(".")) return false;

            return email.All(c => char.IsLetterOrDigit(c) 
                || c == '@' || c == '.' || c == '_' || c == '-');
        }

        // 14. Calculadora de Interés Compuesto - Facil
        public static double CalcularInteresCompuesto(double principal, double tasa, int tiempo)
        {
            return Math.Round(principal * Math.Pow(1 + tasa / 100, tiempo), 2);
        }

        // 15. Detector de Subcadenas Repetitivas - Complejo
        public static string EncontrarSubcadenaRepetitiva(string texto)
        {
            for (int longitud = 1; longitud <= texto.Length / 2; longitud++)
            {
                string subcadena = texto.Substring(0, longitud);
                string repetida = "";

                for (int i = 0; i < texto.Length / longitud; i++)
                {
                    repetida += subcadena;
                }

                if (repetida == texto)
                {
                    return subcadena;
                }
            }   
            return texto;
        }

        // 16. Simulador de Juego de Dados Múltiples - Complejo
        public static Dictionary<int, int> SimularDados(int numDados, int numLanzamientos)
        {
            Random random = new Random();
            Dictionary<int, int> resultados = new Dictionary<int, int>();

            for (int i = 0; i < numLanzamientos; i++)
            {
                int suma = 0;
                for (int j = 0; j < numDados; j++)
                {
                    suma += random.Next(1, 7);
                }

                if (resultados.ContainsKey(suma))
                    resultados[suma]++;
                else
                    resultados[suma] = 1;
            }

            return resultados;
        }

        // 18. Calculadora de Área de Polígonos Regulares - Facil
        public static double CalcularAreaPoligonoRegular(int numLados, double longitudLado)
        {
            double angulo = Math.PI / numLados;
            double area = (numLados * longitudLado * longitudLado) / (4 * Math.Tan(angulo));
            return Math.Round(area, 2);
        }

        // 20. Simulador de Sistema de Calificaciones Ponderadas - Complejo
        public static double CalcularPromedioPonderado(double[] calificaciones, double[] pesos)
        {
            if (calificaciones.Length != pesos.Length) return 0;

            double sumaProductos = 0;
            double sumaPesos = 0;

            for (int i = 0; i < calificaciones.Length; i++)
            {
                sumaProductos += calificaciones[i] * pesos[i];
                sumaPesos += pesos[i];
            }

            return sumaPesos != 0 ? Math.Round(sumaProductos / sumaPesos, 2) : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIOS DE ALGORITMIA ===\n");

            // 1. Verificar Número Autocompuesto
            //Console.WriteLine("1. Número Autocompuesto:");
            //Console.WriteLine($"¿128 es autocompuesto? {SolucionesAlgoritmia.EsNumeroAutocompuesto(128)}");
            //Console.WriteLine($"¿264 es autocompuesto? {SolucionesAlgoritmia.EsNumeroAutocompuesto(264)}");
            //Console.WriteLine();

            // 2. Distancia Manhattan
            //Console.WriteLine("2. Distancia Manhattan:");
            //Console.WriteLine($"Distancia entre (1,1) y (4,5): {SolucionesAlgoritmia.DistanciaManhattan(1, 1, 4, 5)}");
            //Console.WriteLine();

            // 3. Secuencia Tribonacci
            //Console.WriteLine("3. Secuencia Tribonacci (10 números):");
            //var tribonacci = SolucionesAlgoritmia.GenerarTribonacci(10);
            //Console.WriteLine(string.Join(", ", tribonacci));
            //Console.WriteLine();

            // 4. Número Vampiro
            //Console.WriteLine("4. Números Vampiro:");
            //Console.WriteLine($"¿1260 es vampiro? {SolucionesAlgoritmia.EsNumeroVampiro(1260)}");
            //Console.WriteLine($"¿1234 es vampiro? {SolucionesAlgoritmia.EsNumeroVampiro(1234)}");
            //Console.WriteLine();

            // 5. Cifrado César
            //Console.WriteLine("5. Cifrado César:");
            //Console.WriteLine($"'HOLA' con desplazamiento 3: {SolucionesAlgoritmia.CifradoCesar("HOLA", 3)}");
            //Console.WriteLine();

            // 6. Resistencias
            //Console.WriteLine("6. Resistencias:");
            //double[] resistencias = { 10, 20, 30 };
            //Console.WriteLine($"En serie: {SolucionesAlgoritmia.CalcularResistencia(resistencias, true)} ohms");
            //Console.WriteLine($"En paralelo: {SolucionesAlgoritmia.CalcularResistencia(resistencias, false):F2} ohms");
            //Console.WriteLine();

            // 7. Sudoku Parcial
            //Console.WriteLine("7. Sudoku Parcial:");
            //int[] sudokuValida = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] sudokuInvalida = { 1, 2, 3, 4, 5, 6, 7, 8, 8 };
            //Console.WriteLine($"Fila válida: {SolucionesAlgoritmia.VerificarSudokuParcial(sudokuValida)}");
            //Console.WriteLine($"Fila inválida: {SolucionesAlgoritmia.VerificarSudokuParcial(sudokuInvalida)}");
            //Console.WriteLine();

            // 8. Crecimiento Poblacional
            //Console.WriteLine("8. Crecimiento Poblacional:");
            //double poblacionFinal = SolucionesAlgoritmia.CalcularCrecimientoPoblacional(1000, 3.5, 1.2, 10);
            //Console.WriteLine($"Población después de 10 años: {poblacionFinal}");
            //Console.WriteLine();

            // 10. IMC
            //Console.WriteLine("10. Calculadora IMC:");
            //var imc = SolucionesAlgoritmia.CalcularIMC(70, 1.75);
            //Console.WriteLine($"IMC: {imc.imc}, Clasificación: {imc.clasificacion}");
            //Console.WriteLine();

            // 11. Patrón ASCII
            //Console.WriteLine("11. Patrón ASCII (Triángulo):");
            //SolucionesAlgoritmia.GenerarPatronTriangulo(5);
            //Console.WriteLine();

            // 12. Proyectil
            //Console.WriteLine("12. Lanzamiento de Proyectil:");
            //var proyectil = SolucionesAlgoritmia.CalcularProyectil(20, 45);
            //Console.WriteLine($"Alcance: {proyectil.alcance}m, Altura máxima: {proyectil.alturaMaxima}m");
            //Console.WriteLine();

            // 13. Validar Email
            //Console.WriteLine("13. Validar Email:");
            //Console.WriteLine($"usuario@ejemplo.com es válido: {SolucionesAlgoritmia.ValidarEmail("usuario@ejemplo.com")}");
            //Console.WriteLine($"emailinvalido es válido: {SolucionesAlgoritmia.ValidarEmail("emailinvalido")}");
            //Console.WriteLine();

            // 14. Interés Compuesto
            //Console.WriteLine("14. Interés Compuesto:");
            //double montoFinal = SolucionesAlgoritmia.CalcularInteresCompuesto(1000, 5, 3);
            //Console.WriteLine($"$1000 al 5% por 3 años: ${montoFinal}");
            //Console.WriteLine();

            // 15. Subcadena Repetitiva
            //Console.WriteLine("15. Subcadena Repetitiva:");
            //Console.WriteLine($"'abcabcabc' → '{SolucionesAlgoritmia.EncontrarSubcadenaRepetitiva("abcabcabc")}'");
            //Console.WriteLine();

            // 16. Dados Múltiples
            //Console.WriteLine("16. Simulación de Dados (2 dados, 100 lanzamientos):");
            //var resultadosDados = SolucionesAlgoritmia.SimularDados(2, 10);
            //foreach (var kvp in resultadosDados.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine($"Suma {kvp.Key}: {kvp.Value} veces");
            //}
            //Console.WriteLine();

            // 17. Tiempo Unix
            //Console.WriteLine("17. Conversor Tiempo Unix:");
            //long timestamp = 1640995200; // 1 enero 2022
            //Console.WriteLine($"Timestamp {timestamp}: {SolucionesAlgoritmia.ConvertirUnixAFecha(timestamp)}");
            //Console.WriteLine();

            // 18. Área Polígono
            //Console.WriteLine("18. Área de Polígono Regular:");
            //Console.WriteLine($"Hexágono con lado 5: {SolucionesAlgoritmia.CalcularAreaPoligonoRegular(6, 5)} unidades²");
            //Console.WriteLine();

            // 19. Anagramas
            //Console.WriteLine("19. Detector de Anagramas:");
            //Console.WriteLine($"'Listen' y 'Silent': {SolucionesAlgoritmia.SonAnagramas("Listen", "Silent")}");
            //Console.WriteLine($"'Hola' y 'Chao': {SolucionesAlgoritmia.SonAnagramas("Hola", "Chao")}");
            //Console.WriteLine();

            // 20. Promedio Ponderado
            //Console.WriteLine("20. Promedio Ponderado:");
            //double[] calificaciones = { 85, 90, 78 };
            //double[] pesos = { 0.3, 0.4, 0.3 };
            //Console.WriteLine($"Promedio ponderado: {SolucionesAlgoritmia.CalcularPromedioPonderado(calificaciones, pesos)}");

            Console.WriteLine("\n=== FIN DE LAS PRUEBAS ===");
            Console.ReadKey();
        }
    }
}