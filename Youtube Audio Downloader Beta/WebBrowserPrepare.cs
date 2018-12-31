using Microsoft.Win32;
using System.Windows.Forms;

namespace YoutubeAudioDownloaderBeta
{
    internal static class WebBrowserPrepare
    {
        #region GLOBAL_VARIABLE
        private static readonly string applicationName = (Application.ProductName + ".exe");
        private static readonly string registryKeyPath = (@"Software\Microsoft\Internet Explorer\Main\FeatureControl\");
        #endregion

        #region SETWEBBROWSER_FEATURE
        private static void SetBrowserFeatureControlKey(string featureName, uint featureValue)
        {
            string subKeyPath = (registryKeyPath + featureName);

            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(subKeyPath, RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                if (registryKey.GetValue(applicationName) == null)
                {
                    registryKey.SetValue(applicationName, featureValue, RegistryValueKind.DWord);
                }
            }
        }
        #endregion

        #region SETWEBBROWSER_FEATURES
        public static void SetBrowserFeatureControl()
        {
            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", 11001);
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", 1);
        }
        #endregion
    }
}
