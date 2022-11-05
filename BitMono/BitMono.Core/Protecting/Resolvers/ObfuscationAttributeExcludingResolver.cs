﻿using BitMono.API.Protecting.Resolvers;
using BitMono.Core.Models;
using dnlib.DotNet;
using Microsoft.Extensions.Configuration;
using NullGuard;
using System;
using System.Reflection;

namespace BitMono.Core.Protecting.Resolvers
{
    public class ObfuscationAttributeExcludingResolver : IObfuscationAttributeExcludingResolver
    {
        private readonly IAttemptAttributeResolver m_AttemptAttributeResolver;
        private readonly IConfiguration m_Configuration;

        public ObfuscationAttributeExcludingResolver(IAttemptAttributeResolver attemptAttributeResolver, IConfiguration configuration)
        {
            m_AttemptAttributeResolver = attemptAttributeResolver;
            m_Configuration = configuration;
        }

        public bool TryResolve(IHasCustomAttribute from, string feature, [AllowNull] out ObfuscationAttribute obfuscationAttribute)
        {
            var resolvingSucceed = m_AttemptAttributeResolver.TryResolve(from, _ =>
            {
                return m_Configuration.GetValue<bool>(nameof(AppSettings.ObfuscationAttributeObfuscationExcluding)) == true;
            }, o => o.Feature.Equals(feature, StringComparison.OrdinalIgnoreCase), attribute => attribute.StripAfterObfuscation, out obfuscationAttribute);

            if (resolvingSucceed == false)
            {
                return false;
            }
            if (obfuscationAttribute == null)
            {
                return false;
            }
            return true;
        }
    }
}