﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using cloudscribe.Core.IdentityServer.EFCore.pgsql;

namespace cloudscribe.Core.IdentityServer.EFCore.pgsql.Migrations.PersistedGrantDb
{
    [DbContext(typeof(PersistedGrantDbContext))]
    partial class PersistedGrantDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("cloudscribe.Core.IdentityServer.EFCore.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key");

                    b.Property<string>("Type");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<DateTime>("CreationTime");

                    b.Property<string>("Data")
                        .IsRequired();

                    b.Property<DateTime>("Expiration");

                    b.Property<string>("SiteId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 36);

                    b.Property<string>("SubjectId");

                    b.HasKey("Key", "Type");

                    b.HasIndex("SiteId");

                    b.ToTable("csids_PersistedGrants");
                });
        }
    }
}
