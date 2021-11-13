#import "UnityAppController.h"

@interface DeepLinkDelegate : UnityAppController
@property (nonatomic, copy) NSString* gameObjectName;
@property (nonatomic, copy) NSString* methodName;
- (void) configure: (const char*) gameObjName: (const char*) methodName;
@end

// Set DeepLinkDelegate to be the loaded UnityAppController
IMPL_APP_CONTROLLER_SUBCLASS(DeepLinkDelegate)

@implementation DeepLinkDelegate

// Override the openURL method to send the url and parameters to DeeplinkUnityService service
-(BOOL)application:(UIApplication *)app openURL:(NSURL *)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> *)options
{
    const char *URLString = [url.absoluteString UTF8String];
	if (_gameObjectName != nil) {		
		const char *GameObjString = [_gameObjectName cStringUsingEncoding:NSASCIIStringEncoding];
		const char *MethodNameString = [_methodName cStringUsingEncoding:NSASCIIStringEncoding];
		UnitySendMessage(GameObjString, MethodNameString, URLString);
	}
    return [super application:app openURL:url options:options];
}

// Sets the deep link callback to be sent to this specific game object and method
- (void) configure: (const char*)gameObjName: (const char*)methodName 
{
	_gameObjectName = CreateNSStrings(gameObjName);
	_methodName = CreateNSStrings(methodName);
}

NSString* CreateNSStrings(const char* str)
{
	if(str)
		return [NSString stringWithUTF8String: str];
	else
		return [NSString stringWithUTF8String: ""];
}

@end

extern "C" {
	// Delegate the method down to the appDelegate class
	void configure(const char* gameObjName, const char* methodName) {
		DeepLinkDelegate *appDelegate = (DeepLinkDelegate *)[UIApplication sharedApplication].delegate;
		[appDelegate configure: gameObjName: methodName];
	}	
}