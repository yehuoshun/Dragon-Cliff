using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002FC RID: 764
public class WorldMapAdventuererController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001420 RID: 5152 RVA: 0x000A5672 File Offset: 0x000A3A72
	public WorldMapAdventuererController()
	{
	}

	// Token: 0x06001421 RID: 5153 RVA: 0x000A567C File Offset: 0x000A3A7C
	public void Init(AdventurerProfile adventurer, int index)
	{
		this._index = index;
		this._adventuerer = adventurer;
		this.HeroImage.sprite = FilePath.GetAdventuererAvatarSprite(adventurer.UnitClass);
		this.HeroGrade.sprite = FilePath.GetAdventurerGradeBackground(adventurer.Grade, adventurer.IsStar());
		this.HeroName.text = adventurer.GetUnitName();
		this.HeroLevel.text = adventurer.GetLevel().ToLevelText();
	}

	// Token: 0x06001422 RID: 5154 RVA: 0x000A56F0 File Offset: 0x000A3AF0
	private void Update()
	{
		this.HeroLevel.text = this._adventuerer.GetLevel().ToLevelText();
	}

	// Token: 0x06001423 RID: 5155 RVA: 0x000A570D File Offset: 0x000A3B0D
	public void OnPointerClick(PointerEventData eventData)
	{
	}

	// Token: 0x06001424 RID: 5156 RVA: 0x000A570F File Offset: 0x000A3B0F
	public void RemoveHero()
	{
		base.GetComponentInParent<WorldMapController>().RemoveAdventurer(this._adventuerer);
	}

	// Token: 0x04001464 RID: 5220
	public Image HeroImage;

	// Token: 0x04001465 RID: 5221
	public Image HeroGrade;

	// Token: 0x04001466 RID: 5222
	public TextMeshProUGUI HeroName;

	// Token: 0x04001467 RID: 5223
	public TextMeshProUGUI HeroLevel;

	// Token: 0x04001468 RID: 5224
	private AdventurerProfile _adventuerer;

	// Token: 0x04001469 RID: 5225
	private int _index;
}
