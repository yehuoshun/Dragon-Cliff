using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000B4F RID: 2895
public class LocalizedLabel : MonoBehaviour
{
	// Token: 0x06004D07 RID: 19719 RVA: 0x001F32EA File Offset: 0x001F16EA
	public LocalizedLabel()
	{
	}

	// Token: 0x06004D08 RID: 19720 RVA: 0x001F32F2 File Offset: 0x001F16F2
	public void Start()
	{
		this._text = base.GetComponent<Text>();
		this._text.text = this.Type.GetName();
	}

	// Token: 0x04003B29 RID: 15145
	public UIComponentType Type;

	// Token: 0x04003B2A RID: 15146
	private Text _text;
}
