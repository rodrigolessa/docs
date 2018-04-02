namespace Analyzing.Quality.Tools.UI.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tarefa")]
    public partial class Tarefa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tarefa()
        {
            IntervalosDeTarefa = new HashSet<IntervalosDeTarefa>();
        }

        public int Id { get; set; }

        public int IdFuncionario { get; set; }

        [StringLength(200)]
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public bool? Executada { get; set; }

        public long? IdIceScrum { get; set; }

        [StringLength(1)]
        public string Situacao { get; set; }

        public virtual Funcionario Funcionario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IntervalosDeTarefa> IntervalosDeTarefa { get; set; }
    }
}
