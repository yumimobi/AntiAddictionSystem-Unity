package com.zplay.antiaddiction;

import android.app.Activity;
import android.text.TextUtils;
import android.util.Log;

import com.zplay.android.addiction.prevention.ZplayAddictionSDK;
import com.zplay.android.addiction.prevention.callback.ZplayCheckCallback;
import com.zplay.android.addiction.prevention.callback.ZplayLoginCallback;
import com.zplay.android.addiction.prevention.callback.ZplayLogoutCallback;
import com.zplay.android.addiction.prevention.callback.ZplayPrivacyPolicyCallback;
import com.zplay.android.addiction.prevention.callback.ZplayUserAuthVcCallback;
import com.zplay.android.addiction.prevention.callback.ZplayWarningCallback;
import com.zplay.android.addiction.prevention.utils.LogUtils;
import com.zplay.android.addiction.prevention.utils.enumbean.UserVerifiedType;


/**
 * Description:
 * <p>
 * Created by lgd on 2019-10-31.
 */
public class AntiAddictionSDK {
    private static final String TAG = "AntiAddictionSDK";


    private final Activity activity;
    private final UnityAntiAddictionListener listener;

    private ZplayLoginCallback loginCallback;
    private ZplayUserAuthVcCallback userAuthVcCallback;
    private ZplayWarningCallback warningCallback;

    public AntiAddictionSDK(Activity activity, UnityAntiAddictionListener listener) {
        this.activity = activity;
        this.listener = listener;
        init();
    }

    //显示用户营私协议
    public void showPrivacyPolicy() {
        Log.i(TAG, "showPrivacyPolicy");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.showPrivacyPolicy(activity, new ZplayPrivacyPolicyCallback() {
                    @Override
                    public void privacyPolicyShown() {
                        //用户隐私协议页面展示
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.privacyPolicyShown();
                                }
                            });
                        }
                    }

                    @Override
                    public void userAgreesToPrivacyPolicy() {
                        //用户同意隐私协议
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.userAgreesToPrivacyPolicy();
                                }
                            });
                        }
                    }

                    @Override
                    public void userDisagreesWithPrivacyPolicy() {
                        //用户拒绝隐私协议
//                        if (listener != null) {
//                            listener.userDisagreesWithPrivacyPolicy();
//                        }
                    }
                });
            }
        });
    }

    //初始化接口
    public void init() {
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {

                loginCallback = new ZplayLoginCallback() {
                    @Override
                    public void loginSuccess(final String uid, String token, String userName, String loginType) {

                        LogUtils.i(TAG, "uid:" + uid);
                        LogUtils.i(TAG, "token:" + token);
                        //登录成功
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    Log.i(TAG, "uid:" + uid);
                                    listener.loginSuccess(uid);
                                }
                            });
                        }

                    }

                    @Override
                    public void loginHasBeenShown() {
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.loginHasBeenShown();
                                }
                            });
                        }
                    }

                    @Override
                    public void loginCancel() {
                        // TODO Auto-generated method stub
                        Log.d(TAG, "loginCancel: ");
                        //取消登录
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.loginCancel();
                                }
                            });
                        }
                    }

                    @Override
                    public void loginFail() {
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.loginFail();
                                }
                            });
                        }
                    }
                };

                userAuthVcCallback = new ZplayUserAuthVcCallback() {
                    @Override
                    public void userAuthVcHasBeenShown() {
                        //实名认证窗口显示
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.userAuthVcHasBeenShown();
                                }
                            });
                        }
                    }

                    @Override
                    public void userAuthSuccess() {
                        //实名认证通过
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.userAuthSuccess();
                                }
                            });
                        }
                    }
                };

                warningCallback = new ZplayWarningCallback() {
                    @Override
                    public void warningHasBeenShown() {
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.warningHasBeenShown();
                                }
                            });
                        }
                    }

                    @Override
                    public void userClickLoginButtonInPayment() {
                        //游客 状态用户点击支付时提示异常，用户点击了登录按钮，请引导用户进行登录操作，用户可以关闭登录继续玩游戏
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.userClickLoginButtonInPayment();
                                }
                            });
                        }
                    }

                    @Override
                    public void userClickLoginButtonInNoTimeLeft() {
                        //游客 状态用户可以玩的游戏时间结束，用户点击了登录按钮，请引导用户进行登录操作，并且如果未登录完成，不让用户玩游戏
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.userClickLoginButtonInNoTimeLeft();
                                }
                            });
                        }
                    }

                    @Override
                    public void userClickQuitButton() {
                        //游客 状态用户游戏时间结束，用户点击了退出游戏按钮
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.userClickQuitButton();
                                }
                            });
                        }
                    }

                    @Override
                    public void userClickConfirmButton() {
                        //用户点击了计费提示弹窗上面的确定接口
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.userClickConfirmButton();
                                }
                            });
                        }
                    }
                };

                ZplayAddictionSDK.init(activity, loginCallback, userAuthVcCallback, warningCallback);
            }
        });

    }

    //登录
    public void login() {
        Log.i(TAG, "login");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.login(activity);
            }
        });
    }

    public void loginWithZplayID(final String zplayId) {
        Log.i(TAG, "loginWithZplayID");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.loginWithZplayID(activity, zplayId);
            }
        });
    }

    public void loginWithUserName(final String userName, final String password) {
        Log.i(TAG, "loginWithUserName");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.loginWithUserName(activity, userName, password);
            }
        });
    }

    public void loginWithPlatformToken(final String token, final String uid, final String platformName) {
        Log.i(TAG, "loginWithPlatformToken");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.loginWithPlatformToken(activity, token, uid, platformName);
            }
        });
    }

    public void showVisitorUserAuthentication() {
        Log.i(TAG, "showVisitorUserAuthentication");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.showVisitorUserAuthentication(activity);
            }
        });
    }

    //注销登录
    public void logout() {
        Log.i(TAG, "logout");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.logout(activity, new ZplayLogoutCallback() {
                    @Override
                    public void logout(Activity activity) {
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.logoutCallback();
                                }
                            });
                        }
                    }
                });
            }
        });
    }


    /**
     * 检测本次支付是否超过限额
     */
    public void checkPay(final int money) {
        Log.i(TAG, "checkPay");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.checkNumberLimitBeforePayment(activity, money + "", new ZplayCheckCallback() {
                    @Override
                    public void onCanPay() {
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.onCanPay();
                                }
                            });
                        }
                    }

                    @Override
                    public void onProhibitPay(String errorMsg) {
                        if (listener != null && activity != null) {
                            activity.runOnUiThread(new Runnable() {
                                @Override
                                public void run() {
                                    listener.onProhibitPay();
                                }
                            });
                        }
                    }
                });
            }
        });

    }

    /**
     * 支付成功后进行支付成功上报
     */
    public void reportMoney(final int money) {
        Log.i(TAG, "reportMoney");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.reportNumberAfterPayment(activity, money + "");
            }
        });
    }


    /**
     * 获取登录类型
     */
    public int getLoginType() {
        Log.i(TAG, "getLoginType");
        String loginType = ZplayAddictionSDK.getLoginType(activity);
        if (TextUtils.equals(loginType, "notlogin")) {
            return 0;
        } else if (TextUtils.equals(loginType, "visitor")) {
            return 1;
        } else {
            return 2;
        }
    }

    //获取当前账号的实名认证状态
    public int getIdCardType() {
        Log.i(TAG, "getIdCardType");
        UserVerifiedType userAuthenticationIdentity = ZplayAddictionSDK.getUserVerified(activity);
        if (userAuthenticationIdentity == UserVerifiedType.UserAgeUnknow) {
            return 0;
        } else if (userAuthenticationIdentity == UserVerifiedType.UserAdult) {
            return 1;
        } else {
            return 2;
        }
    }


    public void onPause() {
        Log.i(TAG, "onPause");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.onPause();
            }
        });
    }

    public void onResume() {
        Log.i(TAG, "onResume");
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayAddictionSDK.onResume();
            }
        });
    }


}
