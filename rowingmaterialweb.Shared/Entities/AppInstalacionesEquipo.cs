using System.ComponentModel.DataAnnotations;

namespace rowingmaterialweb.Shared.Entities
{
    public class AppInstalacionesEquipo
    {
        [Key]
        public int IDRegistro { get; set; }

        [Display(Name = "N° Obra")]
        public int NroObra { get; set; }

        [Display(Name = "Id Usuario")]
        public int IdUsuario { get; set; }

        public string Imei { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public string Latitud { get; set; } = null!;

        public string Longitud { get; set; } = null!;

        [Display(Name = "Fecha Instalación")]
        public DateTime FechaInstalacion { get; set; }

        public string Grupo { get; set; } = null!;

        public string Causante { get; set; } = null!;

        public string Pedido { get; set; } = null!;

        [Display(Name = "Nombre Cliente")]
        public string NombreCliente { get; set; } = null!;

        [Display(Name = "Apellido Cliente")]
        public string ApellidoCliente { get; set; } = null!;

        public string Documento { get; set; } = null!;

        [Display(Name = "Domicilio Instalación")]
        public string DomicilioInstalacion { get; set; } = null!;

        [Display(Name = "Entre Calles")]
        public string? EntreCalles { get; set; }

        [Display(Name = "Firma Cliente")]
        public string Firmacliente { get; set; } = null!;

        [Display(Name = "Nombre Apellido Cliente")]
        public string NombreApellidoFirmante { get; set; } = null!;

        [Display(Name = "Tipo Instalación")]
        public string TipoInstalacion { get; set; } = null!;

        [Display(Name = "Es Avería")]
        public string EsAveria { get; set; } = null!;

        public int Auditado { get; set; }

        public string DocumentoFirmante { get; set; } = null!;
        public int? MismoFirmante { get; set; }
        public string TipoPedido { get; set; } = null!;

        public string FirmaclienteImageFullPath => string.IsNullOrEmpty(Firmacliente)
     ? $"http://190.111.249.225/RowingAppApi/images/Instalaciones/noimage.png"
     : $"http://190.111.249.225/RowingAppApi{Firmacliente.Substring(1)}";

        public string NombreCompleto => $"{ApellidoCliente} {NombreCliente}";
    }
}
