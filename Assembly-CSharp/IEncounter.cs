using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000446 RID: 1094
public interface IEncounter
{
	// Token: 0x1400000B RID: 11
	// (add) Token: 0x06001E8F RID: 7823
	// (remove) Token: 0x06001E90 RID: 7824
	event Action<List<IBattleUnit>> PlayerWon;

	// Token: 0x1400000C RID: 12
	// (add) Token: 0x06001E91 RID: 7825
	// (remove) Token: 0x06001E92 RID: 7826
	event Action<List<IBattleUnit>> PlayerLost;

	// Token: 0x06001E93 RID: 7827
	List<ResourceUpdate> GetCompletionRewards();

	// Token: 0x170001AA RID: 426
	// (get) Token: 0x06001E94 RID: 7828
	List<IBattleUnit> PlayerUnits { get; }

	// Token: 0x170001AB RID: 427
	// (get) Token: 0x06001E95 RID: 7829
	List<IBattleUnit> EnemyUnits { get; }

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x06001E96 RID: 7830
	bool IsCompleted { get; }

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x06001E97 RID: 7831
	BattleLog Log { get; }

	// Token: 0x06001E98 RID: 7832
	IEnumerable Run();

	// Token: 0x06001E99 RID: 7833
	bool IsPlayerWon();

	// Token: 0x06001E9A RID: 7834
	bool IsPlayerLost();

	// Token: 0x06001E9B RID: 7835
	bool IsWinningConditionMet();

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06001E9C RID: 7836
	Adventure CurrentAdventure { get; }

	// Token: 0x06001E9D RID: 7837
	IEnumerable PerUpdateProcess(float deltaTime);
}
