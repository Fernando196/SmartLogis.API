namespace SmartLogis.API.Models.Dtos
{
    public class DetalleEnvioDto
    {
        public int IdDetalle { get; set; }
        public int IdEnvio { get; set; }
        public int IdTransportista { get; set; }
        public int IdRuta { get; set; }
        public int IdEstatus { get; set; }
        public string? DescripcionCarga { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Peso { get; set; }

        public required Envio Envio { get; set; }
        public required Transportista Transportista { get; set; }
        public required Rutas Rutas { get; set; }
        public required Estatus Estatus { get; set; }
    }
}