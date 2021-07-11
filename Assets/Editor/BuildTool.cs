using System.Linq;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Rendering;

public static class BuildTool
{
	[MenuItem("BuildTool/Build WebGL")]
	public static void BuildWebGL()
	{
		PlayerSettings.colorSpace = ColorSpace.Gamma;
		PlayerSettings.SetUseDefaultGraphicsAPIs(BuildTarget.WebGL, false);
		PlayerSettings.SetGraphicsAPIs(BuildTarget.WebGL, new[] { GraphicsDeviceType.OpenGLES2 });
		PlayerSettings.WebGL.decompressionFallback = true;

		BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
		buildPlayerOptions.scenes = new[] { "Assets/Scenes/Main.unity" };
		buildPlayerOptions.locationPathName = "WebGL";
		buildPlayerOptions.target = BuildTarget.WebGL;
		buildPlayerOptions.options = BuildOptions.None;
		buildPlayerOptions.targetGroup = BuildTargetGroup.WebGL;

		BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
		BuildSummary summary = report.summary;

		if (summary.result == BuildResult.Succeeded)
		{
			Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
		}

		if (summary.result == BuildResult.Failed)
		{
			Debug.Log("Build failed");
		}
	}
}
