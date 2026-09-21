using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public class GameTimeProcessor : CoreProcessorBase
{
	// Token: 0x060020D1 RID: 8401 RVA: 0x000E2FC8 File Offset: 0x000E13C8
	public GameTimeProcessor()
	{
	}

	// Token: 0x060020D2 RID: 8402 RVA: 0x000E2FD0 File Offset: 0x000E13D0
	public override void Process()
	{
		if (!GameWorld.instance.PlayerProfile.GameStarted)
		{
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.GameStarted, null);
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.GameDaysChanged, new GameDaysChangedEvent
			{
				NewDay = GameWorld.instance.PlayerProfile.GameDays,
				OriginalDay = 0
			});
			GameWorld.instance.PlayerProfile.GameStarted = true;
		}
		GameWorld.instance.PlayerProfile.GameDaysFractional += (double)Time.deltaTime * GameWorld.instance.PlayerProfile.DayRate;
		if ((int)GameWorld.instance.PlayerProfile.GameDaysFractional != GameWorld.instance.PlayerProfile.GameDays)
		{
			int gameDays = GameWorld.instance.PlayerProfile.GameDays;
			GameWorld.instance.PlayerProfile.GameDays = (int)GameWorld.instance.PlayerProfile.GameDaysFractional;
			GameWorld.instance.PlayerProfile.ReceiveEvent(GameWorldEvent.GameDaysChanged, new GameDaysChangedEvent
			{
				NewDay = GameWorld.instance.PlayerProfile.GameDays,
				OriginalDay = gameDays
			});
		}
	}
}
