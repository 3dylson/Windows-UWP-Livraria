using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System.Profile;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace LivrariaVirtualApp.UWP.StateTriggers
{
    /// <summary>
    /// Custom trigger for Mobile device UI states.
    /// This trigger is active when the app runs on a mobile device and the
    /// UserInteractionMode is touch, which indicates that the app is showing
    /// on the device screen. When UserInteractionMode is mouse, the app is
    /// using Continuum to show on a larger screen.
    /// https://blogs.windows.com/buildingapps/2015/12/07/optimizing-apps-for-continuum-for-phone/#Yubo3bUdIM4H6Vle.97
    /// </summary>
    public class MobileScreenTrigger : StateTriggerBase
    {
        private UserInteractionMode _interactionMode;


        public MobileScreenTrigger()
        {
            Window.Current.SizeChanged += Window_SizeChanged;
        }

        private void Window_Activated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            UpdateTrigger();
        }

        private void Window_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            UpdateTrigger();
        }

        /// <summary>
        /// The target device family.
        /// </summary>
        public UserInteractionMode InteractionMode
        {
            get { return _interactionMode; }
            set { _interactionMode = value; UpdateTrigger(); }
        }

        private void UpdateTrigger()
        {
            // Get the current device family and interaction mode.
            var _currentDeviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;
            var _currentInteractionMode = UIViewSettings.GetForCurrentView().UserInteractionMode;

            // The trigger will be activated if the current device family is Windows.Mobile
            // and the UserInteractionMode matches the interaction mode value in XAML.
            SetActive(InteractionMode == _currentInteractionMode && _currentDeviceFamily == "Windows.Mobile");
        }
    }
}
