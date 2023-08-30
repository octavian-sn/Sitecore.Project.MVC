using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Sitecore.Project.MVC.Web.Db
{
    public partial class QuoteContext : DbContext
    {
        public QuoteContext()
            : base("name=QuoteContext")
        {
        }

        public virtual DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
