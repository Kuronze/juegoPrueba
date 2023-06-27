using UnityEditor;
using UnityEngine.UIElements;

namespace Unity.Services.Deployment.Editor.Interface.UI.Views
{
    class NotSignedInView : ViewBase
    {
        protected override string UxmlName => "DeploymentWindow_NotSignedIn";

        public NotSignedInView()
        {
            var settingsBtn = this.Q<Button>();
            settingsBtn.clicked += OnSettingsClicked;
        }

        void OnSettingsClicked()
        {
#if ENABLE_EDITOR_GAME_SERVICES
            SettingsService.OpenProjectSettings("Project/Services/Deployment");
#else

            SettingsService.OpenProjectSettings("Project/Services");
#endif
        }

        new class UxmlFactory : UxmlFactory<NotSignedInView> {}
    }
}
