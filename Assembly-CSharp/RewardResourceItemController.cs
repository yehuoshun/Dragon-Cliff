using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200015B RID: 347
public class RewardResourceItemController : MonoBehaviour
{
	// Token: 0x06000953 RID: 2387 RVA: 0x0007A76C File Offset: 0x00078B6C
	public RewardResourceItemController()
	{
	}

	// Token: 0x06000954 RID: 2388 RVA: 0x0007A774 File Offset: 0x00078B74
	public void Init(ResourceUpdate resource)
	{
		this.Icon.sprite = FilePath.GetRecipeImage(resource.ResourceType);
		this.AmountText.text = resource.ChangeAmount.DoubleToString();
	}

	// Token: 0x04000C01 RID: 3073
	public Image Icon;

	// Token: 0x04000C02 RID: 3074
	public TextMeshProUGUI AmountText;
}
