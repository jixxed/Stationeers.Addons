﻿// Stationeers.Addons (c) 2018-2020 Damian 'Erdroy' Korczowski & Contributors

using System;
using System.Collections.Generic;
using System.IO;

namespace Stationeers.Addons.Core
{
    internal static class LocalMods
    {
        public static readonly string LocalModsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/My Games/Stationeers/mods/";

        public static string[] GetLocalModDirectories()
        {
            var directories = Directory.GetDirectories(LocalModsDirectory);
            var modDirectory = new List<string>();

            foreach (var directory in directories)
            {
                modDirectory.Add(directory);
            }

            return modDirectory.ToArray();
        }

        public static string[] GetLocalModDebugAssemblies()
        {
            var directories = GetLocalModDirectories();
            var modAssemblies = new List<string>();

            foreach (var directory in directories)
            {
                if (!directory.EndsWith("-Debug")) continue;
                var pluginName = Directory.GetParent(directory + "\\").Name + ".dll";
                var pluginDebugAssembly = Path.Combine(directory, pluginName);

                if (File.Exists(pluginDebugAssembly))
                    modAssemblies.Add(pluginDebugAssembly);
            }

            return modAssemblies.ToArray();
        }
    }
}
