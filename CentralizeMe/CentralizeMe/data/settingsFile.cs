using System;
using System.IO;

namespace CentralizeMe.data
{
    internal class settingsFile
    {
        public static bool startupOption;
        public static string hotkeyOption;

        //Read file
        public static void Read()
        {
            if (!File.Exists(constants.DATA_FILE)) File.Create(constants.DATA_FILE);
            else
            {
                using(StreamReader streamReader = new StreamReader(constants.DATA_FILE))
                {
                    startupOption = Convert.ToBoolean(streamReader.ReadLine());
                    hotkeyOption = streamReader.ReadLine();
                }
            }
        }
    }
}
