typedef const void *AATypeRef;

#pragma mark - AANotification
typedef const void *AATypeNotificationClientRef;
typedef const void *AATypenotificationRef;
#pragma mark - AANotification callback
// 隐私弹框已经展示
typedef void (*privacyPolicyViewControllerHasBeenShownCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 用户同意隐私政策
typedef void (*userAgreesToPrivacyPolicyCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 开始展示用户登录界面
typedef void (*loginViewControllerHasBeenShownCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 登录界面消失
typedef void (*loginViewControllerHasBeenDismissedCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 登录成功
typedef void (*loginSuccessCallback)(AATypeNotificationClientRef *aaNotificationClient, const char *zplayKey);
// 登录失败
typedef void (*loginFailCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 实名认证界面已经展示
typedef void (*userAuthVcHasBeenShownCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 实名认证成功
typedef void (*userAuthSuccessCallback)(AATypeNotificationClientRef *aaNotificationClient, const char *remainTime);
// warning vc已展示
typedef void (*warningVcHasBeenShownCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 用户在提示界面点击登录
typedef void (*userClickLoginButtonCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 用户在提示界面点击退出游戏
typedef void (*userClickLoginOutButtonCallback)(AATypeNotificationClientRef *aaNotificationClient);
// 用户在提示界面点击确定
typedef void (*userClickConfirmButtonCallback)(AATypeNotificationClientRef *aaNotificationClient);


#pragma mark - AALoginViewController
typedef const void *AATypeLoginVcClientRef;
typedef const void *AATypeLoginVcRef;

#pragma mark - AALogin
typedef const void *AATypeLoginClientRef;
typedef const void *AATypeLoginRef;

#pragma mark - AAPayNumberReport
typedef const void *AATypePayNumberReportClientRef;
typedef const void *AATypePayNumberReportRef;

#pragma mark - AAPrivacyPolicyViewController
typedef const void *AATypePrivacyPolicyVcClientRef;
typedef const void *AATypePrivacyPolicyVcRef;

#pragma mark - AAUserAuthenticationViewController
typedef const void *AATypeAuthVcClientRef;
typedef const void *AATypeAuthVcRef;
