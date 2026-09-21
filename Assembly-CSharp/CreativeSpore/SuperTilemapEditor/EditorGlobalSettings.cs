using System;
using UnityEngine;

namespace CreativeSpore.SuperTilemapEditor
{
	// Token: 0x02000B8E RID: 2958
	public static class EditorGlobalSettings
	{
		// Token: 0x06004E3E RID: 20030 RVA: 0x001FE4E6 File Offset: 0x001FC8E6
		public static int Color32ToInt(Color32 color)
		{
			return (int)color.r << 24 | (int)color.g << 16 | (int)color.b << 8 | (int)color.a;
		}

		// Token: 0x06004E3F RID: 20031 RVA: 0x001FE50F File Offset: 0x001FC90F
		public static Color32 IntToColor32(int value)
		{
			return new Color32((byte)(value >> 24 & 255), (byte)(value >> 16 & 255), (byte)(value >> 8 & 255), (byte)(value & 255));
		}

		// Token: 0x1700109B RID: 4251
		// (get) Token: 0x06004E40 RID: 20032 RVA: 0x001FE53E File Offset: 0x001FC93E
		// (set) Token: 0x06004E41 RID: 20033 RVA: 0x001FE56A File Offset: 0x001FC96A
		public static Color TilemapColliderColor
		{
			get
			{
				return EditorGlobalSettings.IntToColor32(PlayerPrefs.GetInt("STE_TilemapColliderColor", EditorGlobalSettings.Color32ToInt(new Color32(0, byte.MaxValue, 0, 160))));
			}
			set
			{
				PlayerPrefs.SetInt("STE_TilemapColliderColor", EditorGlobalSettings.Color32ToInt(value));
			}
		}

		// Token: 0x1700109C RID: 4252
		// (get) Token: 0x06004E42 RID: 20034 RVA: 0x001FE581 File Offset: 0x001FC981
		// (set) Token: 0x06004E43 RID: 20035 RVA: 0x001FE5B2 File Offset: 0x001FC9B2
		public static Color TilemapGridColor
		{
			get
			{
				return EditorGlobalSettings.IntToColor32(PlayerPrefs.GetInt("STE_TilemapGridColor", EditorGlobalSettings.Color32ToInt(new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 60))));
			}
			set
			{
				PlayerPrefs.SetInt("STE_TilemapGridColor", EditorGlobalSettings.Color32ToInt(value));
			}
		}
	}
}
