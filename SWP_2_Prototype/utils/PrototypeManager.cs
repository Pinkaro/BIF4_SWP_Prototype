using SWP_2_Prototype.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_2_Prototype
{
    internal sealed class PrototypeManager
    {
        private static PrototypeManager _instance = null;
        private static List<string> _configData;
        private static string _configFilePath = "./prototypes.config";
        private static Dictionary<string, Weapon> _weaponTypes = new Dictionary<string, Weapon>();
        private static int _expectedStatsAmount = 6;

        private PrototypeManager ()
        {
            _configData = ReadFileLinesToList();
            InitializeManager();
        }

        public static PrototypeManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new PrototypeManager();
                    return _instance;
                }
                return _instance;
            }
        }

        // Indexes
        public Weapon this[string key]
        {
            get
            {
                try
                {
                    if (_weaponTypes.ContainsKey(key))
                    {
                        return _weaponTypes[key];
                    }
                    else
                    {
                        throw new KeyNotFoundException("Key ('" + key + "') not found in weapon types. Check config.");
                    }                    
                }
                catch(KeyNotFoundException e)
                {
                    throw e;
                }
            }
            set
            {
                _weaponTypes.Add(key, value);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach(KeyValuePair<string, Weapon> weapon in _weaponTypes)
            {
                count++;
                if(count == 1)
                {
                    sb.Append(weapon.Key + "\n");
                }
                else
                {
                    sb.Append("\n\n" + weapon.Key + "\n");
                }
                
                sb.Append(weapon.Value.ToString());
            }

            return sb.ToString();
        }

        private static List<string> ReadFileLinesToList()
        {
            if(_configData == null)
            {
                return new List<string>(File.ReadAllLines(_configFilePath));
            }
            return null;
        }

        private static void InitializeManager()
        {
            try
            {
                Type prototype = null;
                string[] stats;
                int lineCount = 0;
                foreach(string line in _configData)
                {
                    lineCount++;
                    if(line.Contains("SWP_2_Prototype"))
                    {
                        prototype = Type.GetType(line);
                        continue;
                    }

                    if (line.Equals(string.Empty))
                    {
                        continue;
                    }

                    stats = line.Split(';');
                    
                    if(stats.Length != _expectedStatsAmount)
                    {
                        throw new PrototypeLoadingException("Wrong amount of stats at line "+ lineCount +", " +
                            "expected "+ _expectedStatsAmount +" but was "+ stats.Length +". Check config file.");
                    }

                    string name = stats[0];
                    int duration = TryParseStatInt(stats[1]);
                    int damage = TryParseStatInt(stats[2]);
                    float weight = TryParseStatFloat(stats[3]);
                    float length = TryParseStatFloat(stats[4]);
                    string damageType = stats[5];

                    dynamic newWeapon = Activator.CreateInstance(prototype, duration, damage, weight, length, damageType);

                    _weaponTypes.Add(stats[0], newWeapon);
                }
            }
            catch(PrototypeLoadingException e)
            {
                throw e;
            }
        }

        private static int TryParseStatInt(string value)
        {
            if (Int32.TryParse(value, out int stat))
            {
                return stat;
            }
            else
            {
                throw new PrototypeLoadingException("Failed at loading int stat value '"+ value +". Check config file.");
            }
        }

        private static float TryParseStatFloat(string value)
        {
            if (float.TryParse(value, out float stat))
            {
                return stat;
            }
            else
            {
                throw new PrototypeLoadingException("Failed at loading float stat value '" + value + ". Check config file.");
            }
        }
    }
}
