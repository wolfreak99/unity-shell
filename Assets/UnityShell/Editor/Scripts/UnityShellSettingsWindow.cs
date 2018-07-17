using UnityEngine;
using UnityEditor;

namespace UnityShell
{
	public class UnityShellSettingsWindow : EditorWindow
	{
		private static readonly GUIContent UsingStringLabel = new GUIContent("Using string:", "The string of 'using's that are pre-executed before the entered commands");

		public static void OpenWindow()
		{
			GetWindow<UnityShellSettingsWindow>(true, "UnityShell Settings");
		}

		private void OnGUI()
		{
			GUI.DrawTexture(new Rect(0, 0, maxSize.x, maxSize.y), UnityShellWindowStyles.backgroundTexture, ScaleMode.StretchToFill);
			EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
			{
				if (GUILayout.Button("Load", EditorStyles.toolbarButton))
				{
					UnityShellSettings.Load();
				}

				if (GUILayout.Button("Reset", EditorStyles.toolbarButton))
				{
					UnityShellSettings.Reset();
				}

				GUILayout.FlexibleSpace();

				if (GUILayout.Button("Save", EditorStyles.toolbarButton))
				{
					UnityShellSettings.Save();
				}
			}
			EditorGUILayout.EndHorizontal();

			EditorGUI.BeginChangeCheck();
			UnityShellSettings.UsingString = EditorGUILayout.TextField(UsingStringLabel, UnityShellSettings.UsingString);
			if (EditorGUI.EndChangeCheck())
			{
				UnityShellSettings.Save();
			}
		}
	}
}
