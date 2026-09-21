using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200024C RID: 588
public class ResidentItemBaseController : MonoBehaviour
{
	// Token: 0x06000F2A RID: 3882 RVA: 0x00071E78 File Offset: 0x00070278
	public ResidentItemBaseController()
	{
	}

	// Token: 0x17000098 RID: 152
	// (get) Token: 0x06000F2B RID: 3883 RVA: 0x00071E96 File Offset: 0x00070296
	// (set) Token: 0x06000F2C RID: 3884 RVA: 0x00071E9E File Offset: 0x0007029E
	public Resident Resident
	{
		[CompilerGenerated]
		get
		{
			return this.<Resident>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Resident>k__BackingField = value;
		}
	}

	// Token: 0x06000F2D RID: 3885 RVA: 0x00071EA8 File Offset: 0x000702A8
	public virtual void Init(Resident resident)
	{
		this.Resident = resident;
		this.NameText.text = resident.Type.GetDescription().Title;
		this.LevelText.text = resident.Level.ToLevelText();
		this.GradeImage.sprite = FilePath.GetAdventurerGradeBackground(resident.Grade, false);
		this.AvatarImage.sprite = FilePath.GetResidentAppearence(resident.Type).GetStandSprite();
		this.ClearChildren();
		foreach (IResidentEffect effect in from e in resident.Effects
		orderby e.CorrespondingEffectType
		select e)
		{
			GameObject gameObject = this.PoolObject(PoolType.ResidentEffectItem, default(Vector3));
			gameObject.GetComponent<ResidentEffectItemController>().Init(effect);
			gameObject.transform.SetParent(this.EffectContainer, false);
			gameObject.transform.localScale = Vector3.one;
			gameObject.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
			this._effectObjects.Add(gameObject);
		}
		List<JourneyContributionModifier> contributions = resident.GetContributions();
		bool flag = contributions.Any((JourneyContributionModifier c) => c.Value != 0.0);
		if (flag)
		{
			foreach (JourneyContributionModifier contribution in from c in resident.GetContributions()
			orderby c.Type
			select c)
			{
				GameObject gameObject2 = this.PoolObject(PoolType.TravellerContributionItem, default(Vector3));
				gameObject2.GetComponent<TravellerContributionController>().Init(contribution);
				gameObject2.transform.SetParent(this.ContributionContainer, false);
				gameObject2.transform.localScale = Vector3.one;
				gameObject2.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
				this._contributionObjects.Add(gameObject2);
			}
			this.ContributionContainer.gameObject.SetActive(true);
			this.GapBar.SetActive(true);
		}
		else
		{
			this.ContributionContainer.gameObject.SetActive(false);
			this.GapBar.SetActive(false);
		}
	}

	// Token: 0x06000F2E RID: 3886 RVA: 0x00072128 File Offset: 0x00070528
	public void ClearChildren()
	{
		this._contributionObjects.ForEach(delegate(GameObject c)
		{
			c.PoolDestroy(PoolType.TravellerContributionItem);
		});
		this._effectObjects.ForEach(delegate(GameObject e)
		{
			e.PoolDestroy(PoolType.ResidentEffectItem);
		});
		this._contributionObjects.Clear();
		this._effectObjects.Clear();
	}

	// Token: 0x06000F2F RID: 3887 RVA: 0x0007219B File Offset: 0x0007059B
	public void RemoveResident()
	{
		base.GetComponentInParent<ResidentMenuController>().Kickout(this.Resident);
	}

	// Token: 0x06000F30 RID: 3888 RVA: 0x000721AE File Offset: 0x000705AE
	[CompilerGenerated]
	private static ResidentEffectType <Init>m__0(IResidentEffect e)
	{
		return e.CorrespondingEffectType;
	}

	// Token: 0x06000F31 RID: 3889 RVA: 0x000721B6 File Offset: 0x000705B6
	[CompilerGenerated]
	private static bool <Init>m__1(JourneyContributionModifier c)
	{
		return c.Value != 0.0;
	}

	// Token: 0x06000F32 RID: 3890 RVA: 0x000721CC File Offset: 0x000705CC
	[CompilerGenerated]
	private static JourneyContributeType <Init>m__2(JourneyContributionModifier c)
	{
		return c.Type;
	}

	// Token: 0x06000F33 RID: 3891 RVA: 0x000721D4 File Offset: 0x000705D4
	[CompilerGenerated]
	private static void <ClearChildren>m__3(GameObject c)
	{
		c.PoolDestroy(PoolType.TravellerContributionItem);
	}

	// Token: 0x06000F34 RID: 3892 RVA: 0x000721DE File Offset: 0x000705DE
	[CompilerGenerated]
	private static void <ClearChildren>m__4(GameObject e)
	{
		e.PoolDestroy(PoolType.ResidentEffectItem);
	}

	// Token: 0x04001088 RID: 4232
	public TextMeshProUGUI NameText;

	// Token: 0x04001089 RID: 4233
	public TextMeshProUGUI LevelText;

	// Token: 0x0400108A RID: 4234
	public Image GradeImage;

	// Token: 0x0400108B RID: 4235
	public Image AvatarImage;

	// Token: 0x0400108C RID: 4236
	public ResidentEffectItemController EffectItemPre;

	// Token: 0x0400108D RID: 4237
	public Transform EffectContainer;

	// Token: 0x0400108E RID: 4238
	public TravellerContributionController ContributionPre;

	// Token: 0x0400108F RID: 4239
	public Transform ContributionContainer;

	// Token: 0x04001090 RID: 4240
	public GameObject GapBar;

	// Token: 0x04001091 RID: 4241
	private readonly List<GameObject> _effectObjects = new List<GameObject>();

	// Token: 0x04001092 RID: 4242
	private readonly List<GameObject> _contributionObjects = new List<GameObject>();

	// Token: 0x04001093 RID: 4243
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Resident <Resident>k__BackingField;

	// Token: 0x04001094 RID: 4244
	[CompilerGenerated]
	private static Func<IResidentEffect, ResidentEffectType> <>f__am$cache0;

	// Token: 0x04001095 RID: 4245
	[CompilerGenerated]
	private static Func<JourneyContributionModifier, bool> <>f__am$cache1;

	// Token: 0x04001096 RID: 4246
	[CompilerGenerated]
	private static Func<JourneyContributionModifier, JourneyContributeType> <>f__am$cache2;

	// Token: 0x04001097 RID: 4247
	[CompilerGenerated]
	private static Action<GameObject> <>f__am$cache3;

	// Token: 0x04001098 RID: 4248
	[CompilerGenerated]
	private static Action<GameObject> <>f__am$cache4;
}
