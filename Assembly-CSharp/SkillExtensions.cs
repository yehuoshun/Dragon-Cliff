using System;
using System.Collections.Generic;

// Token: 0x0200049D RID: 1181
public static class SkillExtensions
{
	// Token: 0x06002317 RID: 8983 RVA: 0x001011C4 File Offset: 0x000FF5C4
	public static Skill CreatePlayerSkill(this SkillType skillType)
	{
		SkillLogicBase skillLogic = skillType.GetSkillLogic();
		int level = skillType.GetLevel();
		return new Skill
		{
			Level = level,
			SkillType = skillType,
			CommandType = skillLogic.SkillCommandType,
			IsEnabled = false
		};
	}

	// Token: 0x06002318 RID: 8984 RVA: 0x00101208 File Offset: 0x000FF608
	public static Skill CreateMonsterSkill(this SkillType skillType, int skillLevel)
	{
		SkillLogicBase skillLogic = skillType.GetSkillLogic();
		return new Skill
		{
			Level = skillLevel,
			SkillType = skillType,
			CommandType = skillLogic.SkillCommandType,
			IsEnabled = false
		};
	}

	// Token: 0x06002319 RID: 8985 RVA: 0x00101244 File Offset: 0x000FF644
	public static int GetLevel(this SkillType skilltype)
	{
		if (GameWorld.instance == null || GameWorld.instance.PlayerProfile == null || GameWorld.instance.PlayerProfile.SkillLevels == null)
		{
			return 1;
		}
		if (GameWorld.instance.PlayerProfile.SkillLevels.ContainsKey(skilltype))
		{
			return GameWorld.instance.PlayerProfile.SkillLevels[skilltype];
		}
		GameWorld.instance.PlayerProfile.SkillLevels.Add(skilltype, 1);
		return 1;
	}

	// Token: 0x0600231A RID: 8986 RVA: 0x001012D0 File Offset: 0x000FF6D0
	public static void UpdateSkillLevel(this SkillType skillType, int level)
	{
		if (GameWorld.instance.PlayerProfile.SkillLevels.ContainsKey(skillType))
		{
			GameWorld.instance.PlayerProfile.SkillLevels[skillType] = level;
		}
		else
		{
			GameWorld.instance.PlayerProfile.SkillLevels.Add(skillType, level);
		}
	}

	// Token: 0x0600231B RID: 8987 RVA: 0x00101328 File Offset: 0x000FF728
	public static SkillLogicBase GetSkillLogic(this SkillType type)
	{
		return UnitExtensions.SkillBuilders[type];
	}

	// Token: 0x0600231C RID: 8988 RVA: 0x00101335 File Offset: 0x000FF735
	public static SkillLogicBase GetSkillLogic(this AdventureUnitSkill skill)
	{
		return skill.Skill.SkillType.GetSkillLogic();
	}

	// Token: 0x0600231D RID: 8989 RVA: 0x00101347 File Offset: 0x000FF747
	public static SkillLogicBase GetSkillLogic(this Skill skill)
	{
		return skill.SkillType.GetSkillLogic();
	}

	// Token: 0x0600231E RID: 8990 RVA: 0x00101354 File Offset: 0x000FF754
	// Note: this type is marked as 'beforefieldinit'.
	static SkillExtensions()
	{
	}

	// Token: 0x04001E41 RID: 7745
	public static Dictionary<ResourceType, SkillType> SkillBookDictionary = new Dictionary<ResourceType, SkillType>
	{
		{
			ResourceType.BloodThirstBook,
			SkillType.BloodThirst
		},
		{
			ResourceType.FlameBook,
			SkillType.Flame
		},
		{
			ResourceType.FleshToStoneBook,
			SkillType.FleshToStone
		},
		{
			ResourceType.FlourishBook,
			SkillType.Flourish
		},
		{
			ResourceType.HarmoneyBook,
			SkillType.Harmony
		},
		{
			ResourceType.LightFireBook,
			SkillType.LightFire
		},
		{
			ResourceType.LighteningSpeedBook,
			SkillType.LightningSpeed
		},
		{
			ResourceType.PrincipleBook,
			SkillType.Principle
		},
		{
			ResourceType.RageBook,
			SkillType.Rage
		},
		{
			ResourceType.RebirthBook,
			SkillType.Rebirth
		},
		{
			ResourceType.StaminaBook,
			SkillType.Stamina
		},
		{
			ResourceType.StrayBook,
			SkillType.Stray
		},
		{
			ResourceType.SwiftBook,
			SkillType.Swift
		},
		{
			ResourceType.WaveBook,
			SkillType.Wave
		},
		{
			ResourceType.ReturnSoulBook,
			SkillType.ReturningSoul
		},
		{
			ResourceType.SoulSeekerBook,
			SkillType.SoulSeeker
		}
	};
}
