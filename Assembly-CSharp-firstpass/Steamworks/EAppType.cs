using System;

namespace Steamworks
{
	// Token: 0x0200015E RID: 350
	[Flags]
	public enum EAppType
	{
		// Token: 0x04000859 RID: 2137
		k_EAppType_Invalid = 0,
		// Token: 0x0400085A RID: 2138
		k_EAppType_Game = 1,
		// Token: 0x0400085B RID: 2139
		k_EAppType_Application = 2,
		// Token: 0x0400085C RID: 2140
		k_EAppType_Tool = 4,
		// Token: 0x0400085D RID: 2141
		k_EAppType_Demo = 8,
		// Token: 0x0400085E RID: 2142
		k_EAppType_Media_DEPRECATED = 16,
		// Token: 0x0400085F RID: 2143
		k_EAppType_DLC = 32,
		// Token: 0x04000860 RID: 2144
		k_EAppType_Guide = 64,
		// Token: 0x04000861 RID: 2145
		k_EAppType_Driver = 128,
		// Token: 0x04000862 RID: 2146
		k_EAppType_Config = 256,
		// Token: 0x04000863 RID: 2147
		k_EAppType_Hardware = 512,
		// Token: 0x04000864 RID: 2148
		k_EAppType_Franchise = 1024,
		// Token: 0x04000865 RID: 2149
		k_EAppType_Video = 2048,
		// Token: 0x04000866 RID: 2150
		k_EAppType_Plugin = 4096,
		// Token: 0x04000867 RID: 2151
		k_EAppType_Music = 8192,
		// Token: 0x04000868 RID: 2152
		k_EAppType_Series = 16384,
		// Token: 0x04000869 RID: 2153
		k_EAppType_Comic = 32768,
		// Token: 0x0400086A RID: 2154
		k_EAppType_Shortcut = 1073741824,
		// Token: 0x0400086B RID: 2155
		k_EAppType_DepotOnly = -2147483647
	}
}
