using System;
using AVFoundation;
using AWSCore;
using CloudKit;
using CoreAnimation;
using CoreData;
using CoreFoundation;
using CoreGraphics;
using CoreImage;
using CoreLocation;
using CoreSpotlight;
using CoreVideo;
using FileProvider;
using Foundation;
using IOSurface;
using ImageIO;
using Intents;
using Metal;
using ObjCRuntime;
using OpenGLES;
using Security;
using SystemConfiguration;
using UIKit;

namespace AWSCore
{
    // @interface AWSCancellationTokenRegistration : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSCancellationTokenRegistration
    {
        // -(void)dispose;
        [Export("dispose")]
        void Dispose();
    }

    // typedef void (^AWSCancellationBlock)();
    delegate void AWSCancellationBlock();

    // @interface AWSCancellationToken : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSCancellationToken
    {
        // @property (readonly, getter = isCancellationRequested, assign, nonatomic) BOOL cancellationRequested;
        [Export("cancellationRequested")]
        bool CancellationRequested { [Bind("isCancellationRequested")] get; }

        // -(AWSCancellationTokenRegistration * _Nonnull)registerCancellationObserverWithBlock:(AWSCancellationBlock _Nonnull)block;
        [Export("registerCancellationObserverWithBlock:")]
        AWSCancellationTokenRegistration RegisterCancellationObserverWithBlock(AWSCancellationBlock block);
    }

    // @interface AWSCancellationTokenSource : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSCancellationTokenSource
    {
        // +(instancetype _Nonnull)cancellationTokenSource;
        [Static]
        [Export("cancellationTokenSource")]
        AWSCancellationTokenSource CancellationTokenSource();

        // @property (readonly, nonatomic, strong) AWSCancellationToken * _Nonnull token;
        [Export("token", ArgumentSemantic.Strong)]
        AWSCancellationToken Token { get; }

        // @property (readonly, getter = isCancellationRequested, assign, nonatomic) BOOL cancellationRequested;
        [Export("cancellationRequested")]
        bool CancellationRequested { [Bind("isCancellationRequested")] get; }

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();

        // -(void)cancelAfterDelay:(int)millis;
        [Export("cancelAfterDelay:")]
        void CancelAfterDelay(int millis);

        // -(void)dispose;
        [Export("dispose")]
        void Dispose();
    }

    // @interface AWSExecutor : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSExecutor
    {
        // +(instancetype _Nonnull)defaultExecutor;
        [Static]
        [Export("defaultExecutor")]
        AWSExecutor DefaultExecutor();

        // +(instancetype _Nonnull)immediateExecutor;
        [Static]
        [Export("immediateExecutor")]
        AWSExecutor ImmediateExecutor();

        // +(instancetype _Nonnull)mainThreadExecutor;
        [Static]
        [Export("mainThreadExecutor")]
        AWSExecutor MainThreadExecutor();

        // +(instancetype _Nonnull)executorWithBlock:(void (^ _Nonnull)(void (^ _Nonnull)(void)))block;
        [Static]
        [Export("executorWithBlock:")]
        AWSExecutor ExecutorWithBlock(Action<Action> block);

        // +(instancetype _Nonnull)executorWithDispatchQueue:(dispatch_queue_t _Nonnull)queue;
        [Static]
        [Export("executorWithDispatchQueue:")]
        AWSExecutor ExecutorWithDispatchQueue(DispatchQueue queue);

        // +(instancetype _Nonnull)executorWithOperationQueue:(NSOperationQueue * _Nonnull)queue;
        [Static]
        [Export("executorWithOperationQueue:")]
        AWSExecutor ExecutorWithOperationQueue(NSOperationQueue queue);

        // -(void)execute:(void (^ _Nonnull)(void))block;
        [Export("execute:")]
        void Execute(Action block);
    }

    [Static]
    partial interface AWSTaskConstants
    {
        // extern NSString *const _Nonnull AWSTaskErrorDomain;
        [Field("AWSTaskErrorDomain", "__Internal")]
        NSString AWSTaskErrorDomain { get; }

        // extern const NSInteger kAWSMultipleErrorsError;
        [Field("kAWSMultipleErrorsError", "__Internal")]
        nint kAWSMultipleErrorsError { get; }

        // extern NSString *const _Nonnull AWSTaskMultipleErrorsUserInfoKey;
        [Field("AWSTaskMultipleErrorsUserInfoKey", "__Internal")]
        NSString AWSTaskMultipleErrorsUserInfoKey { get; }
    }

    // audit-objc-generics: @interface AWSTask<__covariant ResultType> : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSTask
    {
        // +(instancetype _Nonnull)taskWithResult:(ResultType _Nullable)result;
        [Static]
        [Export("taskWithResult:")]
        AWSTask TaskWithResult([NullAllowed] NSObject result);

        // +(instancetype _Nonnull)taskWithError:(NSError * _Nonnull)error;
        [Static]
        [Export("taskWithError:")]
        AWSTask TaskWithError(NSError error);

        // +(instancetype _Nonnull)cancelledTask;
        [Static]
        [Export("cancelledTask")]
        AWSTask CancelledTask();

        // +(instancetype _Nonnull)taskForCompletionOfAllTasks:(NSArray<AWSTask *> * _Nullable)tasks;
        [Static]
        [Export("taskForCompletionOfAllTasks:")]
        AWSTask TaskForCompletionOfAllTasks([NullAllowed] AWSTask[] tasks);

        // +(instancetype _Nonnull)taskForCompletionOfAllTasksWithResults:(NSArray<AWSTask *> * _Nullable)tasks;
        [Static]
        [Export("taskForCompletionOfAllTasksWithResults:")]
        AWSTask TaskForCompletionOfAllTasksWithResults([NullAllowed] AWSTask[] tasks);

        // +(instancetype _Nonnull)taskForCompletionOfAnyTask:(NSArray<AWSTask *> * _Nullable)tasks;
        [Static]
        [Export("taskForCompletionOfAnyTask:")]
        AWSTask TaskForCompletionOfAnyTask([NullAllowed] AWSTask[] tasks);

        // +(AWSTask<AWSVoid> * _Nonnull)taskWithDelay:(int)millis;
        [Static]
        [Export("taskWithDelay:")]
        AWSTask TaskWithDelay(int millis);

        // +(AWSTask<AWSVoid> * _Nonnull)taskWithDelay:(int)millis cancellationToken:(AWSCancellationToken * _Nullable)token;
        [Static]
        [Export("taskWithDelay:cancellationToken:")]
        AWSTask TaskWithDelay(int millis, [NullAllowed] AWSCancellationToken token);

        // +(instancetype _Nonnull)taskFromExecutor:(AWSExecutor * _Nonnull)executor withBlock:(id  _Nonnull (^ _Nullable)(void))block;
        [Static]
        [Export("taskFromExecutor:withBlock:")]
        AWSTask TaskFromExecutor(AWSExecutor executor, [NullAllowed] Func<NSObject> block);

        // @property (readonly, nonatomic, strong) ResultType _Nullable result;
        [NullAllowed, Export("result", ArgumentSemantic.Strong)]
        NSObject Result { get; }

        // @property (readonly, nonatomic, strong) NSError * _Nullable error;
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; }

        // @property (readonly, getter = isCancelled, assign, nonatomic) BOOL cancelled;
        [Export("cancelled")]
        bool Cancelled { [Bind("isCancelled")] get; }

        // @property (readonly, getter = isFaulted, assign, nonatomic) BOOL faulted;
        [Export("faulted")]
        bool Faulted { [Bind("isFaulted")] get; }

        // @property (readonly, getter = isCompleted, assign, nonatomic) BOOL completed;
        [Export("completed")]
        bool Completed { [Bind("isCompleted")] get; }

        // -(AWSTask * _Nonnull)continueWithBlock:(AWSContinuationBlock _Nonnull)block;
        [Export("continueWithBlock:")]
        AWSTask ContinueWithBlock(AWSContinuationBlock block);

        // -(AWSTask * _Nonnull)continueWithBlock:(AWSContinuationBlock _Nonnull)block cancellationToken:(AWSCancellationToken * _Nullable)cancellationToken;
        [Export("continueWithBlock:cancellationToken:")]
        AWSTask ContinueWithBlock(AWSContinuationBlock block, [NullAllowed] AWSCancellationToken cancellationToken);

        // -(AWSTask * _Nonnull)continueWithExecutor:(AWSExecutor * _Nonnull)executor withBlock:(AWSContinuationBlock _Nonnull)block;
        [Export("continueWithExecutor:withBlock:")]
        AWSTask ContinueWithExecutor(AWSExecutor executor, AWSContinuationBlock block);

        // -(AWSTask * _Nonnull)continueWithExecutor:(AWSExecutor * _Nonnull)executor block:(AWSContinuationBlock _Nonnull)block cancellationToken:(AWSCancellationToken * _Nullable)cancellationToken;
        [Export("continueWithExecutor:block:cancellationToken:")]
        AWSTask ContinueWithExecutor(AWSExecutor executor, AWSContinuationBlock block, [NullAllowed] AWSCancellationToken cancellationToken);

        // -(AWSTask * _Nonnull)continueWithSuccessBlock:(AWSContinuationBlock _Nonnull)block;
        [Export("continueWithSuccessBlock:")]
        AWSTask ContinueWithSuccessBlock(AWSContinuationBlock block);

        // -(AWSTask * _Nonnull)continueWithSuccessBlock:(AWSContinuationBlock _Nonnull)block cancellationToken:(AWSCancellationToken * _Nullable)cancellationToken;
        [Export("continueWithSuccessBlock:cancellationToken:")]
        AWSTask ContinueWithSuccessBlock(AWSContinuationBlock block, [NullAllowed] AWSCancellationToken cancellationToken);

        // -(void)waitUntilFinished;
        [Export("waitUntilFinished")]
        void WaitUntilFinished();
    }

    // typedef id _Nullable (^AWSContinuationBlock)(AWSTask<ResultType> * _Nonnull);
    delegate NSObject AWSContinuationBlock(AWSTask arg0);

    // audit-objc-generics: @interface AWSTaskCompletionSource<__covariant ResultType> : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSTaskCompletionSource
    {
        // +(instancetype _Nonnull)taskCompletionSource;
        [Static]
        [Export("taskCompletionSource")]
        AWSTaskCompletionSource TaskCompletionSource();

        // @property (readonly, nonatomic, strong) AWSTask<ResultType> * _Nonnull task;
        [Export("task", ArgumentSemantic.Strong)]
        AWSTask Task { get; }

        // -(void)setResult:(ResultType _Nullable)result;
        [Export("setResult:")]
        void SetResult([NullAllowed] NSObject result);

        // -(void)setError:(NSError * _Nonnull)error;
        [Export("setError:")]
        void SetError(NSError error);

        // -(void)cancel;
        [Export("cancel")]
        void Cancel();

        // -(BOOL)trySetResult:(ResultType _Nullable)result;
        [Export("trySetResult:")]
        bool TrySetResult([NullAllowed] NSObject result);

        // -(BOOL)trySetError:(NSError * _Nonnull)error;
        [Export("trySetError:")]
        bool TrySetError(NSError error);

        // -(BOOL)trySetCancelled;
        [Export("trySetCancelled")]
        bool TrySetCancelled { get; }
    }

    [Static]
    partial interface AWSDateConstants
    {
        // extern NSString *const AWSDateRFC822DateFormat1;
        [Field("AWSDateRFC822DateFormat1", "__Internal")]
        NSString RFC822DateFormat1 { get; }

        // extern NSString *const AWSDateISO8601DateFormat1;
        [Field("AWSDateISO8601DateFormat1", "__Internal")]
        NSString ISO8601DateFormat1 { get; }

        // extern NSString *const AWSDateISO8601DateFormat2;
        [Field("AWSDateISO8601DateFormat2", "__Internal")]
        NSString ISO8601DateFormat2 { get; }

        // extern NSString *const AWSDateISO8601DateFormat3;
        [Field("AWSDateISO8601DateFormat3", "__Internal")]
        NSString ISO8601DateFormat3 { get; }

        // extern NSString *const AWSDateShortDateFormat1;
        [Field("AWSDateShortDateFormat1", "__Internal")]
        NSString ShortDateFormat1 { get; }

        // extern NSString *const AWSDateShortDateFormat2;
        [Field("AWSDateShortDateFormat2", "__Internal")]
        NSString ShortDateFormat2 { get; }
    }

    // @interface AWS (NSDate)
    [Category]
    [BaseType(typeof(NSDate))]
    interface NSDate_AWS
    {
        // +(NSDate *)aws_clockSkewFixedDate;
        [Static]
        [Export("aws_clockSkewFixedDate")]
        NSDate Aws_clockSkewFixedDate();

        // +(NSDate *)aws_dateFromString:(NSString *)string;
        [Static]
        [Export("aws_dateFromString:")]
        NSDate Aws_dateFromString(string @string);

        // +(NSDate *)aws_dateFromString:(NSString *)string format:(NSString *)dateFormat;
        [Static]
        [Export("aws_dateFromString:format:")]
        NSDate Aws_dateFromString(string @string, string dateFormat);

        // -(NSString *)aws_stringValue:(NSString *)dateFormat;
        [Export("aws_stringValue:")]
        string Aws_stringValue(string dateFormat);

        // +(void)aws_setRuntimeClockSkew:(NSTimeInterval)clockskew;
        [Static]
        [Export("aws_setRuntimeClockSkew:")]
        void Aws_setRuntimeClockSkew(double clockskew);

        // +(NSTimeInterval)aws_getRuntimeClockSkew;
        [Static]
        [Export("aws_getRuntimeClockSkew")]
        double Aws_getRuntimeClockSkew();
    }

    // @interface AWS (NSDictionary)
    [Category]
    [BaseType(typeof(NSDictionary))]
    interface NSDictionary_AWS
    {
        // -(NSDictionary *)aws_removeNullValues;
        [Export("aws_removeNullValues")]
        NSDictionary Aws_removeNullValues();

        // -(id)aws_objectForCaseInsensitiveKey:(id)aKey;
        [Export("aws_objectForCaseInsensitiveKey:")]
        NSObject Aws_objectForCaseInsensitiveKey(NSObject aKey);
    }

    // @interface AWS (NSJSONSerialization)
    [Category]
    [BaseType(typeof(NSJsonSerialization))]
    interface NSJSONSerialization_AWS
    {
        // +(NSData *)aws_dataWithJSONObject:(id)obj options:(NSJSONWritingOptions)opt error:(NSError **)error;
        [Static]
        [Export("aws_dataWithJSONObject:options:error:")]
        NSData Aws_dataWithJSONObject(NSObject obj, NSJsonWritingOptions opt, out NSError error);
    }

    // @interface AWS (NSNumber)
    [Category]
    [BaseType(typeof(NSNumber))]
    interface NSNumber_AWS
    {
        // +(NSNumber *)aws_numberFromString:(NSString *)string;
        [Static]
        [Export("aws_numberFromString:")]
        NSNumber Aws_numberFromString(string @string);
    }

    // @interface AWS (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_AWS
    {
        // -(NSDictionary *)aws_properties;
        [Export("aws_properties")]
        NSDictionary Aws_properties();

        // -(void)aws_copyPropertiesFromObject:(NSObject *)object;
        [Export("aws_copyPropertiesFromObject:")]
        void Aws_copyPropertiesFromObject(NSObject @object);
    }

    // @interface AWS (NSString)
    [Category]
    [BaseType(typeof(NSString))]
    interface NSString_AWS
    {
        // +(NSString *)aws_base64md5FromData:(NSData *)data;
        [Static]
        [Export("aws_base64md5FromData:")]
        string Aws_base64md5FromData(NSData data);

        // -(BOOL)aws_isBase64Data;
        [Export("aws_isBase64Data")]
        bool Aws_isBase64Data();

        // -(NSString *)aws_stringWithURLEncoding;
        [Export("aws_stringWithURLEncoding")]
        string Aws_stringWithURLEncoding();

        // -(NSString *)aws_stringWithURLEncodingPath;
        [Export("aws_stringWithURLEncodingPath")]
        string Aws_stringWithURLEncodingPath();

        // -(NSString *)aws_stringWithURLEncodingPathWithoutPriorDecoding;
        [Export("aws_stringWithURLEncodingPathWithoutPriorDecoding")]
        string Aws_stringWithURLEncodingPathWithoutPriorDecoding();

        // -(NSString *)aws_md5String;
        [Export("aws_md5String")]
        string Aws_md5String();

        // -(NSString *)aws_md5StringLittleEndian;
        [Export("aws_md5StringLittleEndian")]
        string Aws_md5StringLittleEndian();

        // -(BOOL)aws_isVirtualHostedStyleCompliant;
        [Export("aws_isVirtualHostedStyleCompliant")]
        bool Aws_isVirtualHostedStyleCompliant();

        // -(AWSRegionType)aws_regionTypeValue;
        [Export("aws_regionTypeValue")]
        AWSRegionType Aws_regionTypeValue();
    }

    // @interface AWS (NSFileManager)
    [Category]
    [BaseType(typeof(NSFileManager))]
    interface NSFileManager_AWS
    {
        // -(BOOL)aws_atomicallyCopyItemAtURL:(NSURL *)sourceURL toURL:(NSURL *)destinationURL backupItemName:(NSString *)backupItemName error:(NSError **)outError;
        [Export("aws_atomicallyCopyItemAtURL:toURL:backupItemName:error:")]
        bool Aws_atomicallyCopyItemAtURL(NSUrl sourceURL, NSUrl destinationURL, string backupItemName, out NSError outError);
    }

    [Static]
    partial interface AWSClientContextConstants
    {
        // extern NSString *const AWSClientContextVersion;
        [Field("AWSClientContextVersion", "__Internal")]
        NSString Version { get; }

        // extern NSString *const AWSClientContextHeader;
        [Field("AWSClientContextHeader", "__Internal")]
        NSString Header { get; }

        // extern NSString *const AWSClientContextHeaderEncoding;
        [Field("AWSClientContextHeaderEncoding", "__Internal")]
        NSString HeaderEncoding { get; }
    }

    // @interface AWSClientContext : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSClientContext
    {
        // @property (readonly, nonatomic, strong) NSString * installationId;
        [Export("installationId", ArgumentSemantic.Strong)]
        string InstallationId { get; }

        // @property (nonatomic, strong) NSString * appVersion;
        [Export("appVersion", ArgumentSemantic.Strong)]
        string AppVersion { get; set; }

        // @property (nonatomic, strong) NSString * appBuild;
        [Export("appBuild", ArgumentSemantic.Strong)]
        string AppBuild { get; set; }

        // @property (nonatomic, strong) NSString * appPackageName;
        [Export("appPackageName", ArgumentSemantic.Strong)]
        string AppPackageName { get; set; }

        // @property (nonatomic, strong) NSString * appName;
        [Export("appName", ArgumentSemantic.Strong)]
        string AppName { get; set; }

        // @property (nonatomic, strong) NSString * devicePlatformVersion;
        [Export("devicePlatformVersion", ArgumentSemantic.Strong)]
        string DevicePlatformVersion { get; set; }

        // @property (nonatomic, strong) NSString * devicePlatform;
        [Export("devicePlatform", ArgumentSemantic.Strong)]
        string DevicePlatform { get; set; }

        // @property (nonatomic, strong) NSString * deviceManufacturer;
        [Export("deviceManufacturer", ArgumentSemantic.Strong)]
        string DeviceManufacturer { get; set; }

        // @property (nonatomic, strong) NSString * deviceModel;
        [Export("deviceModel", ArgumentSemantic.Strong)]
        string DeviceModel { get; set; }

        // @property (nonatomic, strong) NSString * deviceModelVersion;
        [Export("deviceModelVersion", ArgumentSemantic.Strong)]
        string DeviceModelVersion { get; set; }

        // @property (nonatomic, strong) NSString * deviceLocale;
        [Export("deviceLocale", ArgumentSemantic.Strong)]
        string DeviceLocale { get; set; }

        // @property (nonatomic, strong) NSDictionary * customAttributes;
        [Export("customAttributes", ArgumentSemantic.Strong)]
        NSDictionary CustomAttributes { get; set; }

        // @property (readonly, nonatomic, strong) NSDictionary * serviceDetails;
        [Export("serviceDetails", ArgumentSemantic.Strong)]
        NSDictionary ServiceDetails { get; }

        // -(NSDictionary *)dictionaryRepresentation;
        [Export("dictionaryRepresentation")]
        NSDictionary DictionaryRepresentation { get; }

        // -(NSString *)JSONString;
        [Export("JSONString")]
        string JSONString { get; }

        // -(NSString *)base64EncodedJSONString;
        [Export("base64EncodedJSONString")]
        string Base64EncodedJSONString { get; }

        // -(void)setDetails:(id)details forService:(NSString *)service;
        [Export("setDetails:forService:")]
        void SetDetails(NSObject details, string service);
    }

    // @interface AWSDDLog : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSDDLog
    {
        // @property (readonly, nonatomic, strong, class) AWSDDLog * _Nonnull sharedInstance;
        [Static]
        [Export("sharedInstance", ArgumentSemantic.Strong)]
        AWSDDLog SharedInstance { get; }

        // @property (assign, nonatomic) AWSDDLogLevel logLevel;
        [Export("logLevel", ArgumentSemantic.Assign)]
        AWSDDLogLevel LogLevel { get; set; }

        // @property (readonly, nonatomic, strong, class) dispatch_queue_t _Nonnull loggingQueue;
        [Static]
        [Export("loggingQueue", ArgumentSemantic.Strong)]
        DispatchQueue LoggingQueue { get; }

        // +(void)log:(BOOL)asynchronous level:(AWSDDLogLevel)level flag:(AWSDDLogFlag)flag context:(NSInteger)context file:(const char * _Nonnull)file function:(const char * _Nonnull)function line:(NSUInteger)line tag:(id _Nullable)tag format:(NSString * _Nonnull)format, ... __attribute__((format(NSString, 9, 10)));
        [Static, Internal]
        [Export("log:level:flag:context:file:function:line:tag:format:", IsVariadic = true)]
        unsafe void Log(bool asynchronous, AWSDDLogLevel level, AWSDDLogFlag flag, nint context, NSObject[] file, NSObject[] function, nuint line, [NullAllowed] NSObject tag, string format, IntPtr varArgs);

        // +(void)log:(BOOL)asynchronous level:(AWSDDLogLevel)level flag:(AWSDDLogFlag)flag context:(NSInteger)context file:(const char * _Nonnull)file function:(const char * _Nonnull)function line:(NSUInteger)line tag:(id _Nullable)tag format:(NSString * _Nonnull)format args:(va_list)argList;
        [Static]
        [Export("log:level:flag:context:file:function:line:tag:format:args:")]
        unsafe void Log(bool asynchronous, AWSDDLogLevel level, AWSDDLogFlag flag, nint context, NSObject[] file, NSObject[] function, nuint line, [NullAllowed] NSObject tag, string format, NSObject[] argList);

        // +(void)log:(BOOL)asynchronous message:(AWSDDLogMessage * _Nonnull)logMessage;
        [Static]
        [Export("log:message:")]
        void Log(bool asynchronous, AWSDDLogMessage logMessage);

        // +(void)flushLog;
        [Static]
        [Export("flushLog")]
        void FlushLog();

        // +(void)addLogger:(id<AWSDDLogger> _Nonnull)logger;
        [Static]
        [Export("addLogger:")]
        void AddLogger(AWSDDLogger logger);

        // +(void)addLogger:(id<AWSDDLogger> _Nonnull)logger withLevel:(AWSDDLogLevel)level;
        [Static]
        [Export("addLogger:withLevel:")]
        void AddLogger(AWSDDLogger logger, AWSDDLogLevel level);

        // +(void)removeLogger:(id<AWSDDLogger> _Nonnull)logger;
        [Static]
        [Export("removeLogger:")]
        void RemoveLogger(AWSDDLogger logger);

        // +(void)removeAllLoggers;
        [Static]
        [Export("removeAllLoggers")]
        void RemoveAllLoggers();

        // @property (readonly, copy, nonatomic, class) NSArray<id<AWSDDLogger>> * _Nonnull allLoggers;
        [Static]
        [Export("allLoggers", ArgumentSemantic.Copy)]
        AWSDDLogger[] AllLoggers { get; }

        // @property (readonly, copy, nonatomic, class) NSArray<AWSDDLoggerInformation *> * _Nonnull allLoggersWithLevel;
        [Static]
        [Export("allLoggersWithLevel", ArgumentSemantic.Copy)]
        AWSDDLoggerInformation[] AllLoggersWithLevel { get; }

        // @property (readonly, copy, nonatomic, class) NSArray<Class> * _Nonnull registeredClasses;
        [Static]
        [Export("registeredClasses", ArgumentSemantic.Copy)]
        Class[] RegisteredClasses { get; }

        // @property (readonly, copy, nonatomic, class) NSArray<NSString *> * _Nonnull registeredClassNames;
        [Static]
        [Export("registeredClassNames", ArgumentSemantic.Copy)]
        string[] RegisteredClassNames { get; }

        // +(AWSDDLogLevel)levelForClass:(Class _Nonnull)aClass;
        [Static]
        [Export("levelForClass:")]
        AWSDDLogLevel LevelForClass(Class aClass);

        // +(AWSDDLogLevel)levelForClassWithName:(NSString * _Nonnull)aClassName;
        [Static]
        [Export("levelForClassWithName:")]
        AWSDDLogLevel LevelForClassWithName(string aClassName);

        // +(void)setLevel:(AWSDDLogLevel)level forClass:(Class _Nonnull)aClass;
        [Static]
        [Export("setLevel:forClass:")]
        void SetLevel(AWSDDLogLevel level, Class aClass);

        // +(void)setLevel:(AWSDDLogLevel)level forClassWithName:(NSString * _Nonnull)aClassName;
        [Static]
        [Export("setLevel:forClassWithName:")]
        void SetLevel(AWSDDLogLevel level, string aClassName);
    }

    // @protocol AWSDDLogger <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AWSDDLogger
    {
        // @required -(void)logMessage:(AWSDDLogMessage * _Nonnull)logMessage;
        [Abstract]
        [Export("logMessage:")]
        void LogMessage(AWSDDLogMessage logMessage);

        // @required @property (nonatomic, strong) id<AWSDDLogFormatter> _Nonnull logFormatter;
        [Abstract]
        [Export("logFormatter", ArgumentSemantic.Strong)]
        AWSDDLogFormatter LogFormatter { get; set; }

        // @optional -(void)didAddLogger;
        [Export("didAddLogger")]
        void DidAddLogger();

        // @optional -(void)didAddLoggerInQueue:(dispatch_queue_t _Nonnull)queue;
        [Export("didAddLoggerInQueue:")]
        void DidAddLoggerInQueue(DispatchQueue queue);

        // @optional -(void)willRemoveLogger;
        [Export("willRemoveLogger")]
        void WillRemoveLogger();

        // @optional -(void)flush;
        [Export("flush")]
        void Flush();

        // @optional @property (readonly, nonatomic, strong) dispatch_queue_t _Nonnull loggerQueue;
        [Export("loggerQueue", ArgumentSemantic.Strong)]
        DispatchQueue LoggerQueue { get; }

        // @optional @property (readonly, nonatomic) NSString * _Nonnull loggerName;
        [Export("loggerName")]
        string LoggerName { get; }
    }

    // @protocol AWSDDLogFormatter <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface AWSDDLogFormatter
    {
        // @required -(NSString * _Nullable)formatLogMessage:(AWSDDLogMessage * _Nonnull)logMessage;
        [Abstract]
        [Export("formatLogMessage:")]
        [return: NullAllowed]
        string FormatLogMessage(AWSDDLogMessage logMessage);

        // @optional -(void)didAddToLogger:(id<AWSDDLogger> _Nonnull)logger;
        [Export("didAddToLogger:")]
        void DidAddToLogger(AWSDDLogger logger);

        // @optional -(void)didAddToLogger:(id<AWSDDLogger> _Nonnull)logger inQueue:(dispatch_queue_t _Nonnull)queue;
        [Export("didAddToLogger:inQueue:")]
        void DidAddToLogger(AWSDDLogger logger, DispatchQueue queue);

        // @optional -(void)willRemoveFromLogger:(id<AWSDDLogger> _Nonnull)logger;
        [Export("willRemoveFromLogger:")]
        void WillRemoveFromLogger(AWSDDLogger logger);
    }

    // @protocol AWSDDRegisteredDynamicLogging
    [Protocol, Model]
    interface AWSDDRegisteredDynamicLogging
    {
        // @required @property (readwrite, nonatomic, setter = ddSetLogLevel:, class) AWSDDLogLevel ddLogLevel;
        [Static, Abstract]
        [Export("ddLogLevel", ArgumentSemantic.Assign)]
        AWSDDLogLevel DdLogLevel { get; [Bind("ddSetLogLevel:")] set; }
    }

    // @interface AWSDDLogMessage : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface AWSDDLogMessage : INSCopying
    {
        // -(instancetype _Nonnull)initWithMessage:(NSString * _Nonnull)message level:(AWSDDLogLevel)level flag:(AWSDDLogFlag)flag context:(NSInteger)context file:(NSString * _Nonnull)file function:(NSString * _Nullable)function line:(NSUInteger)line tag:(id _Nullable)tag options:(AWSDDLogMessageOptions)options timestamp:(NSDate * _Nullable)timestamp __attribute__((objc_designated_initializer));
        [Export("initWithMessage:level:flag:context:file:function:line:tag:options:timestamp:")]
        [DesignatedInitializer]
        IntPtr Constructor(string message, AWSDDLogLevel level, AWSDDLogFlag flag, nint context, string file, [NullAllowed] string function, nuint line, [NullAllowed] NSObject tag, AWSDDLogMessageOptions options, [NullAllowed] NSDate timestamp);

        // @property (readonly, nonatomic) NSString * _Nonnull message;
        [Export("message")]
        string Message { get; }

        // @property (readonly, nonatomic) AWSDDLogLevel level;
        [Export("level")]
        AWSDDLogLevel Level { get; }

        // @property (readonly, nonatomic) AWSDDLogFlag flag;
        [Export("flag")]
        AWSDDLogFlag Flag { get; }

        // @property (readonly, nonatomic) NSInteger context;
        [Export("context")]
        nint Context { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull file;
        [Export("file")]
        string File { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull fileName;
        [Export("fileName")]
        string FileName { get; }

        // @property (readonly, nonatomic) NSString * _Nullable function;
        [NullAllowed, Export("function")]
        string Function { get; }

        // @property (readonly, nonatomic) NSUInteger line;
        [Export("line")]
        nuint Line { get; }

        // @property (readonly, nonatomic) id _Nullable tag;
        [NullAllowed, Export("tag")]
        NSObject Tag { get; }

        // @property (readonly, nonatomic) AWSDDLogMessageOptions options;
        [Export("options")]
        AWSDDLogMessageOptions Options { get; }

        // @property (readonly, nonatomic) NSDate * _Nonnull timestamp;
        [Export("timestamp")]
        NSDate Timestamp { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull threadID;
        [Export("threadID")]
        string ThreadID { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull threadName;
        [Export("threadName")]
        string ThreadName { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull queueLabel;
        [Export("queueLabel")]
        string QueueLabel { get; }
    }

    // @interface AWSDDAbstractLogger : NSObject <AWSDDLogger>
    [BaseType(typeof(NSObject))]
    interface AWSDDAbstractLogger : AWSDDLogger
    {
        // @property (readonly, getter = isOnGlobalLoggingQueue, nonatomic) BOOL onGlobalLoggingQueue;
        [Export("onGlobalLoggingQueue")]
        bool OnGlobalLoggingQueue { [Bind("isOnGlobalLoggingQueue")] get; }

        // @property (readonly, getter = isOnInternalLoggerQueue, nonatomic) BOOL onInternalLoggerQueue;
        [Export("onInternalLoggerQueue")]
        bool OnInternalLoggerQueue { [Bind("isOnInternalLoggerQueue")] get; }
    }

    // @interface AWSDDLoggerInformation : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSDDLoggerInformation
    {
        // @property (readonly, nonatomic) id<AWSDDLogger> _Nonnull logger;
        [Export("logger")]
        AWSDDLogger Logger { get; }

        // @property (readonly, nonatomic) AWSDDLogLevel level;
        [Export("level")]
        AWSDDLogLevel Level { get; }

        // +(AWSDDLoggerInformation * _Nonnull)informationWithLogger:(id<AWSDDLogger> _Nonnull)logger andLevel:(AWSDDLogLevel)level;
        [Static]
        [Export("informationWithLogger:andLevel:")]
        AWSDDLoggerInformation InformationWithLogger(AWSDDLogger logger, AWSDDLogLevel level);
    }

    // @interface AWSDDASLLogger : AWSDDAbstractLogger <AWSDDLogger>
    [BaseType(typeof(AWSDDAbstractLogger))]
    interface AWSDDASLLogger : AWSDDLogger
    {
        // @property (readonly, strong, class) AWSDDASLLogger * sharedInstance;
        [Static]
        [Export("sharedInstance", ArgumentSemantic.Strong)]
        AWSDDASLLogger SharedInstance { get; }
    }

    // @interface AWSDDASLLogCapture : NSObject
    [BaseType(typeof(NSObject))]
    interface AWSDDASLLogCapture
    {
        // +(void)start;
        [Static]
        [Export("start")]
        void Start();

        // +(void)stop;
        [Static]
        [Export("stop")]
        void Stop();

        // @property (class) AWSDDLogLevel captureLevel;
        [Static]
        [Export("captureLevel", ArgumentSemantic.Assign)]
        AWSDDLogLevel CaptureLevel { get; set; }
    }
}
