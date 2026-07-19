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
       
        // solcitud y validacion de datos
        Console.WriteLine("Por favor, ingrese su numero de cuenta:");
        int numeroDeCuentaIngresado = int.Parse(Console.ReadLine());
        if (numeroDeCuentaIngresado != cuentaCorrecta)
        {
            Console.WriteLine("Numero de cuenta incorrecto");
            return;
        }

        Console.WriteLine("Ingrese su PIN:");
        int pinIngresado = int.Parse(Console.ReadLine());

        if (pinIngresado != pinCorrecto)
        {
            Console.WriteLine("PIN incorrecto");
            return;
        }

        // MENU PRINCIPAL :)

                Console.WriteLine("Seleccione una opción:");

                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Retirar dinero");
                Console.WriteLine("3. Depositar dinero");
                Console.WriteLine("4. Transferir dinero");
                Console.WriteLine("5. Cambiar PIN");
                Console.WriteLine("6. Simular préstamo");
                Console.WriteLine("7. Ver resumen de cuenta");
                Console.WriteLine("8. Salir");


                    int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {

                // CONSULTAR SALDO

                case 1:
                    Console.WriteLine("Su saldo actual es: $" + saldo);
                    Console.WriteLine("Su límite diario de retiro es: $" + limiteDiarioDeRetiro);
                    Console.WriteLine("Su monto restante para retirar es: $" + (limiteDiarioDeRetiro - saldo));
                    break;

                    // RETIRAR DINERO

                    case 2:
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

                    // DEPOSITAR DINERO

                    case 3:
                        Console.WriteLine("Ingrese el monto a depositar:");
                        decimal montoADepositar = decimal.Parse(Console.ReadLine());
                        

                        if (montoADepositar <= 0)
                        {
                            Console.WriteLine("El monto a depositar debe ser mayor a cero.");
                        }
                        else if (montoADepositar > 5000.00m)
                        {
                            Console.WriteLine("No puede depositar un monto mayor a $5,000.00");
                        }

                        else
                        {
                            saldo += montoADepositar;
                            if (montoADepositar > 2500.00m)
                            {
                                Console.WriteLine("Depósito sujeto a revisión bancaria.");
                            }
                                Console.WriteLine("Saldo actualizado: $" + saldo.ToString("F2"));

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
                            Console.WriteLine("Cuenta destino: " + cuentaDestinatario);
                            Console.WriteLine("Transferencia exitosa. Se ha transferido $" + montoATransferir + " a la cuenta " + cuentaDestinatario);
                            Console.WriteLine("Comisión aplicada: $" + comision);
                            Console.WriteLine("Su nuevo saldo es: $" + saldo);
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

                        //Opcion simular prestamo
                        case 6:

                            Console.WriteLine("Ingrese el monto solicitado:");

                            decimal montoPrestamo = decimal.Parse(Console.ReadLine());



                            Console.WriteLine("Ingrese el plazo en meses (12, 24 o 36):");

                            int plazoMeses = int.Parse(Console.ReadLine());



                            decimal tasaInteres = 0;

                            if (plazoMeses == 12) tasaInteres = 0.08m;

                            else if (plazoMeses == 24) tasaInteres = 0.12m;

                            else if (plazoMeses == 36) tasaInteres = 0.18m;



                            if (montoPrestamo <= 0)

                            {

                                Console.WriteLine("El monto solicitado debe ser mayor a cero.");

                            }

                            else if (plazoMeses != 12 && plazoMeses != 24 && plazoMeses != 36)

                            {

                                Console.WriteLine("Plazo inválido. Debe ser 12, 24 o 36 meses.");

                            }

                            else

                            {

                                decimal interes = montoPrestamo * tasaInteres;

                                decimal totalAPagar = montoPrestamo + interes;

                                decimal cuotaMensual = totalAPagar / plazoMeses;



                                Console.WriteLine("Interés: $" + interes.ToString("F2"));

                                Console.WriteLine("Total a pagar: $" + totalAPagar.ToString("F2"));

                                Console.WriteLine("Cuota mensual: $" + cuotaMensual.ToString("F2"));



                                if (montoPrestamo > 15000.00m)

                                {

                                    Console.WriteLine("Requiere aprobación del gerente.");

                                }

                            }

                            break;

                        // VER RESUMEN DE CUENTA.
                        case 7:
                            Console.WriteLine("Resumen de cuenta:");

                            if (saldo > 2000.00m)
                            {
                                Console.WriteLine("Usted es un Cliente de nivel Oro");
                            }
                            else if (saldo >= 1000.00m && saldo <= 2000.00m)
                            {
                                Console.WriteLine("Usted es un cliente de nivel Plata");
                            }
                            else if (saldo < 1000.00m)
                            {
                                Console.WriteLine("Usted es un cliente de nivel Bronce");
                            }

                            //apartado para nivel de finanza

                            if (saldo > 5000.00m)
                            {
                                Console.WriteLine("Cliente con Excelente capacidad financiera");
                            }
                            else if (saldo >= 2000.00m && saldo <= 5000.00m)
                            {
                                Console.WriteLine("Cliente con nivel saludable de finanzas");
                            }
                            else if (saldo >=1000.00m && saldo < 2000.00m)
                            {
                                Console.WriteLine("El cliente debe controlar sus gastos");
                            }
                            else if (saldo < 1000.00m)
                            {
                                Console.WriteLine("Cliente con nivel de finanzas muy bajo");
                            }

                            // panel para mostrar.

                            Console.WriteLine("El nombre del cliente es : " + nombrePredeterminado);
                            Console.WriteLine("El numero de cuenta es : " + cuentaCorrecta);
                            Console.WriteLine("El saldo actual es : " + saldo);
                            Console.WriteLine("El monto retirado es : " + limiteDiarioDeRetiro);
                            Console.WriteLine("El limite restante es : " + (limiteDiarioDeRetiro - saldo));
                            Console.WriteLine("El estado de la cuenta es : " + (saldo > 0 ? "Activa" : "Inactiva"));

                            break;

                        // Opcion salir
                            case 8:
                            Console.WriteLine("Muchas gracias por utilizar BancoTech, el mejor banco del mundo, lo esperamos nuevamente");
                            break;

                             default:
                                 Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                                break;
        }                       



    }
        }
    




