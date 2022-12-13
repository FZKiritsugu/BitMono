﻿using BitMono.API.Protecting;
using BitMono.API.Protecting.Pipeline;
using BitMono.API.Protecting.Resolvers;
using BitMono.Core.Models;
using BitMono.Core.Protecting.Resolvers;
using BitMono.Utilities.Extensions;
using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ILogger = Serilog.ILogger;

namespace BitMono.Obfuscation
{
    public class ProtectionsSorter
    {
        private readonly IDnlibDefObfuscationAttributeResolver m_DnlibDefFeatureObfuscationAttributeHavingResolver;
        private readonly AssemblyDef m_ModuleDefMDAssembly;
        private readonly ILogger m_Logger;

        public ProtectionsSorter(
            IDnlibDefObfuscationAttributeResolver dnlibDefFeatureObfuscationAttributeHavingResolver,
            AssemblyDef moduleDefMDAssembly,
            ILogger logger)
        {
            m_DnlibDefFeatureObfuscationAttributeHavingResolver = dnlibDefFeatureObfuscationAttributeHavingResolver;
            m_ModuleDefMDAssembly = moduleDefMDAssembly;
            m_Logger = logger;
        }

        public ProtectionsSortingResult Sort(List<IProtection> protections, IEnumerable<ProtectionSettings> protectionSettings)
        {
            protections = new DependencyResolver(protections, protectionSettings, m_Logger)
                .Sort(out List<string> skipped);
            var packers = protections.Where(p => p is IPacker).Cast<IPacker>().ToList();
            var deprecatedProtections = protections.Where(p => p.GetType().GetCustomAttribute<ObsoleteAttribute>(false) != null);
            var stageProtections = protections.Where(p => p is IStageProtection).Cast<IStageProtection>();
            var pipelineProtections = protections.Where(p => p is IPipelineProtection).Cast<IPipelineProtection>();
            var obfuscationAttributeExcludingProtections = protections.Where(p =>
                m_DnlibDefFeatureObfuscationAttributeHavingResolver.Resolve(p.GetName(), m_ModuleDefMDAssembly));

            protections = protections.Except(obfuscationAttributeExcludingProtections).ToList();

            return new ProtectionsSortingResult
            {
                Protections = protections,
                Packers = packers,
                DeprecatedProtections = deprecatedProtections,
                Skipped = skipped,
                StageProtections = stageProtections,
                PipelineProtections = pipelineProtections,
                ObfuscationAttributeExcludingProtections = obfuscationAttributeExcludingProtections
            };
        }
    }
}