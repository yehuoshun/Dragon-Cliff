using System;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x020001A1 RID: 417
public class AdventurerPageCardController : HeroPageCardController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06000B09 RID: 2825 RVA: 0x00084302 File Offset: 0x00082702
	public AdventurerPageCardController()
	{
	}

	// Token: 0x06000B0A RID: 2826 RVA: 0x0008430C File Offset: 0x0008270C
	public override void Init(PageElement item)
	{
		base.Init(item);
		base.PageHero = (PageHero)item;
		bool flag = GameWorld.instance.PlayerProfile.GetBattleTeams().Any((BattleTeam b) => b.Adventurers.Any((AdventurerProfile a) => a.Id == base.PageHero.AdventurerProfile.Id));
		this.InBattleTag.gameObject.SetActive(flag);
		if (flag)
		{
			this.InBattleTag.Init(base.PageHero.AdventurerProfile);
		}
		this.InTripObj.SetActive(GameWorld.instance.PlayerProfile.CurrentJourneys.Any((TripRecord j) => j.Vehicle.Travellers.OfType<AdventurerProfile>().Any((AdventurerProfile a) => a.Id == base.PageHero.AdventurerProfile.Id)));
	}

	// Token: 0x06000B0B RID: 2827 RVA: 0x000843A8 File Offset: 0x000827A8
	public void OnPointerClick(PointerEventData eventData)
	{
		HeroManagementController componentInParent = base.GetComponentInParent<HeroManagementController>();
		if (componentInParent != null)
		{
			componentInParent.SelectHero(base.PageHero);
		}
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x000843D4 File Offset: 0x000827D4
	[CompilerGenerated]
	private bool <Init>m__0(BattleTeam b)
	{
		return b.Adventurers.Any((AdventurerProfile a) => a.Id == base.PageHero.AdventurerProfile.Id);
	}

	// Token: 0x06000B0D RID: 2829 RVA: 0x000843ED File Offset: 0x000827ED
	[CompilerGenerated]
	private bool <Init>m__1(TripRecord j)
	{
		return j.Vehicle.Travellers.OfType<AdventurerProfile>().Any((AdventurerProfile a) => a.Id == base.PageHero.AdventurerProfile.Id);
	}

	// Token: 0x06000B0E RID: 2830 RVA: 0x00084410 File Offset: 0x00082810
	[CompilerGenerated]
	private bool <Init>m__2(AdventurerProfile a)
	{
		return a.Id == base.PageHero.AdventurerProfile.Id;
	}

	// Token: 0x06000B0F RID: 2831 RVA: 0x0008442D File Offset: 0x0008282D
	[CompilerGenerated]
	private bool <Init>m__3(AdventurerProfile a)
	{
		return a.Id == base.PageHero.AdventurerProfile.Id;
	}

	// Token: 0x04000DA1 RID: 3489
	public GameObject InTripObj;

	// Token: 0x04000DA2 RID: 3490
	public AdventurerGroupTagController InBattleTag;
}
