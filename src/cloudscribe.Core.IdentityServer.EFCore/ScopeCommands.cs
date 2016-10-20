﻿// Copyright (c) Source Tree Solutions, LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0
// Author:					Joe Audette
// Created:					2016-10-16
// Last Modified:			2016-10-16
// 

using cloudscribe.Core.IdentityServer.EFCore.Interfaces;
using cloudscribe.Core.IdentityServer.EFCore.Mappers;
using cloudscribe.Core.IdentityServerIntegration.Storage;
using cloudscribe.Core.Models.Generic;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cloudscribe.Core.IdentityServer.EFCore
{
    public class ScopeCommands : IScopeCommands
    {
        public ScopeCommands(
            IConfigurationDbContext context
            )
        {
            if(context == null) throw new ArgumentNullException(nameof(context));
            this.context = context;
           
        }

        private readonly IConfigurationDbContext context;
        

        public async Task CreateScope(string siteId, Scope scope, CancellationToken cancellationToken = default(CancellationToken))
        {
            var ent = scope.ToEntity();
            ent.SiteId = siteId;
            context.Scopes.Add(ent);
            await context.SaveChangesAsync();
        }

        public async Task UpdateScope(string siteId, Scope scope, CancellationToken cancellationToken = default(CancellationToken))
        {
            var name = scope.Name;
            var found = await context.Scopes.AsNoTracking().Where(x => x.SiteId == siteId && x.Name == name)
               .Select(x => x.Id).FirstOrDefaultAsync();
            var ent = scope.ToEntity();
            ent.Id = found;
            ent.SiteId = siteId;
            context.Scopes.Update(ent);
            await context.SaveChangesAsync();
        }

        public async Task DeleteScope(string siteId, string scopeName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scope = await context.Scopes.FirstOrDefaultAsync(x => x.SiteId == siteId && x.Name == scopeName);
            if (scope != null)
            {
                context.Scopes.Remove(scope);
                await context.SaveChangesAsync();
            }
        }

    }
}