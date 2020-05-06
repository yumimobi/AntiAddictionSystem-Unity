#import "AANotificationBridge.h"

@interface AANotificationBridge ()<AANotificationDelegate>

@end

@implementation AANotificationBridge

- (instancetype)initWithNotificationClientReference:(AATypeNotificationClientRef*)aaNotificationClientRef {
    if (self = [super init]) {
        _notificationClient = aaNotificationClientRef;
        _notification = [AANotification shared];
        _notification.delegate = self;
    }
    return self;
}

// 获取当前用户登录状态
// 0: 未知
// 1: 游客
// 2: 正式用户
- (int)getUserLoginStatus {
    return [self.notification getUserLoginStatus];
}

// 获取用户的认证身份
// 0: 未知
// 1：已成年
// 2: 未成年
- (int)getUserAuthenticationIdentity {
    return [self.notification getUserAuthenticationIdentity];
}

#pragma mark - notification delegate
// 隐私弹框已经展示
- (void)privacyPolicyViewControllerHasBeenShown {
    if(self.privacyPolicyViewControllerHasBeenShownCallback) {
        self.privacyPolicyViewControllerHasBeenShownCallback(self.notificationClient);
    }
}
// 用户同意隐私政策
- (void)userAgreesToPrivacyPolicy {
    if(self.userAgreesToPrivacyPolicyCallback) {
        self.userAgreesToPrivacyPolicyCallback(self.notificationClient);
    }
}
// 开始展示用户登录界面
- (void)loginViewControllerHasBeenShown {
    if(self.loginViewControllerHasBeenShownCallback) {
        self.loginViewControllerHasBeenShownCallback(self.notificationClient);
    }
}
// 登录界面消失
- (void)loginViewControllerHasBeenDismissed {
    if(self.loginViewControllerHasBeenDismissedCallback) {
        self.loginViewControllerHasBeenDismissedCallback(self.notificationClient);
    }
}
// 登录成功
- (void)loginSuccessWith:(NSString *)zplayKey {
    if(self.loginSuccessCallback) {
        self.loginSuccessCallback(self.notificationClient, [zplayKey cStringUsingEncoding:NSUTF8StringEncoding]);
    }
}
// 登录失败
- (void)loginFail {
    if(self.loginFailCallback) {
        self.loginFailCallback(self.notificationClient);
    }
}
// 实名认证界面已经展示
- (void)userAuthVcHasBeenShown {
    if(self.userAuthVcHasBeenShownCallback) {
        self.userAuthVcHasBeenShownCallback(self.notificationClient);
    }
}
// 实名认证成功
- (void)userAuthSuccessWithRemainTime:(NSNumber *)remainTime {
    NSString *timeStr = [[NSString alloc] initWithFormat:@"%@", remainTime];
    if(self.userAuthSuccessCallback) {
        self.userAuthSuccessCallback(self.notificationClient, [timeStr cStringUsingEncoding:NSUTF8StringEncoding]);
    }
}
// warning vc已展示
- (void)warningVcHasBeenShown {
    if(self.warningVcHasBeenShownCallback) {
        self.warningVcHasBeenShownCallback(self.notificationClient);
    }
}
// 用户在提示界面点击登录
- (void)userClickLoginButton {
    if(self.userClickLoginButtonCallback) {
        self.userClickLoginButtonCallback(self.notificationClient);
    }
}
// 用户在提示界面点击退出游戏
- (void)userClickLoginOutButton {
    if(self.userClickLoginOutButtonCallback) {
        self.userClickLoginOutButtonCallback(self.notificationClient);
    }
}
// 用户在提示界面点击确定
- (void)userClickConfirmButton {
    if(self.userClickConfirmButtonCallback) {
        self.userClickConfirmButtonCallback(self.notificationClient);
    }
}

@end