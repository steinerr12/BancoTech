using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net.NetworkInformation;

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

        bool accesoConcedido = (numeroDeCuentaIngresado == cuentaCorrecta && pinIngresado == pinCorrecto);

        if (accesoConcedido)
    {
            switch (numeroDeCuentaIngresado)
        {
            case 100200300:
                Console.WriteLine("Seleccione una opción:");

                Console.WriteLine("1. Retirar dinero");
                Console.WriteLine("2. Consultar saldo");
                Console.WriteLine("3. Depositar dinero");
                Console.WriteLine("4. Transferir dinero");
                Console.WriteLine("5. Cambiar PIN");
                Console.WriteLine("6. Simular préstamo");


                    int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    // RETIRAR DINERO

                    case 1:
                        Console.WriteLine("Ingrese el monto a retirar:");
                        decimal montoARetirar = decimal.Parse(Console.ReadLine());

                        if (montoARetirar <= 0)
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
                        else if (montoARetirar % 10 != 0)
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

                    // TRANSFERIR DINERO
                    case 4:
                        Console.WriteLine("Ingrese el número de cuenta del destinatario:");
                        int cuentaDestinatario = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el monto a transferir:");
                        decimal montoATransferir = decimal.Parse(Console.ReadLine());

                        //calculo para la comision.

                        decimal comision = 0;
                        if (montoATransferir <= 500) comision = 2.00m;
                        else if (montoATransferir <= 1000) comision = 5.00m;
                        else comision = 8.00m;

                        if (cuentaDestinatario == cuentaCorrecta)
                        {
                            Console.WriteLine("La cuenta destino no puede ser la misma que su propia cuenta");
                        }

                        else if (cuentaDestinatario.ToString().Length != 9)
                        {
                            Console.WriteLine("La cuenta destino debe tener 9 dígitos");
                        }

                        else if (montoATransferir <= 0)
                        {
                            Console.WriteLine("El monto a transferir debe ser mayor a cero.");
                        }
                        else if ((montoATransferir + comision) > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente para realizar la transferencia.");
                        }
                        else
                        {
                            saldo -= (montoATransferir + comision);
                            Console.WriteLine("Transferencia exitosa. Se ha transferido $" + montoATransferir + " a la cuenta " + cuentaDestinatario);
                            Console.WriteLine("Comisión aplicada: $" + comision);
                            Console.WriteLine("Su nuevo saldo es: $" + saldo);
                            Console.WriteLine("Monto transferido: $" + montoATransferir);
                        }

                        break;

                    //Opcion cambiar Pin
                    case 5:
                        Console.WriteLine("Ingrese su PIN actual:");
                        int pinActualIngresado = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el nuevo PIN:");
                        int nuevoPin = int.Parse(Console.ReadLine());

                        Console.WriteLine("Confirme el nuevo PIN:");
                        int confirmacionPin = int.Parse(Console.ReadLine());

                        if (pinActualIngresado != pinCorrecto)
                        {
                            Console.WriteLine("El PIN actual es incorrecto.");
                        }
                        else if (nuevoPin == pinCorrecto)
                        {
                            Console.WriteLine("El nuevo PIN debe ser diferente al anterior.");
                        }
                        else if (nuevoPin.ToString().Length != 4)
                        {
                            Console.WriteLine("El PIN debe tener exactamente 4 dígitos.");
                        }
                        else if (nuevoPin < 1000)
                        {
                            Console.WriteLine("El PIN no puede iniciar con cero.");
                        }
                        else if (nuevoPin != confirmacionPin)
                        {
                            Console.WriteLine("La confirmación no coincide con el nuevo PIN.");
                        }
                        else
                        {
                            pinCorrecto = nuevoPin;
                            Console.WriteLine("PIN actualizado correctamente.");
                        }
                        break;
                            
                      



                    }
                    break;
            default:
                Console.WriteLine("Cuenta no reconocida.");
                break;
            }
        }
    }

}


