using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace FilterRemover
{
    public static class Config
    {
        private static string FullConfigPath { get { return $"{_assemblyPath}\\{_configFileName}"; } }

        private const float DEFAULT_BLOCK_COUNT = 5000f;
        private static readonly string _assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string _configFileName = "blockcount.txt";
        private static float _blockCount;

        /// <summary>
        /// Read the config file.<br/>
        /// Block count is how many pixels are rendered? I think?
        /// </summary>
        public static float ReadBlockCount()
        {
            // Create config file if it doesn't exist
            if (!File.Exists(FullConfigPath))
            {
                _blockCount = DEFAULT_BLOCK_COUNT;
                using (StreamWriter writer = new StreamWriter(FullConfigPath))
                    writer.WriteLine(_blockCount);
            }

            // Read block count if config exists
            else
            {
                using (StreamReader reader = new StreamReader(FullConfigPath))
                {
                    string strBlockCount = reader.ReadLine();
                    if (!float.TryParse(strBlockCount, out _blockCount))
                    {
                        _blockCount = DEFAULT_BLOCK_COUNT;
                        Plugin.StaticLogger.LogWarning("Invalid config file.");
                    }
                }
            }

            return _blockCount;

        } // end constructor

    } // end class Config

} // end namespace