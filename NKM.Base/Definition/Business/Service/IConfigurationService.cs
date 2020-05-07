using NKM.Base.Definition.Enums.Applications;

namespace NKM.Base.Definition.Business.Service {
    public interface IConfigurationService {
        string AuthenticationServiceUrl { get; }
        string AuthorisationServiceUrl { get; }
        string ConfigPortalServiceUrl { get; }
        string SymmetricEncryptionKey { get; }
        OperationMode OperationMode { get; }
        string InstallFolderPath { get; }
        bool IsMultitenant { get; }
    }
}