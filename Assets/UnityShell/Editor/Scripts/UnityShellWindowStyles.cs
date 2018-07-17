using UnityEditor;
using UnityEngine;

namespace UnityShell
{
	public static class UnityShellWindowStyles
	{
		public static readonly GUIStyle textAreaStyle;

		// Default background Color(0.76f, 0.76f, 0.76f)
		private static readonly Color bgColorLightSkin = new Color(0.87f, 0.87f, 0.87f);
		// Default background Color(0.22f, 0.22f, 0.22f)
		private static readonly Color bgColorDarkSkin = new Color(0.2f, 0.2f, 0.2f);
		// Default text Color(0.0f, 0.0f, 0.0f)
		private static readonly Color textColorLightSkin = new Color(0.0f, 0.0f, 0.0f);
		// Default text Color(0.706f, 0.706f, 0.706f)
		private static readonly Color textColorDarkSkin = new Color(0.706f, 0.706f, 0.706f);

		private static Texture2D _backgroundTexture;
		public static Texture2D backgroundTexture
		{
			get
			{
				if (_backgroundTexture == null)
				{
					_backgroundTexture = new Texture2D(1, 1, TextureFormat.RGBA32, false, true);
					_backgroundTexture.SetPixel(0, 0, EditorGUIUtility.isProSkin ? bgColorDarkSkin : bgColorLightSkin);
					_backgroundTexture.Apply();
				}
				return _backgroundTexture;
			}
		}

		static UnityShellWindowStyles()
		{
			textAreaStyle = new GUIStyle(EditorStyles.textArea);
			textAreaStyle.padding = new RectOffset();

			var style = textAreaStyle.focused;
			style.background = backgroundTexture;
			style.textColor = EditorGUIUtility.isProSkin ? textColorDarkSkin : textColorLightSkin;

			textAreaStyle.focused = style;
			textAreaStyle.active = style;
			textAreaStyle.onActive = style;
			textAreaStyle.hover = style;
			textAreaStyle.normal = style;
			textAreaStyle.onNormal = style;
		}

	}

}