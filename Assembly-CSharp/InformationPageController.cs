using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000271 RID: 625
public class InformationPageController : MonoBehaviour
{
	// Token: 0x06001025 RID: 4133 RVA: 0x00097880 File Offset: 0x00095C80
	public InformationPageController()
	{
	}

	// Token: 0x06001026 RID: 4134 RVA: 0x00097888 File Offset: 0x00095C88
	public void Init(string title, string description)
	{
		this.Title.text = title;
		this.Description.text = description;
	}

	// Token: 0x04001167 RID: 4455
	public Text Title;

	// Token: 0x04001168 RID: 4456
	public Text Description;
}
