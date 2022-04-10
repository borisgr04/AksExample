using System.Threading.Tasks;

namespace MsExample5.Services
{
    public interface IAzureKeyVaultService
    {
        Task<string> GetSecret(string secretName);

        Task<string> SetSecret(string secretName, string secretValue);

        Task<string> DeleteSecret(string secretName);
    }
}
