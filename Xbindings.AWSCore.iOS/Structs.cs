using System;
using System.Runtime.InteropServices;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using CoreText;
using CoreVideo;
using Foundation;
using IOSurface;
using ImageIO;
using Metal;
using ObjCRuntime;
using OpenGLES;
using Security;
using SystemConfiguration;
using UIKit;

namespace AWSCore
{
    [Native]
    public enum AWSRegionType : long
    {
        Unknown,
        USEast1,
        USEast2,
        USWest1,
        USWest2,
        EUWest1,
        EUWest2,
        EUCentral1,
        APSoutheast1,
        APNortheast1,
        APNortheast2,
        APSoutheast2,
        APSouth1,
        SAEast1,
        CNNorth1,
        CACentral1,
        USGovWest1
    }

    [Native]
    public enum AWSServiceType : long
    {
        Unknown,
        APIGateway,
        AutoScaling,
        CloudWatch,
        CognitoIdentity,
        CognitoIdentityProvider,
        CognitoSync,
        DynamoDB,
        Ec2,
        ElasticLoadBalancing,
        IoT,
        IoTData,
        Firehose,
        Kinesis,
        Kms,
        Lambda,
        LexRuntime,
        Logs,
        MachineLearning,
        MobileAnalytics,
        MobileTargeting,
        Polly,
        Rekognition,
        S3,
        Ses,
        SimpleDB,
        Sns,
        Sqs,
        Sts
    }

    [Native]
    public enum AWSDDLogFlag : ulong
    {
        Error = (1 << 0),
        Warning = (1 << 1),
        Info = (1 << 2),
        Debug = (1 << 3),
        Verbose = (1 << 4)
    }

    [Native]
    public enum AWSDDLogLevel : ulong
    {
        Off = 0,
        Error = (AWSDDLogFlag.Error),
        Warning = (Error | AWSDDLogFlag.Warning),
        Info = (Warning | AWSDDLogFlag.Info),
        Debug = (Info | AWSDDLogFlag.Debug),
        Verbose = (Debug | AWSDDLogFlag.Verbose),
        All = (3372036854775807L * 2 + 1)
    }

    [Native]
    public enum AWSDDLogMessageOptions : long
    {
        CopyFile = 1 << 0,
        CopyFunction = 1 << 1,
        DontCopyMessage = 1 << 2
    }

    [Native]
    public enum AWSMTLModelEncodingBehavior : ulong
    {
        Excluded = 0,
        Unconditional,
        Conditional
    }

    [Native]
    public enum AWSNetworkingErrorType : long
    {
        Unknown,
        Cancelled
    }

    [Native]
    public enum AWSNetworkingRetryType : long
    {
        Unknown,
        ShouldNotRetry,
        ShouldRetry,
        ShouldRefreshCredentialsAndRetry,
        ShouldCorrectClockSkewAndRetry,
        ResetStreamAndRetry
    }

    [Native]
    public enum AWSHTTPMethod : long
    {
        Unknown,
        Get,
        Head,
        Post,
        Put,
        Patch,
        Delete
    }

    [Native]
    public enum AWSCognitoCredentialsProviderHelperErrorType : long
    {
        IdentityIsNil,
        TokenRefreshTimeout
    }

    [Native]
    public enum AWSCognitoCredentialsProviderErrorType : long
    {
        ErrorUnknown,
        IdentityIdIsNil,
        InvalidConfiguration,
        InvalidCognitoIdentityToken,
        CredentialsRefreshTimeout
    }

    [Native]
    public enum AWSServiceErrorType : long
    {
        Unknown,
        RequestTimeTooSkewed,
        InvalidSignatureException,
        SignatureDoesNotMatch,
        RequestExpired,
        AuthFailure,
        AccessDeniedException,
        UnrecognizedClientException,
        IncompleteSignature,
        InvalidClientTokenId,
        MissingAuthenticationToken,
        AccessDenied,
        ExpiredToken,
        InvalidAccessKeyId,
        InvalidToken,
        TokenRefreshRequired,
        AccessFailure,
        AuthMissingFailure,
        Throttling,
        ThrottlingException
    }

    [Native]
    public enum AWSLogLevel : long
    {
        Unknown = -1,
        None = 0,
        Error = 1,
        Warn = 2,
        Info = 3,
        Debug = 4,
        Verbose = 5
    }

    [Native]
    public enum AWSXMLBuilderErrorType : long
    {
        UnknownError = 900,
        DefinitionFileIsEmpty = 901,
        UndefinedXMLNamespace = 902,
        UndefinedActionRule = 903,
        MissingRequiredXMLElements = 904,
        InvalidXMLValue = 905,
        UnCatchedRuleTypeInDifinitionFile = 906
    }

    [Native]
    public enum AWSXMLParserErrorType : long
    {
        UnknownError,
        NoTypeDefinitionInRule,
        UnHandledType,
        UnExpectedType,
        DefinitionFileIsEmpty,
        UnexpectedXMLElement,
        XMLNameNotFoundInDefinition,
        MissingRequiredXMLElements,
        InvalidXMLValue
    }

    [Native]
    public enum AWSQueryParamBuilderErrorType : long
    {
        UnknownError,
        DefinitionFileIsEmpty,
        UndefinedActionRule,
        InternalError,
        InvalidParameter
    }

    [Native]
    public enum AWSEC2ParamBuilderErrorType : long
    {
        UnknownError,
        DefinitionFileIsEmpty,
        UndefinedActionRule,
        InternalError,
        InvalidParameter
    }

    [Native]
    public enum AWSJSONBuilderErrorType : long
    {
        UnknownError,
        DefinitionFileIsEmpty,
        UndefinedActionRule,
        InternalError,
        InvalidParameter
    }

    [Native]
    public enum AWSJSONParserErrorType : long
    {
        UnknownError,
        DefinitionFileIsEmpty,
        UndefinedActionRule,
        InternalError,
        InvalidParameter
    }

    [Native]
    public enum AWSValidationErrorType : long
    {
        UnknownError,
        UnexpectedParameter,
        UnhandledType,
        MissingRequiredParameter,
        OutOfRangeParameter,
        InvalidStringParameter,
        UnexpectedStringParameter,
        InvalidParameterType,
        InvalidBase64Data,
        HeaderTargetInvalid,
        HeaderAPIActionIsUndefined,
        HeaderDefinitionFileIsNotFound,
        HeaderDefinitionFileIsEmpty,
        HeaderAPIActionIsInvalid,
        URIIsInvalid
    }

    [Native]
    public enum AWSUICKeyChainStoreErrorCode : long
    {
        AWSUICKeyChainStoreErrorInvalidArguments = 1
    }

    [Native]
    public enum AWSUICKeyChainStoreItemClass : long
    {
        GenericPassword = 1,
        InternetPassword
    }

    [Native]
    public enum AWSUICKeyChainStoreProtocolType : long
    {
        Ftp = 1,
        FTPAccount,
        Http,
        Irc,
        Nntp,
        Pop3,
        Smtp,
        Socks,
        Imap,
        Ldap,
        AppleTalk,
        Afp,
        Telnet,
        Ssh,
        Ftps,
        Https,
        HTTPProxy,
        HTTPSProxy,
        FTPProxy,
        Smb,
        Rtsp,
        RTSPProxy,
        Daap,
        Eppc,
        Nntps,
        Ldaps,
        TelnetS,
        Ircs,
        Pop3s
    }

    [Native]
    public enum AWSUICKeyChainStoreAuthenticationType : long
    {
        Ntlm = 1,
        Msn,
        Dpa,
        Rpa,
        HTTPBasic,
        HTTPDigest,
        HTMLForm,
        Default
    }

    [Native]
    public enum AWSUICKeyChainStoreAccessibility : long
    {
        WhenUnlocked = 1,
        AfterFirstUnlock,
        Always,
        WhenPasscodeSetThisDeviceOnly,
        WhenUnlockedThisDeviceOnly,
        AfterFirstUnlockThisDeviceOnly,
        AlwaysThisDeviceOnly
    }

    [Native]
    public enum AWSUICKeyChainStoreAuthenticationPolicy : long
    {
        AWSUICKeyChainStoreAuthenticationPolicyUserPresence = 1 << 0
    }

    [Native]
    public enum AWSSTSErrorType : long
    {
        Unknown,
        ExpiredToken,
        IDPCommunicationError,
        IDPRejectedClaim,
        InvalidAuthorizationMessage,
        InvalidIdentityToken,
        MalformedPolicyDocument,
        PackedPolicyTooLarge,
        RegionDisabled
    }

    [Native]
    public enum AWSCognitoIdentityErrorType : long
    {
        Unknown,
        ConcurrentModification,
        DeveloperUserAlreadyRegistered,
        ExternalService,
        InternalError,
        InvalidIdentityPoolConfiguration,
        InvalidParameter,
        LimitExceeded,
        NotAuthorized,
        ResourceConflict,
        ResourceNotFound,
        TooManyRequests
    }

    [Native]
    public enum AWSCognitoIdentityErrorCode : long
    {
        Unknown,
        AccessDenied,
        InternalServerError
    }

    [Native]
    public enum AWSDDDispatchQueueLogFormatterMode : ulong
    {
        Shareble = 0,
        NonShareble
    }
}
