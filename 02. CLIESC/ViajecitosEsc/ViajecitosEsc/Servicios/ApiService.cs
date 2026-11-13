using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using ViajecitosEsc.Models;

namespace ViajecitosEsc.Servicios
{
    public class ApiService
    {
        private readonly HttpClient _http;
        public string BaseApiUrl => "http://localhost:5070/api"; // AJUSTA EL PUERTO SEGÚN TU SERVIDOR

        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public ApiService()
        {
        }

        public async Task<UsuarioViewModel?> LoginAsync(LoginViewModel login)
        {
            var response = await _http.PostAsJsonAsync($"{BaseApiUrl}/Login", login);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<UsuarioViewModel>();
        }

        public async Task<List<string>> GetOrigenesAsync()
            => await _http.GetFromJsonAsync<List<string>>($"{BaseApiUrl}/Vuelo/origenes");

        public async Task<List<string>> GetDestinosAsync(string origen)
            => await _http.GetFromJsonAsync<List<string>>($"{BaseApiUrl}/Vuelo/destinos?origen={origen}");

        public async Task<List<VueloViewModel>> BuscarVuelosAsync(string origen, string destino, DateTime fecha)
        {
            string dateParam = fecha.ToString("yyyy-MM-ddTHH:mm:ss");
            return await _http.GetFromJsonAsync<List<VueloViewModel>>(
                $"{BaseApiUrl}/Vuelo?origen={origen}&destino={destino}&horaSalida={dateParam}");
        }

        public async Task<FacturaViewModel?> ComprarAsync(CompraViewModel compra)
        {
            var response = await _http.PostAsJsonAsync($"{BaseApiUrl}/Compra/comprar", compra);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content.ReadFromJsonAsync<FacturaViewModel>();
        }

        // ----------------------------- NUEVO: Resultado con error -----------------------
        public class CompraResult
        {
            public FacturaViewModel Factura { get; set; }
            public string Error { get; set; }
        }

        public async Task<CompraResult> ComprarConResultadoAsync(CarritoCompraViewModel carrito)
        {
            // Construcción dinámica: solo incluir tipoAmortizacion si aplica
            object bodyObj;
            if (carrito.Pago.TipoTarjeta == "Crédito" && carrito.Pago.Diferido == true && !string.IsNullOrWhiteSpace(carrito.TipoAmortizacion))
            {
                bodyObj = new
                {
                    idUsuario = carrito.IdUsuario,
                    vuelos = carrito.Vuelos.Select(v => new { idVuelo = v.IdVuelo, cantidadBoletos = v.CantidadBoletos }).ToList(),
                    pago = carrito.Pago,
                    tipoAmortizacion = carrito.TipoAmortizacion
                };
            }
            else
            {
                bodyObj = new
                {
                    idUsuario = carrito.IdUsuario,
                    vuelos = carrito.Vuelos.Select(v => new { idVuelo = v.IdVuelo, cantidadBoletos = v.CantidadBoletos }).ToList(),
                    pago = carrito.Pago
                    // tipoAmortizacion NO se envía
                };
            }

            var response = await _http.PostAsJsonAsync($"{BaseApiUrl}/Compra/comprar", bodyObj);

            if (!response.IsSuccessStatusCode)
            {
                var errorText = await response.Content.ReadAsStringAsync();
                return new CompraResult { Error = errorText };
            }

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var factura = await response.Content.ReadFromJsonAsync<FacturaViewModel>(options);

            // Captura tablaAmortizacion si viene en la respuesta (array)
            if (factura != null && response.Content != null)
            {
                var jsonDoc = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonDoc);
                if (doc.RootElement.TryGetProperty("tablaAmortizacion", out var tablaElement) && tablaElement.ValueKind == JsonValueKind.Array)
                {
                    factura.TablaAmortizacion = JsonSerializer.Deserialize<List<AmortizacionFilaViewModel>>(tablaElement.GetRawText(), options);
                }
                // También campo string amortizacionJson
                else if (doc.RootElement.TryGetProperty("amortizacionJson", out var amortJsonElement)
                        && amortJsonElement.ValueKind == JsonValueKind.String)
                {
                    var json = amortJsonElement.GetString();
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        try
                        {
                            factura.TablaAmortizacion = JsonSerializer.Deserialize<List<AmortizacionFilaViewModel>>(json, options);
                        }
                        catch { }
                    }
                }
            }
            return new CompraResult { Factura = factura };
        }

        // -----------------------------------------------------------------------------

        public async Task<FacturaViewModel?> GetFacturaAsync(int idFactura)
        {
            try
            {
                var response = await _http.GetAsync($"{BaseApiUrl}/Factura/{idFactura}");
                if (!response.IsSuccessStatusCode)
                    return null;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var factura = await response.Content.ReadFromJsonAsync<FacturaViewModel>(options);

                // Deserializa la tabla si viene en el campo amortizacionJson (string json)
                var jsonDoc = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonDoc);
                if (doc.RootElement.TryGetProperty("amortizacionJson", out var tablaElement)
                    && tablaElement.ValueKind == JsonValueKind.String)
                {
                    var json = tablaElement.GetString();
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        try
                        {
                            factura.TablaAmortizacion = JsonSerializer.Deserialize<List<AmortizacionFilaViewModel>>(json, options);
                        }
                        catch { }
                    }
                }

                // (por si acaso también viniera como array)
                else if (doc.RootElement.TryGetProperty("tablaAmortizacion", out var tablaArrElement)
                         && tablaArrElement.ValueKind == JsonValueKind.Array)
                {
                    factura.TablaAmortizacion = JsonSerializer.Deserialize<List<AmortizacionFilaViewModel>>(tablaArrElement.GetRawText(), options);
                }

                return factura;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<FacturaResumenViewModel>> GetHistorialAsync(int idUsuario)
        {
            return await _http.GetFromJsonAsync<List<FacturaResumenViewModel>>(
                $"{BaseApiUrl}/Factura/historial/{idUsuario}");
        }

        public async Task<List<CompraHistorialViewModel>> GetHistorialComprasAsync(int idUsuario)
        {
            return await _http.GetFromJsonAsync<List<CompraHistorialViewModel>>(
                $"{BaseApiUrl}/Factura/historial/{idUsuario}");
        }

        // Llama a la API de amortización
        public async Task<List<AmortizacionFilaViewModel>> CalcularAmortizacionAsync(decimal total, int meses, string tipo)
        {
            var obj = new { total = total, meses = meses, tipo = tipo };
            var response = await _http.PostAsJsonAsync($"{BaseApiUrl}/Amortizacion", obj);
            if (!response.IsSuccessStatusCode) return new List<AmortizacionFilaViewModel>();
            return await response.Content.ReadFromJsonAsync<List<AmortizacionFilaViewModel>>();
        }
    }
}
