using System;

// Token: 0x0200042B RID: 1067
public enum AdventureEventType
{
	// Token: 0x04001B3A RID: 6970
	AdventureInitialized,
	// Token: 0x04001B3B RID: 6971
	AdventurerPreWalking,
	// Token: 0x04001B3C RID: 6972
	AdventurersWalking,
	// Token: 0x04001B3D RID: 6973
	AdventurerPostWalking,
	// Token: 0x04001B3E RID: 6974
	UnitRegularTurnStarts,
	// Token: 0x04001B3F RID: 6975
	UnitRegularTurnEnds,
	// Token: 0x04001B40 RID: 6976
	UnitEntersTurn,
	// Token: 0x04001B41 RID: 6977
	UnitSelectsSkill,
	// Token: 0x04001B42 RID: 6978
	UnitSelectedSkill,
	// Token: 0x04001B43 RID: 6979
	UnitCastsSkill,
	// Token: 0x04001B44 RID: 6980
	UnitPostCastSkill,
	// Token: 0x04001B45 RID: 6981
	UnitCompletesTurn,
	// Token: 0x04001B46 RID: 6982
	UnitCompletesAction,
	// Token: 0x04001B47 RID: 6983
	UnitCompletesSkillCast,
	// Token: 0x04001B48 RID: 6984
	UnitEffectTriggered,
	// Token: 0x04001B49 RID: 6985
	UnitReceivesDamage_CompleteSet,
	// Token: 0x04001B4A RID: 6986
	UnitReceivesDamage_Single,
	// Token: 0x04001B4B RID: 6987
	UnitPostReceivesDamage_Single,
	// Token: 0x04001B4C RID: 6988
	UnitDamageNeutralized,
	// Token: 0x04001B4D RID: 6989
	UnitReleasesDamage,
	// Token: 0x04001B4E RID: 6990
	UnitReleasesHeal,
	// Token: 0x04001B4F RID: 6991
	UnitReceivesHeal = 22,
	// Token: 0x04001B50 RID: 6992
	UnitPostReceivesDamage,
	// Token: 0x04001B51 RID: 6993
	UnitPostReceivesHeal,
	// Token: 0x04001B52 RID: 6994
	UnitKilled,
	// Token: 0x04001B53 RID: 6995
	UnitPreKilled,
	// Token: 0x04001B54 RID: 6996
	UnitRevived,
	// Token: 0x04001B55 RID: 6997
	UnitReceivesEffect,
	// Token: 0x04001B56 RID: 6998
	UnitLoosesEffect,
	// Token: 0x04001B57 RID: 6999
	UnitNormalAttack,
	// Token: 0x04001B58 RID: 7000
	BattleEffectDispersed,
	// Token: 0x04001B59 RID: 7001
	BattleEffectResisted,
	// Token: 0x04001B5A RID: 7002
	UnitPreEntersBattle,
	// Token: 0x04001B5B RID: 7003
	UnitReadyInBattle,
	// Token: 0x04001B5C RID: 7004
	PriorUnitTurnProgressChange,
	// Token: 0x04001B5D RID: 7005
	UnitTurnProgressAlterred,
	// Token: 0x04001B5E RID: 7006
	UnitTriggersDialog,
	// Token: 0x04001B5F RID: 7007
	EnemyUnitDropsLoot,
	// Token: 0x04001B60 RID: 7008
	UnitEscaped,
	// Token: 0x04001B61 RID: 7009
	BattleEncounterPlayerGaugeUpdated,
	// Token: 0x04001B62 RID: 7010
	BattleEncounterEnemyGaugeUpdated,
	// Token: 0x04001B63 RID: 7011
	BattleEncounterPlayerGaugeFullyCharged,
	// Token: 0x04001B64 RID: 7012
	BattleEncounterPlayerGaugeReleased,
	// Token: 0x04001B65 RID: 7013
	BattleEncounterEnemyGaugeFullyCharged,
	// Token: 0x04001B66 RID: 7014
	BattleEncounterEnemyGaugeReleased,
	// Token: 0x04001B67 RID: 7015
	ActiveBattleSkillEntersCoolingDowns,
	// Token: 0x04001B68 RID: 7016
	ActiveBattleSkillCompletesCoolingDowns,
	// Token: 0x04001B69 RID: 7017
	BattleEffectTurnProgresses,
	// Token: 0x04001B6A RID: 7018
	ActiveSkillPassiveBecomesAlive,
	// Token: 0x04001B6B RID: 7019
	ActiveSkillPassiveBecomesFades,
	// Token: 0x04001B6C RID: 7020
	AdventureProgresses,
	// Token: 0x04001B6D RID: 7021
	AdventureSuccess,
	// Token: 0x04001B6E RID: 7022
	AdventureFailed,
	// Token: 0x04001B6F RID: 7023
	UnitPreRealKilled,
	// Token: 0x04001B70 RID: 7024
	AdventureStoryTriggered,
	// Token: 0x04001B71 RID: 7025
	BattleEncounterStarts,
	// Token: 0x04001B72 RID: 7026
	AttributeCheckup,
	// Token: 0x04001B73 RID: 7027
	BattleUnitPreDrops,
	// Token: 0x04001B74 RID: 7028
	AdventureEffectTriggered,
	// Token: 0x04001B75 RID: 7029
	UnitCastActiveSkill,
	// Token: 0x04001B76 RID: 7030
	UnitPostCastActiveSkill,
	// Token: 0x04001B77 RID: 7031
	UnitCompleteActiveSkill,
	// Token: 0x04001B78 RID: 7032
	BattleEncounterOptionsTriggered = 64,
	// Token: 0x04001B79 RID: 7033
	BattleUnitSequenceCompleted,
	// Token: 0x04001B7A RID: 7034
	BattleEffectCapStackReached = 67,
	// Token: 0x04001B7B RID: 7035
	BattleUnitHalfLifeLostForTheFirstTime,
	// Token: 0x04001B7C RID: 7036
	DemonSoulFullyCharged,
	// Token: 0x04001B7D RID: 7037
	InversedKillPerformed,
	// Token: 0x04001B7E RID: 7038
	DragonChargeReleased,
	// Token: 0x04001B7F RID: 7039
	UnitBattleDialogueCompleted,
	// Token: 0x04001B80 RID: 7040
	ElementDamageProcessCompleted,
	// Token: 0x04001B81 RID: 7041
	BlackBeadSoulCollected,
	// Token: 0x04001B82 RID: 7042
	TimeFragmentTriggered,
	// Token: 0x04001B83 RID: 7043
	DamageReleased,
	// Token: 0x04001B84 RID: 7044
	TurnSetupCompleted,
	// Token: 0x04001B85 RID: 7045
	PostHealRelease,
	// Token: 0x04001B86 RID: 7046
	ChargeUpdated,
	// Token: 0x04001B87 RID: 7047
	FirstEncounterStarted,
	// Token: 0x04001B88 RID: 7048
	PetSummoned,
	// Token: 0x04001B89 RID: 7049
	PetRemoving,
	// Token: 0x04001B8A RID: 7050
	DamageReleaseProcessCompleted,
	// Token: 0x04001B8B RID: 7051
	EncounterSetupCompleted,
	// Token: 0x04001B8C RID: 7052
	DamagePerSecondTrigger,
	// Token: 0x04001B8D RID: 7053
	UnitPriorTurnStart,
	// Token: 0x04001B8E RID: 7054
	RunePowerCharged,
	// Token: 0x04001B8F RID: 7055
	RunePowerUsed,
	// Token: 0x04001B90 RID: 7056
	AdventureEnergyPointsConsumed,
	// Token: 0x04001B91 RID: 7057
	UnitPreKilledFinal
}
