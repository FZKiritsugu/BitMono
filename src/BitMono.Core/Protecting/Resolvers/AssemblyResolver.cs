﻿namespace BitMono.Core.Protecting.Resolvers;

public class AssemblyResolver
{
    public AssemblyResolve Resolve(IEnumerable<byte[]> dependenciesData, ProtectionContext context)
    {
        context.ThrowIfCancellationRequested();

        var resolvedReferences = new List<AssemblyReference>();
        var failedToResolveReferences = new List<AssemblyReference>();
        var signatureComparer = new SignatureComparer(SignatureComparisonFlags.AcceptNewerVersions);

        foreach (var originalReference in context.Module.AssemblyReferences)
        {
            context.ThrowIfCancellationRequested();

            foreach (var data in dependenciesData)
            {
                context.ThrowIfCancellationRequested();

                var definition = AssemblyDefinition.FromBytes(data);
                if (context.AssemblyResolver.HasCached(originalReference) == false && signatureComparer.Equals(originalReference, definition))
                {
                    context.AssemblyResolver.AddToCache(originalReference, definition);
                }
            }
        }
        var succeed = true;
        foreach (var originalReference in context.Module.AssemblyReferences)
        {
            if (context.AssemblyResolver.HasCached(originalReference))
            {
                resolvedReferences.Add(originalReference);
            }
            else
            {
                failedToResolveReferences.Add(originalReference);
                succeed = false;
            }
        }
        return new AssemblyResolve
        {
            ResolvedReferences = resolvedReferences,
            FailedToResolveReferences = failedToResolveReferences,
            Succeed = succeed
        };
    }
}