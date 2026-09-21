using System;
using System.Collections.Generic;

// Token: 0x02000495 RID: 1173
public static class FactionExtensions
{
	// Token: 0x0600223D RID: 8765 RVA: 0x000F90E8 File Offset: 0x000F74E8
	public static Dictionary<GameFactionType, IFactionProcessor> GetFactionProcessors()
	{
		Dictionary<GameFactionType, IFactionProcessor> dictionary = new Dictionary<GameFactionType, IFactionProcessor>();
		List<IFactionProcessor> implementationsOfInterface = GameConfigurations.GetImplementationsOfInterface<IFactionProcessor>();
		foreach (IFactionProcessor factionProcessor in implementationsOfInterface)
		{
			if (!dictionary.ContainsKey(factionProcessor.CorrespondingGameFactionType))
			{
				dictionary.Add(factionProcessor.CorrespondingGameFactionType, factionProcessor);
			}
		}
		return dictionary;
	}

	// Token: 0x0600223E RID: 8766 RVA: 0x000F9164 File Offset: 0x000F7564
	public static IFactionProcessor GetProcessor(this GameFactionType type)
	{
		return FactionExtensions.FactionProcessors[type];
	}

	// Token: 0x0600223F RID: 8767 RVA: 0x000F9171 File Offset: 0x000F7571
	// Note: this type is marked as 'beforefieldinit'.
	static FactionExtensions()
	{
	}

	// Token: 0x04001DF3 RID: 7667
	public static Dictionary<GameFactionType, IFactionProcessor> FactionProcessors = FactionExtensions.GetFactionProcessors();
}
