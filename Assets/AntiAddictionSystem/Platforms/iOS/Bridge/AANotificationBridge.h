#import <Foundation/Foundation.h>
#import <AntiAddictionSystem/AANotification.h>
#import "AATypes.h"

@interface AANotificationBridge : NSObject

- (instancetype)initWithNotificationClientReference:(AATypeNotificationClientRef*)aaNotificationClientRef;

@property(nonatomic, assign) AATypeNotificationClientRef *notificationClient;
@property(nonatomic, strong) AANotification *notification;
// 隐私弹框已经展示
@property(nonatomic, assign) AAPrivacyPolicyViewControllerHasBeenShownCallback privacyPolicyViewControllerHasBeenShownCallback;
// 用户同意隐私政策
@property(nonatomic, assign) AAUserAgreesToPrivacyPolicyCallback userAgreesToPrivacyPolicyCallback;
// 开始展示用户登录界面
@property(nonatomic, assign) AALoginViewControllerHasBeenShownCallback loginViewControllerHasBeenShownCallback;
// 登录界面消失
@property(nonatomic, assign) AALoginViewControllerHasBeenDismissedCallback loginViewControllerHasBeenDismissedCallback;
// 登录成功
@property(nonatomic, assign) AALoginSuccessCallback loginSuccessCallback;
// 登录失败
@property(nonatomic, assign) AALoginFailCallback loginFailCallback;
// 实名认证界面已经展示
@property(nonatomic, assign) AAUserAuthVcHasBeenShownCallback userAuthVcHasBeenShownCallback;
// 实名认证成功
@property(nonatomic, assign) AAUserAuthSuccessCallback userAuthSuccessCallback;
// warning vc已展示
@property(nonatomic, assign) AAWarningVcHasBeenShownCallback warningVcHasBeenShownCallback;
// 用户在提示界面点击登录
@property(nonatomic, assign) AAUserClickLoginButtonCallback userClickLoginButtonCallback;
// 用户在提示界面点击退出游戏
@property(nonatomic, assign) AAUserClickLoginOutButtonCallback userClickLoginOutButtonCallback;
// 用户在提示界面点击确定
@property(nonatomic, assign) AAUserClickConfirmButtonCallback userClickConfirmButtonCallback;

// 获取当前用户登录状态
// 0: 未知
// 1: 游客
// 2: 正式用户
- (int)getUserLoginStatus;

// 获取用户的认证身份
// 0: 未知
// 1：已成年
// 2: 未成年
- (int)getUserAuthenticationIdentity;

@end