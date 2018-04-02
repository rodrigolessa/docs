namespace Analyzing.Quality.Tools.UI.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ponto")]
    public partial class Ponto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ponto()
        {
            Intervalo = new HashSet<Intervalo>();
        }

        public int Id { get; set; }

        public int IdFuncionario { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Dia { get; set; }

        public TimeSpan? Horas { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intervalo> Intervalo { get; set; }
    }
}
