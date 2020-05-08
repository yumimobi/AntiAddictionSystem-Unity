package com.zplay.antiaddiction;

/**
 * Description:
 * <p>
 * Created by lgd on 2019-10-31.
 */
public interface UnityAntiAddictionListener {
    //隐私协议回调
    void privacyPolicyShown();

    void userAgreesToPrivacyPolicy();

//    void userDisagreesWithPrivacyPolicy();


    //登录回调
    void loginSuccess(String zplayId);

    void loginHasBeenShown();

    void loginCancel();

    void loginFail();

    //实名认证回调
    void userAuthVcHasBeenShown();

    void userAuthSuccess();

    //用户点击回调
    void userClickLoginButtonInPayment();
    void userClickLoginButtonInNoTimeLeft();

    void userClickQuitButton();

    void userClickConfirmButton();

    void warningHasBeenShown();
    //注销回调
    void logoutCallback();

    //检测支付
    void onCanPay();

    void onProhibitPay();

}
