using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace UnityShell
{
	public static class UnityShellSettings
	{
		public static string UsingString;
		private const string UsingStringKeyname = "UnityShellSettings.UsingString";
		public const string UsingStringDefault = "using UnityEngine; using UnityEditor; using System; using System.Collections.Generic;";
		
		public static void Save()
		{
			EditorPrefs.SetString(UsingStringKeyname, UsingString);
		}

		public static void Load()
		{
			UsingString = EditorPrefs.GetString(UsingStringKeyname, UsingStringDefault);
		}

		public static void Reset()
		{
			UsingString = UsingStringDefault;
		}
	}
}
