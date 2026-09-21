using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200029B RID: 667
public class MuteInBackgroundController : MonoBehaviour
{
	// Token: 0x0600120C RID: 4620 RVA: 0x0009D036 File Offset: 0x0009B436
	public MuteInBackgroundController()
	{
	}

	// Token: 0x0600120D RID: 4621 RVA: 0x0009D03E File Offset: 0x0009B43E
	private void Start()
	{
		this.Toggle.isOn = this.GetAdditionalData(UIAdditionalDataKey.MuteInBackground, false);
	}

	// Token: 0x0600120E RID: 4622 RVA: 0x0009D057 File Offset: 0x0009B457
	public void OnToggleChange()
	{
		GameWorld.instance.PlayerProfile.AdditionalData.AddOrUpdateData(UIAdditionalDataKey.MuteInBackground, this.Toggle.isOn);
	}

	// Token: 0x040012E3 RID: 4835
	public Toggle Toggle;
}
