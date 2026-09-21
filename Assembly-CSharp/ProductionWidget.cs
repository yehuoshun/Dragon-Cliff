using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000FD RID: 253
public class ProductionWidget : MonoBehaviour
{
	// Token: 0x06000704 RID: 1796 RVA: 0x0006AFC1 File Offset: 0x000693C1
	public ProductionWidget()
	{
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x0006AFC9 File Offset: 0x000693C9
	public void UpdateProgress(double progress)
	{
		this.ProgressBar.fillAmount = (float)(progress / 1.0);
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x0006AFE2 File Offset: 0x000693E2
	public void UpdateItemImage(ResourceType resource)
	{
		this.ItemImage.color = Color.white;
		this.ItemImage.sprite = FilePath.GetRecipeImage(resource);
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x0006B005 File Offset: 0x00069405
	public void ClearWidget()
	{
		this.ProgressBar.fillAmount = 0f;
		this.ItemImage.color = ColorPicker.Transparent;
	}

	// Token: 0x04000A01 RID: 2561
	public Image ProgressBar;

	// Token: 0x04000A02 RID: 2562
	public Image ItemImage;
}
