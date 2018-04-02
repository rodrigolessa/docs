namespace Analyzing.Quality.Tools.UI.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Intervalo")]
    public partial class Intervalo
    {
        public long Id { get; set; }

        public int IdPonto { get; set; }

        public TimeSpan? Entrada { get; set; }

        public TimeSpan? Saida { get; set; }

        public virtual Ponto Ponto { get; set; }
    }
}
