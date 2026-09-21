using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020002A8 RID: 680
public class PageTravellerController : PageElementController, IPointerClickHandler, IEventSystemHandler
{
	// Token: 0x06001244 RID: 4676 RVA: 0x0009D909 File Offset: 0x0009BD09
	public PageTravellerController()
	{
	}

	// Token: 0x170000CC RID: 204
	// (get) Token: 0x06001245 RID: 4677 RVA: 0x0009D911 File Offset: 0x0009BD11
	// (set) Token: 0x06001246 RID: 4678 RVA: 0x0009D919 File Offset: 0x0009BD19
	public PageTraveller Traveller
	{
		[CompilerGenerated]
		get
		{
			return this.<Traveller>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Traveller>k__BackingField = value;
		}
	}

	// Token: 0x06001247 RID: 4679 RVA: 0x0009D924 File Offset: 0x0009BD24
	public override void Init(PageElement item)
	{
		base.PageElement = item;
		this.Traveller = (PageTraveller)item;
		if (this.Traveller.Traveller is AdventurerProfile)
		{
			AdventurerProfile adventurer = this.Traveller.Traveller as AdventurerProfile;
			this.AvatarImage.sprite = FilePath.GetCharacterBasicAppearance(adventurer.UnitClass, false).GetStandSprite();
			this.GradeFrame.sprite = FilePath.GetAdventurerGradeBackground(adventurer.Grade, false);
			this.NameText.text = adventurer.GetUnitName();
			this.InBattleTeamSymbol.SetActive(GameWorld.instance.PlayerProfile.GetBattleTeams().Any((BattleTeam b) => b.Adventurers.Contains(adventurer)));
		}
		if (this.Traveller.Traveller is Resident)
		{
			Resident resident = this.Traveller.Traveller as Resident;
			this.AvatarImage.sprite = FilePath.GetResidentAppearence(resident.Type).GetStandSprite();
			this.GradeFrame.sprite = FilePath.GetAdventurerGradeBackground(resident.Grade, false);
			this.NameText.text = resident.Type.GetDescription().Title;
			this.InBattleTeamSymbol.SetActive(false);
		}
		IEnumerator enumerator = this.ContributionContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		foreach (JourneyContributionModifier contribution in this.Traveller.Traveller.GetContributions())
		{
			TravellerContributionController travellerContributionController = UnityEngine.Object.Instantiate<TravellerContributionController>(this.ContributionPre);
			travellerContributionController.Init(contribution);
			travellerContributionController.transform.SetParent(this.ContributionContainer, false);
		}
		this._picked = this.Traveller.Picked;
	}

	// Token: 0x06001248 RID: 4680 RVA: 0x0009DB5C File Offset: 0x0009BF5C
	public void Pick()
	{
		base.GetComponentInParent<ShipMenuController>().PickTraveller(this.Traveller.Traveller);
	}

	// Token: 0x06001249 RID: 4681 RVA: 0x0009DB74 File Offset: 0x0009BF74
	public void UnPick()
	{
		base.GetComponentInParent<ShipMenuController>().UnpickTraveller(this.Traveller.Traveller);
	}

	// Token: 0x0600124A RID: 4682 RVA: 0x0009DB8C File Offset: 0x0009BF8C
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this._picked)
		{
			this.UnPick();
		}
		else
		{
			this.Pick();
		}
		this.CloseTooltip();
	}

	// Token: 0x0400130A RID: 4874
	public Image AvatarImage;

	// Token: 0x0400130B RID: 4875
	public Image GradeFrame;

	// Token: 0x0400130C RID: 4876
	public TextMeshProUGUI NameText;

	// Token: 0x0400130D RID: 4877
	public TravellerContributionController ContributionPre;

	// Token: 0x0400130E RID: 4878
	public Transform ContributionContainer;

	// Token: 0x0400130F RID: 4879
	public GameObject InBattleTeamSymbol;

	// Token: 0x04001310 RID: 4880
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PageTraveller <Traveller>k__BackingField;

	// Token: 0x04001311 RID: 4881
	private bool _picked;

	// Token: 0x02000C65 RID: 3173
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x060052D3 RID: 21203 RVA: 0x0009DBB0 File Offset: 0x0009BFB0
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x060052D4 RID: 21204 RVA: 0x0009DBB8 File Offset: 0x0009BFB8
		internal bool <>m__0(BattleTeam b)
		{
			return b.Adventurers.Contains(this.adventurer);
		}

		// Token: 0x04004092 RID: 16530
		internal AdventurerProfile adventurer;
	}
}
