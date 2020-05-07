#if UNITY_IOS
using System;
using AntiAddictionSystem.Common;
using AntiAddictionSystem.Api;
using System.Runtime.InteropServices;
using UnityEngine;

namespace AntiAddictionSystem.iOS
{
    public class NotificationClient : IAntiAddictionClient
    {
        private IntPtr notificationPtr;

        private IntPtr notificationClientPtr;

#region Notification callback types

        internal delegate void AAPrivacyPolicyViewControllerHasBeenShownCallback(IntPtr notificationClient);
        internal delegate void AAUserAgreesToPrivacyPolicyCallback(IntPtr notificationClient);
        internal delegate void AALoginViewControllerHasBeenShownCallback(IntPtr notificationClient);
        internal delegate void AALoginViewControllerHasBeenDismissedCallback(IntPtr notificationClient);
        internal delegate void AALoginSuccessCallback(IntPtr notificationClient, string zplayID);
        internal delegate void AALoginFailCallback(IntPtr notificationClient);
        internal delegate void AAUserAuthVcHasBeenShownCallback(IntPtr notificationClient);
        internal delegate void AAUserAuthSuccessCallback(IntPtr notificationClient);
        internal delegate void AAWarningVcHasBeenShownCallback(IntPtr notificationClient);
        internal delegate void AAUserClickLoginButtonCallback(IntPtr notificationClient);
        internal delegate void AAUserClickLoginOutButtonCallback(IntPtr notificationClient);
        internal delegate void AAUserClickConfirmButtonCallback(IntPtr notificationClient);
        internal delegate void AALoginOutSuccessfullCallback(IntPtr notificationClient);
        internal delegate void AAPaymentIsRestrictedCallback(IntPtr notificationClient);
        internal delegate void AAPaymentUnlimitedCallback(IntPtr notificationClient);

#endregion

        // 隐私协议回调
        public event EventHandler<EventArgs> OnPrivacyPolicyShown;
        public event EventHandler<EventArgs> OnUserAgreesToPrivacyPolicy;

        // 登录回调
        public event EventHandler<LoginSuccessEventArgs> OnLoginSuccess;
        public event EventHandler<EventArgs> OnLoginHasBeenShown;
        public event EventHandler<EventArgs> OnLoginHasBeenDismissed;
        public event EventHandler<EventArgs> OnLoginFail;

        //实名认证回调
        public event EventHandler<EventArgs> OnUserAuthVcHasBeenShown;
        public event EventHandler<EventArgs> OnUserAuthSuccess;
        
        //用户提示界面回调
        public event EventHandler<EventArgs> OnWarningHasBeenShown;
        public event EventHandler<EventArgs> OnUserClickLoginButton;
        public event EventHandler<EventArgs> OnUserClickQuitButton;
        public event EventHandler<EventArgs> OnUserClickConfirmButton;
        
        //注销登录
        public event EventHandler<EventArgs> OnLogoutCallback;

        //检测支付
        public event EventHandler<EventArgs> OnCanPay;
        public event EventHandler<EventArgs> OnProhibitPay;

        public NotificationClient()
        {
            notificationClientPtr = (IntPtr)GCHandle.Alloc(this);
            notificationPtr = Externs.AACreateNotification(notificationClientPtr);

            Externs.AASetNotificationCallbacks(
                notificationPtr,
                privacyPolicyViewControllerHasBeenShownCallback,
                userAgreesToPrivacyPolicyCallback,
                loginViewControllerHasBeenShownCallback,
                loginViewControllerHasBeenDismissedCallback,
                loginSuccessCallback,
                loginFailCallback,
                userAuthVcHasBeenShownCallback,
                userAuthSuccessCallback,
                warningVcHasBeenShownCallback,
                userClickLoginButtonCallback,
                userClickLoginOutButtonCallback,
                userClickConfirmButtonCallback,
                loginOutSuccessfullCallback,
                paymentIsRestrictedCallback,
                paymentUnlimitedCallback
            );
        }

        private IntPtr NotificationPtr
        {
            get
            {
                return NotificationPtr;
            }

            set
            {
                Externs.AARelease(NotificationPtr);
                NotificationPtr = value;
            }
        }

#region IAntiAddictionClient implement 
        public int GetUserLoginStatus()
        {
            return Externs.getUserLoginStatus(notificationClientPtr);
        }
        
        public int GetUserAuthenticationIdentity()
        {
            return Externs.getUserAuthenticationIdentity(notificationClientPtr);
        }

        public void ShowPrivacyPolicyView()
        {
            Externs.showPrivacyPolicyView(notificationClientPtr);
        }

        public void ShowLoginViewController()
        {
            Externs.showLoginViewController(notificationClientPtr);
        }

        public void ShowUserAuthenticationViewController()
        {
            Externs.showUserAuthenticationViewController(notificationClientPtr);
        }

        public void LoginWithUserName(String username, String password)
        {
            Externs.loginWithUserNameAndPassword(notificationClientPtr, username, password);
        }

        public void LoginWithPlatformToken(String token, String otherID,String platformName)
        {
            Externs.loginWithThirdPartyPlatform(notificationClientPtr, token, otherID, platformName);
        }

        public void LoginWithZplayID(String zplayID) 
        {
            Externs.loginWithZplayID(notificationClientPtr, zplayID);
        }
        
        public void LoginOut()
        {
            Externs.loginOut(notificationClientPtr);
        }

        public void CheckNumberLimitBeforePayment(int payNumber)
        {
            Externs.checkNumberLimitBeforePayment(notificationClientPtr, payNumber);
        }

        public void ReportNumberAfterPayment(int payNumber)
        {
            Externs.reportNumberAfterPayment(notificationClientPtr, payNumber);
        }

        public void GameOnPause()
        {
        }

        public void GameOnResume()
        {
        }
#endregion

#region Notification callback methods
        [MonoPInvokeCallback(typeof(AAPrivacyPolicyViewControllerHasBeenShownCallback))]
        private static void privacyPolicyViewControllerHasBeenShownCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnPrivacyPolicyShown != null)
            {
                client.OnPrivacyPolicyShown(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAUserAgreesToPrivacyPolicyCallback))]
        private static void userAgreesToPrivacyPolicyCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnUserAgreesToPrivacyPolicy != null)
            {
                client.OnUserAgreesToPrivacyPolicy(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AALoginViewControllerHasBeenShownCallback))]
        private static void loginViewControllerHasBeenShownCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnLoginHasBeenShown != null)
            {
                client.OnLoginHasBeenShown(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AALoginViewControllerHasBeenDismissedCallback))]
        private static void loginViewControllerHasBeenDismissedCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnLoginHasBeenDismissed != null)
            {
                client.OnLoginHasBeenDismissed(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AALoginSuccessCallback))]
        private static void loginSuccessCallback(IntPtr notificationClient, string zplayID)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnLoginSuccess != null)
            {
                LoginSuccessEventArgs args = new LoginSuccessEventArgs()
                {
                    Message = zplayID
                };
                client.OnLoginSuccess(client, args);
            }
        }

        [MonoPInvokeCallback(typeof(AALoginFailCallback))]
        private static void loginFailCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnLoginFail != null)
            {
                client.OnLoginFail(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAUserAuthVcHasBeenShownCallback))]
        private static void userAuthVcHasBeenShownCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnUserAuthVcHasBeenShown != null)
            {
                client.OnUserAuthVcHasBeenShown(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAUserAuthSuccessCallback))]
        private static void userAuthSuccessCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnUserAuthSuccess != null)
            {
                client.OnUserAuthSuccess(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAWarningVcHasBeenShownCallback))]
        private static void warningVcHasBeenShownCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnWarningHasBeenShown != null)
            {
                client.OnWarningHasBeenShown(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAUserClickLoginButtonCallback))]
        private static void userClickLoginButtonCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnUserClickLoginButton != null)
            {
                client.OnUserClickLoginButton(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAUserClickLoginOutButtonCallback))]
        private static void userClickLoginOutButtonCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnUserClickQuitButton != null)
            {
                client.OnUserClickQuitButton(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAUserClickConfirmButtonCallback))]
        private static void userClickConfirmButtonCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnUserClickConfirmButton != null)
            {
                client.OnUserClickConfirmButton(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AALoginOutSuccessfullCallback))]
        private static void loginOutSuccessfullCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnLogoutCallback != null)
            {
                client.OnLogoutCallback(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAPaymentIsRestrictedCallback))]
        private static void paymentIsRestrictedCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnCanPay != null)
            {
                client.OnCanPay(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(AAPaymentUnlimitedCallback))]
        private static void paymentUnlimitedCallback(IntPtr notificationClient)
        {
            NotificationClient client = IntPtrToNotifiactionClient(notificationClient);
            if (client.OnProhibitPay != null)
            {
                client.OnProhibitPay(client, EventArgs.Empty);
            }
        }
        
        private static NotificationClient IntPtrToNotifiactionClient(IntPtr notificationClient)
        {
            GCHandle handle = (GCHandle)notificationClient;

            return handle.Target as NotificationClient;
        }

#endregion
    }
}
#endif