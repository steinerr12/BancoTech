using System;
using System.ComponentModel.Design;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // los datos correctos
        string nombrePredeterminado = "Juan Perez";
        int cuentaCorrecta = 100200300;
        int pinCorrecto = 2580;
        decimal saldo = 2750.50m;
        decimal limiteDiarioDeRetiro = 1200.00m;
        decimal montoMaximoDiario = 350.00m;
       
        // solcitar datos
        Console.WriteLine("Por favor, ingrese su numero de cuenta:");
        int numeroDeCuentaIngresado = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese su PIN:");
        int pinIngresado = int.Parse(Console.ReadLine());

        // validar datos 
        if (numeroDeCuentaIngresado == cuentaCorrecta && pinIngresado == pinCorrecto)
        {
            // Si es correcto, le damos la bienvenida usando su nombre guardado
            Console.WriteLine("Bienvenido " + nombrePredeterminado);

            Console.WriteLine("Tu saldo actual es de: $" + saldo);
        }
        else
        {
            Console.WriteLine("Numero de cuenta o PIN incorrecto");
        }

        // menu principal

        switch (numeroDeCuentaIngresado)
        {
            case 100200300:
                Console.WriteLine("Seleccione una opción:");

                Console.WriteLine("1. Retirar dinero");
                Console.WriteLine("2. Consultar saldo");
                Console.WriteLine("3. Depositar dinero");
                Console.WriteLine("4. Transferir dinero");

                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {                 
                    // RETIRAR DINERO

                    case 1: 
                        Console.WriteLine("Ingrese el monto a retirar:");
                        decimal montoARetirar = decimal.Parse(Console.ReadLine());

                       if (montoARetirar <=0)
                        {
                            Console.WriteLine("El monto a retirar debe ser mayor a cero.");
                        }
                        else if (montoARetirar > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente para realizar el retiro.");
                        }
                        else if (montoARetirar > limiteDiarioDeRetiro)
                        {
                            Console.WriteLine("El monto a retirar excede el límite diario de retiro.");
                        }
                       else if (montoARetirar > 500.00m)
                        {
                            Console.WriteLine("No puede retirar mas de $500.00 en una sola operación");
                        }
                       else if (montoARetirar %10 != 0)
                        {
                            Console.WriteLine("Solo se permiten multiplos de 10");
                        }
                        else
                        {
                            saldo -= montoARetirar;
                            Console.WriteLine("Retiro exitoso. Su nuevo saldo es: $" + saldo);
                            Console.WriteLine("Su nuevo saldo es: $" + saldo);
                        }
                        break;

                    // CONSULTAR SALDO

                    case 2:
                        Console.WriteLine("Su saldo actual es: $" + saldo);
                        Console.WriteLine("Su límite diario de retiro es: $" + limiteDiarioDeRetiro);
                        Console.WriteLine("Su monto restante para retirar es: $" + (limiteDiarioDeRetiro - saldo));
                        break;

                    // DEPOSITAR DINERO

                    case 3:
                        Console.WriteLine("Ingrese el monto a depositar:");
                        decimal montoADepositar = decimal.Parse(Console.ReadLine());
                        saldo += montoADepositar;
                        
                        if (montoADepositar <= 0)
                        {
                            Console.WriteLine("El monto a depositar debe ser mayor a cero.");
                        }
                        else if (montoADepositar > 5000.00m)
                        {
                            Console.WriteLine("No puede depositar un monto mayor a $5,000.00");
                        }                     

                        else if (montoADepositar > 2500.00m)
                        {
                            Console.WriteLine("Depósito sujeto a revisión bancaria.");
                        }

                        else
                        {
                            saldo += montoADepositar;
                            Console.WriteLine("Depósito exitoso. Su nuevo saldo es: $" + saldo);
                        }
                        break;


                    case 4:
                        Console.WriteLine("Ingrese el número de cuenta del destinatario:");
                        int cuentaDestinatario = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el monto a transferir:");
                        decimal montoATransferir = decimal.Parse(Console.ReadLine());


                }
                break;
                default:
                Console.WriteLine("Cuenta no reconocida.");
                break;
        }
    }

}