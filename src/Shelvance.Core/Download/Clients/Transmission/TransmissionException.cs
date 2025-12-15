namespace Shelvance.Core.Download.Clients.Transmission
{
    public class TransmissionException : DownloadClientException
    {
        public TransmissionException(string message)
            : base(message)
        {
        }
    }
}
