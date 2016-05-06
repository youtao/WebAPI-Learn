namespace WebAPI_Learn.Console
{
    using System.Net;

    public class FileDownload
    {
        public long Length { get; private set; }

        public readonly string Uri;

        public FileDownload(string uri)
        {
            this.Uri = uri;
        }

        public void Download()
        {
            this.GetContentLength();
        }

        private void GetContentLength()
        {
            HttpWebRequest request = WebRequest.Create(this.Uri) as HttpWebRequest;
            request.Method = "HEAD";
            var response = request.GetResponse() as HttpWebResponse;
            this.Length = response.ContentLength;
        }
    }
}