using System.IO;
using System.Threading.Tasks;

namespace Tgs.Core.Infrastructures.Utility
{
    public class StreamToString
    {
        public static Task<string> GetStringAsync(Stream stream)
        {
            var sr = new StreamReader(stream);
            return sr.ReadToEndAsync();
        }
    }
}