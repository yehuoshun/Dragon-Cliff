using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000303 RID: 771
public class WorldMapHeroDetailsController : MonoBehaviour, IEquipmentControl, IHeroInfoController
{
	// Token: 0x06001480 RID: 5248 RVA: 0x000A7721 File Offset: 0x000A5B21
	public WorldMapHeroDetailsController()
	{
	}

	// Token: 0x06001481 RID: 5249 RVA: 0x000A7729 File Offset: 0x000A5B29
	public void Start()
	{
		this.HeroSubTran.SetActive(false);
	}

	// Token: 0x06001482 RID: 5250 RVA: 0x000A7738 File Offset: 0x000A5B38
	public void Init(AdventurerProfile profile)
	{
		this.Reset();
		this._profile = profile;
		this.HeroName.text = profile.GetUnitName();
		this.HeroLevel.text = profile.GetLevel().ToLevelText();
		this.Grade.text = profile.Grade.GetDescription().Title + " " + profile.UnitClass.GetConfiguration().CorrespondingClassStyle.GetClassCategory().GetDescription().Title;
		this.Grade.color = FilePath.GetGradeColor(profile.Grade);
		this.AdventurerUi.Init(profile, FixedAdventurerAnimation.Walk);
		this.OutputText.Init(profile);
		List<AttributeDisplayValue> attributeDisplayValues = profile.GetAttributeDisplayValues(AttributeRetrievalLevel.Skill);
		AttributeDisplayValue displayValue = attributeDisplayValues.FirstOrDefault((AttributeDisplayValue a) => a.AttributeType == profile.GetOutputAttributeType());
		this.AttackTypeText.Init(displayValue);
		this.UpdateAdventuererSkillDetails();
		this.UpdateEquipments();
		this.HeroSubTran.SetActive(true);
		this.ScrollRect.verticalNormalizedPosition = 1f;
	}

	// Token: 0x06001483 RID: 5251 RVA: 0x000A7878 File Offset: 0x000A5C78
	public TooltipItem GetGemSetTooltip()
	{
		List<ItemController> list = new List<ItemController>();
		if (this.Weapon.CurrentEquipment != null)
		{
			list.Add(this.Weapon.CurrentEquipment);
		}
		if (this.Armor.CurrentEquipment != null)
		{
			list.Add(this.Armor.CurrentEquipment);
		}
		if (this.Accessory1.CurrentEquipment != null)
		{
			list.Add(this.Accessory1.CurrentEquipment);
		}
		if (this.Scroll.CurrentEquipment != null)
		{
			list.Add(this.Scroll.CurrentEquipment);
		}
		if (this.Amulet.CurrentEquipment != null)
		{
			list.Add(this.Amulet.CurrentEquipment);
		}
		if (this.Device.CurrentEquipment != null)
		{
			list.Add(this.Device.CurrentEquipment);
		}
		return list.GetGemSetTooltip();
	}

	// Token: 0x06001484 RID: 5252 RVA: 0x000A797C File Offset: 0x000A5D7C
	public void UpdateEquipments()
	{
		List<HeroMenuEquipmentItem> list = this.UpdateEquipmentInfo(this._profile.GetEquipments());
		foreach (HeroMenuEquipmentItem heroMenuEquipmentItem in list)
		{
			NormalItem item = (heroMenuEquipmentItem.Equipment == null) ? null : heroMenuEquipmentItem.Equipment.ConvertToUiNormalItem();
			switch (heroMenuEquipmentItem.SlotType)
			{
			case UiSlotType.Weapon:
				this.Weapon.Init(item);
				break;
			case UiSlotType.Armor:
				this.Armor.Init(item);
				break;
			case UiSlotType.Accessory1:
				this.Accessory1.Init(item);
				break;
			case UiSlotType.Scroll:
				this.Scroll.Init(item);
				break;
			case UiSlotType.Amulet:
				this.Amulet.Init(item);
				break;
			case UiSlotType.Device:
				this.Device.Init(item);
				break;
			}
		}
	}

	// Token: 0x06001485 RID: 5253 RVA: 0x000A7A90 File Offset: 0x000A5E90
	public void UpdateAdventuererSkillDetails()
	{
		if (this._profile == null)
		{
			return;
		}
		List<Skill> skills = this._profile.GetSkills();
		Skill skill = skills.FirstOrDefault((Skill s) => s.CommandType == SkillCommandType.Main);
		Skill skill2 = skills.FirstOrDefault((Skill s) => s.CommandType == SkillCommandType.Secondary && s.IsEnabled);
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
		}
		else
		{
			this.SecondSkill.gameObject.SetActive(false);
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
		List<AttributeDisplayValue> list = this.OrderHeroDisplayValues(this._profile.GetAttributeDisplayValues(AttributeRetrievalLevel.Skill));
		if (this._profile.IsStar())
		{
			HeroStarEffectController heroStarEffectController = UnityEngine.Object.Instantiate<HeroStarEffectController>(this.StarEffectPre);
			heroStarEffectController.Init(this._profile.GetAdventurerStarEffects());
			heroStarEffectController.transform.SetParent(this.AttributeContainer, false);
		}
		for (int i = 0; i < list.Count; i++)
		{
			AttributeTextController attributeTextController = UnityEngine.Object.Instantiate<AttributeTextController>(this.AttributePre);
			attributeTextController.Init(list[i]);
			attributeTextController.transform.SetParent(this.AttributeContainer, false);
		}
	}

	// Token: 0x06001486 RID: 5254 RVA: 0x000A7C70 File Offset: 0x000A6070
	public void Reset()
	{
		this.OutputText.Clear();
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
	}

	// Token: 0x06001487 RID: 5255 RVA: 0x000A7CE4 File Offset: 0x000A60E4
	[CompilerGenerated]
	private static bool <UpdateAdventuererSkillDetails>m__0(Skill s)
	{
		return s.CommandType == SkillCommandType.Main;
	}

	// Token: 0x06001488 RID: 5256 RVA: 0x000A7CEF File Offset: 0x000A60EF
	[CompilerGenerated]
	private static bool <UpdateAdventuererSkillDetails>m__1(Skill s)
	{
		return s.CommandType == SkillCommandType.Secondary && s.IsEnabled;
	}

	// Token: 0x06001489 RID: 5257 RVA: 0x000A7D06 File Offset: 0x000A6106
	[CompilerGenerated]
	private static bool <UpdateAdventuererSkillDetails>m__2(Skill s)
	{
		return s.CommandType == SkillCommandType.Active;
	}

	// Token: 0x040014AF RID: 5295
	public TextMeshProUGUI HeroName;

	// Token: 0x040014B0 RID: 5296
	public TextMeshProUGUI HeroLevel;

	// Token: 0x040014B1 RID: 5297
	public TextMeshProUGUI Grade;

	// Token: 0x040014B2 RID: 5298
	public SkillIconController MainSkill;

	// Token: 0x040014B3 RID: 5299
	public SkillIconController SecondSkill;

	// Token: 0x040014B4 RID: 5300
	public SkillIconController ActiveSkill;

	// Token: 0x040014B5 RID: 5301
	public EquipmentSlotDisplayController Weapon;

	// Token: 0x040014B6 RID: 5302
	public EquipmentSlotDisplayController Armor;

	// Token: 0x040014B7 RID: 5303
	public EquipmentSlotDisplayController Accessory1;

	// Token: 0x040014B8 RID: 5304
	public EquipmentSlotDisplayController Scroll;

	// Token: 0x040014B9 RID: 5305
	public EquipmentSlotDisplayController Amulet;

	// Token: 0x040014BA RID: 5306
	public EquipmentSlotDisplayController Device;

	// Token: 0x040014BB RID: 5307
	public ElementTextController OutputText;

	// Token: 0x040014BC RID: 5308
	public AttackTypeTextController AttackTypeText;

	// Token: 0x040014BD RID: 5309
	public Transform AttributeContainer;

	// Token: 0x040014BE RID: 5310
	public AttributeTextController AttributePre;

	// Token: 0x040014BF RID: 5311
	public HeroStarEffectController StarEffectPre;

	// Token: 0x040014C0 RID: 5312
	public ScrollRect ScrollRect;

	// Token: 0x040014C1 RID: 5313
	public AdventurerUIController AdventurerUi;

	// Token: 0x040014C2 RID: 5314
	public GameObject HeroSubTran;

	// Token: 0x040014C3 RID: 5315
	private AdventurerProfile _profile;

	// Token: 0x040014C4 RID: 5316
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache0;

	// Token: 0x040014C5 RID: 5317
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache1;

	// Token: 0x040014C6 RID: 5318
	[CompilerGenerated]
	private static Func<Skill, bool> <>f__am$cache2;

	// Token: 0x02000C86 RID: 3206
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x0600531D RID: 21277 RVA: 0x000A7D11 File Offset: 0x000A6111
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x0600531E RID: 21278 RVA: 0x000A7D19 File Offset: 0x000A6119
		internal bool <>m__0(AttributeDisplayValue a)
		{
			return a.AttributeType == this.profile.GetOutputAttributeType();
		}

		// Token: 0x040040B9 RID: 16569
		internal AdventurerProfile profile;
	}
}
