using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002D9 RID: 729
public class TooltipIconController : MonoBehaviour
{
	// Token: 0x06001365 RID: 4965 RVA: 0x000A311A File Offset: 0x000A151A
	public TooltipIconController()
	{
	}

	// Token: 0x06001366 RID: 4966 RVA: 0x000A3124 File Offset: 0x000A1524
	public void Init(Sprite sprite, Sprite childSprite)
	{
		if (childSprite != null)
		{
			this.ChildImage.sprite = childSprite;
			this.ChildImage.gameObject.SetActive(true);
		}
		else
		{
			this.ChildImage.gameObject.SetActive(false);
		}
		this.Image.sprite = sprite;
	}

	// Token: 0x040013F8 RID: 5112
	public Image Image;

	// Token: 0x040013F9 RID: 5113
	public Image ChildImage;
}
