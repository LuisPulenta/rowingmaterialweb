using System.ComponentModel.DataAnnotations;

namespace rowingmaterialweb.Shared.Entities
{
    public class AppInstalacionesEquiposDetalle
    {
        [Key]
        public int IDDETALLE { get; set; }
        public int IDINSTALACIONEQUIPO { get; set; }
        public string NROSERIEINSTALADA { get; set; } = null!;
        public int IDLOTECAB { get; set; }
        public string CODSIAG { get; set; } = null!;
        public string CODSAP { get; set; } = null!;
        public string NombreEquipo { get; set; } = null!;
        public string LinkFoto { get; set; } = null!;
        public int NROREGISTROLOTESCAB { get; set; }

        public string LinkFotoFullPath => string.IsNullOrEmpty(LinkFoto)
    ? $"http://190.111.249.225/RowingAppApi/images/Instalaciones/noimage.png"
    : $"http://190.111.249.225/RowingAppApi{LinkFoto.Substring(1)}";
    }
}
