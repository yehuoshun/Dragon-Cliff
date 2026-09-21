using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002BF RID: 703
public class DecomposeItemController : MonoBehaviour
{
	// Token: 0x060012D0 RID: 4816 RVA: 0x000A01BF File Offset: 0x0009E5BF
	public DecomposeItemController()
	{
	}

	// Token: 0x060012D1 RID: 4817 RVA: 0x000A01C7 File Offset: 0x0009E5C7
	public void Init(ResourceType resource, int amount)
	{
		this.ResourceImage.sprite = FilePath.GetRecipeImage(resource);
		this.Amount.text = "X " + amount;
	}

	// Token: 0x0400137A RID: 4986
	public Image ResourceImage;

	// Token: 0x0400137B RID: 4987
	public TextMeshProUGUI Amount;
}
