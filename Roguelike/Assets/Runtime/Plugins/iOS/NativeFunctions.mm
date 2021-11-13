extern "C" {
	long _GetFreeDiskSpace() {
		uint64_t totalSpace = 0;
		uint64_t totalFreeSpace = 0;
		NSError *error = nil;  
		NSArray *paths = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);  
		NSDictionary *dictionary = [[NSFileManager defaultManager] attributesOfFileSystemForPath:[paths lastObject] error: &error];  

		if (dictionary) {  
			NSNumber *fileSystemSizeInBytes = [dictionary objectForKey: NSFileSystemSize];  
			NSNumber *freeFileSystemSizeInBytes = [dictionary objectForKey:NSFileSystemFreeSize];
			totalSpace = [fileSystemSizeInBytes unsignedLongLongValue];
			totalFreeSpace = [freeFileSystemSizeInBytes unsignedLongLongValue];
			NSLog(@"Memory Capacity of %llu MiB with %llu MiB Free memory available.", ((totalSpace/1024ll)/1024ll), ((totalFreeSpace/1024ll)/1024ll));
		} else {  
			NSLog(@"Error Obtaining System Memory Info: Domain = %@, Code = %ld", [error domain], (long)[error code]);
		}  

		return (totalSpace * 1l);
	}
	
	bool _IsAppInstalled(char *text) {
		NSString *urlScheme = [NSString stringWithCString: text encoding: NSUTF8StringEncoding];
		return [[UIApplication sharedApplication] canOpenURL:[NSURL URLWithString: urlScheme]];
	}
	
	void _LogIOS(char *text) {
		NSString *logString = [NSString stringWithCString: text encoding: NSUTF8StringEncoding];
		NSLog(logString);
	}
	
	void _RegisterIOSPrefs() {
		NSString *settingsBundle = [[NSBundle mainBundle] pathForResource:@"Settings" ofType:@"bundle"];
		if(!settingsBundle) {
			NSLog(@"Could not find Settings.bundle");
		}
		
		NSDictionary *settings = [NSDictionary dictionaryWithContentsOfFile:[settingsBundle stringByAppendingPathComponent:@"Root.plist"]];
		NSArray *preferences = [settings objectForKey:@"PreferenceSpecifiers"];
		
		NSMutableDictionary *defaultsToRegister = [[NSMutableDictionary alloc] initWithCapacity:[preferences count]];
		for(NSDictionary *prefSpecification in preferences) {
			NSString *key = [prefSpecification objectForKey:@"Key"];
			if(key) {
				[defaultsToRegister setObject:[prefSpecification objectForKey:@"DefaultValue"] forKey:key];
				NSLog(@"writing as default %@ to the key %@",[prefSpecification objectForKey:@"DefaultValue"],key);
			}
		}
		[[NSUserDefaults standardUserDefaults] registerDefaults:defaultsToRegister];
	}
}