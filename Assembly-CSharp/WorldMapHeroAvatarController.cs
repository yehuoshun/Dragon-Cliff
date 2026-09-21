using System;
using TMPro;
using UnityEngine.EventSystems;

// Token: 0x02000301 RID: 769
public class WorldMapHeroAvatarController : WorldMapDefualtHeroController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001475 RID: 5237 RVA: 0x000A7390 File Offset: 0x000A5790
	public WorldMapHeroAvatarController()
	{
	}

	// Token: 0x06001476 RID: 5238 RVA: 0x000A7398 File Offset: 0x000A5798
	public override void Init(AdventurerProfile profile, int index)
	{
		this.Reset();
		base.Init(profile, index);
		if (profile != null)
		{
			this.LevelText.text = profile.GetLevel().ToLevelText();
		}
	}

	// Token: 0x06001477 RID: 5239 RVA: 0x000A73C4 File Offset: 0x000A57C4
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right && this._profile != null)
		{
			base.GetComponentInParent<ConfigueAdventurerPanelController>().UnpickHero(this._profile);
		}
		if (eventData.button == PointerEventData.InputButton.Left && this._profile != null)
		{
			base.GetComponentInParent<ConfigueAdventurerPanelController>().JumpToHeroPage(this._profile);
		}
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000A7420 File Offset: 0x000A5820
	public override void Reset()
	{
		base.Reset();
		this.LevelText.text = string.Empty;
	}

	// Token: 0x040014A3 RID: 5283
	public TextMeshProUGUI LevelText;
}
