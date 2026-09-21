using System;
using TMPro;
using UnityEngine;

// Token: 0x020001DC RID: 476
public class TitleInputController : MonoBehaviour
{
	// Token: 0x06000CC5 RID: 3269 RVA: 0x0008BD09 File Offset: 0x0008A109
	public TitleInputController()
	{
	}

	// Token: 0x06000CC6 RID: 3270 RVA: 0x0008BD11 File Offset: 0x0008A111
	public void Init(AdventurerProfile unit)
	{
		this.InputField.text = unit.GetUnitName();
	}

	// Token: 0x06000CC7 RID: 3271 RVA: 0x0008BD24 File Offset: 0x0008A124
	public void SetName()
	{
		HeroMenuController componentInParent = base.GetComponentInParent<HeroMenuController>();
		if (componentInParent != null)
		{
			componentInParent.SetHeroName(this.InputField.text);
		}
	}

	// Token: 0x04000EE7 RID: 3815
	public TMP_InputField InputField;
}
