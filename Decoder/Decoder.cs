using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoder
{
    public class DecodeItem{
        public string DateTime{ get; set;}
        public string Message{ get; set;}
    }

    public class Decoder
    {
        public Decoder(string fileName)
        {
            _FileName = fileName;
        }

        public List<DecodeItem> DecodeData{
            get{
                return DecodeFile();
            }
        }

        private string _FileName;

        private List<DecodeItem> DecodeFile(){
            List<DecodeItem> result = new List<DecodeItem>();

            if(File.Exists(_FileName)){

                string message = string.Empty;

                TextReader tr = new StreamReader(_FileName);
                string line = string.Empty;
                while ((line = tr.ReadLine()) != null)
                {
                    if (line.Length > 21)
                    {
                        DecodeItem item = new DecodeItem();

                        item.DateTime = line.Substring(0, 19);
                        message = line.Substring(21);

                        var data = Convert.FromBase64String(message);
                        item.Message = Encoding.UTF8.GetString(data);

                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}
