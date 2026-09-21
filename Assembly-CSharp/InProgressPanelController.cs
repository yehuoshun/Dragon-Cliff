using System;
using TMPro;
using UnityEngine;

// Token: 0x0200026E RID: 622
public class InProgressPanelController : MonoBehaviour
{
	// Token: 0x06001015 RID: 4117 RVA: 0x0009737E File Offset: 0x0009577E
	public InProgressPanelController()
	{
	}

	// Token: 0x06001016 RID: 4118 RVA: 0x00097386 File Offset: 0x00095786
	public void Init(string text)
	{
		this.ProgressText.text = text;
	}

	// Token: 0x04001153 RID: 4435
	public TextMeshProUGUI ProgressText;
}
