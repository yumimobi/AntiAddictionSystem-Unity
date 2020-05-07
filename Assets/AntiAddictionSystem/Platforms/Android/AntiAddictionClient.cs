#if UNITY_ANDROID

using System;
using UnityEngine;

using AntiAddictionSystem.Api;
using AntiAddictionSystem.Common;

namespace AntiAddictionSystem.Android
{
    public class AntiAddictionClient : AndroidJavaProxy, IAntiAddictionClient
    {
        private AndroidJavaObject androidWindowAd;

        public event EventHandler<EventArgs> OnPrivacyPolicyShown = delegate { };
        public event EventHandler<EventArgs> OnUserAgreesToPrivacyPolicy = delegate { };
        public event EventHandler<LoginSuccessEventArgs> OnLoginSuccess = delegate { };
        public event EventHandler<EventArgs> OnLoginHasBeenShown = delegate { };
        public event EventHandler<EventArgs> OnLoginHasBeenDismissed = delegate { };
        public event EventHandler<EventArgs> OnLoginFail;
        public event EventHandler<EventArgs> OnUserAuthVcHasBeenShown = delegate { };
        public event EventHandler<EventArgs> OnUserAuthSuccess = delegate { };
        public event EventHandler<EventArgs> OnWarningHasBeenShown = delegate { };
        public event EventHandler<EventArgs> OnUserClickLoginButton = delegate { };
        public event EventHandler<EventArgs> OnUserClickQuitButton = delegate { };
        public event EventHandler<EventArgs> OnUserClickConfirmButton = delegate { };
        public event EventHandler<EventArgs> OnLogoutCallback = delegate { };
        public event EventHandler<EventArgs> OnCanPay = delegate { };
        public event EventHandler<EventArgs> OnProhibitPay = delegate { };


        public AntiAddictionClient() : base(Utils.UnityAntiAddictionListenerClassName)
        {

            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            androidWindowAd = new AndroidJavaObject(Utils.AntiAddictionClassName, activity,  this);
        }

        #region IWindowAdClient implementation


        public int GetUserLoginStatus()
        {
            return androidWindowAd.Call<int>("getLoginType"); 
        }

        public int GetUserAuthenticationIdentity()
        {
            return androidWindowAd.Call<int>("getIdCardType");
        }

        public void ShowPrivacyPolicyView()
        {
            androidWindowAd.Call("showPrivacyPolicy");
        }

        public void ShowLoginViewController()
        {
            androidWindowAd.Call("login");
        }

        public void ShowUserAuthenticationViewController()
        {
            androidWindowAd.Call("showVisitorUserAuthentication");
        }

        public void LoginWithUserName(string username, string password)
        {
            androidWindowAd.Call("loginWithUserName", username, password);
        }

        public void LoginWithPlatformToken(string token, string otherID, string platformName)
        {
            androidWindowAd.Call("loginWithPlatformToken", token, otherID, platformName);
        }

        public void LoginWithZplayID(string zplayID)
        {
            androidWindowAd.Call("loginWithZplayID", zplayID);
        }

        public void LoginOut()
        {
            androidWindowAd.Call("logout");
        }

        public void CheckNumberLimitBeforePayment(int payNumber)
        {
            androidWindowAd.Call("checkPay", payNumber);
        }

        public void ReportNumberAfterPayment(int payNumber)
        {
            androidWindowAd.Call("reportMoney", payNumber);
        }

        public void GameOnPause()
        {
            androidWindowAd.Call("onPause");
        }

        public void GameOnResume()
        {
            androidWindowAd.Call("onResume");
        }

        #endregion



        #region Callback from UnityWindowAdListener
        void privacyPolicyShown()
        {
            if (OnPrivacyPolicyShown != null)
            {
                OnPrivacyPolicyShown(this, EventArgs.Empty);
            }
        }

        void userAgreesToPrivacyPolicy()
        {
            if (OnUserAgreesToPrivacyPolicy != null)
            {
                OnUserAgreesToPrivacyPolicy(this, EventArgs.Empty);
            }
        }

        void loginSuccess(string zplayId)
        {
            Debug.Log("-----loginSuccess zplayId: " + zplayId);
            if (OnLoginSuccess != null)
            {
                LoginSuccessEventArgs args = new LoginSuccessEventArgs()
                {
                    Message = zplayId
                };
                OnLoginSuccess(this, args);
            }
        }

        void loginHasBeenShown()
        {
            if (OnLoginHasBeenShown != null)
            {
                OnLoginHasBeenShown(this, EventArgs.Empty);
            }
        }

    
        void loginCancel()
        {
            if (OnLoginHasBeenDismissed != null)
            {
                OnLoginHasBeenDismissed(this, EventArgs.Empty);
            }
        }

        void loginFail()
        {
            if (OnLoginFail != null)
            {
                OnLoginFail(this, EventArgs.Empty);
            }
        }

        void userAuthVcHasBeenShown()
        {
            if (OnUserAuthVcHasBeenShown != null)
            {
                OnUserAuthVcHasBeenShown(this, EventArgs.Empty);
            }
        }
                       
        void userAuthSuccess()
        {
            if (OnUserAuthSuccess != null)
            {
                OnUserAuthSuccess(this, EventArgs.Empty);
            }
        }

        void userClickLoginButton()
        {
            if (OnUserClickLoginButton != null)
            {
                OnUserClickLoginButton(this, EventArgs.Empty);
            }
        }

        void userClickQuitButton()
        {
            if (OnUserClickQuitButton != null)
            {
                OnUserClickQuitButton(this, EventArgs.Empty);
            }
        }

        void userClickConfirmButton()
        {
            if (OnUserClickConfirmButton != null)
            {
                OnUserClickConfirmButton(this, EventArgs.Empty);
            }
        }

        void warningHasBeenShown()
        {
            if (OnWarningHasBeenShown != null)
            {
                OnWarningHasBeenShown(this, EventArgs.Empty);
            }
        }


        void logoutCallback()
        {
            if (OnLogoutCallback != null)
            {
                OnLogoutCallback(this, EventArgs.Empty);
            }
        }

        void onCanPay()
        {
            if (OnCanPay != null)
            {
                OnCanPay(this, EventArgs.Empty);
            }
        }

        void onProhibitPay()
        {
            if (OnProhibitPay != null)
            {
                OnProhibitPay(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}

#endif