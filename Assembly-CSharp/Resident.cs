using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x020004FC RID: 1276
[Serializable]
public class Resident : ITraveller
{
	// Token: 0x060025D1 RID: 9681 RVA: 0x0011199F File Offset: 0x0010FD9F
	public Resident()
	{
	}

	// Token: 0x170002A3 RID: 675
	// (get) Token: 0x060025D2 RID: 9682 RVA: 0x001119A7 File Offset: 0x0010FDA7
	// (set) Token: 0x060025D3 RID: 9683 RVA: 0x001119AF File Offset: 0x0010FDAF
	public List<IResidentEffect> Effects
	{
		[CompilerGenerated]
		get
		{
			return this.<Effects>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Effects>k__BackingField = value;
		}
	}

	// Token: 0x060025D4 RID: 9684 RVA: 0x001119B8 File Offset: 0x0010FDB8
	public ResidentHappinessRecord GetCorrespondingHappinessRecordOrNull(TownEventType type)
	{
		if (this.HappinessCache == null)
		{
			this.CacheHappiness();
		}
		if (this.HappinessCache.ContainsKey(type))
		{
			return this.HappinessCache[type];
		}
		return null;
	}

	// Token: 0x060025D5 RID: 9685 RVA: 0x001119EC File Offset: 0x0010FDEC
	private void CacheHappiness()
	{
		this.HappinessCache = new Dictionary<TownEventType, ResidentHappinessRecord>();
		foreach (ResidentHappinessRecord residentHappinessRecord in this.GetHappinessRecords())
		{
			this.HappinessCache[residentHappinessRecord.RelevantType] = residentHappinessRecord;
		}
	}

	// Token: 0x060025D6 RID: 9686 RVA: 0x00111A60 File Offset: 0x0010FE60
	private List<ResidentHappinessRecord> GetHappinessRecords()
	{
		if (this.HappinessRecords != null && this.HappinessRecords.Count != 0)
		{
			if (!this.HappinessRecords.Any((ResidentHappinessRecord r) => r.ToleranceRatio == 0.0))
			{
				goto IL_255;
			}
		}
		this.HappinessRecords = new List<ResidentHappinessRecord>
		{
			new ResidentHappinessRecord
			{
				CurrentContributedValue = 0.0,
				IsInCoolingDown = false,
				RelevantType = TownEventType.TeaParty,
				ToleranceRatio = (double)UnityEngine.Random.Range(1f, 3f)
			},
			new ResidentHappinessRecord
			{
				CurrentContributedValue = 0.0,
				IsInCoolingDown = false,
				RelevantType = TownEventType.Banquet,
				ToleranceRatio = (double)UnityEngine.Random.Range(1f, 3f)
			},
			new ResidentHappinessRecord
			{
				CurrentContributedValue = 0.0,
				IsInCoolingDown = false,
				RelevantType = TownEventType.Drumming,
				ToleranceRatio = (double)UnityEngine.Random.Range(1f, 3f)
			},
			new ResidentHappinessRecord
			{
				IsInCoolingDown = false,
				CurrentContributedValue = 0.0,
				RelevantType = TownEventType.Meditation,
				ToleranceRatio = (double)UnityEngine.Random.Range(1f, 3f)
			},
			new ResidentHappinessRecord
			{
				IsInCoolingDown = false,
				CurrentContributedValue = 0.0,
				RelevantType = TownEventType.PoetryParty,
				ToleranceRatio = (double)UnityEngine.Random.Range(1f, 3f)
			},
			new ResidentHappinessRecord
			{
				IsInCoolingDown = false,
				CurrentContributedValue = 0.0,
				RelevantType = TownEventType.Trade,
				ToleranceRatio = (double)UnityEngine.Random.Range(1f, 3f)
			},
			new ResidentHappinessRecord
			{
				IsInCoolingDown = false,
				CurrentContributedValue = 0.0,
				RelevantType = TownEventType.Alchemy,
				ToleranceRatio = (double)UnityEngine.Random.Range(1f, 3f)
			},
			new ResidentHappinessRecord
			{
				IsInCoolingDown = false,
				CurrentContributedValue = 0.0,
				RelevantType = TownEventType.ArmoryResearch,
				ToleranceRatio = (double)UnityEngine.Random.Range(1f, 3f)
			}
		};
		IL_255:
		return this.HappinessRecords;
	}

	// Token: 0x060025D7 RID: 9687 RVA: 0x00111CC8 File Offset: 0x001100C8
	public void LevelUp(int upgradeLevels = 1)
	{
	}

	// Token: 0x060025D8 RID: 9688 RVA: 0x00111CCC File Offset: 0x001100CC
	public bool AddHappiness(double value, TownEventType type)
	{
		ResidentHappinessRecord correspondingHappinessRecordOrNull = this.GetCorrespondingHappinessRecordOrNull(type);
		if (correspondingHappinessRecordOrNull != null)
		{
			if (correspondingHappinessRecordOrNull.CanAddHappiness())
			{
				correspondingHappinessRecordOrNull.AddContribution(value);
				this.AddHappinessValue(value);
				return true;
			}
			correspondingHappinessRecordOrNull.DailyCoolDownWhileERventActive();
		}
		return false;
	}

	// Token: 0x060025D9 RID: 9689 RVA: 0x00111D0C File Offset: 0x0011010C
	public void AddHappinessValue(double value)
	{
		this.HappinessValue += value;
		if (this.HappinessValue >= 100.0)
		{
			this.HappinessValue = 0.0;
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.ResidentHappinessReached, this);
			this.Type.GetResidentBase().TriggerHappyState(this);
		}
	}

	// Token: 0x060025DA RID: 9690 RVA: 0x00111D6D File Offset: 0x0011016D
	public bool CanLevelUp()
	{
		return false;
	}

	// Token: 0x060025DB RID: 9691 RVA: 0x00111D70 File Offset: 0x00110170
	public string GetId()
	{
		return this.Id;
	}

	// Token: 0x060025DC RID: 9692 RVA: 0x00111D78 File Offset: 0x00110178
	public List<JourneyContributionModifier> GetContributions()
	{
		if (this.JourneyContributionModifiers == null)
		{
			return new List<JourneyContributionModifier>();
		}
		return this.JourneyContributionModifiers;
	}

	// Token: 0x060025DD RID: 9693 RVA: 0x00111D91 File Offset: 0x00110191
	[CompilerGenerated]
	private static bool <GetHappinessRecords>m__0(ResidentHappinessRecord r)
	{
		return r.ToleranceRatio == 0.0;
	}

	// Token: 0x04002099 RID: 8345
	public string Id;

	// Token: 0x0400209A RID: 8346
	public ResidentType Type;

	// Token: 0x0400209B RID: 8347
	public QualityGrade Grade;

	// Token: 0x0400209C RID: 8348
	public int Level;

	// Token: 0x0400209D RID: 8349
	public int UntilLevelUpDaysCounter;

	// Token: 0x0400209E RID: 8350
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<IResidentEffect> <Effects>k__BackingField;

	// Token: 0x0400209F RID: 8351
	public double GeneratedOnDifficultyValue;

	// Token: 0x040020A0 RID: 8352
	public List<JourneyContributionModifier> JourneyContributionModifiers;

	// Token: 0x040020A1 RID: 8353
	public int? GeneratedOnStarRating;

	// Token: 0x040020A2 RID: 8354
	public List<ResidentHappinessRecord> HappinessRecords;

	// Token: 0x040020A3 RID: 8355
	public double HappinessValue;

	// Token: 0x040020A4 RID: 8356
	[NonSerialized]
	public Dictionary<TownEventType, ResidentHappinessRecord> HappinessCache;

	// Token: 0x040020A5 RID: 8357
	[CompilerGenerated]
	private static Func<ResidentHappinessRecord, bool> <>f__am$cache0;
}
