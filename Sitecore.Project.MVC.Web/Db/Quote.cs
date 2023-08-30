using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Sitecore.Project.MVC.Web.Db
{
    public partial class Quote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }

        public string Mobile { get; set; }

        [Required]
        [StringLength(128)]
        public string Service { get; set; }

        [Required]
        public string Note { get; set; }
    }
}
