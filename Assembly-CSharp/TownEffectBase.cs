using System;
using System.Collections.Generic;

// Token: 0x02000995 RID: 2453
[Serializable]
public abstract class TownEffectBase
{
	// Token: 0x06004328 RID: 17192 RVA: 0x001B5029 File Offset: 0x001B3429
	protected TownEffectBase(int? lastingNumberOfDays, int startingOnGameDays)
	{
		this.LastingNumberOfDays = lastingNumberOfDays;
		this.StartingOnGameDays = startingOnGameDays;
	}

	// Token: 0x17000D47 RID: 3399
	// (get) Token: 0x06004329 RID: 17193
	public abstract TownEffectType Type { get; }

	// Token: 0x0600432A RID: 17194 RVA: 0x001B5040 File Offset: 0x001B3440
	public int? RemainingDays()
	{
		if (this.LastingNumberOfDays != null)
		{
			int num = GameWorld.instance.PlayerProfile.GameDays - this.StartingOnGameDays;
			if (num < 0)
			{
				num = 0;
			}
			return new int?(this.LastingNumberOfDays.Value - num);
		}
		return null;
	}

	// Token: 0x0600432B RID: 17195 RVA: 0x001B5099 File Offset: 0x001B3499
	public virtual List<ISpecialEffectDataLoad> GetPlayerEffectsForAdventure()
	{
		return new List<ISpecialEffectDataLoad>();
	}

	// Token: 0x0600432C RID: 17196 RVA: 0x001B50A0 File Offset: 0x001B34A0
	public virtual void PlayerEffectsExtractedOnce()
	{
	}

	// Token: 0x0600432D RID: 17197 RVA: 0x001B50A4 File Offset: 0x001B34A4
	public void ProcessGameEvent(GameWorldEvent evt, object data)
	{
		if (evt == GameWorldEvent.GameDaysChanged && this.LastingNumberOfDays != null)
		{
			int num = GameWorld.instance.PlayerProfile.GameDays - this.StartingOnGameDays;
			if (num >= this.LastingNumberOfDays.Value)
			{
				GameWorld.instance.PlayerProfile.RemoveTownEffect(this);
			}
		}
		this.AdditionalGameEventProcess(evt, data);
	}

	// Token: 0x0600432E RID: 17198 RVA: 0x001B5109 File Offset: 0x001B3509
	protected virtual void AdditionalGameEventProcess(GameWorldEvent evt, object data)
	{
	}

	// Token: 0x0600432F RID: 17199 RVA: 0x001B510C File Offset: 0x001B350C
	protected Description GetLocalization()
	{
		TownEffectLocalization townEffect = LocalizationSession.instance.LocalizationManager.GetTownEffect(this.Type);
		return new Description
		{
			Details1 = townEffect.Description,
			Title = townEffect.Name,
			Details2 = string.Empty
		};
	}

	// Token: 0x06004330 RID: 17200
	public abstract bool CanbeMergedWith(TownEffectBase effect);

	// Token: 0x06004331 RID: 17201
	public abstract void Merge(TownEffectBase effect);

	// Token: 0x06004332 RID: 17202
	public abstract Description GetDescription();

	// Token: 0x04003304 RID: 13060
	public int? LastingNumberOfDays;

	// Token: 0x04003305 RID: 13061
	public int StartingOnGameDays;
}
