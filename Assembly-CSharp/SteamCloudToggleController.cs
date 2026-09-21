using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200029F RID: 671
public class SteamCloudToggleController : MonoBehaviour
{
	// Token: 0x0600121F RID: 4639 RVA: 0x0009D316 File Offset: 0x0009B716
	public SteamCloudToggleController()
	{
	}

	// Token: 0x06001220 RID: 4640 RVA: 0x0009D31E File Offset: 0x0009B71E
	private void Start()
	{
		this.Toggle.isOn = (PlayerPrefs.GetInt(UIAdditionalDataKey.SteamCloud) == 1);
	}

	// Token: 0x06001221 RID: 4641 RVA: 0x0009D338 File Offset: 0x0009B738
	public void OnToggleChange()
	{
		PlayerPrefs.SetInt(UIAdditionalDataKey.SteamCloud, (!this.Toggle.isOn) ? 0 : 1);
	}

	// Token: 0x040012F1 RID: 4849
	public Toggle Toggle;
}
