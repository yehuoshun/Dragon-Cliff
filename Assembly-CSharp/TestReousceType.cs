using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003AA RID: 938
public class TestReousceType : MonoBehaviour
{
	// Token: 0x060018F9 RID: 6393 RVA: 0x000BFC14 File Offset: 0x000BE014
	public TestReousceType()
	{
	}

	// Token: 0x060018FA RID: 6394 RVA: 0x000BFC1C File Offset: 0x000BE01C
	public void SetReourceType(ResourceType type)
	{
		this.Text.text = type.GetDescription().Title + string.Empty;
		this.Image.sprite = FilePath.GetRecipeImage(type);
	}

	// Token: 0x040018C5 RID: 6341
	public Text Text;

	// Token: 0x040018C6 RID: 6342
	public Image Image;
}
