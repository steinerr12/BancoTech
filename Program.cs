using System;
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
                    case 1:
                        Console.WriteLine("Ingrese el monto a retirar:");
                        decimal montoARetirar = decimal.Parse(Console.ReadLine());
                        if (montoARetirar <= limiteDiarioDeRetiro && montoARetirar <= montoMaximoDiario && montoARetirar <= saldo && montoARetirar % 10 == 0)
                        {
                            saldo -= montoARetirar;
                            
                            Console.WriteLine("Retiro exitoso. Su nuevo saldo es: $" + saldo);
                        }
                        else
                        {
                            Console.WriteLine("Monto de retiro excede el límite diario o su saldo disponible.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Su saldo actual es: $" + saldo);
                        Console.WriteLine("Su límite diario de retiro es: $" + limiteDiarioDeRetiro);
                        Console.WriteLine("Su monto restante para retirar es: $" + (limiteDiarioDeRetiro - saldo));
                        break;

                     case 3:
                        Console.WriteLine("Ingrese el monto a depositar:");
                        decimal montoADepositar = decimal.Parse(Console.ReadLine());
                        saldo += montoADepositar;
                        

                        if (montoADepositar > 2500)
                        {
                            Console.WriteLine("Deposito Sujeto a revisión por exceder el monto máximo permitido.");
                       
                        }
                        else
                        {
                            Console.WriteLine("Depósito exitoso. Su nuevo saldo es: $" + saldo);
                        }

                        break;

                    case 4:
                        Console.WriteLine("Ingrese el número de cuenta del destinatario:");
                        int cuentaDestinatario = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el monto a transferir:");
                        decimal montoATransferir = decimal.Parse(Console.ReadLine());
                        if (montoATransferir <= saldo)
                        {
                            saldo -= montoATransferir;
                            Console.WriteLine("Transferencia exitosa. Su nuevo saldo es: $" + saldo);
                        }
                        else
                        {
                            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                        }
                        if (cuentaDestinatario == 100200300)
                        {
                            Console.WriteLine("No puede transferirse a la misma cuenta.");
                        }

                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
                break;
                default:
                Console.WriteLine("Cuenta no reconocida.");
                break;
        }
    }

}