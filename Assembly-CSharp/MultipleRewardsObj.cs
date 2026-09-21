using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000333 RID: 819
public class MultipleRewardsObj : MonoBehaviour
{
	// Token: 0x060015C5 RID: 5573 RVA: 0x000ACB8B File Offset: 0x000AAF8B
	public MultipleRewardsObj()
	{
	}

	// Token: 0x060015C6 RID: 5574 RVA: 0x000ACB93 File Offset: 0x000AAF93
	private void Start()
	{
		if (this.Texts.Length != this.Images.Length)
		{
			Debug.LogError("MultipleRewardsObj");
		}
	}

	// Token: 0x060015C7 RID: 5575 RVA: 0x000ACBB4 File Offset: 0x000AAFB4
	private void SetTextAndImageStatus(Text text, Image image, bool active)
	{
		text.gameObject.SetActive(active);
		image.gameObject.SetActive(active);
	}

	// Token: 0x040015E4 RID: 5604
	public Text[] Texts;

	// Token: 0x040015E5 RID: 5605
	public Image[] Images;
}
