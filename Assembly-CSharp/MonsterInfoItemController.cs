using System;
using TMPro;
using UnityEngine;

// Token: 0x02000158 RID: 344
public class MonsterInfoItemController : MonoBehaviour
{
	// Token: 0x0600094A RID: 2378 RVA: 0x0007A5BE File Offset: 0x000789BE
	public MonsterInfoItemController()
	{
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x0007A5C8 File Offset: 0x000789C8
	public void Init(ISpecialEffectDataLoad specialEffect)
	{
		Description description = specialEffect.GetDescription();
		this.Title.text = description.Title;
		this.Description.text = description.Details1;
	}

	// Token: 0x04000BFA RID: 3066
	public TextMeshProUGUI Title;

	// Token: 0x04000BFB RID: 3067
	public TextMeshProUGUI Description;
}
