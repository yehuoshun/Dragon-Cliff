using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000112 RID: 274
public class AdventurerAppearanceController : MonoBehaviour
{
	// Token: 0x06000781 RID: 1921 RVA: 0x0007182F File Offset: 0x0006FC2F
	public AdventurerAppearanceController()
	{
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x00071837 File Offset: 0x0006FC37
	public void InitAppearance(AdventurerProfile adventurer)
	{
		this.UpdateBasicSprites(FilePath.GetCharacterBasicAppearance(adventurer.UnitClass, false));
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x0007184C File Offset: 0x0006FC4C
	private void UpdateBasicSprites(CharacterBasicAppearance appearance)
	{
		Sprite[] array = Resources.LoadAll<Sprite>(FilePath.CharacterImagePath + appearance.Path);
		this.SouthLeft.sprite = array[appearance.SouthLeft];
		this.SouthMiddle.sprite = array[appearance.SouthMiddle];
		this.SouthRight.sprite = array[appearance.SouthRight];
		this.WestLeft.sprite = array[appearance.WestLeft];
		this.WestMiddle.sprite = array[appearance.WestMiddle];
		this.WestRight.sprite = array[appearance.WestRight];
		this.EastLeft.sprite = array[appearance.EastLeft];
		this.EastMiddle.sprite = array[appearance.EastMiddle];
		this.EastRight.sprite = array[appearance.EastRight];
		this.NorthLeft.sprite = array[appearance.NorthLeft];
		this.NorthMiddle.sprite = array[appearance.NorthMiddle];
		this.NorthRight.sprite = array[appearance.NorthRight];
	}

	// Token: 0x04000A55 RID: 2645
	public Image SouthLeft;

	// Token: 0x04000A56 RID: 2646
	public Image SouthMiddle;

	// Token: 0x04000A57 RID: 2647
	public Image SouthRight;

	// Token: 0x04000A58 RID: 2648
	public Image WestLeft;

	// Token: 0x04000A59 RID: 2649
	public Image WestMiddle;

	// Token: 0x04000A5A RID: 2650
	public Image WestRight;

	// Token: 0x04000A5B RID: 2651
	public Image EastLeft;

	// Token: 0x04000A5C RID: 2652
	public Image EastMiddle;

	// Token: 0x04000A5D RID: 2653
	public Image EastRight;

	// Token: 0x04000A5E RID: 2654
	public Image NorthLeft;

	// Token: 0x04000A5F RID: 2655
	public Image NorthMiddle;

	// Token: 0x04000A60 RID: 2656
	public Image NorthRight;

	// Token: 0x04000A61 RID: 2657
	public Image Nod1;

	// Token: 0x04000A62 RID: 2658
	public Image Nod2;

	// Token: 0x04000A63 RID: 2659
	public Image Nod3;

	// Token: 0x04000A64 RID: 2660
	public Image Shake1;

	// Token: 0x04000A65 RID: 2661
	public Image Shake2;

	// Token: 0x04000A66 RID: 2662
	public Image Shake3;

	// Token: 0x04000A67 RID: 2663
	public Image Laugh1;

	// Token: 0x04000A68 RID: 2664
	public Image Laugh2;

	// Token: 0x04000A69 RID: 2665
	public Image Laugh3;

	// Token: 0x04000A6A RID: 2666
	public Image Shock1;

	// Token: 0x04000A6B RID: 2667
	public Image Shock2;

	// Token: 0x04000A6C RID: 2668
	public Image Shock3;
}
