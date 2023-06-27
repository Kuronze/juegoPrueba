using System;
using Unity.Services.Deployment.Editor.Shared.Analytics;
using UnityEditor;

namespace Unity.Services.Deployment.Editor.Analytics
{
    class DeployOnPlayAnalytics : IDeployOnPlayAnalytics
    {
        const string k_EventNameDeployOnPlay = "deployment_deployonplay";
        const int k_VersionDeployOnPlay = 1;

        public DeployOnPlayAnalytics()
        {
            AnalyticsUtils.RegisterEventDefault(k_EventNameDeployOnPlay, k_VersionDeployOnPlay);
        }

        void SendDeployOnPlayEvent(int duration)
        {
            var evt = new DeployOnPlayEvent()
            {
                msDuration = duration
            };
            var result = EditorAnalytics.SendEventWithLimit(k_EventNameDeployOnPlay, evt, k_VersionDeployOnPlay);
            AnalyticsUtils.LogVerbose(k_EventNameDeployOnPlay, k_VersionDeployOnPlay, result);
        }

        public IDisposable GetEventScope()
        {
            return new DeployOnPlayScope(this);
        }

        struct DeployOnPlayScope : IDisposable
        {
            readonly AnalyticsTimer m_Timer;
            public DeployOnPlayScope(DeployOnPlayAnalytics parent)
            {
                m_Timer = new AnalyticsTimer(parent.SendDeployOnPlayEvent);
            }

            public void Dispose()
            {
                m_Timer.Dispose();
            }
        }

        [Serializable]
        struct DeployOnPlayEvent
        {
            public int msDuration;
        }
    }
}
