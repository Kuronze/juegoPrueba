using System;
using Unity.Services.Deployment.Core.Model;
using Unity.Services.Deployment.Editor.Shared.Infrastructure.Collections;

namespace Unity.Services.Deployment.Editor.Interface
{
    interface IDeploymentDefinitionViewModel : IDeploymentDefinition
    {
        IDeploymentDefinition Model { get; }
        IReadOnlyObservable<IDeploymentItemViewModel> DeploymentItemViewModels { get; }
    }
}
