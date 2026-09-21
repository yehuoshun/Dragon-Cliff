using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000322 RID: 802
public class AdventurerWithCanvasObj : MonoBehaviour
{
	// Token: 0x06001558 RID: 5464 RVA: 0x000AA76A File Offset: 0x000A8B6A
	public AdventurerWithCanvasObj()
	{
	}

	// Token: 0x17000114 RID: 276
	// (get) Token: 0x06001559 RID: 5465 RVA: 0x000AA772 File Offset: 0x000A8B72
	// (set) Token: 0x0600155A RID: 5466 RVA: 0x000AA77A File Offset: 0x000A8B7A
	public AdventurerProfile Adventurer
	{
		[CompilerGenerated]
		get
		{
			return this.<Adventurer>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Adventurer>k__BackingField = value;
		}
	}

	// Token: 0x0600155B RID: 5467 RVA: 0x000AA783 File Offset: 0x000A8B83
	public void Init(AdventurerProfile adventurer)
	{
		this.Adventurer = adventurer;
		this.InitAppearance();
	}

	// Token: 0x0600155C RID: 5468 RVA: 0x000AA792 File Offset: 0x000A8B92
	public void InitAppearance()
	{
		this.UpdateBasicSprites(FilePath.GetCharacterBasicAppearance(this.Adventurer.UnitClass, false));
	}

	// Token: 0x0600155D RID: 5469 RVA: 0x000AA7AC File Offset: 0x000A8BAC
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

	// Token: 0x0600155E RID: 5470 RVA: 0x000AA8B4 File Offset: 0x000A8CB4
	private void UpdateEmoteSprites(CharacterEmoteAppearance appearance)
	{
		Sprite[] array = Resources.LoadAll<Sprite>(FilePath.CharacterImagePath + appearance.Path);
		this.Nod1.sprite = array[appearance.Nod1];
		this.Nod2.sprite = array[appearance.Nod2];
		this.Nod3.sprite = array[appearance.Nod3];
		this.Shake1.sprite = array[appearance.Shake1];
		this.Shake2.sprite = array[appearance.Shake2];
		this.Shake3.sprite = array[appearance.Shake3];
		this.Laugh1.sprite = array[appearance.Laugh1];
		this.Laugh2.sprite = array[appearance.Laugh2];
		this.Laugh3.sprite = array[appearance.Laugh3];
		this.Shock1.sprite = array[appearance.Shock1];
		this.Shock2.sprite = array[appearance.Shock2];
		this.Shock3.sprite = array[appearance.Shock3];
	}

	// Token: 0x04001567 RID: 5479
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AdventurerProfile <Adventurer>k__BackingField;

	// Token: 0x04001568 RID: 5480
	public Image SouthLeft;

	// Token: 0x04001569 RID: 5481
	public Image SouthMiddle;

	// Token: 0x0400156A RID: 5482
	public Image SouthRight;

	// Token: 0x0400156B RID: 5483
	public Image WestLeft;

	// Token: 0x0400156C RID: 5484
	public Image WestMiddle;

	// Token: 0x0400156D RID: 5485
	public Image WestRight;

	// Token: 0x0400156E RID: 5486
	public Image EastLeft;

	// Token: 0x0400156F RID: 5487
	public Image EastMiddle;

	// Token: 0x04001570 RID: 5488
	public Image EastRight;

	// Token: 0x04001571 RID: 5489
	public Image NorthLeft;

	// Token: 0x04001572 RID: 5490
	public Image NorthMiddle;

	// Token: 0x04001573 RID: 5491
	public Image NorthRight;

	// Token: 0x04001574 RID: 5492
	public Image Nod1;

	// Token: 0x04001575 RID: 5493
	public Image Nod2;

	// Token: 0x04001576 RID: 5494
	public Image Nod3;

	// Token: 0x04001577 RID: 5495
	public Image Shake1;

	// Token: 0x04001578 RID: 5496
	public Image Shake2;

	// Token: 0x04001579 RID: 5497
	public Image Shake3;

	// Token: 0x0400157A RID: 5498
	public Image Laugh1;

	// Token: 0x0400157B RID: 5499
	public Image Laugh2;

	// Token: 0x0400157C RID: 5500
	public Image Laugh3;

	// Token: 0x0400157D RID: 5501
	public Image Shock1;

	// Token: 0x0400157E RID: 5502
	public Image Shock2;

	// Token: 0x0400157F RID: 5503
	public Image Shock3;
}
