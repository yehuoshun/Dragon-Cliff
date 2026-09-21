using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020001DB RID: 475
public class TalentSkillController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x06000CC0 RID: 3264 RVA: 0x0008B6B8 File Offset: 0x00089AB8
	public TalentSkillController()
	{
	}

	// Token: 0x06000CC1 RID: 3265 RVA: 0x0008B6C0 File Offset: 0x00089AC0
	public void Init(IAdventurerTalent talent, AdventurerProfile adventurer)
	{
		this._talent = talent;
		bool talentIsAvailable = talent.IsAvaliable(adventurer);
		int currentLevel = talent.GetCurrentLevel();
		this.Cover.SetActive(!talentIsAvailable);
		this.AllButtons.ForEach(delegate(Button b)
		{
			b.interactable = talentIsAvailable;
		});
		if (!talentIsAvailable && currentLevel > 0)
		{
			this.Cover.SetActive(false);
		}
		AdventurerTalentType correspondingType = talent.GetCorrespondingType();
		if (correspondingType == AdventurerTalentType.AttributeBoostOnKillByRate)
		{
			AttributeBoostOnKillTalentByRate attributeBoostOnKillTalentByRate = talent as AttributeBoostOnKillTalentByRate;
			List<BoostSetting> boosts = attributeBoostOnKillTalentByRate.GetBoosts();
			if (boosts[0].BoostAttribute == AttributeType.Allresistances)
			{
				this.SkillIcon.sprite = FilePath.DghzSprites[89];
			}
			else
			{
				this.SkillIcon.sprite = FilePath.DghzSprites[81];
			}
		}
		else if (correspondingType == AdventurerTalentType.BrightCircleBoostEnhancement)
		{
			BrightCircleBoostEnhancementTalent brightCircleBoostEnhancementTalent = talent as BrightCircleBoostEnhancementTalent;
			AttributeType attributeType = brightCircleBoostEnhancementTalent.GetAttributeType();
			if (attributeType == AttributeType.HealingAbsorbRate)
			{
				this.SkillIcon.sprite = FilePath.DghzSprites[70];
			}
			else
			{
				this.SkillIcon.sprite = FilePath.DghzSprites[75];
			}
		}
		else if (correspondingType == AdventurerTalentType.AttributeDebuffByRateOnHit)
		{
			AttributeDebuffByRateOnHitTalent attributeDebuffByRateOnHitTalent = talent as AttributeDebuffByRateOnHitTalent;
			List<BoostSetting> debuffs = attributeDebuffByRateOnHitTalent.GetDebuffs();
			if (debuffs.Count > 0)
			{
				AttributeType boostAttribute = debuffs[0].BoostAttribute;
				if (boostAttribute == AttributeType.Allresistances)
				{
					this.SkillIcon.sprite = FilePath.PutumnoIcons[159];
				}
				else if (boostAttribute == AttributeType.Agility)
				{
					this.SkillIcon.sprite = FilePath.PutumnoIcons[193];
				}
				else if (boostAttribute == AttributeType.Resilience)
				{
					this.SkillIcon.sprite = FilePath.PutumnoIcons[400];
				}
				else if (boostAttribute == AttributeType.Intelligience)
				{
					this.SkillIcon.sprite = FilePath.PutumnoIcons[172];
				}
				else
				{
					this.SkillIcon.sprite = FilePath.GetAdventurerTalentIcon(correspondingType);
				}
			}
			else
			{
				this.SkillIcon.sprite = FilePath.GetAdventurerTalentIcon(correspondingType);
			}
		}
		else if (correspondingType == AdventurerTalentType.ActiveTargetDebuff)
		{
			TacticTargetAttributeDebuffTalent tacticTargetAttributeDebuffTalent = talent as TacticTargetAttributeDebuffTalent;
			AttributeBuff buff = tacticTargetAttributeDebuffTalent.GetBuff();
			AttributeType attributeType2 = buff.AttributeType;
			if (attributeType2 != AttributeType.HitRateAdjustment)
			{
				if (attributeType2 != AttributeType.DodgeRateAdjustment)
				{
					if (attributeType2 != AttributeType.Allresistances)
					{
						if (attributeType2 == AttributeType.Resilience)
						{
							this.SkillIcon.sprite = FilePath.PutumnoIcons[773];
						}
					}
					else
					{
						this.SkillIcon.sprite = FilePath.PutumnoIcons[772];
					}
				}
				else
				{
					this.SkillIcon.sprite = FilePath.PutumnoIcons[770];
				}
			}
			else
			{
				this.SkillIcon.sprite = FilePath.PutumnoIcons[771];
			}
		}
		else if (correspondingType == AdventurerTalentType.TargetSelectionBuff)
		{
			TargetSelectionBuffTalent targetSelectionBuffTalent = talent as TargetSelectionBuffTalent;
			AttributeBuff buff2 = targetSelectionBuffTalent.GetBuff();
			AttributeType attributeType3 = buff2.AttributeType;
			switch (attributeType3)
			{
			case AttributeType.HitRateAdjustment:
				this.SkillIcon.sprite = FilePath.PutumnoIcons[775];
				break;
			case AttributeType.DodgeRateAdjustment:
				this.SkillIcon.sprite = FilePath.PutumnoIcons[774];
				break;
			case AttributeType.EffectHitRating:
				this.SkillIcon.sprite = FilePath.PutumnoIcons[779];
				break;
			case AttributeType.EffectResistanceRating:
				this.SkillIcon.sprite = FilePath.PutumnoIcons[778];
				break;
			default:
				if (attributeType3 != AttributeType.Allresistances)
				{
					if (attributeType3 == AttributeType.Resilience)
					{
						this.SkillIcon.sprite = FilePath.PutumnoIcons[777];
					}
				}
				else
				{
					this.SkillIcon.sprite = FilePath.PutumnoIcons[776];
				}
				break;
			}
		}
		else if (correspondingType == AdventurerTalentType.SpiritOfDemonBoost)
		{
			SpiritOfDemonPetTalent spiritOfDemonPetTalent = talent as SpiritOfDemonPetTalent;
			UnitClass petType = spiritOfDemonPetTalent.GetPetType();
			if (petType != UnitClass.ConjourerSpiritRed)
			{
				if (petType != UnitClass.ConjourerSpiritBlue)
				{
					if (petType == UnitClass.ConjourerSpiritGreen)
					{
						this.SkillIcon.sprite = FilePath.DghzSprites[1863];
					}
				}
				else
				{
					this.SkillIcon.sprite = FilePath.DghzSprites[1847];
				}
			}
			else
			{
				this.SkillIcon.sprite = FilePath.DghzSprites[1988];
			}
		}
		else if (correspondingType == AdventurerTalentType.ActiveTargetAttributeDecayPriorCast)
		{
			PriorCastDecayTalent priorCastDecayTalent = talent as PriorCastDecayTalent;
			AttributeBuff buff3 = priorCastDecayTalent.GetBuff();
			if (buff3.AttributeType == AttributeType.Allresistances)
			{
				this.SkillIcon.sprite = FilePath.PutumnoIcons[772];
			}
			else if (buff3.AttributeType == AttributeType.Resilience)
			{
				this.SkillIcon.sprite = FilePath.PutumnoIcons[773];
			}
		}
		else if (correspondingType == AdventurerTalentType.GrandMeteoroliteElementalChange)
		{
			MeteoroliteElementalTalent meteoroliteElementalTalent = talent as MeteoroliteElementalTalent;
			OutputType changeType = meteoroliteElementalTalent.GetChangeType();
			if (changeType == OutputType.Ice)
			{
				this.SkillIcon.sprite = FilePath.DghzSprites[1910];
			}
			else if (changeType == OutputType.Poison)
			{
				this.SkillIcon.sprite = FilePath.DghzSprites[1943];
			}
		}
		else
		{
			this.SkillIcon.sprite = FilePath.GetAdventurerTalentIcon(correspondingType);
		}
		this.LevelText.text = currentLevel + "/" + talent.GetMaxLevel();
		this.LevelText.color = ((currentLevel <= 0) ? Color.white : Color.green);
	}

	// Token: 0x06000CC2 RID: 3266 RVA: 0x0008BC60 File Offset: 0x0008A060
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._talent == null)
		{
			return;
		}
		Description description = this._talent.GetDescription();
		this.OpenTooltip(new TooltipItem
		{
			Title = description.Title,
			Description = ColorPicker.ReplaceSkillTag(description.Details1),
			Position = base.transform.position
		}, null, TooltipPosition.None, 0f, 0f);
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x0008BCCC File Offset: 0x0008A0CC
	public void OnPointerExit(PointerEventData eventData)
	{
		this.CloseTooltip();
	}

	// Token: 0x06000CC4 RID: 3268 RVA: 0x0008BCD4 File Offset: 0x0008A0D4
	public void SelectTalentSkill()
	{
		if (this._talent == null)
		{
			return;
		}
		base.GetComponentInParent<HeroMenuController>().UpgradeTalent(this._talent);
	}

	// Token: 0x04000EE0 RID: 3808
	public Image SkillIcon;

	// Token: 0x04000EE1 RID: 3809
	public Image Frame;

	// Token: 0x04000EE2 RID: 3810
	public GameObject Cover;

	// Token: 0x04000EE3 RID: 3811
	public Color UnselectedColor;

	// Token: 0x04000EE4 RID: 3812
	public TextMeshProUGUI LevelText;

	// Token: 0x04000EE5 RID: 3813
	public List<Button> AllButtons;

	// Token: 0x04000EE6 RID: 3814
	private IAdventurerTalent _talent;

	// Token: 0x02000C3A RID: 3130
	[CompilerGenerated]
	private sealed class <Init>c__AnonStorey0
	{
		// Token: 0x0600524D RID: 21069 RVA: 0x0008BCF3 File Offset: 0x0008A0F3
		public <Init>c__AnonStorey0()
		{
		}

		// Token: 0x0600524E RID: 21070 RVA: 0x0008BCFB File Offset: 0x0008A0FB
		internal void <>m__0(Button b)
		{
			b.interactable = this.talentIsAvailable;
		}

		// Token: 0x04004043 RID: 16451
		internal bool talentIsAvailable;
	}
}
