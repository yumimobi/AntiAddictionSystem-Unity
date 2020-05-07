#import "AATypes.h"
#import "AAObjectCache.h"
#import "AANotificationBridge.h"

#pragma mark - AANotification method

AATypeNotificationRef AACreateNotification(AATypeNotificationClientRef *notificationClient) {
    AANotificationBridge *notification = [[AANotificationBridge alloc] initWithNotificationClientReference:notificationClient];
    AAObjectCache *cache = [AAObjectCache sharedInstance];
    [cache.references setObject:notification forKey:[notification aa_referenceKey]];
    return (__bridge AATypeNotificationRef)notification;
}

void AASetNotificationCallbacks(
        AATypeNotificationClientRef notification,
        // 隐私弹框已经展示
        AAPrivacyPolicyViewControllerHasBeenShownCallback privacyPolicyViewControllerHasBeenShownCallback,
        // 用户同意隐私政策
        AAUserAgreesToPrivacyPolicyCallback userAgreesToPrivacyPolicyCallback,
        // 开始展示用户登录界面
        AALoginViewControllerHasBeenShownCallback loginViewControllerHasBeenShownCallback,
        // 登录界面消失
        AALoginViewControllerHasBeenDismissedCallback loginViewControllerHasBeenDismissedCallback,
        // 登录成功
        AALoginSuccessCallback loginSuccessCallback,
        // 登录失败
        AALoginFailCallback loginFailCallback,
        // 实名认证界面已经展示
        AAUserAuthVcHasBeenShownCallback userAuthVcHasBeenShownCallback,
        // 实名认证成功
        AAUserAuthSuccessCallback userAuthSuccessCallback,
        // warning vc已展示
        AAWarningVcHasBeenShownCallback warningVcHasBeenShownCallback,
        // 用户在提示界面点击登录
        AAUserClickLoginButtonCallback userClickLoginButtonCallback,
        // 用户在提示界面点击退出游戏
        AAUserClickLoginOutButtonCallback userClickLoginOutButtonCallback,
        // 用户在提示界面点击确定
        AAUserClickConfirmButtonCallback userClickConfirmButtonCallback) {
    AANotificationBridge *internalNotification = (__bridge AANotificationBridge *)notification;
    internalNotification.privacyPolicyViewControllerHasBeenShownCallback = privacyPolicyViewControllerHasBeenShownCallback;
    internalNotification.userAgreesToPrivacyPolicyCallback = userAgreesToPrivacyPolicyCallback;
    internalNotification.loginViewControllerHasBeenShownCallback = loginViewControllerHasBeenShownCallback;
    internalNotification.loginViewControllerHasBeenDismissedCallback = loginViewControllerHasBeenDismissedCallback;
    internalNotification.loginSuccessCallback = loginSuccessCallback;
    internalNotification.loginFailCallback = loginFailCallback;
    internalNotification.userAuthVcHasBeenShownCallback = userAuthVcHasBeenShownCallback;
    internalNotification.userAuthSuccessCallback = userAuthSuccessCallback;
    internalNotification.warningVcHasBeenShownCallback = warningVcHasBeenShownCallback;
    internalNotification.userClickLoginButtonCallback = userClickLoginButtonCallback;
    internalNotification.userClickLoginOutButtonCallback = userClickLoginOutButtonCallback;
    internalNotification.userClickConfirmButtonCallback = userClickConfirmButtonCallback;
}

int getUserLoginStatus(AATypeNotificationRef notification) {    
    AANotificationBridge *internalNotification = (__bridge AANotificationBridge *)notification;
    [internalNotification getUserLoginStatus];
}

int getUserAuthenticationIdentity(AATypeNotificationRef notification) {
    AANotificationBridge *internalNotification = (__bridge AANotificationBridge *)notification;
    return [internalNotification getUserAuthenticationIdentity];
}

#pragma mark - Other methods
void AARelease(AATypeRef ref) {
    if (ref) {
        AAObjectCache *cache = [AAObjectCache sharedInstance];
        [cache.references removeObjectForKey:[(__bridge NSObject *)ref aa_referenceKey]];
    }
}