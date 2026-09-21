using System;
using UnityEngine;

// Token: 0x02000A1E RID: 2590
public static class ResourceImage
{
	// Token: 0x060046A8 RID: 18088 RVA: 0x001CF28D File Offset: 0x001CD68D
	public static Sprite getChar()
	{
		return Resources.LoadAll<Sprite>(ResourceImage.CharacterImagePath)[1];
	}

	// Token: 0x060046A9 RID: 18089 RVA: 0x001CF29B File Offset: 0x001CD69B
	public static string GetImage(ResourceType type)
	{
		if (type != ResourceType.IronSword)
		{
			throw new Exception("Image has not been assigned to ResourceCategory: " + type + ".");
		}
		return ResourceImage.MainPath + "icon_42";
	}

	// Token: 0x060046AA RID: 18090 RVA: 0x001CF2D7 File Offset: 0x001CD6D7
	// Note: this type is marked as 'beforefieldinit'.
	static ResourceImage()
	{
	}

	// Token: 0x040035CB RID: 13771
	public static readonly string MainPath = "Images/Pack 1B/";

	// Token: 0x040035CC RID: 13772
	public static readonly string CharacterImagePath = "Images/Characters/chara2";
}
