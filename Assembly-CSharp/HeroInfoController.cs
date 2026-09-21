using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001BC RID: 444
public class HeroInfoController : MonoBehaviour, IHeroInfoController
{
	// Token: 0x06000B8F RID: 2959 RVA: 0x00086A52 File Offset: 0x00084E52
	public HeroInfoController()
	{
	}

	// Token: 0x06000B90 RID: 2960 RVA: 0x00086A65 File Offset: 0x00084E65
	private void OnDisable()
	{
		this.ClearOldData();
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x00086A70 File Offset: 0x00084E70
	public virtual void UpdateInfo(AdventurerProfile profile, ALUTextItem item = null)
	{
		if (profile == null)
		{
			this.Activate(false);
		}
		else
		{
			this._profile = profile;
			this.AdventurerUi.Init(profile, FixedAdventurerAnimation.Walk);
			this.ClearOldData();
			this.HeroName.text = profile.GetUnitName();
			this.Grade.text = profile.Grade.GetDescription().Title + " " + profile.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory().GetDescription().Title;
			this.Grade.color = FilePath.GetGradeColor(profile.Grade);
			this.HeroLevel.text = "Lv." + ((item != null) ? item.NewLevel : profile.GetLevel());
			List<AttributeDisplayValue> attributeDisplayValues = profile.GetAttributeDisplayValues(AttributeRetrievalLevel.Skill);
			AttributeType heroAttackType = profile.GetOutputAttributeType();
			AttributeDisplayValue attributeDisplayValue = attributeDisplayValues.FirstOrDefault((AttributeDisplayValue a) => a.AttributeType == heroAttackType);
			List<AttributeDisplayValue> list = this.OrderHeroDisplayValues((from a in attributeDisplayValues
			where a.AttributeType != heroAttackType
			select a).ToList<AttributeDisplayValue>());
			list.Insert(0, attributeDisplayValue);
			this.OutputText.Init(profile);
			this.AttackTypeText.Init(attributeDisplayValue);
			this.RatingPanel.Init(attributeDisplayValue, profile.GetRating());
			if (profile.IsStar() && this.HeroStarEffectPre != null)
			{
				HeroStarEffectController heroStarEffectController = UnityEngine.Object.Instantiate<HeroStarEffectController>(this.HeroStarEffectPre);
				heroStarEffectController.Init(profile.GetAdventurerStarEffects());
				heroStarEffectController.transform.SetParent(this.AttributeContainer, false);
			}
			for (int i = 0; i < list.Count; i++)
			{
				AttributeTextController attributeTextController = UnityEngine.Object.Instantiate<AttributeTextController>(this.AttributePre);
				attributeTextController.Init(list[i]);
				attributeTextController.transform.SetParent(this.AttributeContainer, false);
				this._textControllers.Add(attributeTextController);
			}
			List<Skill> skills = profile.GetSkills();
			Skill skill = skills.FirstOrDefault((Skill s) => s.CommandType == SkillCommandType.Main);
			Skill skill2 = (from s in skills
			where s.CommandType == SkillCommandType.Secondary
			select s).FirstOrDefault((Skill s) => s.IsEnabled);
			Skill skill3 = skills.FirstOrDefault((Skill s) => s.CommandType == SkillCommandType.Active);
			if (skill != null)
			{
				this.MainSkill.Init(skill);
				this.MainSkill.gameObject.SetActive(true);
			}
			else
			{
				this.MainSkill.gameObject.SetActive(false);
			}
			if (skill2 != null)
			{
				this.SecondSkill.Init(skill2);
				this.SecondSkill.gameObject.SetActive(true);
				if (this.UnkonwnSecondSkill != null)
				{
					this.UnkonwnSecondSkill.SetActive(false);
				}
			}
			else
			{
				this.SecondSkill.gameObject.SetActive(false);
				if (this.UnkonwnSecondSkill != null)
				{
					this.UnkonwnSecondSkill.SetActive(GameWorld.instance.PlayerProfile.BuildingHasBeenBuilt(BuildingType.School));
				}
			}
			if (skill3 != null)
			{
				this.ActiveSkill.Init(skill3);
				this.ActiveSkill.gameObject.SetActive(true);
			}
			else
			{
				this.ActiveSkill.gameObject.SetActive(false);
			}
			if (this.AdventurerEffectTransform != null)
			{
				this.UpdateAdventurerEffect(profile.UnitClass);
			}
			if (item != null)
			{
				item.Change.ChangedValues.ForEach(delegate(LevelUpChangeValue c)
				{
					this._textControllers.ForEach(delegate(AttributeTextController a)
					{
						if (a.DisplayValue != null && a.DisplayValue.AttributeType == c.AttributeType)
						{
							a.AddSupplement(c.Value.DoubleToInt(), 0);
						}
					});
				});
			}
			this.ScrollRect.verticalNormalizedPosition = 1f;
			this.ShowCanLevelUpFrame();
			this.Activate(true);
		}
	}

	// Token: 0x06000B92 RID: 2962 RVA: 0x00086E5B File Offset: 0x0008525B
	public void ShowCanLevelUpFrame()
	{
		if (this._profile != null && this.CanLevelUpFrame != null)
		{
			this.CanLevelUpFrame.SetActive(this._profile.CanUpgradeLevel());
		}
	}

	// Token: 0x06000B93 RID: 2963 RVA: 0x00086E90 File Offset: 0x00085290
	public void ShowNameTooltip()
	{
		string title = this._profile.UnitClass.GetDescription().Title;
		this.OpenTooltip(new TooltipItem
		{
			Title = title,
			Position = this.HeroName.transform.position,
			Description = this._profile.Grade.GetDescription().Title + title
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000B94 RID: 2964 RVA: 0x00086F0A File Offset: 0x0008530A
	public void HideNameTooltip()
	{
		this.CloseTooltip();
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x00086F14 File Offset: 0x00085314
	private void UpdateAdventurerEffect(UnitClass unit)
	{
		IEnumerator enumerator = this.AdventurerEffectTransform.GetEnumerator();
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
		GameObject adventurerUIEffect = FilePath.GetAdventurerUIEffect(unit);
		if (adventurerUIEffect != null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(adventurerUIEffect);
			gameObject.transform.SetParent(this.AdventurerEffectTransform, false);
		}
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x00086FAC File Offset: 0x000853AC
	public void InactivateInfoPanel()
	{
		this.Activate(false);
		this.CloseTooltip();
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x00086FBC File Offset: 0x000853BC
	public void ClearOldData()
	{
		this.OutputText.Clear();
		this.AttackTypeText.Clear();
		this.HeroName.text = string.Empty;
		this.MainSkill.Init(null);
		this.SecondSkill.Init(null);
		this.ResetAttributes();
	}

	// Token: 0x06000B98 RID: 2968 RVA: 0x0008700D File Offset: 0x0008540D
	public void Activate(bool activate)
	{
		this.InfoPanel.SetActive(activate);
		if (!activate)
		{
			this.ClearOldData();
		}
	}

	// Token: 0x06000B99 RID: 2969 RVA: 0x00087028 File Offset: 0x00085428
	private void ResetAttributes()
	{
		IEnumerator enumerator = this.AttributeContainer.GetEnumerator();
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
		this._textControllers.Clear();
	}

	// Token: 0x06000B9A RID: 2970 RVA: 0x0008709C File Offset: 0x0008549C
	[CompilerGenerated]
	private static bool <UpdateInfo>m__0(Skill s)
	{
		return s.CommandType == SkillCommandType.Main;
	}

	// Token: 0x06000B9B RID: 2971 RVA: 0x000870A7 File Offset: 0x000854A7
	[CompilerGenerated]
	private static bool <UpdateInfo>m__1(Skill s)
	{
		return s.CommandType == SkillCommandType.Secondary;
	}

	// Token: 0x06000B9C RID: 2972 RVA: 0x000870B2 File Offset: 0x000854B2
	[CompilerGenerated]
	private static bool <UpdateInfo>m__2(Skill s)
	{
		return s.IsEnabled;
	}

	// Token: 0x06000B9D RID: 2973 RVA: 0x000870BA File Offset: 0x000854BA
	[CompilerGenerated]
	private static bool <UpdateInfo>m__3(Skill s)
	{
		return s.CommandType == SkillCommandType.Active;
	}

	// Token: 0x04000DFC RID: 3580
	public TextMeshProUGUI HeroName;

	// Token: 0x04000DFD RID: 3581
	public TextMeshProUGUI Grade;

	// Token: 0x04000DFE RID: 3582
	public TextMeshProUGUI HeroLevel;

	// Token: 0x04000DFF RID: 3583
	public GameObject CanLevelUpFrame;

	// Token: 0x04000E00 RID: 3584
	public GameObject InfoPanel;

	// Token: 0x04000E01 RID: 3585
	public Image MainSkillImage;

	// Token: 0x04000E02 RID: 3586
	public Image SecondSkillImage;

	// Token: 0x04000E03 RID: 3587
	public SkillIconController MainSkill;

	// Token: 0x04000E04 RID: 3588
	public SkillIconController SecondSkill;

	// Token: 0x04000E05 RID: 3589
	public SkillIconController ActiveSkill;

	// Token: 0x04000E06 RID: 3590
	public GameObject UnkonwnSecondSkill;

	// Token: 0x04000E07 RID: 3591
	public AdventurerUIController AdventurerUi;

	// Token: 0x04000E08 RID: 3592
	public Transform AdventurerEffectTransform;

	// Token: 0x04000E09 RID: 3593
	public ElementTextController OutputText;

	// Token: 0x04000E0A RID: 3594
	public AttackTypeTextController AttackTypeText;

	// Token: 0x04000E0B RID: 3595
	public Transform AttributeContainer;

	// Token: 0x04000E0C RID: 3596
	public AttributeTextController AttributePre;

	// Token: 0x04000E0D RID: 3597
	public HeroStarEffectController HeroStarEffectPre;

	// Token: 0x04000E0E RID: 3598
	public ScrollRect ScrollRect;

	// Token: 0x04000E0F RID: 3599
	public HeroRatingPanelController RatingPanel;

	// Token: 0x04000E10 RID: 3600
	private readonly List<AttributeTextController> _textControllers = new List<AttributeTextController>();

	// Token: 0x04000E11 RID: 3601
	private AdventurerProfile _profile;

	// Token: 0x04000E12 RID: 3602
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache0;

	// Token: 0x04000E13 RID: 3603
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache1;

	// Token: 0x04000E14 RID: 3604
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache2;

	// Token: 0x04000E15 RID: 3605
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache3;

	// Token: 0x02000C2E RID: 3118
	[CompilerGenerated]
	private sealed class <UpdateInfo>c__AnonStorey0
	{
		// Token: 0x06005232 RID: 21042 RVA: 0x000870C5 File Offset: 0x000854C5
		public <UpdateInfo>c__AnonStorey0()
		{
		}

		// Token: 0x06005233 RID: 21043 RVA: 0x000870CD File Offset: 0x000854CD
		internal bool <>m__0(AttributeDisplayValue a)
		{
			return a.AttributeType == this.heroAttackType;
		}

		// Token: 0x06005234 RID: 21044 RVA: 0x000870DD File Offset: 0x000854DD
		internal bool <>m__1(AttributeDisplayValue a)
		{
			return a.AttributeType != this.heroAttackType;
		}

		// Token: 0x06005235 RID: 21045 RVA: 0x000870F0 File Offset: 0x000854F0
		internal void <>m__2(LevelUpChangeValue c)
		{
			this.$this._textControllers.ForEach(delegate(AttributeTextController a)
			{
				if (a.DisplayValue != null && a.DisplayValue.AttributeType == c.AttributeType)
				{
					a.AddSupplement(c.Value.DoubleToInt(), 0);
				}
			});
		}

		// Token: 0x04004034 RID: 16436
		internal AttributeType heroAttackType;

		// Token: 0x04004035 RID: 16437
		internal HeroInfoController $this;

		// Token: 0x02000C2F RID: 3119
		private sealed class <UpdateInfo>c__AnonStorey1
		{
			// Token: 0x06005236 RID: 21046 RVA: 0x0008712D File Offset: 0x0008552D
			public <UpdateInfo>c__AnonStorey1()
			{
			}

			// Token: 0x06005237 RID: 21047 RVA: 0x00087135 File Offset: 0x00085535
			internal void <>m__0(AttributeTextController a)
			{
				if (a.DisplayValue != null && a.DisplayValue.AttributeType == this.c.AttributeType)
				{
					a.AddSupplement(this.c.Value.DoubleToInt(), 0);
				}
			}

			// Token: 0x04004036 RID: 16438
			internal LevelUpChangeValue c;

			// Token: 0x04004037 RID: 16439
			internal HeroInfoController.<UpdateInfo>c__AnonStorey0 <>f__ref$0;
		}
	}
}
