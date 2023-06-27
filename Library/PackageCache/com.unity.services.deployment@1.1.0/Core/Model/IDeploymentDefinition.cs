using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Unity.Services.Deployment.Core.Model
{
    internal interface IDeploymentDefinition : INotifyPropertyChanged
    {
        string Name { get; set; }
        string Path { get; set; }
        ObservableCollection<string> ExcludePaths { get; }
    }
}
