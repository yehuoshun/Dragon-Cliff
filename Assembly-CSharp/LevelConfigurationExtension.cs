using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000498 RID: 1176
public static class LevelConfigurationExtension
{
	// Token: 0x060022AF RID: 8879 RVA: 0x000FEB64 File Offset: 0x000FCF64
	public static int GetMaxAchieveableLevel(this AdventureType type)
	{
		if (type == AdventureType.Endless_Entry)
		{
			return 1000000;
		}
		LevelConfigurationBase configuration = type.GetConfiguration();
		return DifficultyLevelMeasurement.GetMaxNumberOfLevels(configuration.StartingDifficultyLevel, configuration.EndingDifficultyLevel);
	}

	// Token: 0x060022B0 RID: 8880 RVA: 0x000FEB98 File Offset: 0x000FCF98
	public static int GetMaxVisibleLevel(this AdventureType type)
	{
		int currentAchievedLevel = GameWorld.instance.PlayerProfile.GetDungeonRecord(type).GetCurrentAchievedLevel();
		int num = currentAchievedLevel + 1;
		return (num > type.GetMaxAchieveableLevel()) ? type.GetMaxAchieveableLevel() : num;
	}

	// Token: 0x060022B1 RID: 8881 RVA: 0x000FEBD8 File Offset: 0x000FCFD8
	public static List<DungeonLevelDetails> GetLevelDetails(this AdventureType type)
	{
		List<DungeonLevelDetails> list = new List<DungeonLevelDetails>();
		for (int i = 1; i <= type.GetMaxVisibleLevel(); i++)
		{
			DifficultyLevelMeasurement difficultyLevelMeasurementByDungeonLevel = DifficultyLevelMeasurement.GetDifficultyLevelMeasurementByDungeonLevel(i, type, GameWorld.instance.PlayerProfile.GetStarRating());
			list.Add(new DungeonLevelDetails
			{
				LevelNumber = i,
				EquipmentLevel = difficultyLevelMeasurementByDungeonLevel.GetDropableEquipmentLevel(),
				GemLevel = difficultyLevelMeasurementByDungeonLevel.GemTier
			});
		}
		return list;
	}

	// Token: 0x060022B2 RID: 8882 RVA: 0x000FEC46 File Offset: 0x000FD046
	public static T WeightedRandomSelect<T>(this IEnumerable<T> presences) where T : IPresentable
	{
		return Possibility<T>.Select(presences.ToList<T>());
	}

	// Token: 0x060022B3 RID: 8883 RVA: 0x000FEC54 File Offset: 0x000FD054
	public static List<T> WeightedRandomSelectMaxUniqueness<T>(this List<T> presences, Func<T, T, bool> equalityFunc, int numberOfSelections) where T : IPresentable
	{
		List<T> list = (from p in presences
		select p).ToList<T>();
		if (!list.Any<T>())
		{
			return new List<T>();
		}
		List<T> list2 = new List<T>();
		for (int i = 0; i < numberOfSelections; i++)
		{
			T item = list.WeightedRandomSelect<T>();
			list2.Add(item);
			list.Remove(list.First((T p) => equalityFunc(p, item)));
			if (!list.Any<T>())
			{
				list = (from p in presences
				select p).ToList<T>();
			}
		}
		return list2;
	}

	// Token: 0x060022B4 RID: 8884 RVA: 0x000FED18 File Offset: 0x000FD118
	public static List<T> WeightedRandomSelectMaxUniquenessNoRepeat<T>(this List<T> presences, Func<T, T, bool> equalityFunc, int numberOfSelections) where T : IPresentable
	{
		List<T> list = (from p in presences
		select p).ToList<T>();
		if (!list.Any<T>())
		{
			return new List<T>();
		}
		List<T> list2 = new List<T>();
		int num = 0;
		while (num < numberOfSelections && list.Any<T>())
		{
			T item = list.WeightedRandomSelect<T>();
			list2.Add(item);
			list.Remove(list.First((T p) => equalityFunc(p, item)));
			num++;
		}
		return list2;
	}

	// Token: 0x060022B5 RID: 8885 RVA: 0x000FEDC2 File Offset: 0x000FD1C2
	public static AdventureLevelConfiguration GetAdventureLevelConfiguration(this AdventureType type, int level)
	{
		return type.GetConfiguration().GetLevel(level);
	}

	// Token: 0x060022B6 RID: 8886 RVA: 0x000FEDD0 File Offset: 0x000FD1D0
	// Note: this type is marked as 'beforefieldinit'.
	static LevelConfigurationExtension()
	{
	}

	// Token: 0x060022B7 RID: 8887 RVA: 0x000FEE08 File Offset: 0x000FD208
	[CompilerGenerated]
	private static T <WeightedRandomSelectMaxUniqueness<T>(T p) where T : IPresentable
	{
		return p;
	}

	// Token: 0x060022B8 RID: 8888 RVA: 0x000FEE0B File Offset: 0x000FD20B
	[CompilerGenerated]
	private static T <WeightedRandomSelectMaxUniqueness<T>(T p) where T : IPresentable
	{
		return p;
	}

	// Token: 0x060022B9 RID: 8889 RVA: 0x000FEE0E File Offset: 0x000FD20E
	[CompilerGenerated]
	private static T <WeightedRandomSelectMaxUniquenessNoRepeat<T>(T p) where T : IPresentable
	{
		return p;
	}

	// Token: 0x060022BA RID: 8890 RVA: 0x000FEE11 File Offset: 0x000FD211
	[CompilerGenerated]
	private static AdventureType <AdventureConfigurations>m__3(LevelConfigurationBase l)
	{
		return l.CorrespondingAdventureType;
	}

	// Token: 0x060022BB RID: 8891 RVA: 0x000FEE19 File Offset: 0x000FD219
	[CompilerGenerated]
	private static int <LevelResolvers>m__4(AdventureResolverBase r)
	{
		return r.ResolverPrecedenceValue();
	}

	// Token: 0x04001E26 RID: 7718
	public static Dictionary<AdventureType, LevelConfigurationBase> AdventureConfigurations = ItemExtensions.GetDictionaryOfAbastract<AdventureType, LevelConfigurationBase>((LevelConfigurationBase l) => l.CorrespondingAdventureType);

	// Token: 0x04001E27 RID: 7719
	public static List<AdventureResolverBase> LevelResolvers = (from r in GameConfigurations.GetImplementationsOfAbstractClass<AdventureResolverBase>()
	orderby r.ResolverPrecedenceValue() descending
	select r).ToList<AdventureResolverBase>();

	// Token: 0x02000D7F RID: 3455
	[CompilerGenerated]
	private sealed class <WeightedRandomSelectMaxUniqueness>c__AnonStorey0<T> where T : IPresentable
	{
		// Token: 0x060057E4 RID: 22500 RVA: 0x000FEE21 File Offset: 0x000FD221
		public <WeightedRandomSelectMaxUniqueness>c__AnonStorey0()
		{
		}

		// Token: 0x040047A4 RID: 18340
		internal Func<T, T, bool> equalityFunc;
	}

	// Token: 0x02000D80 RID: 3456
	[CompilerGenerated]
	private sealed class <WeightedRandomSelectMaxUniqueness>c__AnonStorey1<T> where T : IPresentable
	{
		// Token: 0x060057E5 RID: 22501 RVA: 0x000FEE29 File Offset: 0x000FD229
		public <WeightedRandomSelectMaxUniqueness>c__AnonStorey1()
		{
		}

		// Token: 0x060057E6 RID: 22502 RVA: 0x000FEE31 File Offset: 0x000FD231
		internal bool <>m__0(T p)
		{
			return this.<>f__ref$0.equalityFunc(p, this.item);
		}

		// Token: 0x040047A5 RID: 18341
		internal T item;

		// Token: 0x040047A6 RID: 18342
		internal LevelConfigurationExtension.<WeightedRandomSelectMaxUniqueness>c__AnonStorey0<T> <>f__ref$0;
	}

	// Token: 0x02000D81 RID: 3457
	[CompilerGenerated]
	private sealed class <WeightedRandomSelectMaxUniquenessNoRepeat>c__AnonStorey2<T> where T : IPresentable
	{
		// Token: 0x060057E7 RID: 22503 RVA: 0x000FEE4A File Offset: 0x000FD24A
		public <WeightedRandomSelectMaxUniquenessNoRepeat>c__AnonStorey2()
		{
		}

		// Token: 0x040047A7 RID: 18343
		internal Func<T, T, bool> equalityFunc;
	}

	// Token: 0x02000D82 RID: 3458
	[CompilerGenerated]
	private sealed class <WeightedRandomSelectMaxUniquenessNoRepeat>c__AnonStorey3<T> where T : IPresentable
	{
		// Token: 0x060057E8 RID: 22504 RVA: 0x000FEE52 File Offset: 0x000FD252
		public <WeightedRandomSelectMaxUniquenessNoRepeat>c__AnonStorey3()
		{
		}

		// Token: 0x060057E9 RID: 22505 RVA: 0x000FEE5A File Offset: 0x000FD25A
		internal bool <>m__0(T p)
		{
			return this.<>f__ref$2.equalityFunc(p, this.item);
		}

		// Token: 0x040047A8 RID: 18344
		internal T item;

		// Token: 0x040047A9 RID: 18345
		internal LevelConfigurationExtension.<WeightedRandomSelectMaxUniquenessNoRepeat>c__AnonStorey2<T> <>f__ref$2;
	}
}
