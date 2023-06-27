using Unity.Services.Deployment.Editor.Shared.EditorUtils;
using Unity.Services.Deployment.Editor.Shared.Logging;
using UnityEditor;
using UnityEngine.Analytics;

namespace Unity.Services.Deployment.Editor.Analytics
{
    static class AnalyticsUtils
    {
        public static void RegisterEventDefault(string eventName, int version = 1)
        {
            Sync.RunNextUpdateOnMain(() =>
            {
                var result = EditorAnalytics.RegisterEventWithLimit(
                    eventName,
                    AnalyticsConstants.k_MaxEventPerHour,
                    AnalyticsConstants.k_MaxItems,
                    AnalyticsConstants.k_VendorKey,
                    version);

                Logger.LogVerbose($"Registered Analytics: {eventName}.v{version}. Result: {result}");
            });
        }

        public static void LogVerbose(string eventName, int version, AnalyticsResult result)
        {
            Logger.LogVerbose($"Sent Analytics Event: {eventName}.v{version}. Result: {result}");
        }
    }
}
