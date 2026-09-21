using System;

// Token: 0x0200043E RID: 1086
[Serializable]
public class DungeonRecord
{
	// Token: 0x06001E5A RID: 7770 RVA: 0x000D5319 File Offset: 0x000D3719
	private DungeonRecord()
	{
	}

	// Token: 0x06001E5B RID: 7771 RVA: 0x000D5321 File Offset: 0x000D3721
	public bool IsEnabledRecord()
	{
		if (this.AdventureType == AdventureType.Endless_Entry)
		{
			return GameWorld.instance.PlayerProfile.GetResourceQuantity(ResourceType.MysticKey) > 0.0;
		}
		return this.IsEnabled;
	}

	// Token: 0x06001E5C RID: 7772 RVA: 0x000D5358 File Offset: 0x000D3758
	public static DungeonRecord InitLockedRecord(AdventureType type)
	{
		return new DungeonRecord
		{
			AdventureType = type,
			CurrentAchievedLevel = 0,
			CurrentSelectedLevel = 1,
			IsEnabled = false
		};
	}

	// Token: 0x06001E5D RID: 7773 RVA: 0x000D5388 File Offset: 0x000D3788
	public static DungeonRecord InitUnlockedRecord(AdventureType type)
	{
		return new DungeonRecord
		{
			AdventureType = type,
			CurrentAchievedLevel = 0,
			CurrentSelectedLevel = 1,
			IsEnabled = true
		};
	}

	// Token: 0x06001E5E RID: 7774 RVA: 0x000D53B8 File Offset: 0x000D37B8
	public void SetCurrentAchievedLevel(int level)
	{
		if (level > this.CurrentAchievedLevel)
		{
			this.CurrentAchievedLevel = level;
		}
	}

	// Token: 0x06001E5F RID: 7775 RVA: 0x000D53D0 File Offset: 0x000D37D0
	public int GetCurrentAchievedLevel()
	{
		if (this.AdventureType == AdventureType.Endless_Entry)
		{
			return this.CurrentAchievedLevel;
		}
		LevelConfigurationBase configuration = this.AdventureType.GetConfiguration();
		int num = configuration.GetCorrespondingMaxVisibleLevel(GameWorld.instance.PlayerProfile.GetProgress(null).Reputation / 100.0);
		if (num < 0)
		{
			num = 0;
		}
		if (this.CurrentAchievedLevel < num)
		{
			this.CurrentAchievedLevel = num;
		}
		return this.CurrentAchievedLevel;
	}

	// Token: 0x04001BF7 RID: 7159
	public AdventureType AdventureType;

	// Token: 0x04001BF8 RID: 7160
	public bool IsEnabled;

	// Token: 0x04001BF9 RID: 7161
	public int CurrentAchievedLevel;

	// Token: 0x04001BFA RID: 7162
	public int CurrentSelectedLevel;
}
