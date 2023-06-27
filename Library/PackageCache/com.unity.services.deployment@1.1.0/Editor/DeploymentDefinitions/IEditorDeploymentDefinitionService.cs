using System;
using System.Collections.ObjectModel;
using Unity.Services.Deployment.Core;

namespace Unity.Services.Deployment.Editor.DeploymentDefinitions
{
    interface IEditorDeploymentDefinitionService : IDeploymentDefinitionService
    {
        ObservableCollection<DeploymentDefinition> ObservableDeploymentDefinitions { get; }
        event Action DeploymentDefinitionPathChanged;
        event Action DeploymentDefinitionExcludePathsChanged;
        event Action DeploymentItemPathChanged;
    }
}
