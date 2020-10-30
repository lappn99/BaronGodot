using Godot;
using System;
using GCollctions = Godot.Collections;
namespace BaronyGame.Helpers
{
    public static class IOHelper
    {

        public static bool ReadJsonFile(string fileName,out JSONParseResult result)
        {
            result = null;
            if(fileName != null)
			{
				File dataFile = new File();
				dataFile.Open(fileName, File.ModeFlags.Read);
				string dataText = dataFile.GetAsText();
				dataFile.Close();
				result = JSON.Parse(dataText);
                return true;
			}            
            return false;
        }

    }
}

