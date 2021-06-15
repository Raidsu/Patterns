using System.IO;
using System.Net.Mime;

namespace Asteroids.Parsing
{
    public sealed class ParseFile
    {
        
        private StreamReader _inputData;
        private static readonly char[] DelimiterArray = {':', ','};

        public ParseFile()
        {
            
        }
        public void SetFileToParse(string path)
        {
            _inputData = new StreamReader(path);
        }

        public string[] PrepareFile()
        {
            var receivedText = _inputData.ReadToEnd().Replace(" ", "").
                Replace("[","").
                Replace("]","").
                Replace("{","").
                Replace("}","").
                Replace("\"","") + ",";
            var splitText = receivedText.Split(DelimiterArray);
            return splitText;
        }
    }
}