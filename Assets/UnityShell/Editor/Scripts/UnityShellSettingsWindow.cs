using UnityEngine;
using UnityEditor;

namespace UnityShell
{
	public class UnityShellSettingsWindow : EditorWindow
	{
		private static readonly GUIContent UsingStringLabel = new GUIContent("Using string:", "The string of 'using's that are pre-executed before the entered commands");

		private static readonly GUIContent loadButtonGui = new GUIContent("Load", "Loads the values from the Editor Prefs"),
			saveButtonGui = new GUIContent("Save", "Saves the values to the Editor Prefs"),
			resetButtonGui = new GUIContent("Reset", "Reset the values to the default UnityShell values");

		private const string Title = "UnityShell Settings";

		public static void OpenWindow()
		{
			GetWindow<UnityShellSettingsWindow>(true, UnityShellSettingsWindow.Title);

			// Ensure instance of settings container exists.
			UnityShellSettings.GetOrCreateSingleton();
		}

		private void DrawSettings(UnityShellSettings settings)
		{
			settings.UsingStringValue = EditorGUILayout.TextField(UsingStringLabel, settings.UsingStringValue);
		}

		private void OnGUI()
		{
			var settings = UnityShellSettings.Instance;
			if (settings == null)
			{
				Debug.LogError("UnityShellSettings.Instance is null.");
				return;
			}

			GUI.DrawTexture(new Rect(0, 0, maxSize.x, maxSize.y), UnityShellWindowStyles.backgroundTexture, ScaleMode.StretchToFill);

			EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
			{
				if (GUILayout.Button(loadButtonGui, EditorStyles.toolbarButton))
				{
					settings.LoadValues();
				}
				if (GUILayout.Button(resetButtonGui, EditorStyles.toolbarButton))
				{
					settings.ResetToDefaultValues();
				}
				GUILayout.FlexibleSpace();
				if (GUILayout.Button(saveButtonGui, EditorStyles.toolbarButton))
				{
					settings.SaveValues();
				}
			}
			EditorGUILayout.EndHorizontal();

			EditorGUI.BeginChangeCheck();
			{
				DrawSettings(settings);
			}
			if (EditorGUI.EndChangeCheck())
			{
				settings.SaveValues();
			}
		}
	}
}
