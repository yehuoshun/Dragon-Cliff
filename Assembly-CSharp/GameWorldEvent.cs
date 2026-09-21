using System;

// Token: 0x020004AA RID: 1194
public enum GameWorldEvent
{
	// Token: 0x04001E6C RID: 7788
	GameSessionStarted,
	// Token: 0x04001E6D RID: 7789
	GameSessionInitializationCompleted,
	// Token: 0x04001E6E RID: 7790
	AdventurerReceivesProfessionExp,
	// Token: 0x04001E6F RID: 7791
	AdventurerReceivesAdventureExp,
	// Token: 0x04001E70 RID: 7792
	AdventurerProfessionLevelUp,
	// Token: 0x04001E71 RID: 7793
	AdventureLevelUp,
	// Token: 0x04001E72 RID: 7794
	AdventurerSkillPerformed,
	// Token: 0x04001E73 RID: 7795
	AdventurerProductionSkillTriggered,
	// Token: 0x04001E74 RID: 7796
	AdventurerSkillReceivesExp,
	// Token: 0x04001E75 RID: 7797
	AdventurerSkillLevelsUp,
	// Token: 0x04001E76 RID: 7798
	AdventurererStatusChanges,
	// Token: 0x04001E77 RID: 7799
	AdventurerTacticUnlocked,
	// Token: 0x04001E78 RID: 7800
	ResidentUnderMaintainance,
	// Token: 0x04001E79 RID: 7801
	MoneySpent,
	// Token: 0x04001E7A RID: 7802
	TownItemPurchaseMade,
	// Token: 0x04001E7B RID: 7803
	NewQuestReceived,
	// Token: 0x04001E7C RID: 7804
	TributeRefugeePurchaseMadeSuccessfully,
	// Token: 0x04001E7D RID: 7805
	GameStarted,
	// Token: 0x04001E7E RID: 7806
	RandomSideQuestsSpawnTime,
	// Token: 0x04001E7F RID: 7807
	QuestCompleted,
	// Token: 0x04001E80 RID: 7808
	QuestPreCompletion,
	// Token: 0x04001E81 RID: 7809
	QuestExpired,
	// Token: 0x04001E82 RID: 7810
	QuestCancelled,
	// Token: 0x04001E83 RID: 7811
	AdventurerTypeUnloced,
	// Token: 0x04001E84 RID: 7812
	GameDaysChanged,
	// Token: 0x04001E85 RID: 7813
	NewReceipeLearned,
	// Token: 0x04001E86 RID: 7814
	ItemProduced,
	// Token: 0x04001E87 RID: 7815
	LengendaryItemProduced,
	// Token: 0x04001E88 RID: 7816
	AncientItemProduced,
	// Token: 0x04001E89 RID: 7817
	EpicItemProduced,
	// Token: 0x04001E8A RID: 7818
	ResourceUpdated,
	// Token: 0x04001E8B RID: 7819
	QuestRewardReceived,
	// Token: 0x04001E8C RID: 7820
	ItemPutOnSale,
	// Token: 0x04001E8D RID: 7821
	ItemReserved,
	// Token: 0x04001E8E RID: 7822
	ItemEquipped,
	// Token: 0x04001E8F RID: 7823
	AdventurerListUpdated,
	// Token: 0x04001E90 RID: 7824
	RecruitmentListUpdated,
	// Token: 0x04001E91 RID: 7825
	ResidentAdded,
	// Token: 0x04001E92 RID: 7826
	ResidentContributed,
	// Token: 0x04001E93 RID: 7827
	ResidentUpgraded,
	// Token: 0x04001E94 RID: 7828
	ResidentExpelled,
	// Token: 0x04001E95 RID: 7829
	ResidentCandidateAdded,
	// Token: 0x04001E96 RID: 7830
	ResidentCandidateRemoved,
	// Token: 0x04001E97 RID: 7831
	ResidentOccupancyNumberUpdated,
	// Token: 0x04001E98 RID: 7832
	AdventurePreInitialization,
	// Token: 0x04001E99 RID: 7833
	AdventureInitialising,
	// Token: 0x04001E9A RID: 7834
	AdventureInitialized,
	// Token: 0x04001E9B RID: 7835
	AdventureRewarding,
	// Token: 0x04001E9C RID: 7836
	AdventureCompleted,
	// Token: 0x04001E9D RID: 7837
	ReputationIncreased,
	// Token: 0x04001E9E RID: 7838
	ReputationDecreased,
	// Token: 0x04001E9F RID: 7839
	TownTitleUpdated,
	// Token: 0x04001EA0 RID: 7840
	BuildingTypeUnlocked,
	// Token: 0x04001EA1 RID: 7841
	BuildingConstructed,
	// Token: 0x04001EA2 RID: 7842
	BuildingDemolished,
	// Token: 0x04001EA3 RID: 7843
	DungeonNewLevelUnlocked,
	// Token: 0x04001EA4 RID: 7844
	DungeonNewTypeUnlocked,
	// Token: 0x04001EA5 RID: 7845
	WeatherChanged,
	// Token: 0x04001EA6 RID: 7846
	SeasonChanged,
	// Token: 0x04001EA7 RID: 7847
	ShopStockRefreshed,
	// Token: 0x04001EA8 RID: 7848
	PurchaseSuccessful,
	// Token: 0x04001EA9 RID: 7849
	PurchaseFailed,
	// Token: 0x04001EAA RID: 7850
	AdventurerTriggersDialog,
	// Token: 0x04001EAB RID: 7851
	BattleUnitTriggersDialog,
	// Token: 0x04001EAC RID: 7852
	StoryEventTriggerred,
	// Token: 0x04001EAD RID: 7853
	CriticalStoryEventTriggerred,
	// Token: 0x04001EAE RID: 7854
	BattleEncounterRewardsCollected,
	// Token: 0x04001EAF RID: 7855
	TownAutoDialogTriggers,
	// Token: 0x04001EB0 RID: 7856
	TownUpgraded,
	// Token: 0x04001EB1 RID: 7857
	AdventurerPurchased,
	// Token: 0x04001EB2 RID: 7858
	AdventureSnapUpdated,
	// Token: 0x04001EB3 RID: 7859
	InitialRandomSideQuestsPreIssue,
	// Token: 0x04001EB4 RID: 7860
	ItemCombined,
	// Token: 0x04001EB5 RID: 7861
	NewSkillUnlocked,
	// Token: 0x04001EB6 RID: 7862
	RefreshingStock,
	// Token: 0x04001EB7 RID: 7863
	ItemGrowthCompleted,
	// Token: 0x04001EB8 RID: 7864
	ForgeUpgraded,
	// Token: 0x04001EB9 RID: 7865
	SchoolUpgraded,
	// Token: 0x04001EBA RID: 7866
	ChestBlessBoosted,
	// Token: 0x04001EBB RID: 7867
	TripEncounterCollected,
	// Token: 0x04001EBC RID: 7868
	BoatAdded,
	// Token: 0x04001EBD RID: 7869
	NewJourneyStarted,
	// Token: 0x04001EBE RID: 7870
	JourneyCompleted,
	// Token: 0x04001EBF RID: 7871
	InventoryIsFull,
	// Token: 0x04001EC0 RID: 7872
	ShopPackOpenned,
	// Token: 0x04001EC1 RID: 7873
	ResidentHappinessReached,
	// Token: 0x04001EC2 RID: 7874
	TownEventCompleted,
	// Token: 0x04001EC3 RID: 7875
	TownEffectAdded,
	// Token: 0x04001EC4 RID: 7876
	TownEffectRemoved,
	// Token: 0x04001EC5 RID: 7877
	TownEffectGenerated,
	// Token: 0x04001EC6 RID: 7878
	TownEventResourceContributed,
	// Token: 0x04001EC7 RID: 7879
	ResidentPushedEventProgress,
	// Token: 0x04001EC8 RID: 7880
	ResidentBoostedAnotherResidentHappiness
}
