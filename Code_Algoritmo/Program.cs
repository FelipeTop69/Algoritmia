using System.Text;

namespace EjerciciosAlgoritmia
{
    public class SolucionesAlgoritmia
    {
        // ================================================
        //                       EASY
        // ================================================

        // 1. Calculadora de Distancia Manhattan
        public static int DistanciaManhattan(int x1, int y1, int x2, int y2)
        {
            int valorAbsX = Math.Abs(x1 - x2);
            int valorAbsY = Math.Abs(y1 - y2);
            int distManhattan = valorAbsX + valorAbsY;
            return distManhattan;
        }

        // 2. Calculadora de Resistencias en Serie/Paralelo
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

        // 3. Calculadora de Índice de Masa Corporal (IMC)
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

        // 4. Simulador de Lanzamiento de Proyectil
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

        // 5. Verificador de Formato de Email Básico
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

        // 6. Calculadora de Interés Compuesto
        public static double CalcularInteresCompuesto(double principal, double tasa, int tiempo)
        {
            return Math.Round(principal * Math.Pow(1 + tasa / 100, tiempo), 2);
        }

        // 7. Calculadora de Área de Polígonos Regulares
        public static double CalcularAreaPoligonoRegular(int numLados, double longitudLado)
        {
            double angulo = Math.PI / numLados;
            double area = (numLados * longitudLado * longitudLado) / (4 * Math.Tan(angulo));
            return Math.Round(area, 2);
        }

        // 8. Pedir una frase y contar cuántas veces aparece la letra ‘a’
        public static int ContadorA(string palabra)
        {
            int contador = 0;

            foreach (char c in palabra)
                if (c == 'a')
                    contador++;

            return contador;
        } 

        // 9. Recibir una cadena y contar cuántas letras tiene
        public static int ContadorLetras(string palabra)
        {
            int contador = 0;
            foreach (char c in palabra)
            {
                if((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                    contador++;
            }

            return contador;
        }

        // 10.Pedir al usuario una palabra y mostrarla al revés.
        public static string PalabraReverso(string palabra)
        {
            string reverso = "";

            for (int i = palabra.Length - 1; i >= 0; i--)
            {
                reverso += palabra[i];
            }

            return reverso;
        }

        // ================================================
        //                       HARD
        // ================================================

        // 11. Verificar Número Autocompuesto 
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

        // 12. Detector de Números Vampiro
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
        // 13. Verificar Sudoku Parcial
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

        // 14. Simulador de Crecimiento Poblacional
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

        // 15. Detector de Subcadenas Repetitivas
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

        // 16. Simulador de Juego de Dados Múltiples
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

        // 17. Simulador de Sistema de Calificaciones Ponderadas
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

        // 18. Contador de Ensambles Válidos de Fichas
        public static int ContadorTorreEstable(int[] fichas)
        {
            int count = 0;
            for (int i = 0; i < fichas.Length - 2; i++)
            {
                int suma = fichas[i] + fichas[i + 1] + fichas[i + 2];
                if (suma % 3 == 0) count++;
            }
            return count;
        }

        // 19. Simulador de Parpadeo Alternante
        public static bool TieneParpadeoAlternante(int[] leds)
        {
            if (leds.Length < 6) return false;
            for (int i = 0; i <= leds.Length - 6; i++)
            {
                bool valido = true;
                for (int j = 0; j < 5; j++)
                    if (leds[i + j] == leds[i + j + 1]) { valido = false; break; }
                if (valido) return true;
            }
            return false;
        }

        // 20. Contador de Giros Equilibrados
        public static bool GirosEquilibrados(char[] movimientos)
        {
            int horizontales = 0, verticales = 0;

            foreach (char mov in movimientos)
            {
                if (mov == 'L' || mov == 'R')
                    horizontales++;
                else if (mov == 'U' || mov == 'D')
                    verticales++;
            }

            return horizontales == verticales;
        }

        // 21. Agrupador por Dígito Final
        public static int[] AgruparPorDigitoFinal(int[] numeros)
        {
            int[] grupos = new int[10]; // índices 0-9

            foreach (int num in numeros)
            {
                int ultimoDigito = Math.Abs(num) % 10;
                grupos[ultimoDigito]++;
            }

            return grupos;
        }

        // 22. Detector de Cambios Bruscos
        public static int ContarCambiosBruscos(int[] valores)
        {
            int contador = 0;
            for (int i = 1; i < valores.Length; i++)
            {
                if (Math.Abs(valores[i] - valores[i - 1]) > 10)
                    contador++;
            }
            return contador;
        }

        // 23. Verificador de Encaje de Fichas
        public static bool PuedenEncajar(int[] fichas1, int[] fichas2)
        {
            if (fichas1.Length != fichas2.Length)
                return false;

            for (int i = 0; i < fichas1.Length; i++)
            {
                if (fichas1[i] + fichas2[i] != 0)
                    return false;
            }

            return true;
        }

        // 24. Contador de Zonas Oscuras
        public static int ContarZonasOscuras(int[] leds)
        {
            int count = 0, seguidos = 0;
            for (int i = 0; i < leds.Length; i++)
            {
                if (leds[i] == 0)
                {
                    seguidos++;
                    if (seguidos == 3) count++;
                }
                else seguidos = 0;
            }
            return count;
        }

        // 25. Medidor de Progreso del Cubo
        public static double CalcularPorcentajeResuelto(int[] piezas)
        {
            if (piezas.Length == 0)
                return 0.0;

            int correctas = 0;
            foreach (int pieza in piezas)
            {
                if (pieza == 1)
                    correctas++;
            }

            return (double)correctas / piezas.Length * 100.0;
        }

        // 26. Analizador de Racha Ganadora
        public static int RachaMasLarga(int[] resultados)
        {
            int rachaMaxima = 0;
            int rachaActual = 0;

            foreach (int resultado in resultados)
            {
                if (resultado == 1)
                {
                    rachaActual++;
                    if (rachaActual > rachaMaxima)
                        rachaMaxima = rachaActual;
                }
                else
                {
                    rachaActual = 0;
                }
            }

            return rachaMaxima;
        }

        // 27. Filtro de suma numérico
        public static int[] FiltroEcoNumerico(int[] arreglo)
        {
            int[] resultado = new int[arreglo.Length];
            for (int i = 0; i < arreglo.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < arreglo.Length; j++)
                    if (arreglo[j] == arreglo[i]) count++;
                resultado[i] = arreglo[i] + count;
            }
            return resultado;
        }

        // 28. Orden de densidad numérica
        public static int[] OrdenPorFrecuencia(int[] arreglo)
        {
            int[] resultado = new int[arreglo.Length];
            bool[] usados = new bool[arreglo.Length];
            int pos = 0;

            for (int i = 0; i < arreglo.Length; i++)
            {
                if (usados[i]) continue;
                int count = 1;
                for (int j = i + 1; j < arreglo.Length; j++)
                    if (arreglo[j] == arreglo[i]) { count++; usados[j] = true; }
                for (int k = 0; k < arreglo.Length; k++)
                    if (arreglo[k] == arreglo[i])
                        resultado[pos++] = arreglo[k];
            }

            for (int i = 0; i < resultado.Length - 1; i++)
            {
                for (int j = i + 1; j < resultado.Length; j++)
                {
                    int ci = 0, cj = 0;
                    for (int k = 0; k < arreglo.Length; k++)
                    {
                        if (arreglo[k] == resultado[i]) ci++;
                        if (arreglo[k] == resultado[j]) cj++;
                    }
                    if (cj > ci)
                    {
                        int temp = resultado[i];
                        resultado[i] = resultado[j];
                        resultado[j] = temp;
                    }
                }
            }

            return resultado;
        }

        // 29. Validador de Valor según posición
        public static bool EsImpulsoAlterno(int[] arreglo)
        {
            for (int i = 1; i < arreglo.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (arreglo[i] <= arreglo[i - 1]) return false;
                }
                else
                {
                    if (arreglo[i] >= arreglo[i - 1]) return false;
                }
            }
            return true;
        }

        // 30. Ajustador de Arreglos por Mitades
        public static int AjustarPorMitades(int[] lista)
        {
            if (lista.Length % 2 != 0)
                return -1;

            int mitad = lista.Length / 2;
            int suma1 = 0, suma2 = 0;

            for (int i = 0; i < mitad; i++)
                suma1 += lista[i];

            for (int i = mitad; i < lista.Length; i++)
                suma2 += lista[i];

            int diferencia = Math.Abs(suma1 - suma2);

            if (diferencia % 2 != 0)
                return -1;

            return diferencia / 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJERCICIOS DE ALGORITMIA ===\n");

            // ================================================
            //                       EASY
            // ================================================

            // 1. Distancia Manhattan
            //Console.WriteLine("1. Distancia Manhattan:");
            //Console.WriteLine($"Distancia entre (1,1) y (4,5): {SolucionesAlgoritmia.DistanciaManhattan(1, 1, 4, 5)}");

            // 2. Resistencias
            //Console.WriteLine("2. Resistencias:");
            //double[] resistencias = { 10, 20, 30 };
            //Console.WriteLine($"En serie: {SolucionesAlgoritmia.CalcularResistencia(resistencias, true)} ohms");
            //Console.WriteLine($"En paralelo: {SolucionesAlgoritmia.CalcularResistencia(resistencias, false):F2} ohms");

            // 3. IMC
            //Console.WriteLine("3. Calculadora IMC:");
            //var imc = SolucionesAlgoritmia.CalcularIMC(70, 1.75);
            //Console.WriteLine($"IMC: {imc.imc}, Clasificación: {imc.clasificacion}");

            // 4. Proyectil
            //Console.WriteLine("4. Lanzamiento de Proyectil:");
            //var proyectil = SolucionesAlgoritmia.CalcularProyectil(20, 45);
            //Console.WriteLine($"Alcance: {proyectil.alcance}m, Altura máxima: {proyectil.alturaMaxima}m");

            // 5. Validar Email
            //Console.WriteLine("5. Validar Email:");
            //Console.WriteLine($"usuario@ejemplo.com es válido: {SolucionesAlgoritmia.ValidarEmail("usuario@ejemplo.com")}");
            //Console.WriteLine($"emailinvalido es válido: {SolucionesAlgoritmia.ValidarEmail("emailinvalido")}");

            // 6. Interés Compuesto
            //Console.WriteLine("6. Interés Compuesto:");
            //double montoFinal = SolucionesAlgoritmia.CalcularInteresCompuesto(1000, 5, 3);
            //Console.WriteLine($"$1000 al 5% por 3 años: ${montoFinal}");

            // 7. Área Polígono
            //Console.WriteLine("7. Área de Polígono Regular:");
            //Console.WriteLine($"Hexágono con lado 5: {SolucionesAlgoritmia.CalcularAreaPoligonoRegular(6, 5)} unidades²");

            // 8. Contador vocal 'a'
            //Console.WriteLine("8. Contador vocal 'a':");
            //Console.WriteLine($"La palabra tiene {SolucionesAlgoritmia.ContadorA("muercielago")} 'a'");

            // 9. Contador de letras
            //Console.WriteLine("9. Contador Letras:");
            //Console.WriteLine($"La palabra tiene {SolucionesAlgoritmia.ContadorLetras("muercielago")} letras");

            // 10.Palabra al Reves
            //Console.WriteLine("10. Palabra al Reves:");
            //Console.WriteLine($"El reverso de la palabra {SolucionesAlgoritmia.PalabraReverso("Arroz")}");

            // ================================================
            //                       HARD
            // ================================================

            // 11. Verificar Número Autocompuesto
            //Console.WriteLine("11. Número Autocompuesto:");
            //Console.WriteLine($"¿128 es autocompuesto? {SolucionesAlgoritmia.EsNumeroAutocompuesto(128)}");
            //Console.WriteLine($"¿264 es autocompuesto? {SolucionesAlgoritmia.EsNumeroAutocompuesto(264)}");

            // 12. Número Vampiro
            //Console.WriteLine("12. Números Vampiro:");
            //Console.WriteLine($"¿1260 es vampiro? {SolucionesAlgoritmia.EsNumeroVampiro(1260)}");
            //Console.WriteLine($"¿1234 es vampiro? {SolucionesAlgoritmia.EsNumeroVampiro(1234)}");

            // 13. Sudoku Parcial
            //Console.WriteLine("13. Sudoku Parcial:");
            //int[] sudokuValida = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //int[] sudokuInvalida = { 1, 2, 3, 4, 5, 6, 7, 8, 8 };
            //Console.WriteLine($"Fila válida: {SolucionesAlgoritmia.VerificarSudokuParcial(sudokuValida)}");
            //Console.WriteLine($"Fila inválida: {SolucionesAlgoritmia.VerificarSudokuParcial(sudokuInvalida)}");

            // 14. Crecimiento Poblacional
            //Console.WriteLine("14. Crecimiento Poblacional:");
            //double poblacionFinal = SolucionesAlgoritmia.CalcularCrecimientoPoblacional(1000, 3.5, 1.2, 10);
            //Console.WriteLine($"Población después de 10 años: {poblacionFinal}");

            // 15. Subcadena Repetitiva
            //Console.WriteLine("15. Subcadena Repetitiva:");
            //Console.WriteLine($"'abcabcabc' → '{SolucionesAlgoritmia.EncontrarSubcadenaRepetitiva("abcabcabc")}'");

            // 16. Dados Múltiples
            //Console.WriteLine("16. Simulación de Dados (2 dados, 100 lanzamientos):");
            //var resultadosDados = SolucionesAlgoritmia.SimularDados(2, 10);
            //foreach (var kvp in resultadosDados.OrderBy(x => x.Key))
            //{
            //    Console.WriteLine($"Suma {kvp.Key}: {kvp.Value} veces");
            //}

            // 17. Promedio Ponderado
            //Console.WriteLine("17. Promedio Ponderado:");
            //double[] calificaciones = { 85, 90, 78 };
            //double[] pesos = { 0.3, 0.4, 0.3 };
            //Console.WriteLine($"Promedio ponderado: {SolucionesAlgoritmia.CalcularPromedioPonderado(calificaciones, pesos)}");

            //Console.WriteLine("18. Contador de Ensambles Válidos de Fichas:");
            //Console.WriteLine(SolucionesAlgoritmia.ContadorTorreEstable(new int[] { 2, 4, 5, 3, 6, 1 }));

            //Console.WriteLine("19. Simulador de Parpadeo Alternante:");
            //Console.WriteLine(SolucionesAlgoritmia.TieneParpadeoAlternante(new int[] { 1, 0, 1, 0, 1, 0 }));

            //Console.WriteLine("20. Contador de Giros Equilibrados:");
            //char[] movimientos = { 'L', 'R', 'U', 'D', 'L', 'U' };
            //Console.WriteLine($"Giros equilibrados: {SolucionesAlgoritmia.GirosEquilibrados(movimientos)}\n");

            //Console.WriteLine("21. Agrupador por Dígito Final:");
            //int[] numeros = { 12, 23, 34, 42, 53, 62 };
            //int[] grupos = SolucionesAlgoritmia.AgruparPorDigitoFinal(numeros);
            //for (int i = 0; i < grupos.Length; i++)
            //{
            //    if (grupos[i] > 0)
            //        Console.WriteLine($"Dígito {i}: {grupos[i]} números");
            //}

            //Console.WriteLine("22. Detector de Cambios Bruscos:");
            //Console.WriteLine(SolucionesAlgoritmia.ContarCambiosBruscos(new int[] { 5, 7, 20, 25, 10, 23 }));

            //Console.WriteLine("23. Verificador de Encaje de Fichas:");
            //int[] fichas1 = { 3, -2, 5, -1 };
            //int[] fichas2 = { -3, 2, -5, 1 };
            //Console.WriteLine($"Pueden encajar: {SolucionesAlgoritmia.PuedenEncajar(fichas1, fichas2)}\n");

            //Console.WriteLine("24. Contador de Zonas Oscuras:");
            //Console.WriteLine(SolucionesAlgoritmia.ContarZonasOscuras(new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 0 }));

            //Console.WriteLine("25. Medidor de Progreso del Cubo:");
            //int[] piezas = { 1, 1, 0, 1, 0, 1, 1, 0 };
            //Console.WriteLine($"Porcentaje resuelto: {SolucionesAlgoritmia.CalcularPorcentajeResuelto(piezas):F1}%\n");

            //Console.WriteLine("26. Analizador de Racha Ganadora:");
            //int[] resultados = { 1, 1, 0, 1, 1, 1, 0, 1 };
            //Console.WriteLine($"Racha más larga: {SolucionesAlgoritmia.RachaMasLarga(resultados)}\n");

            //Console.WriteLine("27. Filtro de Suma Numérico:");
            //int[] resultado = SolucionesAlgoritmia.FiltroEcoNumerico(new int[] { 5, 3, 5, 2, 5 });
            //Console.WriteLine(string.Join(", ", resultado));  // Debería dar: 8, 4, 8, 3, 8

            //Console.WriteLine("28. Orden de Densidad Numérica:");
            //int[] resultadoDos = SolucionesAlgoritmia.OrdenPorFrecuencia(new int[] { 2, 5, 2, 3, 3, 3, 5 });
            //Console.WriteLine(string.Join(", ", resultadoDos));  // Más frecuentes primero

            //Console.WriteLine("29. Validador de Impulso Alterno:");
            //Console.WriteLine(SolucionesAlgoritmia.EsImpulsoAlterno(new int[] { 1, 3, 2, 4, 3 })); // true
            //Console.WriteLine(SolucionesAlgoritmia.EsImpulsoAlterno(new int[] { 1, 3, 3, 4, 3 })); // false

            //Console.WriteLine("30. Ajustador de Arreglos por Mitades:");
            //int[] listaAjustar = { 1, 2, 3, 4 };
            //Console.WriteLine($"Ajustes necesarios: {SolucionesAlgoritmia.AjustarPorMitades(listaAjustar)}\n");

            Console.WriteLine("\n=== FIN DE LAS PRUEBAS ===");
            Console.ReadKey();
        }
    }
}