using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000FF RID: 255
public class RecruitmentFacilityController : BuildingController
{
	// Token: 0x0600070A RID: 1802 RVA: 0x0006B048 File Offset: 0x00069448
	public RecruitmentFacilityController()
	{
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600070B RID: 1803 RVA: 0x0006B05B File Offset: 0x0006945B
	// (set) Token: 0x0600070C RID: 1804 RVA: 0x0006B063 File Offset: 0x00069463
	public RecruitmentFacility Facility
	{
		[CompilerGenerated]
		get
		{
			return this.<Facility>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Facility>k__BackingField = value;
		}
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x0006B06C File Offset: 0x0006946C
	private void Update()
	{
		if (Input.GetKeyUp(KeyCode.R) && TownManager.Instance.Ui.CanUseHotKey())
		{
			this.OpenMenu();
		}
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x0006B094 File Offset: 0x00069494
	public void Init(TownSlot slot, RecruitmentFacility facility)
	{
		this.Facility = facility;
		this._slot = slot;
		this.UpdateHeroList(facility.Candidates);
		RecruitmentFacility facility2 = this.Facility;
		facility2.CandidatesListUpdated = (Action<List<AdventurerCandidate>>)Delegate.Combine(facility2.CandidatesListUpdated, new Action<List<AdventurerCandidate>>(this.Facility_CandidatesListUpdated));
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0006B0E4 File Offset: 0x000694E4
	private void Facility_CandidatesListUpdated(List<AdventurerCandidate> candidates)
	{
		List<AdventurerCandidate> list = (from c in candidates
		where !this._currentHeroes.Contains(c)
		select c).ToList<AdventurerCandidate>();
		if (list.Count > 0)
		{
			this.ShowWidget();
		}
		this.UpdateHeroList(candidates);
		foreach (AdventurerCandidate adventurerCandidate in list)
		{
			AdventurerProfile profile = adventurerCandidate.Profile;
			if (profile.Grade == QualityGrade.Legendary || profile.Grade == QualityGrade.Ancient)
			{
				this.DisplyMovingNotification(new FlyingText
				{
					DisplyingText = UIComponentType.NotificationHighClassAdventurerVisits.GetName().ReplaceToBuilder(UIComponentKey.Grade, ColorPicker.GetHaxString(ColorPicker.GetGradeColor(profile.Grade, false), profile.Grade.GetDescription().Title)).ToString().ReplaceToBuilder(UIComponentKey.UnitClass, ColorPicker.GetHaxString(ColorPicker.Yellow, profile.GetUnitName())).ToString()
				});
				TownManager.Instance.Ui.RecruitmentMenu.TryAutoHire(profile);
			}
		}
		List<AdventurerCandidate> list2 = (from c in candidates
		orderby c.Profile.Grade descending
		select c).ToList<AdventurerCandidate>();
		if (list2.Count > 0)
		{
			this.GradeImage.sprite = FilePath.GetAdventurerGradeBackground(list2[0].Profile.Grade, list2[0].Profile.IsStar());
			this.GradeImage.gameObject.SetActive(true);
		}
		else
		{
			this.GradeImage.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x0006B29C File Offset: 0x0006969C
	private void UpdateHeroList(List<AdventurerCandidate> obj)
	{
		this._currentHeroes.Clear();
		this._currentHeroes.AddRange(obj);
		TownManager.Instance.Ui.RecruitmentMenu.UpdateHeroList((from a in obj
		select a.Profile).ToList<AdventurerProfile>());
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x0006B2FC File Offset: 0x000696FC
	private void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		this.OpenMenu();
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x0006B314 File Offset: 0x00069714
	private void OpenMenu()
	{
		TownManager.Instance.Ui.OpenRecritmentMenu();
		this.HideWidget();
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x0006B32B File Offset: 0x0006972B
	public void ShowWidget()
	{
		if (!TownManager.Instance.Ui.RecruitmentMenu.gameObject.activeSelf)
		{
			this.Widget.SetActive(true);
		}
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x0006B357 File Offset: 0x00069757
	public void HideWidget()
	{
		this.Widget.SetActive(false);
	}

	// Token: 0x06000715 RID: 1813 RVA: 0x0006B365 File Offset: 0x00069765
	[CompilerGenerated]
	private bool <Facility_CandidatesListUpdated>m__0(AdventurerCandidate c)
	{
		return !this._currentHeroes.Contains(c);
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x0006B376 File Offset: 0x00069776
	[CompilerGenerated]
	private static QualityGrade <Facility_CandidatesListUpdated>m__1(AdventurerCandidate c)
	{
		return c.Profile.Grade;
	}

	// Token: 0x06000717 RID: 1815 RVA: 0x0006B383 File Offset: 0x00069783
	[CompilerGenerated]
	private static AdventurerProfile <UpdateHeroList>m__2(AdventurerCandidate a)
	{
		return a.Profile;
	}

	// Token: 0x04000A04 RID: 2564
	public GameObject Widget;

	// Token: 0x04000A05 RID: 2565
	public Image GradeImage;

	// Token: 0x04000A06 RID: 2566
	public GameObject RecruitmentHero;

	// Token: 0x04000A07 RID: 2567
	private TownSlot _slot;

	// Token: 0x04000A08 RID: 2568
	private List<AdventurerCandidate> _currentHeroes = new List<AdventurerCandidate>();

	// Token: 0x04000A09 RID: 2569
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private RecruitmentFacility <Facility>k__BackingField;

	// Token: 0x04000A0A RID: 2570
	[CompilerGenerated]
	private static Func<AdventurerCandidate, QualityGrade> <>f__am$cache0;

	// Token: 0x04000A0B RID: 2571
	[CompilerGenerated]
	private static Func<AdventurerCandidate, AdventurerProfile> <>f__am$cache1;
}
