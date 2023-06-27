using System.Collections.Generic;
using Unity.Services.Deployment.Core.Model;

namespace Unity.Services.Deployment.Core
{
    internal interface IDeploymentDefinitionService
    {
        IDeploymentDefinition DefaultDefinition { get; }
        IReadOnlyList<IDeploymentDefinition> DeploymentDefinitions { get; }
    }
}
