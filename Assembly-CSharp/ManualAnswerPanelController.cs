using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000209 RID: 521
public class ManualAnswerPanelController : MonoBehaviour
{
	// Token: 0x06000DD1 RID: 3537 RVA: 0x0008FE9D File Offset: 0x0008E29D
	public ManualAnswerPanelController()
	{
	}

	// Token: 0x06000DD2 RID: 3538 RVA: 0x0008FEA5 File Offset: 0x0008E2A5
	private void Start()
	{
		this.TitleText.text = string.Empty;
		this.DescriptionText.text = string.Empty;
	}

	// Token: 0x06000DD3 RID: 3539 RVA: 0x0008FEC8 File Offset: 0x0008E2C8
	public void Init(ManualType type)
	{
		Description description = type.GetDescription();
		this.TitleText.text = description.Title;
		this.DescriptionText.text = description.Details1.Replace("\n", "<size=7>\n</size>");
		this.ScrollRect.verticalNormalizedPosition = 1f;
	}

	// Token: 0x04000FC1 RID: 4033
	public TextMeshProUGUI TitleText;

	// Token: 0x04000FC2 RID: 4034
	public TextMeshProUGUI DescriptionText;

	// Token: 0x04000FC3 RID: 4035
	public ScrollRect ScrollRect;
}
