﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RepositoriesEntity
{
    public class Context : DbContext
    {
        public Context()
            : base(RepositoriesEntity.Configuration.Parameters.getChaveConexao())
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Models.Caderno> caderno { get; set; }
        public virtual DbSet<Models.Doce> doce { get; set; }
        public virtual DbSet<Models.Gibi> gibi { get; set; }

    }
}
