using System.IO;
using System.Linq;
using System.Text;
using Unity.Services.Deployment.Core.Model;

namespace Unity.Services.Deployment.Core
{
    static class DeploymentDefinitionServiceExtensions
    {
        public static IDeploymentDefinition DefinitionForPath(this IDeploymentDefinitionService service, string path)
        {
            if (path == null)
            {
                return null;
            }

            var fullPath = path;
            if (!Path.IsPathFullyQualified(fullPath))
            {
                fullPath = Path.GetFullPath(fullPath);
            }

            var dirPath = Path.GetDirectoryName(fullPath);

            var bestPath = string.Empty;

            IDeploymentDefinition bestDefinition = service.DefaultDefinition;
            foreach (var definition in service.DeploymentDefinitions)
            {
                var definitionRootDir = Directory.GetParent(definition.Path)?.FullName;
                if (definitionRootDir != null
                    && dirPath.Contains(definitionRootDir)
                    && definitionRootDir.Length > bestPath.Length)
                {
                    bestDefinition = definition;
                    bestPath = definitionRootDir;
                }
            }

            return bestDefinition;
        }

        public static bool HasDuplicateDeploymentDefinitions(this IDeploymentDefinitionService service, out string duplicationError)
        {
            duplicationError = string.Empty;
            var paths = service.DeploymentDefinitions.Select(dDef => Path.GetDirectoryName(dDef.Path));
            var duplicates = paths
                .GroupBy(p => p)
                .Where(g => g.Count() > 1)
                .Select(x => x.Key)
                .ToList();

            if (duplicates.Any())
            {
                var error = new StringBuilder();
                duplicates.ForEach(path =>
                    error.AppendLine($"Folder <{path}> contains multiple deployment definition files."));

                duplicationError = error.ToString().TrimEnd();

                return true;
            }

            return false;
        }
    }
}
