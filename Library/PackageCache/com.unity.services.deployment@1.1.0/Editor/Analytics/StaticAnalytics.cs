using Unity.Services.Deployment.Editor.Shared.Analytics;
using Unity.Services.Deployment.Editor.Shared.Logging;
using UnityEditor;

namespace Unity.Services.Deployment.Editor.Analytics
{
    static class StaticAnalytics
    {
        const string k_EventNameOpenDeploymentWindow = "deployment_windowopened";
        const int k_VersionOpen = 1;

        public static void RegisterEvents()
        {
            AnalyticsUtils.RegisterEventDefault(k_EventNameOpenDeploymentWindow, k_VersionOpen);
            AnalyticsUtils.RegisterEventDefault(CommonAnalytics.eventName, CommonAnalytics.version);
        }

        public static void SendOpenedEvent()
        {
            var result = EditorAnalytics.SendEventWithLimit(k_EventNameOpenDeploymentWindow, null, k_VersionOpen);
            AnalyticsUtils.LogVerbose(k_EventNameOpenDeploymentWindow, k_VersionOpen, result);
        }

        public static void SendInitializeTiming(string context, int duration)
        {
            var result = new CommonAnalytics().Send(new ICommonAnalytics.CommonEventPayload
            {
                action = "initialize",
                duration = duration,
                context = context
            });
            Logger.LogVerbose($"Initialized {context} {duration}ms");
            AnalyticsUtils.LogVerbose(CommonAnalytics.eventName, CommonAnalytics.version, result);
        }
    }
}
