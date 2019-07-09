using UnityEngine;

namespace LightVibration
{

    public static class VibrationManager
    {
        private static bool _isVibrationEnabled = true;
        public static bool VibrationEnabled { get { return _isVibrationEnabled; } set { _isVibrationEnabled = value; } }

        public static void VibrateLight()
        {
            if (VibrationEnabled)
            {
#if UNITY_IOS
                if (TapticManager.IsSupport())
                    TapticManager.Impact(ImpactFeedback.Light);
#endif
#if UNITY_EDITOR
                Debug.Log("Vibrate Light");
#endif
            }
        }


        public static void VibrateMedium()
        {
            if (VibrationEnabled)
            {
#if UNITY_IOS
                if (TapticManager.IsSupport())
                    TapticManager.Impact(ImpactFeedback.Midium);
#endif
#if UNITY_EDITOR
                Debug.Log("Vibrate Medium");
#endif
            }
        }

        public static void VibrateHeavy()
        {
            if (VibrationEnabled)
            {
#if UNITY_IOS
                if (TapticManager.IsSupport())
                    TapticManager.Impact(ImpactFeedback.Heavy);
#endif
#if UNITY_EDITOR
                Debug.Log("Vibrate Heavy");
#endif
            }
        }


        public static void VibrateGameOver()
        {
            if (VibrationEnabled)
            {
#if UNITY_IOS
                if (TapticManager.IsSupport())
                    TapticManager.Notification(NotificationFeedback.Warning);
#endif
#if UNITY_ANDROID
        Handheld.Vibrate();
#endif
#if UNITY_EDITOR
                Debug.Log("Vibrate GameOver");
#endif
            }
        }

    }
}