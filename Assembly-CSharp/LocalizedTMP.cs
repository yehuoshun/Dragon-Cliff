using System;
using TMPro;
using UnityEngine;

// Token: 0x02000B50 RID: 2896
public class LocalizedTMP : MonoBehaviour
{
	// Token: 0x06004D09 RID: 19721 RVA: 0x001F3316 File Offset: 0x001F1716
	public LocalizedTMP()
	{
	}

	// Token: 0x06004D0A RID: 19722 RVA: 0x001F3320 File Offset: 0x001F1720
	private void Start()
	{
		TextMeshProUGUI component = base.GetComponent<TextMeshProUGUI>();
		if (component != null)
		{
			base.GetComponent<TextMeshProUGUI>().text = this.Type.GetName();
		}
	}

	// Token: 0x04003B2B RID: 15147
	public UIComponentType Type;
}
