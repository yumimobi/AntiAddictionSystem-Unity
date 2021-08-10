using System;
using AntiAddictionSystem.Common;
using UnityEngine;

namespace AntiAddictionSystem.Api
{
    public class AntiAddictionSDK
    {
        static readonly object objLock = new object();

        IAntiAddictionClient client;

        // Creates AntiAddictionSDK instance.
        public AntiAddictionSDK()
        {
            client = AntiAddictionClientFactory.BuildAntiAddictionClient();

            client.OnPrivacyPolicyShown += (sender, args) =>
            {
                if (OnPrivacyPolicyShown != null)
                {
                    OnPrivacyPolicyShown(this, args);
                }
            };

            client.OnUserAgreesToPrivacyPolicy += (sender, args) =>
            {
                if (OnUserAgreesToPrivacyPolicy != null)
                {
                    OnUserAgreesToPrivacyPolicy(this, args);
                }
            };

            client.OnLoginSuccess += (sender, args) =>
            {
                if (OnLoginSuccess != null)
                {
                    OnLoginSuccess(this, args);
                }
            };

            client.OnLoginHasBeenShown += (sender, args) =>
            {
                if (OnLoginHasBeenShown != null)
                {
                    OnLoginHasBeenShown(this, args);
                }
            };

            client.OnLoginHasBeenDismissed += (sender, args) =>
            {
                if (OnLoginHasBeenDismissed != null)
                {
                    OnLoginHasBeenDismissed(this, args);
                }
            };

            client.OnLoginFail += (sender, args) =>
            {
                if (OnLoginFail != null)
                {
                    OnLoginFail(this, args);
                }
            };

            client.OnSwitch += (sender, args) =>
            {
                if (OnSwitch != null)
                {
                    OnSwitch(this, args);
                }
            };

            

            client.OnUserAuthVcHasBeenShown += (sender, args) =>
            {
                if(OnUserAuthVcHasBeenShown != null)
                {
                    OnUserAuthVcHasBeenShown(this, args);
                }
            };

            client.OnUserAuthSuccess += (sender, args) =>
            {
                if (OnUserAuthSuccess != null)
                {
                    OnUserAuthSuccess(this, args);
                }
            };

            client.OnWarningHasBeenShown += (sender, args) =>
            {
                if (OnWarningHasBeenShown != null)
                {
                    OnWarningHasBeenShown(this, args);
                }
            };

            client.OnUserClickLoginButtonInPayment += (sender, args) =>
            {
                if (OnUserClickLoginButtonInPayment != null)
                {
                    OnUserClickLoginButtonInPayment(this, args);
                }
            };

            client.OnUserClickLoginButtonInNoTimeLeft += (sender, args) =>
            {
                if (OnUserClickLoginButtonInNoTimeLeft != null)
                {
                    OnUserClickLoginButtonInNoTimeLeft(this, args);
                }
            };

            
            client.OnUserClickQuitButton += (sender, args) =>
            {
                if (OnUserClickQuitButton != null)
                {
                    OnUserClickQuitButton(this, args);
                }
            };

            client.OnUserClickConfirmButton += (sender, args) =>
            {
                if (OnUserClickConfirmButton != null)
                {
                    OnUserClickConfirmButton(this, args);
                }
            };

            client.OnLogoutCallback += (sender, args) =>
            {
                if (OnLogoutCallback != null)
                {
                    OnLogoutCallback(this, args);
                }
            };

            client.OnCanPay += (sender, args) =>
            {
                if (OnCanPay != null)
                {
                    OnCanPay(this, args);
                }
            };

            client.OnProhibitPay += (sender, args) =>
            {
                if (OnProhibitPay != null)
                {
                    OnProhibitPay(this, args);
                }
            };

        }

        // 隐私协议回调
        // 隐私协议界面已经展示
        public event EventHandler<EventArgs> OnPrivacyPolicyShown;
        // 用户已经同意隐私协议
        public event EventHandler<EventArgs> OnUserAgreesToPrivacyPolicy;

        // 登录回调
        // 登录成功
        public event EventHandler<LoginSuccessEventArgs> OnLoginSuccess;
        // 登录界面已经展示
        public event EventHandler<EventArgs> OnLoginHasBeenShown;
        // 登录界面已经隐藏
        public event EventHandler<EventArgs> OnLoginHasBeenDismissed;
        // 登录失败
        public event EventHandler<EventArgs> OnLoginFail;
        // 切换账号
        public event EventHandler<EventArgs> OnSwitch;

        // 实名认证回调
        // 实名认证界面开始展示
        public event EventHandler<EventArgs> OnUserAuthVcHasBeenShown;
        // 实名认证成功
        public event EventHandler<EventArgs> OnUserAuthSuccess;

        // 用户提示界面回调
        // 用户提示界面开始展示
        public event EventHandler<EventArgs> OnWarningHasBeenShown;
        // 用户在游客模式不可支付提示界面点击登录
        public event EventHandler<EventArgs> OnUserClickLoginButtonInPayment;
        // 用户在游客模式可玩时间超时提示界面点击登录
        public event EventHandler<EventArgs> OnUserClickLoginButtonInNoTimeLeft;
        // 用户在提示界面点击退出
        public event EventHandler<EventArgs> OnUserClickQuitButton;
        // 用户在提示界面点击确定
        public event EventHandler<EventArgs> OnUserClickConfirmButton;
        // 注销登录成功
        public event EventHandler<EventArgs> OnLogoutCallback;

        // 支付前调用`CheckNumberLimitBeforePayment`会返回如下两个回调
        // 可以支付
        public event EventHandler<EventArgs> OnCanPay;
        // 不可以支付
        public event EventHandler<EventArgs> OnProhibitPay;
     
        // 获取当前用户登录状态
        // 0: 未知
        // 1: 游客
        // 2: 正式用户
        public int GetUserLoginStatus()
        {
            return client.GetUserLoginStatus();
        }

        // 获取用户的认证身份
        // 0: 未知
        // 1：已成年
        // 2: 未成年
        public int GetUserAuthenticationIdentity()
        {
            return client.GetUserAuthenticationIdentity();
        }

        // 展示隐私政策弹框
        public void ShowPrivacyPolicyView()
        {
            client.ShowPrivacyPolicyView();
        }
        

        // 展示登录界面
        public void ShowLoginViewController()
        {
            client.ShowLoginViewController();
        }

        // 展示游客账号的实名认证界面
        // 登录后先检测实名认证状态，如已经实名认证，则不展示此界面
        public void ShowUserAuthenticationViewController()
        {
            client.ShowUserAuthenticationViewController();
        }

        // 使用帐号密码注册
        // username: 用户帐号
        // password: 用户密码
        public void LoginWithUserName(String username, String password)
        {
            client.LoginWithUserName(username, password);

        }

        // 使用第三方平台登录SDK
        // token: 如使用第三方登录（如微信），请使用三方登录SDK返回的唯一ID
        // otherID: 如果三方登录平台d返回除token之外的ID，请将此ID赋值给此参数
        // platformName : 三方平台名称（请联系产品获取）
        public void LoginWithPlatformToken(String token, String otherID, String platformName)
        {
            client.LoginWithPlatformToken(token, otherID, platformName);
        }

        // 使用Zplay登录SDK
        public void LoginWithZplayID(String zplayID)
        {
            client.LoginWithZplayID(zplayID);
        }

        // 注销用户
        public void LoginOut()
        {
            client.LoginOut();
        }

        // 支付前检查用户是否被限额（成年人不受限制）
        // paynumber: 付费金额，单位分
        public void CheckNumberLimitBeforePayment(int payNumber)
        {
            client.CheckNumberLimitBeforePayment(payNumber);
        }

        // 支付成功后上报玩家支付金额
        // payNumber: 付费金额，单位分
        public void ReportNumberAfterPayment(int payNumber)
        {
            client.ReportNumberAfterPayment(payNumber);
        }

        //游戏退到后台时调用
        public void GameOnPause()
        {
            client.GameOnPause();
        }

        //游戏恢复到前台时调用
        public void GameOnResume()
        {
            client.GameOnResume();
        }


    }
}