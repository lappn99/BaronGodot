using Godot;
using System;
using GCollections = Godot.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BaronyGame.Singletons
{
    public class StringProvider : Node
    {


        private string _stringFile;
        private Dictionary<string, string> _strings;

        public override void _Ready()
        {
            _strings = new Dictionary<string, string>();
            _stringFile = "res://GameData/Core/strings/strings.json";
            ReadStringFile();
        }
        private void ReadStringFile()
        {
            if (_stringFile != null)
            {
                File dataFile = new File();
                dataFile.Open(_stringFile, File.ModeFlags.Read);
                string dataText = dataFile.GetAsText();
                dataFile.Close();
                JSONParseResult result = JSON.Parse(dataText);
                if (result.Error != 0)
                {
                    return;
                }

                GCollections.Dictionary file = result.Result as GCollections.Dictionary;

                GCollections.Array strings = file["strings"] as GCollections.Array;

                foreach (GCollections.Dictionary entry in strings)
                {

                    _strings.Add(entry["id"] as string, entry["string"] as string);
                }
            }
        }
        public string GetString(string id)
        {

            if(_strings.ContainsKey(id))
            {   
                return _strings[id];
            }
            else
            {   
                return id;
            }

        }
        public string GetString(string id,params object[] args)
        {
            return String.Format(GetString(id),args);


        }
    }
}

