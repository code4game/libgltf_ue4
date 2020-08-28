// Copyright (o) 2016-2018 Code 4 Game <develop@c4g.io>

using UnrealBuildTool;
using System.Collections.Generic;

public class libgltf_ue4 : ModuleRules
{
    public libgltf_ue4(TargetInfo Target)
    {
        Type = ModuleType.External;

        string glTFPath = System.IO.Path.Combine(ModuleDirectory, "libgltf-0.1.6");
        string IncludePath = System.IO.Path.Combine(glTFPath, "include");
        List<string> LibPaths = new List<string>();
        string LibFilePath = "";

        if ((Target.Platform == UnrealTargetPlatform.Win32) || (Target.Platform == UnrealTargetPlatform.Win64))
        {
            string PlatformName = "";
            switch (Target.Platform)
            {
            case UnrealTargetPlatform.Win32:
                PlatformName = "win32";
                break;
            case UnrealTargetPlatform.Win64:
                PlatformName = "win64";
                break;
            }

            string TargetConfiguration = "Release";
            string TargetPostfix = "";
            if (Target.Configuration == UnrealTargetConfiguration.Debug)
            {
                TargetConfiguration = "Debug";
                TargetPostfix = "d";
            }

            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", PlatformName, "vs2019", TargetConfiguration));

            LibFilePath = "libgltf" + TargetPostfix + ".lib";
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "linux"));

            LibFilePath = "libgltf.a";
        }
        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "macos"));

            LibFilePath = "libgltf.a";
        }
        else if (Target.Platform == UnrealTargetPlatform.Android)
        {
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "android", "armeabi-v7a"));
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "android", "armeabi-v7a-with-neon"));
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "android", "arm64-v8a"));
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "android", "x86"));
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "android", "x86_64"));

            LibFilePath = "libgltf.a";
        }
        else if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "ios", "os"));
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "ios", "simulator"));
            LibPaths.Add(System.IO.Path.Combine(glTFPath, "lib", "ios", "watchos"));

            LibFilePath = "libgltf.a";
        }

        PublicIncludePaths.Add(IncludePath);
        PublicLibraryPaths.AddRange(LibPaths);
        PublicAdditionalLibraries.Add(LibFilePath);
    }
}
