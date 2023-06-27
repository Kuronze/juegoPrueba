using System;
using UnityEditor;
using Hashing = Unity.Services.Deployment.Editor.Shared.Crypto.Hash;

namespace Unity.Services.Deployment.Editor.Analytics
{
    class DeploymentWindowAnalytics : IDeploymentWindowAnalytics
    {
        const string k_EventNameDoubleClickItem = "deployment_doubleclickitem";
        const string k_EventNameContextMenuOpened = "deployment_contextmenuopened";
        const string k_EventNameContextMenuSelect = "deployment_contextmenuselect";
        const int k_VersionDoubleClick = 1;
        const int k_VersionContextMenuOpened = 1;
        const int k_VersionContextMenuSelect = 1;

        public DeploymentWindowAnalytics()
        {
            AnalyticsUtils.RegisterEventDefault(k_EventNameDoubleClickItem, k_VersionDoubleClick);
            AnalyticsUtils.RegisterEventDefault(k_EventNameContextMenuOpened, k_VersionContextMenuOpened);
            AnalyticsUtils.RegisterEventDefault(k_EventNameContextMenuSelect, k_VersionContextMenuSelect);
        }

        public void SendDoubleClickEvent(string itemPath)
        {
            var result = EditorAnalytics.SendEventWithLimit(
                k_EventNameDoubleClickItem,
                new ItemPathParams(itemPath),
                k_VersionDoubleClick);
            AnalyticsUtils.LogVerbose(k_EventNameDoubleClickItem, k_VersionDoubleClick, result);
        }

        public void SendContextMenuOpenEvent(string itemPath)
        {
            var result = EditorAnalytics.SendEventWithLimit(
                k_EventNameContextMenuOpened,
                new ItemPathParams(itemPath),
                k_VersionContextMenuOpened);
            AnalyticsUtils.LogVerbose(k_EventNameContextMenuOpened, k_VersionContextMenuOpened, result);
        }

        public void SendContextMenuSelectEvent(string itemPath)
        {
            var result = EditorAnalytics.SendEventWithLimit(
                k_EventNameContextMenuSelect,
                new ItemPathParams(itemPath),
                k_VersionContextMenuSelect);
            AnalyticsUtils.LogVerbose(k_EventNameContextMenuSelect, k_VersionContextMenuSelect, result);
        }

        // Lowercase to match the naming schema
        [Serializable]
        public struct ItemPathParams
        {
            static readonly GUID k_NullGUID = new GUID();

            public string itemName;

            public ItemPathParams(string itemPath)
            {
                var assetGuid = AssetDatabase.GUIDFromAssetPath(itemPath);
                this.itemName = Hashing.SHA1(assetGuid == k_NullGUID ? itemPath : assetGuid.ToString());
            }
        }
    }
}
