namespace Analyzing.Quality.Tools.UI.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IntervalosDeTarefa")]
    public partial class IntervalosDeTarefa
    {
        public long Id { get; set; }

        public int IdTarefa { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Inicio { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? Fim { get; set; }

        public virtual Tarefa Tarefa { get; set; }
    }
}
