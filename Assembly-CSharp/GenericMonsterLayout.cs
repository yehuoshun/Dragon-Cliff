using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000345 RID: 837
public class GenericMonsterLayout : MonoBehaviour
{
	// Token: 0x0600166C RID: 5740 RVA: 0x000B0631 File Offset: 0x000AEA31
	public GenericMonsterLayout()
	{
	}

	// Token: 0x0600166D RID: 5741 RVA: 0x000B063C File Offset: 0x000AEA3C
	public void SetupGenericMonsterLayout(UnitClass unitClass)
	{
		List<Sprite> list = NewGenericMonsterLayourImageMapper.MapMonsterImages(unitClass, 3, 1);
		if (list == null || list.Count == 0)
		{
			Debug.Log("Image not found ");
		}
		this.SetupImages(list);
	}

	// Token: 0x0600166E RID: 5742 RVA: 0x000B0674 File Offset: 0x000AEA74
	public void SetupImages(List<Sprite> sprites)
	{
		if (sprites.Count < this.SpritesOnObj.Length)
		{
			Debug.LogError("the given Image length is not sufficient");
			return;
		}
		for (int i = 0; i < this.SpritesOnObj.Length; i++)
		{
			this.SpritesOnObj[i].sprite = sprites[i];
		}
	}

	// Token: 0x0400167E RID: 5758
	public SpriteRenderer[] SpritesOnObj;
}
