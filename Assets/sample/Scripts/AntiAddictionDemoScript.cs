using System;
using UnityEngine;
using AntiAddictionSystem.Api;
using AntiAddictionSystem.Common;
using AntiAddictionSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AntiAddictionDemoScript : MonoBehaviour
{

    AntiAddictionSDK antiAddictionSDK;
    public Text statusText;
    public Text showZplayIdText;
    public InputField userNameInput;
    public InputField passwordInput;
    public InputField tokenInput;
    public InputField otherIDInput;
    public InputField platformNameInput;
    public InputField payNumberInput;
    public InputField zplayIDInput;
    

    void Start()
    {
        antiAddictionSDK = new AntiAddictionSDK();
        antiAddictionSDK.OnPrivacyPolicyShown += HandlePrivacyPolicyShown;
        antiAddictionSDK.OnUserAgreesToPrivacyPolicy += HandleUserAgreesToPrivacyPolicy;
        antiAddictionSDK.OnLoginSuccess += HandleLoginSuccess;
        antiAddictionSDK.OnLoginHasBeenShown += HandleLoginHasBeenShown;
        antiAddictionSDK.OnLoginHasBeenDismissed += HandleLoginHasBeenDismissed;
        antiAddictionSDK.OnLoginFail += HandleLoginFail;
        antiAddictionSDK.OnUserAuthVcHasBeenShown += HandleUserAuthVcHasBeenShown;
        antiAddictionSDK.OnUserAuthSuccess += HandleUserAuthSuccess;
        antiAddictionSDK.OnWarningHasBeenShown += HandleWarningHasBeenShown;
        antiAddictionSDK.OnUserClickLoginButton += HandleUserClickLoginButton;
        antiAddictionSDK.OnUserClickQuitButton += HandleUserClickQuitButton;
        antiAddictionSDK.OnUserClickConfirmButton += HandleUserClickConfirmButton;
        antiAddictionSDK.OnLoginFail += HandleLoginFail;
        antiAddictionSDK.OnLogoutCallback += HandleLogoutCallback;
        antiAddictionSDK.OnCanPay += HandleCanPay;
        antiAddictionSDK.OnProhibitPay += HandleProhibitPay;
    }

    // 获取当前用户登录状态
    // 0: 未知
    // 1: 游客
    // 2: 正式用户
    public void GetUserLoginStatus()
    {
        statusText.text = "GetUserLoginStatus";
        if (antiAddictionSDK != null)
        {
            statusText.text = antiAddictionSDK.GetUserLoginStatus()+"";
        }
    }

    // 获取用户的认证身份
    // 0: 未知
    // 1：已成年
    // 2: 未成年
    public void GetUserAuthenticationIdentity()
    {
        statusText.text = "GetUserAuthenticationIdentity";
        if (antiAddictionSDK != null)
        {
            statusText.text = antiAddictionSDK.GetUserAuthenticationIdentity() + "";
        }
    }

    // 展示隐私政策弹框
    public void ShowPrivacyPolicyView()
    {
        statusText.text = "ShowPrivacyPolicyView";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.ShowPrivacyPolicyView();
        }
    }


    // 展示登录界面
    public void ShowLoginViewController()
    {
        statusText.text = "ShowLoginViewController";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.ShowLoginViewController();
        }
    }

    // 展示游客账号的实名认证界面
    // 登录后先检测实名认证状态，如已经实名认证，则不展示此界面
    public void ShowUserAuthenticationViewController()
    {
        statusText.text = "ShowUserAuthenticationViewController";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.ShowUserAuthenticationViewController();
        }
    }

    // 使用帐号密码注册
    // username: 用户帐号
    // password: 用户密码
    public void LoginWithUserName()
    {

        String username = userNameInput.text;
        String password = passwordInput.text;

        if (username == null) {
            statusText.text = "userName is null";
            return;
        }

        if (password == null) {
            statusText.text = "password is null";
            return;
        }
        
        statusText.text = "LoginWithUserName";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.LoginWithUserName(username, password);
        }

    }

    // 使用第三方平台登录SDK
    // token: 如使用第三方登录（如微信），请使用三方登录SDK返回的唯一ID
    // otherID: 如果三方登录平台d返回除token之外的ID，请将此ID赋值给此参数
    // platformName : 三方平台名称（请联系产品获取）
    public void LoginWithPlatformToken()
    {
        String token = tokenInput.text;
        String otherID = otherIDInput.text;
        String platformName = platformNameInput.text;

        if (token == null)
        {
            statusText.text = "token is null";
            return;
        }

        if (otherID == null)
        {
            statusText.text = "otherID is null";
            return;
        }

        if (platformName == null)
        {
            statusText.text = "platformName is null";
            return;
        }

        statusText.text = "loginWithPlatformToken";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.LoginWithPlatformToken(token, otherID, platformName);
        }
    }

    // 使用Zplay登录SDK
    public void LoginWithZplayID()
    {
        String zplayID = zplayIDInput.text;
        
        if (zplayID == null)
        {
            statusText.text = "zplayID is null";
            return;
        }

        statusText.text = "LoginWithZplayID";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.LoginWithZplayID(zplayID);
        }
    }

    // 注销用户
    public void LoginOut()
    {
        statusText.text = "LoginOut";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.LoginOut();
        }
    }

    // 支付前检查用户是否被限额（成年人不受限制）
    // paynumber: 付费金额，单位分
    public void CheckNumberLimitBeforePayment()
    {
        int payNumber;


        if (payNumberInput.text != null)
        {
            payNumber = int.Parse(payNumberInput.text);
        }
        else {
            statusText.text = "payNumber is null";
            return;
        }

        statusText.text = "checkNumberLimitBeforePayment";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.CheckNumberLimitBeforePayment(payNumber);
        }
     
    }

    // 支付成功后上报玩家支付金额
    // payNumber: 付费金额，单位分
    public void ReportNumberAfterPayment()
    {
        int payNumber;


        if (payNumberInput.text != null)
        {
            payNumber = int.Parse(payNumberInput.text);
        }
        else
        {
            statusText.text = "payNumber is null";
            return;
        }

        statusText.text = "reportNumberAfterPayment";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.ReportNumberAfterPayment(payNumber);
        }
    }

    //游戏退到后台时调用
    public void GameOnPause()
    {
        statusText.text = "GameOnPause";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.GameOnPause();
        }
    }

    //游戏恢复到前台时调用
    public void GameOnResume()
    {
        statusText.text = "GameOnResume";
        if (antiAddictionSDK != null)
        {
            antiAddictionSDK.GameOnResume();
        }
    }


    #region AntiAddiction callback handlers
    public void HandlePrivacyPolicyShown(object sender, EventArgs args)
    {
        statusText.text = "HandlePrivacyPolicyShown";
        print("AntiAddiction---HandlePrivacyPolicyShown");
    }

    public void HandleUserAgreesToPrivacyPolicy(object sender, EventArgs args)
    {
        statusText.text = "HandleUserAgreesToPrivacyPolicy ";
        print("AntiAddiction---HandleUserAgreesToPrivacyPolicy");
    }


    public void HandleLoginSuccess(object sender, LoginSuccessEventArgs args)
    {
        String zplayId = args.Message;
        print("AntiAddiction---HandleLoginSuccess: " + zplayId);
        showZplayIdText.text = "ZplayId : " + zplayId;
        statusText.text = "HandleLoginSuccess";
    }

    public void HandleLoginHasBeenShown(object sender, EventArgs args)
    {
        statusText.text = "HandleLoginHasBeenShown";
        print("AntiAddiction---HandleLoginHasBeenShown");
    }


    public void HandleLoginHasBeenDismissed(object sender, EventArgs args)
    {
        statusText.text = "HandleLoginHasBeenDismissed";
        print("AntiAddiction---HandleLoginHasBeenDismissed");
    }


    public void HandleLoginFail(object sender, EventArgs args)
    {
        statusText.text = "HandleLoginFail";
        print("AntiAddiction---HandleLoginFail");
    }

    public void HandleUserAuthVcHasBeenShown(object sender, EventArgs args)
    {
        statusText.text = "HandleUserAuthVcHasBeenShown";
        print("AntiAddiction---HandleUserAuthVcHasBeenShown");
    }

    public void HandleUserAuthSuccess(object sender, EventArgs args)
    {
        statusText.text = "HandleUserAuthSuccess";
        print("AntiAddiction---HandleUserAuthSuccess");
    }

    public void HandleWarningHasBeenShown(object sender, EventArgs args)
    {
        statusText.text = "HandleWarningHasBeenShown";
        print("AntiAddiction---HandleWarningHasBeenShown");
    }

    public void HandleUserClickLoginButton(object sender, EventArgs args)
    {
        statusText.text = "HandleUserClickLoginButton";
        print("AntiAddiction---HandleUserClickLoginButton");
    }

    public void HandleUserClickQuitButton(object sender, EventArgs args)
    {
        statusText.text = "HandleUserClickQuitButton";
        print("AntiAddiction---HandleUserClickQuitButton");
    }

    public void HandleUserClickConfirmButton(object sender, EventArgs args)
    {
        statusText.text = "HandleUserClickConfirmButton";
        print("AntiAddiction---HandleUserClickConfirmButton");
    }

    public void HandleLogoutCallback(object sender, EventArgs args)
    {
        statusText.text = "HandleLogoutCallback";
        print("AntiAddiction---HandleLogoutCallback");
    }

    public void HandleCanPay(object sender, EventArgs args)
    {
        statusText.text = "HandleCanPay";
        print("AntiAddiction---HandleCanPay");
    }

    public void HandleProhibitPay(object sender, EventArgs args)
    {
        statusText.text = "HandleProhibitPay";
        print("AntiAddiction---HandleProhibitPay");
    }
    #endregion
}
