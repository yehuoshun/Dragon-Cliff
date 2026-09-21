using System;
using UnityEngine;

// Token: 0x0200009C RID: 156
public class TablaSenoCoseno
{
	// Token: 0x060004CA RID: 1226 RVA: 0x00059095 File Offset: 0x00057495
	public TablaSenoCoseno()
	{
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x000590A0 File Offset: 0x000574A0
	public static void initSenCos()
	{
		if (!TablaSenoCoseno.hasInstanced)
		{
			TablaSenoCoseno.SenArray = new float[360];
			TablaSenoCoseno.CosArray = new float[360];
			for (int i = 0; i < 360; i++)
			{
				TablaSenoCoseno.SenArray[i] = Mathf.Sin((float)i * 0.0174532924f);
				TablaSenoCoseno.CosArray[i] = Mathf.Cos((float)i * 0.0174532924f);
			}
			TablaSenoCoseno.hasInstanced = true;
		}
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x00059119 File Offset: 0x00057519
	// Note: this type is marked as 'beforefieldinit'.
	static TablaSenoCoseno()
	{
	}

	// Token: 0x0400083B RID: 2107
	private static bool hasInstanced;

	// Token: 0x0400083C RID: 2108
	public static float[] SenArray;

	// Token: 0x0400083D RID: 2109
	public static float[] CosArray;
}
