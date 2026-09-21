using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000302 RID: 770
public class WorldMapHeroController : CharacterCardController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001479 RID: 5241 RVA: 0x000A7438 File Offset: 0x000A5838
	public WorldMapHeroController()
	{
	}

	// Token: 0x0600147A RID: 5242 RVA: 0x000A7440 File Offset: 0x000A5840
	private void Start()
	{
		this._parentPanel = base.GetComponentInParent<ConfigueAdventurerPanelController>();
	}

	// Token: 0x0600147B RID: 5243 RVA: 0x000A744E File Offset: 0x000A584E
	public override void Init(PageElement item)
	{
		base.Init(item);
		this._worldMenuHero = (PageWorldMenuHero)item;
		this.UpdateVisualStatus(this._worldMenuHero.Selected);
	}

	// Token: 0x0600147C RID: 5244 RVA: 0x000A7474 File Offset: 0x000A5874
	public void Deselect()
	{
		this._worldMenuHero.Selected = false;
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x000A7484 File Offset: 0x000A5884
	public void UpdateVisualStatus(bool selected)
	{
		this.ButtonImage.sprite = ((!selected) ? this.OriginalButtonSprite : this.SelectedButtonSprite);
		this.SelectButtonText.text = ((!selected) ? UIComponentType.WorldMapHeroCardSelect.GetName() : UIComponentType.WorldMapHeroCardSelected.GetName());
		List<BattleTeam> list = (from b in GameWorld.instance.PlayerProfile.GetBattleTeams()
		where b.Adventurers.Contains(this._worldMenuHero.AdventurerProfile)
		select b).ToList<BattleTeam>();
		if (list.Count > 0)
		{
			this.GroupIcon.SetActive(true);
			this.GroupText.text = string.Empty;
			foreach (BattleTeam item in list)
			{
				TextMeshProUGUI groupText = this.GroupText;
				groupText.text += GameWorld.instance.PlayerProfile.GetBattleTeams().IndexOf(item) + 1;
			}
		}
		else
		{
			this.GroupIcon.SetActive(false);
		}
		this.InTripIcon.SetActive(false);
		List<ITraveller> travellers = new List<ITraveller>();
		GameWorld.instance.PlayerProfile.CurrentJourneys.ForEach(delegate(TripRecord c)
		{
			travellers.AddRange(c.Travellers);
		});
		this.SelectButton.interactable = true;
		foreach (ITraveller traveller in travellers)
		{
			if (traveller is AdventurerProfile)
			{
				AdventurerProfile adventurerProfile = traveller as AdventurerProfile;
				if (adventurerProfile.Id == this._worldMenuHero.AdventurerProfile.Id)
				{
					this.InTripIcon.SetActive(true);
					this.SelectButton.interactable = false;
				}
			}
		}
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x000A7698 File Offset: 0x000A5A98
	public void OnPointerClick(PointerEventData eventData)
	{
		this._parentPanel.SelectHero(base.PageHero);
	}

	// Token: 0x0600147F RID: 5247 RVA: 0x000A76AB File Offset: 0x000A5AAB
	public void Pick()
	{
		if (this._worldMenuHero.Selected)
		{
			this._parentPanel.UnpickHero(this._worldMenuHero.AdventurerProfile);
		}
		else
		{
			this._parentPanel.PickHero(this._worldMenuHero);
		}
	}

	// Token: 0x040014A4 RID: 5284
	public Sprite OriginalBackgroundSprite;

	// Token: 0x040014A5 RID: 5285
	public Sprite OriginalButtonSprite;

	// Token: 0x040014A6 RID: 5286
	public Sprite SelectedButtonSprite;

	// Token: 0x040014A7 RID: 5287
	public Image ButtonImage;

	// Token: 0x040014A8 RID: 5288
	public TextMeshProUGUI SelectButtonText;

	// Token: 0x040014A9 RID: 5289
	public Button SelectButton;

	// Token: 0x040014AA RID: 5290
	public GameObject InTripIcon;

	// Token: 0x040014AB RID: 5291
	public GameObject GroupIcon;

	// Token: 0x040014AC RID: 5292
	public TextMeshProUGUI GroupText;

	// Token: 0x040014AD RID: 5293
	private ConfigueAdventurerPanelController _parentPanel;

	// Token: 0x040014AE RID: 5294
	private PageWorldMenuHero _worldMenuHero;

	// Token: 0x02000C85 RID: 3205
	[CompilerGenerated]
	private sealed class <UpdateVisualStatus>c__AnonStorey0
	{
		// Token: 0x0600531A RID: 21274 RVA: 0x000A76E9 File Offset: 0x000A5AE9
		public <UpdateVisualStatus>c__AnonStorey0()
		{
		}

		// Token: 0x0600531B RID: 21275 RVA: 0x000A76F1 File Offset: 0x000A5AF1
		internal bool <>m__0(BattleTeam b)
		{
			return b.Adventurers.Contains(this.$this._worldMenuHero.AdventurerProfile);
		}

		// Token: 0x0600531C RID: 21276 RVA: 0x000A770E File Offset: 0x000A5B0E
		internal void <>m__1(TripRecord c)
		{
			this.travellers.AddRange(c.Travellers);
		}

		// Token: 0x040040B7 RID: 16567
		internal List<ITraveller> travellers;

		// Token: 0x040040B8 RID: 16568
		internal WorldMapHeroController $this;
	}
}
