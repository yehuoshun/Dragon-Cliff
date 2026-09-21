using System;
using UnityEngine;

// Token: 0x02000311 RID: 785
public class ResidentTownEffectController : MonoBehaviour
{
	// Token: 0x060014FF RID: 5375 RVA: 0x000A9476 File Offset: 0x000A7876
	public ResidentTownEffectController()
	{
	}

	// Token: 0x06001500 RID: 5376 RVA: 0x000A947E File Offset: 0x000A787E
	public void Init(TownEffectBase townEffect)
	{
		this.Image.sprite = FilePath.GetTownEffectIcon(townEffect);
	}

	// Token: 0x0400150F RID: 5391
	public SpriteRenderer Image;
}
