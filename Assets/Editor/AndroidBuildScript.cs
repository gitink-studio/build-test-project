using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class AndroidBuildScript
{
    [MenuItem("Build/Build Android")]
    public static void BuildAndroid()
    {
        // Define build path
        string buildPath = "Builds/Android/MyGame.apk";

        // Define build options
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Scenes/SampleScene.unity" }, // Add your scene paths here
            locationPathName = buildPath,
            target = BuildTarget.Android,
            options = BuildOptions.None // Use BuildOptions.Development for debug builds
        };

        // Set Android-specific settings
        //PlayerSettings.Android.keystorePass = "your-keystore-password";
        //PlayerSettings.Android.keyaliasPass = "your-alias-password";

        // Set scripting backend (IL2CPP or Mono)
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);

        // Set target architecture (ARMv7, ARM64, etc.)
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64 | AndroidArchitecture.ARMv7;

        // Perform the build
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        // Check for success or failure
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            Debug.Log("[BUILD PATH]" + buildPath);
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.LogError("Build failed");
        }
    }
}
