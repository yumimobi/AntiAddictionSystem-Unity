using System;
using AntiAddictionSystem.Api;
using UnityEngine;

namespace AntiAddictionSystem.Common
{
    public interface IAntiAddictionClient 
    {
        //隐私协议回调
        event EventHandler<EventArgs> OnPrivacyPolicyShown;
        event EventHandler<EventArgs> OnUserAgreesToPrivacyPolicy;

        //登录回调
        event EventHandler<LoginSuccessEventArgs> OnLoginSuccess;
        event EventHandler<EventArgs> OnLoginHasBeenShown;
        event EventHandler<EventArgs> OnLoginHasBeenDismissed;
        event EventHandler<EventArgs> OnLoginFail;

        //实名认证回调
        event EventHandler<EventArgs> OnUserAuthVcHasBeenShown;
        event EventHandler<EventArgs> OnUserAuthSuccess;

        //用户提示界面回调
        event EventHandler<EventArgs> OnWarningHasBeenShown;
        event EventHandler<EventArgs> OnUserClickLoginButtonInPayment;
        event EventHandler<EventArgs> OnUserClickLoginButtonInNoTimeLeft;
        event EventHandler<EventArgs> OnUserClickQuitButton;
        event EventHandler<EventArgs> OnUserClickConfirmButton;
        //注销登录
        event EventHandler<EventArgs> OnLogoutCallback;

        //检测支付
        event EventHandler<EventArgs> OnCanPay;
        event EventHandler<EventArgs> OnProhibitPay;

        // 获取当前用户登录状态
        // 0: 未知
        // 1: 游客
        // 2: 正式用户
        int GetUserLoginStatus();
        // 获取用户的认证身份
        // 0: 未知
        // 1：已成年
        // 2: 未成年
        int GetUserAuthenticationIdentity();

        // 展示隐私政策弹框
        void ShowPrivacyPolicyView();

        // 展示登录界面
        void ShowLoginViewController();

        // 展示游客账号的实名认证界面
        // 登录后先检测实名认证状态，如已经实名认证，则不展示此界面
        void ShowUserAuthenticationViewController();

        // 使用帐号密码注册
        // username: 用户帐号
        // password: 用户密码
        void LoginWithUserName(String username, String password);

        // 使用第三方平台登录SDK
        // token: 如使用第三方登录（如微信），请使用三方登录SDK返回的唯一ID
        // otherID: 如果三方登录平台d返回除token之外的ID，请将此ID赋值给此参数
        // platformName : 三方平台名称（请联系产品获取）
        void LoginWithPlatformToken(String token, String otherID,String platformName);

        // 使用Zplay登录SDK
        void LoginWithZplayID(String zplayID);

        // 注销用户
        void LoginOut();

        // 支付前检查用户是否被限额（成年人不受限制）
        // paynumber: 付费金额，单位分
        void CheckNumberLimitBeforePayment(int payNumber);

        // 支付成功后上报玩家支付金额
        // payNumber: 付费金额，单位分
        void ReportNumberAfterPayment(int payNumber);

        //游戏退到后台时调用
        void GameOnPause();
        //游戏恢复到前台时调用
        void GameOnResume();
    }
}