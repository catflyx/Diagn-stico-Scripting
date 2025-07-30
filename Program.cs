namespace estructuras_de_datos
{
    internal class Program
    {
        static bool ganadorobtenido = false;
        static void Main(string[] args)
        {
            int confirmacion;
            bool entradaValida = false;
            Console.WriteLine("Que ejercicio quieres mirar?");
            Console.WriteLine("------Menu------");

            while (!entradaValida)
            {
                Console.WriteLine("(1) Primer ejercicio  (2) Segundo ejercicio  (3) Tercer ejercicio  (4) Cuarto ejercicio");
                string entrada = Console.ReadLine();

                // Intentamos convertir la entrada a entero
                if (int.TryParse(entrada, out confirmacion))
                {
                    // Verificamos que sea 1 o 2
                    switch (confirmacion)
                    {
                        case 1:
                            Console.WriteLine("¡Hola, usuario!, vamos al ejercicio 1");
                            PrimerEjercicio();
                            break;

                        case 2:
                            Console.WriteLine("¡Hola, usuario!, vamos al ejercicio 2");
                            SegundoEjercicio();
                            break;

                        case 3:
                            Console.WriteLine("¡Hola, usuario!, vamos al ejercicio 3");
                            TercerEjercicio();
                            break;

                        case 4:
                            Console.WriteLine("¡Hola, usuario!, vamos al ejercicio 4");
                            CuartoEjercicio();
                            break;
                      
                        default:
                            Console.WriteLine("Opción inválida. Por favor, ingresa 1, 2, 3 o 4.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                }
            }
        }        

        public abstract class AbstractSample
        {
            private string message;
            public abstract void PrintMessage(string input);

            // Método virtual que invierte el mensaje recibido
            public virtual void InvertMessage(string input)
            {
                // Invertimos el string (char array + Reverse)
                char[] array = input.ToCharArray();
                Array.Reverse(array);
                message = new string(array);
            }

            // Método protected para acceder a message
            protected string GetMessage()
            {
                return message;
            }

            //Método protected para establecer message (si alguna hija quiere modificarlo directamente)
            protected void SetMessage(string newMessage)
            {
                message = newMessage;
            }
        }

        public class PlainSample : AbstractSample
        {
            public override void PrintMessage(string input)
            {
                // Invertimos el mensaje primero
                InvertMessage(input);

                // Imprimimos el mensaje tal como quedó
                Console.WriteLine(GetMessage());
            }
        }


        public class FancySample : AbstractSample
        {
            public override void PrintMessage(string input)
            {
                InvertMessage(input); // Ya realiza todo: inversión + cambio de mayúsculas/minúsculas
                Console.WriteLine(GetMessage()); // Solo imprimimos el resultado
            }

            // Esta clase también sobreescribe InvertMessage para que además invierta mayúsculas y minúsculas
            public override void InvertMessage(string input)
            {
                base.InvertMessage(input); // Llama al método base para invertir el texto

                string message = GetMessage();
                string modified = "";

                foreach (char c in message)
                {
                    if (char.IsUpper(c))
                        modified += char.ToLower(c);
                    else if (char.IsLower(c))
                        modified += char.ToUpper(c);
                    else
                        modified += c;
                }

                SetMessage(modified); // Actualiza el mensaje invertido con el nuevo formato
            }

        }

        public class MessageManager
        {
            public void Run()
            {
                Console.WriteLine("Ingrese un mensaje:");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Entrada vacía. Intenta nuevamente.");
                    return;
                }

                AbstractSample simple = new PlainSample();
                AbstractSample fancy = new FancySample();

                //simple.SetMessage(input);
                //fancy.SetMessage(input);

                Console.WriteLine("\n--- Resultado usando PlainSample ---");
                simple.PrintMessage(input);

                Console.WriteLine("\n--- Resultado usando FancySample ---");
                fancy.PrintMessage(input);
            }
        }


        static void CuartoEjercicio()
        {
            MessageManager manager = new MessageManager();
            manager.Run();
        }

        static void TercerEjercicio()
        {
            Console.Write("Ingrese la cantidad de segundos: ");
            int segundos = int.Parse(Console.ReadLine());

            string resultado = ConvertirASegundos(segundos);
            Console.WriteLine("Formato HH:MM:SS → " + resultado);
        }

        static string ConvertirASegundos(int segundos)
        {
            int horas = segundos / 3600;
            int segundosRestantes = segundos % 3600;
            int minutos = segundosRestantes / 60;
            int segundosFinales = segundosRestantes % 60;

            return $"{horas:D2}:{minutos:D2}:{segundosFinales:D2}";
        }

        static void SegundoEjercicio()
        {
            int confirmacion;
            bool entradaValida = false;

            Console.WriteLine("Quieres comenzar?");
            Console.WriteLine("------Menu------");
            while (!entradaValida)
            {
                Console.WriteLine("(1) Comenzar  (2) No comenzar");
                string entrada = Console.ReadLine();

                // Intentamos convertir la entrada a entero
                if (int.TryParse(entrada, out confirmacion))
                {
                    // Verificamos que sea 1 o 2
                    if (confirmacion == 1 || confirmacion == 2)
                    {
                        entradaValida = true;
                        Console.WriteLine("Seleccionaste: " + (confirmacion == 1 ? "Comenzar" : "No comenzar"));
                        if (confirmacion == 1)
                        {
                            Continuacion();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Por favor, ingresa solamente 1 o 2.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Debes ingresar un número.");
                }
            }


        }

        static void Continuacion()
        {
            byte aciertos = 0;
            byte fallas = 0;

            int cantidadapostada = 1;
            byte perdedor = 0;
            int multiplicador1 = cantidadapostada * 4500;
            int multiplicador2 = cantidadapostada * 200;
            int multiplicador3 = cantidadapostada * 400;
            int multiplicador4 = cantidadapostada * 50;
            int multiplicador5 = cantidadapostada * 5;
            byte primeraesfalla = 1;

            string numero = "";

            Random aleatorio = new Random();

            List<int> digitos = new List<int>();
            List<int> numeroganador = new List<int>();


            while (true)
            {
                Console.WriteLine("¿Cuanto quieres apostar?");
                numero = Console.ReadLine();


                if (int.TryParse(numero, out int numeroEntero) && numeroEntero >= 1)
                {
                    cantidadapostada = Convert.ToInt32(numero);


                    break; // Salimos del ciclo si todo fue válido
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
            }

            numeroganador.Clear();
            for (int i = 0; i < 4; i++)
            {
                numeroganador.Add(aleatorio.Next(0, 10)); // un dígito aleatorio entre 0 y 9
            }

            while (true)
            {
                Console.WriteLine("¿A qué número deseas apostar?");
                numero = Console.ReadLine();

                // Validamos si es un número y si es menor o igual a 9999
                if (int.TryParse(numero, out int numeroEntero) && numero.Length == 4)
                {

                    // Guardamos cada dígito como int en la lista
                    digitos.Clear();
                    foreach (char c in numero)
                    {
                        digitos.Add(int.Parse(c.ToString()));
                    }

                    break; // Salimos del ciclo si todo fue válido

                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido de hasta 4 dígitos (entre 0 y 9999).");
                }
            }

            // Mostrar los dígitos por separado
            Console.WriteLine("Dígitos individuales:");
            foreach (int d in digitos)
            {
                Console.WriteLine(d);
            }
            int[] ocupado = new int[4];
            Console.WriteLine("Los números gandores son: ");
            foreach (int d in numeroganador)
            {
                Console.WriteLine(d);
            }
            for (byte i = 3; i >= 0; i--)
            {

                if (digitos[i] == numeroganador[i])
                {
                    aciertos++;
                    Console.WriteLine($"¡Coincidencia en la posición {i + 1}!");
                    //Console.WriteLine(aciertos + " " + fallas);                    
                }
                else
                {
                    fallas++;
                    ocupado[i] = i;
                    if (i == 3)
                    {
                        primeraesfalla = i;
                    }
                }

                if(primeraesfalla == 1)
                {
                    if (aciertos == 4)
                    {
                        Console.WriteLine("Felicidades, has acertado todos los números, por lo que luego de haber apostado " + cantidadapostada + " , ha logrado ganar " + multiplicador1);
                        ganadorobtenido = true;
                    }


                    if (aciertos == 3 && fallas == 1)
                    {
                        if (ocupado[0] == 0)
                        {
                            Console.WriteLine("Felicidades, has acertado en los tres ultimos números, por lo que luego de haber apostado " + cantidadapostada + " , ha logrado ganar " + multiplicador3);
                            ganadorobtenido = true;
                        }
                        else
                        {
                            Console.WriteLine("Perdón, pero has perdido, tu apuesta dio como resultado " + perdedor);
                        }
                    }



                    if (aciertos == 2 && fallas == 2)
                    {
                        if (ocupado[0] == 0 && ocupado[1] == 1)
                        {
                            Console.WriteLine("Felicidades, has acertado en los dos ultimos números, por lo que luego de haber apostado " + cantidadapostada + " , ha logrado ganar " + multiplicador4);
                            ganadorobtenido = true;
                        }
                        else
                        {
                            Console.WriteLine("Perdón, pero has perdido, tu apuesta dio como resultado " + perdedor);
                        }

                    }

                    if (aciertos == 1 && fallas == 3)
                    {
                        if (ocupado[0] == 0 && ocupado[1] == 1 && ocupado[2] == 2)
                        {
                            Console.WriteLine("Felicidades, has acertado en el ultimo número, por lo que luego de haber apostado " + cantidadapostada + " , ha logrado ganar " + multiplicador5);
                            ganadorobtenido = true;
                        }
                        else
                        {
                            Console.WriteLine("Perdón, pero has perdido, tu apuesta dio como resultado " + perdedor);
                        }

                    }
                    //Console.WriteLine(aciertos + " " + fallas);
                }
                if(primeraesfalla == 3)
                {
                    Console.WriteLine("Lo siento pero como el ultimo número no coincide con el número ganador no pudiste ganar, ahora comprovaremos si tuviste la suerte de ganar de manera desordenada");
                }
            }
            if (ganadorobtenido == false)
            {
                bool esGanadorDesordenado = true;

                // Verificamos que los dígitos sean los mismos, pero en diferentes posiciones
                for (int i = 0; i < 4; i++)
                {
                    if (digitos[i] == numeroganador[i])
                    {
                        esGanadorDesordenado = false; // al menos uno está en la misma posición
                        break;
                    }
                }

                // Creamos copias para no modificar las originales
                List<int> copiaJugador = new List<int>(digitos);
                List<int> copiaGanador = new List<int>(numeroganador);

                // Verificamos que los mismos dígitos están presentes
                foreach (int d in copiaJugador)
                {
                    if (copiaGanador.Contains(d))
                    {
                        copiaGanador.Remove(d); // Evitamos contar el mismo dígito dos veces
                    }
                    else
                    {
                        esGanadorDesordenado = false;
                        break;
                    }
                }

                if (esGanadorDesordenado)
                {
                    Console.WriteLine("¡Ganador desordenado! Todos los dígitos son correctos pero en posiciones distintas.");
                    Console.WriteLine("Felicidades, has acertado en los números, pero en diferentes posiciones, por lo que luego de haber apostado " + cantidadapostada + ", ha logrado ganar " + multiplicador2);
                }
            }
            Console.WriteLine("Gracias por jugar");

        }

        static int PrimerEjercicio()
        {
            //Secuencia de Fibonacci: Escribe un programa que genere los primeros n términos de la secuencia de Fibonacci,
            //donde n es un número ingresado por el usuario. Utiliza un ciclo while para generar la secuencia.

            int num2 = 0;
            int sumar2 = 1;
            int confirmacion = 0;

            List<int> fibonacciLista = new List<int>();

            int n = 0;
            int m = 0;
            int b = 1;

            Console.WriteLine("Quieres comenzar?");
            Console.WriteLine("------Menu------");
            Console.WriteLine("(1)Comenzar  (2)No comenzar");
            confirmacion = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Escribe cuantas veces quieres que se repita el codigo");
            m = Convert.ToInt32(Console.ReadLine());
            while (confirmacion == 1 && n <= m)
            {

                while (n <= m)
                {
                    fibonacciLista.Add(sumar2);
                    Console.WriteLine(sumar2);

                    sumar2 = sumar2 + num2;
                    num2 = sumar2 - num2;
                    Console.WriteLine(sumar2);
                    if (b <= m)
                    {
                        Console.WriteLine("------Menu------");
                        Console.WriteLine("(1)Seguir  (2)No seguir");
                        confirmacion = Convert.ToInt32(Console.ReadLine());
                    }
                    n++;
                    b++;
                }
            }
            Console.WriteLine("Hola este fue el resultado " + sumar2);

            Console.WriteLine("Números primos en la secuencia:");

            MostrarPrimosEnFibonacci(fibonacciLista);

            return sumar2;
        }

        // Función secundaria: muestra los números primos dentro de la secuencia de Fibonacci
        static void MostrarPrimosEnFibonacci(List<int> lista)
        {
            foreach (int num in lista)
            {
                if (EsPrimo(num))
                {
                    Console.WriteLine(num);
                }
            }
        }

        // Función auxiliar para verificar si un número es primo
        static bool EsPrimo(int numero)
        {
            if (numero <= 1) return false;
            if (numero == 2) return true;

            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0)
                    return false;
            }

            return true;
        }
    }
}
