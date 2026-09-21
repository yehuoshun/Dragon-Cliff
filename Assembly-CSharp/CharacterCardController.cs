using System;
using TMPro;
using UnityEngine.UI;

// Token: 0x02000116 RID: 278
public class CharacterCardController : PageHeroController
{
	// Token: 0x06000794 RID: 1940 RVA: 0x00071BA6 File Offset: 0x0006FFA6
	public CharacterCardController()
	{
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x00071BB0 File Offset: 0x0006FFB0
	public override void Init(PageElement item)
	{
		base.Init(item);
		base.PageHero = (PageHero)item;
		this.NameText.text = base.PageHero.AdventurerProfile.GetUnitName();
		this.AvatarImage.sprite = FilePath.GetAdventuererAvatarSprite(base.PageHero.AdventurerProfile.UnitClass);
		this.GradeFrame.sprite = FilePath.GetAdventurerGradeBackground(base.PageHero.AdventurerProfile.Grade, base.PageHero.AdventurerProfile.IsStar());
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x00071C3C File Offset: 0x0007003C
	private void UpdateLevelText()
	{
		if (this.LevelText != null)
		{
			this.LevelText.text = base.PageHero.AdventurerProfile.GetLevel().ToLevelText();
		}
		this._lastLevel = base.PageHero.AdventurerProfile.GetLevel();
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x00071C90 File Offset: 0x00070090
	private void Update()
	{
		if (this._lastLevel != base.PageHero.AdventurerProfile.GetLevel())
		{
			this.UpdateLevelText();
		}
	}

	// Token: 0x04000A77 RID: 2679
	public Image AvatarImage;

	// Token: 0x04000A78 RID: 2680
	public Image GradeFrame;

	// Token: 0x04000A79 RID: 2681
	public TextMeshProUGUI NameText;

	// Token: 0x04000A7A RID: 2682
	public TextMeshProUGUI LevelText;

	// Token: 0x04000A7B RID: 2683
	private int _lastLevel;
}
