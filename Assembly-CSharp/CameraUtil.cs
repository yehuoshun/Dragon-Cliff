using System;
using UnityEngine;

// Token: 0x02000365 RID: 869
public class CameraUtil : MonoBehaviour
{
	// Token: 0x06001776 RID: 6006 RVA: 0x000B6254 File Offset: 0x000B4654
	public CameraUtil()
	{
	}

	// Token: 0x06001777 RID: 6007 RVA: 0x000B6271 File Offset: 0x000B4671
	private void Awake()
	{
		if (this.MyBattleCamera.orthographic)
		{
			CameraUtil.scale = (float)Screen.height / this.nativeResolution.y;
			CameraUtil.pixelsToUnit *= CameraUtil.scale;
		}
	}

	// Token: 0x06001778 RID: 6008 RVA: 0x000B62AA File Offset: 0x000B46AA
	// Note: this type is marked as 'beforefieldinit'.
	static CameraUtil()
	{
	}

	// Token: 0x04001765 RID: 5989
	public static float pixelsToUnit = 3f;

	// Token: 0x04001766 RID: 5990
	public static float scale = 1f;

	// Token: 0x04001767 RID: 5991
	public Camera MyBattleCamera;

	// Token: 0x04001768 RID: 5992
	public Vector2 nativeResolution = new Vector2(800f, 450f);
}
