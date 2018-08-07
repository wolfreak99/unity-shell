using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityShell
{
	[System.Serializable]
	public class UnityShellSettings : ScriptableObject
	{
		[SerializeField]
		static public UnityShellSettings Instance;

		[Tooltip("These are passed into the compiler before running"),
		 Header("UsingString"), 
		 SerializeField]
		public string UsingStringValue;
		public const string UsingStringDefaultValue = "using UnityEngine; using UnityEditor; using System; using System.Collections.Generic;";
		public string UsingStringKeyname = "UnityShellSettings.UsingString";

		internal void LoadValues()
		{

		}

		internal void ResetToDefaultValues()
		{
			UsingStringValue = UsingStringDefaultValue;
		}

		internal void SaveValues()
		{

		}

		// This should be the only code to create an instance if it doesn't exist.
		// Isolating it to here will help with loading and saving
		static public UnityShellSettings GetOrCreateSingleton()
		{
			if (UnityShellSettings.Instance == null)
			{
				UnityShellSettings.Instance = ScriptableObject.CreateInstance<UnityShellSettings>();
				// This may not be needed. I don't know.
				EditorUtility.SetDirty(UnityShellSettings.Instance);
			}

			return UnityShellSettings.Instance;
		}
	}
}
