using System.Text;
using ViajecitosCon.Models;
using ViajecitosEsc.Models;
using ViajecitosEsc.Servicios;

class Program
{
    static ApiService apiService = new ApiService(new HttpClient());
    static UsuarioViewModel usuarioActual = null;
    static CarritoCompraConsola carrito = new CarritoCompraConsola();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // LOGIN
        while (usuarioActual == null)
        {
            Console.Clear();
            Console.WriteLine("=== Viajecitos Esc ===");
            Console.WriteLine("Iniciar sesión");
            Console.Write("Correo: ");
            var correo = Console.ReadLine();
            Console.Write("Contraseña: ");
            var contrasena = LeerPassword();

            var loginModel = new LoginViewModel
            {
                Email = correo,
                Contraseña = contrasena
            };

            usuarioActual = apiService.LoginAsync(loginModel).GetAwaiter().GetResult();

            if (usuarioActual == null)
            {
                Console.WriteLine("Correo o contraseña incorrectos.");
                Console.WriteLine("¿Desea intentar de nuevo? (S/N): ");
                var retry = Console.ReadLine();
                if (retry?.Trim().ToUpper() != "S")
                    return;
            }
        }

        // MENÚ PRINCIPAL
        MostrarMenuPrincipal();
    }

    static void MostrarMenuPrincipal()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Bienvenido, {usuarioActual.Nombre} {usuarioActual.Apellido}");
            Console.WriteLine("1. Buscar vuelos");
            Console.WriteLine("2. Ver carrito");
            Console.WriteLine("3. Consultar factura");
            Console.WriteLine("4. Ver historial");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    BuscarVuelos(apiService, usuarioActual);
                    break;
                case "2":
                    VerCarritoYProcederPago(apiService, usuarioActual);
                    break;
                case "3":
                    ConsultarFactura(apiService);
                    break;
                case "4":
                    VerHistorial(apiService, usuarioActual);
                    break;
                case "0":
                    Console.WriteLine("¡Hasta luego!");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    // Método para leer contraseña oculta
    static string LeerPassword()
    {
        var pass = new StringBuilder();
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                pass.Append(key.KeyChar);
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
            {
                pass.Remove(pass.Length - 1, 1);
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        return pass.ToString();
    }

    static void BuscarVuelos(ApiService apiService, UsuarioViewModel usuarioActual)
    {
        Console.Clear();
        Console.WriteLine("=== Buscar Vuelos ===");

        // 1. Seleccionar origen
        var origenes = apiService.GetOrigenesAsync().GetAwaiter().GetResult();
        if (origenes == null || origenes.Count == 0)
        {
            Console.WriteLine("No hay ciudades de origen disponibles.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("Ciudades de origen:");
        for (int i = 0; i < origenes.Count; i++)
            Console.WriteLine($"{i + 1}. {origenes[i]}");
        int idxOrigen;
        while (true)
        {
            Console.Write("Seleccione origen: ");
            if (int.TryParse(Console.ReadLine(), out idxOrigen) && idxOrigen > 0 && idxOrigen <= origenes.Count)
                break;
            Console.WriteLine("Opción inválida.");
        }
        string origen = origenes[idxOrigen - 1];

        // 2. Seleccionar destino
        var destinos = apiService.GetDestinosAsync(origen).GetAwaiter().GetResult();
        if (destinos == null || destinos.Count == 0)
        {
            Console.WriteLine("No hay destinos disponibles para ese origen.");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("Ciudades de destino:");
        for (int i = 0; i < destinos.Count; i++)
            Console.WriteLine($"{i + 1}. {destinos[i]}");
        int idxDestino;
        while (true)
        {
            Console.Write("Seleccione destino: ");
            if (int.TryParse(Console.ReadLine(), out idxDestino) && idxDestino > 0 && idxDestino <= destinos.Count)
                break;
            Console.WriteLine("Opción inválida.");
        }
        string destino = destinos[idxDestino - 1];

        // 3. Seleccionar fecha
        DateTime fecha;
        while (true)
        {
            Console.Write("Ingrese la fecha de salida (yyyy-MM-dd): ");
            var fechaStr = Console.ReadLine();
            if (DateTime.TryParse(fechaStr, out fecha) && fecha.Date >= DateTime.Now.Date)
                break;
            Console.WriteLine("Fecha inválida o anterior a hoy. Intente de nuevo.");
        }

        // 4. Buscar vuelos
        var vuelos = apiService.BuscarVuelosAsync(origen, destino, fecha).GetAwaiter().GetResult();
        if (vuelos == null || vuelos.Count == 0)
        {
            Console.WriteLine("No hay vuelos disponibles para esa búsqueda.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nVuelos disponibles:");
        for (int i = 0; i < vuelos.Count; i++)
        {
            var v = vuelos[i];
            Console.WriteLine($"{i + 1}. {v.CiudadOrigen} -> {v.CiudadDestino} | {v.HoraSalida:yyyy-MM-dd HH:mm} | ${v.Valor:N2}");
        }

        // 5. Seleccionar vuelo y cantidad
        int idxVuelo;
        while (true)
        {
            Console.Write("Seleccione el vuelo a agregar al carrito (0 para volver): ");
            if (int.TryParse(Console.ReadLine(), out idxVuelo) && idxVuelo >= 0 && idxVuelo <= vuelos.Count)
                break;
            Console.WriteLine("Opción inválida.");
        }
        if (idxVuelo == 0)
            return;

        var vueloSeleccionado = vuelos[idxVuelo - 1];
        int cantidad;
        while (true)
        {
            Console.Write("Cantidad de boletos: ");
            if (int.TryParse(Console.ReadLine(), out cantidad) && cantidad > 0)
                break;
            Console.WriteLine("Cantidad inválida.");
        }

        // 6. Agregar al carrito
        carrito.AgregarVuelo(new VueloCarritoItem
        {
            IdVuelo = vueloSeleccionado.IdVuelo,
            CiudadOrigen = vueloSeleccionado.CiudadOrigen,
            CiudadDestino = vueloSeleccionado.CiudadDestino,
            HoraSalida = vueloSeleccionado.HoraSalida,
            Valor = vueloSeleccionado.Valor,
            CantidadBoletos = cantidad
        });

        Console.WriteLine($"Agregado {cantidad} boleto(s) de {vueloSeleccionado.CiudadOrigen} a {vueloSeleccionado.CiudadDestino} en {vueloSeleccionado.HoraSalida:yyyy-MM-dd HH:mm} al carrito.");
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    static void VerCarritoYProcederPago(ApiService apiService, UsuarioViewModel usuarioActual)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Carrito de Compras ===");

            if (carrito.Vuelos.Count == 0)
            {
                Console.WriteLine("El carrito está vacío.");
                Console.WriteLine("Presione una tecla para volver al menú...");
                Console.ReadKey();
                return;
            }

            // Mostrar detalles del carrito
            for (int i = 0; i < carrito.Vuelos.Count; i++)
            {
                var v = carrito.Vuelos[i];
                Console.WriteLine($"{i + 1}. {v.CiudadOrigen} -> {v.CiudadDestino} | {v.HoraSalida:yyyy-MM-dd HH:mm} | " +
                                  $"Boletos: {v.CantidadBoletos} | Precio unitario: ${v.Valor:N2} | Subtotal: ${v.Valor * v.CantidadBoletos:N2}");
            }
            Console.WriteLine($"Total del carrito: ${carrito.Total:N2}");

            // Opción para eliminar vuelos del carrito
            Console.Write("¿Desea eliminar algún vuelo del carrito? (S/N): ");
            var eliminar = Console.ReadLine();
            if (eliminar?.Trim().ToUpper() == "S")
            {
                Console.Write("Ingrese el número del vuelo a eliminar (0 para cancelar): ");
                if (int.TryParse(Console.ReadLine(), out int idxEliminar) && idxEliminar > 0 && idxEliminar <= carrito.Vuelos.Count)
                {
                    carrito.Vuelos.RemoveAt(idxEliminar - 1);
                    Console.WriteLine("Vuelo eliminado del carrito.");
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    continue; // Refresca el carrito
                }
            }

            // Validación de reglas antes de pagar
            if (!carrito.EsCompraValida(out string mensajeError))
            {
                Console.WriteLine(mensajeError);
                Console.WriteLine("No se puede proceder con la compra. Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            // 1. Selección de tipo de tarjeta
            string tipoTarjeta = "";
            while (true)
            {
                Console.Write("Tipo de tarjeta (1 = Crédito, 2 = Débito): ");
                var tipo = Console.ReadLine();
                if (tipo == "1") { tipoTarjeta = "Crédito"; break; }
                if (tipo == "2") { tipoTarjeta = "Débito"; break; }
                Console.WriteLine("Opción inválida.");
            }

            // 2. Si es crédito, preguntar por diferido y amortización
            bool diferido = false;
            int mesesDiferido = 1;
            string tipoAmortizacion = "";

            if (tipoTarjeta == "Crédito")
            {
                Console.Write("¿Desea diferir el pago? (S/N): ");
                var deseaDiferir = Console.ReadLine();
                if (deseaDiferir?.Trim().ToUpper() == "S")
                {
                    diferido = true;
                    while (true)
                    {
                        Console.Write("¿A cuántos meses desea diferir? (1-24): ");
                        if (int.TryParse(Console.ReadLine(), out mesesDiferido) && mesesDiferido >= 1 && mesesDiferido <= 24)
                            break;
                        Console.WriteLine("Meses inválidos.");
                    }
                    while (true)
                    {
                        Console.Write("Tipo de amortización (1 = Alemana, 2 = Francesa): ");
                        var tipoAmort = Console.ReadLine();
                        if (tipoAmort == "1") { tipoAmortizacion = "alemana"; break; }
                        if (tipoAmort == "2") { tipoAmortizacion = "francesa"; break; }
                        Console.WriteLine("Opción inválida.");
                    }

                    // Mostrar tabla de amortización
                    var tabla = apiService.CalcularAmortizacionAsync(carrito.Total, mesesDiferido, tipoAmortizacion).GetAwaiter().GetResult();
                    Console.WriteLine("\nTabla de Amortización:");
                    Console.WriteLine("Mes | Cuota | Interés | Amortización | Saldo");
                    foreach (var fila in tabla)
                    {
                        Console.WriteLine($"{fila.Mes,2} | {fila.Cuota,10:N2} | {fila.Interes,8:N2} | {fila.Amortizacion,13:N2} | {fila.Saldo,10:N2}");
                    }
                }
            }

            // 3. Solicitar datos de pago
            Console.Write("Nombre del titular: ");
            var nombreTitular = Console.ReadLine();
            Console.Write("Número de tarjeta: ");
            var numeroTarjeta = Console.ReadLine();
            Console.Write("Código de seguridad: ");
            var codigoSeguridad = Console.ReadLine();

            // 4. Confirmar datos antes de comprar
            Console.WriteLine("\nResumen de pago:");
            Console.WriteLine($"Titular: {nombreTitular}");
            Console.WriteLine($"Tarjeta: {tipoTarjeta}");
            if (tipoTarjeta == "Crédito")
            {
                Console.WriteLine($"Diferido: {(diferido ? "Sí" : "No")}");
                if (diferido)
                {
                    Console.WriteLine($"Meses: {mesesDiferido}");
                    Console.WriteLine($"Tipo de amortización: {tipoAmortizacion}");
                }
            }
            Console.WriteLine($"Total a pagar: ${carrito.Total:N2}");
            Console.Write("¿Los datos son correctos? (S/N): ");
            var confirmacion = Console.ReadLine();
            if (confirmacion?.Trim().ToUpper() != "S")
            {
                Console.WriteLine("Reingresando datos de pago...");
                continue; // Vuelve a pedir los datos
            }

            // 5. Construir el modelo de pago y carrito para la API
            var carritoApi = new CarritoCompraViewModel
            {
                IdUsuario = usuarioActual.IdUsuario,
                Vuelos = carrito.Vuelos.Select(v => new VueloCarritoItemViewModel
                {
                    IdVuelo = v.IdVuelo,
                    CiudadOrigen = v.CiudadOrigen,
                    CiudadDestino = v.CiudadDestino,
                    Valor = v.Valor,
                    HoraSalida = v.HoraSalida.ToString("yyyy-MM-dd HH:mm"),
                    CantidadBoletos = v.CantidadBoletos
                }).ToList(),
                Pago = new PagoViewModel
                {
                    TipoTarjeta = tipoTarjeta,
                    NombreTitular = nombreTitular,
                    NumeroTarjeta = numeroTarjeta,
                    CodigoSeguridad = codigoSeguridad,
                    Diferido = diferido,
                    MesesDiferido = diferido ? mesesDiferido : null
                },
                TipoAmortizacion = diferido ? tipoAmortizacion : null
            };

            // 6. Llamar a la API para comprar
            var resultado = apiService.ComprarConResultadoAsync(carritoApi).GetAwaiter().GetResult();

            if (!string.IsNullOrWhiteSpace(resultado.Error))
            {
                Console.WriteLine("Error al realizar la compra: " + resultado.Error);
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            if (resultado.Factura == null)
            {
                Console.WriteLine("No se pudo realizar la compra. Inténtalo nuevamente.");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"¡Compra exitosa! Factura N° {resultado.Factura.IdFactura}");
            carrito.Vuelos.Clear(); // Vacía el carrito tras la compra
            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey();
            return;
        }
    }

    static void ConsultarFactura(ApiService apiService)
    {
        Console.Clear();
        Console.WriteLine("=== Consultar Factura ===");

        Console.Write("Ingrese el número de factura: ");
        if (!int.TryParse(Console.ReadLine(), out int idFactura))
        {
            Console.WriteLine("ID de factura inválido.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }

        var factura = apiService.GetFacturaAsync(idFactura).GetAwaiter().GetResult();
        if (factura == null)
        {
            Console.WriteLine($"No existe factura con el código {idFactura}.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }

        // Mostrar datos de la factura
        Console.WriteLine($"\nFactura N°: {factura.IdFactura}");
        Console.WriteLine($"Fecha: {factura.FechaFactura:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"Empleado: {factura.Empleado}");
        Console.WriteLine($"Usuario: {factura.NombreUsuario} {factura.ApellidoUsuario}");
        Console.WriteLine($"Teléfono: {factura.TelefonoUsuario}");
        Console.WriteLine($"Método de Pago: {factura.MetodoPago}");
        Console.WriteLine($"Descripción: {factura.Descripcion}");
        Console.WriteLine($"Cantidad de Boletos: {factura.CantidadBoletos}");
        Console.WriteLine($"Tarifa Unitario: {factura.TarifaUnitario:C}");
        Console.WriteLine($"Subtotal: {factura.TotalParcial:C}");
        Console.WriteLine($"Impuesto: {factura.Impuesto:C}");
        Console.WriteLine($"Total: {factura.TotalFinal:C}");

        // Mostrar tabla de amortización si existe
        if (factura.TablaAmortizacion != null && factura.TablaAmortizacion.Count > 0)
        {
            Console.WriteLine("\nTabla de Amortización:");
            Console.WriteLine("Mes | Cuota | Interés | Amortización | Saldo");
            foreach (var fila in factura.TablaAmortizacion)
            {
                Console.WriteLine($"{fila.Mes,2} | {fila.Cuota,10:N2} | {fila.Interes,8:N2} | {fila.Amortizacion,13:N2} | {fila.Saldo,10:N2}");
            }
        }

        Console.WriteLine("\nPresione una tecla para volver al menú...");
        Console.ReadKey();
    }

    static void VerHistorial(ApiService apiService, UsuarioViewModel usuarioActual)
    {
        Console.Clear();
        Console.WriteLine("=== Historial de Compras ===");

        var historial = apiService.GetHistorialAsync(usuarioActual.IdUsuario).GetAwaiter().GetResult();
        if (historial == null || historial.Count == 0)
        {
            Console.WriteLine("No hay facturas registradas.");
            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey();
            return;
        }

        // Mostrar listado de facturas
        for (int i = 0; i < historial.Count; i++)
        {
            var f = historial[i];
            Console.WriteLine($"{i + 1}. Factura: {f.IdFactura} | Fecha: {f.FechaFactura:yyyy-MM-dd HH:mm} | Boletos: {f.CantidadBoletos} | Total: {f.TotalFinal:C} | {f.Descripcion}");
        }

        // Permitir seleccionar una factura para ver detalles
        Console.Write("\nSeleccione el número de la factura para ver detalles (0 para volver): ");
        if (!int.TryParse(Console.ReadLine(), out int idx) || idx < 0 || idx > historial.Count)
        {
            Console.WriteLine("Opción inválida.");
            Console.ReadKey();
            return;
        }
        if (idx == 0)
            return;

        var facturaSeleccionada = historial[idx - 1];
        // Llama al método de consulta de factura para mostrar detalles
        ConsultarFacturaPorId(apiService, facturaSeleccionada.IdFactura);
    }

    static void ConsultarFacturaPorId(ApiService apiService, int idFactura)
    {
        var factura = apiService.GetFacturaAsync(idFactura).GetAwaiter().GetResult();
        if (factura == null)
        {
            Console.WriteLine($"No existe factura con el código {idFactura}.");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            return;
        }

        // Mostrar datos de la factura
        Console.WriteLine($"\nFactura N°: {factura.IdFactura}");
        Console.WriteLine($"Fecha: {factura.FechaFactura:yyyy-MM-dd HH:mm}");
        Console.WriteLine($"Empleado: {factura.Empleado}");
        Console.WriteLine($"Usuario: {factura.NombreUsuario} {factura.ApellidoUsuario}");
        Console.WriteLine($"Teléfono: {factura.TelefonoUsuario}");
        Console.WriteLine($"Método de Pago: {factura.MetodoPago}");
        Console.WriteLine($"Descripción: {factura.Descripcion}");
        Console.WriteLine($"Cantidad de Boletos: {factura.CantidadBoletos}");
        Console.WriteLine($"Tarifa Unitario: {factura.TarifaUnitario:C}");
        Console.WriteLine($"Subtotal: {factura.TotalParcial:C}");
        Console.WriteLine($"Impuesto: {factura.Impuesto:C}");
        Console.WriteLine($"Total: {factura.TotalFinal:C}");

        // Mostrar tabla de amortización si existe
        if (factura.TablaAmortizacion != null && factura.TablaAmortizacion.Count > 0)
        {
            Console.WriteLine("\nTabla de Amortización:");
            Console.WriteLine("Mes | Cuota | Interés | Amortización | Saldo");
            foreach (var fila in factura.TablaAmortizacion)
            {
                Console.WriteLine($"{fila.Mes,2} | {fila.Cuota,10:N2} | {fila.Interes,8:N2} | {fila.Amortizacion,13:N2} | {fila.Saldo,10:N2}");
            }
        }

        Console.WriteLine("\nPresione una tecla para volver al historial...");
        Console.ReadKey();
    }
}