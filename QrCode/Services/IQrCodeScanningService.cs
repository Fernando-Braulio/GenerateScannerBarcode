using System.Threading.Tasks;

namespace QrCode.Services
{
    public interface IQrCodeScanningService
    {
        Task<string> ScanAsync();
    }
}
