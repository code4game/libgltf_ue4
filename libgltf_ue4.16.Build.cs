// Copyright (o) 2016-2018 Code 4 Game <develop@c4g.io>

using UnrealBuildTool;

public class libdraco_ue4 : ModuleRules
{
    public libdraco_ue4(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;

        string DracoPath = System.IO.Path.Combine(ModuleDirectory, "libdraco-1.2.5");
        string IncludePath = System.IO.Path.Combine(DracoPath, "include");
        string LibPath = "";

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

            string VSName = "vs" + WindowsPlatform.GetVisualStudioCompilerVersionName();

            LibPath = System.IO.Path.Combine(DracoPath, "lib", PlatformName, VSName);

            PublicAdditionalLibraries.Add("dracodec.lib");
            PublicAdditionalLibraries.Add("dracoenc.lib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            LibPath = System.IO.Path.Combine(DracoPath, "lib", "linux");

            PublicAdditionalLibraries.Add("libdracodec.a");
            PublicAdditionalLibraries.Add("libdracoenc.a");
        }
        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            LibPath = System.IO.Path.Combine(DracoPath, "lib", "macos");

            PublicAdditionalLibraries.Add("libdracodec.a");
            PublicAdditionalLibraries.Add("libdracoenc.a");
        }
        else if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            LibPath = System.IO.Path.Combine(DracoPath, "lib", "ios");

            PublicAdditionalLibraries.Add("libdracodec.a");
            PublicAdditionalLibraries.Add("libdracoenc.a");
        }

        PublicIncludePaths.Add(IncludePath);
        PublicLibraryPaths.Add(LibPath);
    }
}
