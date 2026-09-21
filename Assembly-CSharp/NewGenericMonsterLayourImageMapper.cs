using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000346 RID: 838
public static class NewGenericMonsterLayourImageMapper
{
	// Token: 0x0600166F RID: 5743 RVA: 0x000B06CC File Offset: 0x000AEACC
	public static List<Sprite> MapMonsterImages(UnitClass unitclass, int ImagePerRow = 3, int loadrowFacingLeft = 1)
	{
		GameObject x = Resources.Load("Prefabs/ThreeImagesMonsterObj") as GameObject;
		if (x == null)
		{
			return null;
		}
		List<Sprite> list = new List<Sprite>();
		Sprite[] array = new Sprite[3];
		if (unitclass != UnitClass.YellowBat)
		{
			Debug.LogError("this unit class " + unitclass + "  is not supported ");
		}
		else
		{
			array = Resources.LoadAll<Sprite>("Images/Monsters/NewPack/angel_a_trans_Yellow");
		}
		int num = ImagePerRow * loadrowFacingLeft;
		for (int i = 0; i < 3; i++)
		{
			list.Add(array[num + i]);
		}
		return list;
	}

	// Token: 0x0400167F RID: 5759
	private const int _loadrowFacingLeft = 1;

	// Token: 0x04001680 RID: 5760
	private const int _imagePerRow = 3;

	// Token: 0x04001681 RID: 5761
	private const string MonsterImagePath = "Images/Monsters/NewPack/";

	// Token: 0x04001682 RID: 5762
	private const string ThreeImageMonsterObjPath = "Prefabs/ThreeImagesMonsterObj";

	// Token: 0x04001683 RID: 5763
	private const string OriginalColorAnglePath = "Images/Monsters/NewPack/angel_a_trans_Yellow";

	// Token: 0x04001684 RID: 5764
	private const string BlueColorAnglePath = "Images/Monsters/NewPack/angel_b_trans_blue";
}
