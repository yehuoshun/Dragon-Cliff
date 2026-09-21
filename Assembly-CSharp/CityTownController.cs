using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020000F9 RID: 249
public class CityTownController : BuildingController
{
	// Token: 0x060006DB RID: 1755 RVA: 0x0006A4D4 File Offset: 0x000688D4
	public CityTownController()
	{
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x0006A4E8 File Offset: 0x000688E8
	private void Update()
	{
		this._timer += Time.deltaTime;
		if (this._timer >= this.regularCheckingTime)
		{
			this._timer = 0f;
		}
		if (Input.GetKeyUp(KeyCode.T) && TownManager.Instance.Ui.CanUseHotKey())
		{
			TownManager.Instance.Ui.OpenResidentMenu();
		}
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x0006A552 File Offset: 0x00068952
	public void PlayGoodResidentClip()
	{
		this.PlaySoundClip(this.GoodResidentClip);
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x0006A560 File Offset: 0x00068960
	public void ShowNewResidentIcon(List<ResidentCandidate> candidates)
	{
		this.NewResident.SetActive(true);
		List<ResidentCandidate> list = (from c in candidates
		orderby c.Candidate.Grade descending
		select c).ToList<ResidentCandidate>();
		if (list.Count > 0)
		{
			this.GradeImage.sprite = FilePath.GetAdventurerGradeBackground(list[0].Candidate.Grade, false);
		}
		else
		{
			this.GradeImage.gameObject.SetActive(false);
		}
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x0006A5E6 File Offset: 0x000689E6
	public void HideNewResidentIcon()
	{
		this.NewResident.SetActive(false);
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x0006A5F4 File Offset: 0x000689F4
	public void OnMouseUp()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		TownManager.Instance.Ui.OpenResidentMenu();
	}

	// Token: 0x060006E1 RID: 1761 RVA: 0x0006A615 File Offset: 0x00068A15
	[CompilerGenerated]
	private static QualityGrade <ShowNewResidentIcon>m__0(ResidentCandidate c)
	{
		return c.Candidate.Grade;
	}

	// Token: 0x040009F4 RID: 2548
	public GameObject NewResident;

	// Token: 0x040009F5 RID: 2549
	public Image GradeImage;

	// Token: 0x040009F6 RID: 2550
	public AudioClip GoodResidentClip;

	// Token: 0x040009F7 RID: 2551
	private float regularCheckingTime = 1f;

	// Token: 0x040009F8 RID: 2552
	private float _timer;

	// Token: 0x040009F9 RID: 2553
	[CompilerGenerated]
	private static Func<ResidentCandidate, QualityGrade> <>f__am$cache0;
}
