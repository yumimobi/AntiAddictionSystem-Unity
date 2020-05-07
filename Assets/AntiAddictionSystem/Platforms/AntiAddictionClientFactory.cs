using AntiAddictionSystem.Api;
using AntiAddictionSystem.Common;
using UnityEngine;

namespace AntiAddictionSystem
{
    public class AntiAddictionClientFactory
    {

        public static IAntiAddictionClient BuildAntiAddictionClient()
        {
#if UNITY_ANDROID
            return new Android.AntiAddictionClient();
#elif UNITY_IPHONE
            return new iOS.NotificationClient();
#else
            return new DummyClient();
#endif
        }


    }
}