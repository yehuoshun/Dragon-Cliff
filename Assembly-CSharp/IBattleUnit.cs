using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x02000445 RID: 1093
public interface IBattleUnit : IBattleEffectSource
{
	// Token: 0x06001E74 RID: 7796
	OutputType GetOutputType();

	// Token: 0x06001E75 RID: 7797
	void RegisterEventCallbackFromUiLayer(Func<IBattleUnit, AdventureEventType, object, IEnumerable> callback);

	// Token: 0x06001E76 RID: 7798
	void RemoveAllEventCallbackFromUiLayer();

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x06001E77 RID: 7799
	double TurnProgress { get; }

	// Token: 0x1700019D RID: 413
	// (get) Token: 0x06001E78 RID: 7800
	// (set) Token: 0x06001E79 RID: 7801
	double HealthPoints { get; set; }

	// Token: 0x1700019E RID: 414
	// (get) Token: 0x06001E7A RID: 7802
	// (set) Token: 0x06001E7B RID: 7803
	List<BattleEffectBase> BattleEffects { get; set; }

	// Token: 0x1700019F RID: 415
	// (get) Token: 0x06001E7C RID: 7804
	// (set) Token: 0x06001E7D RID: 7805
	BattleUnitStatus Status { get; set; }

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x06001E7E RID: 7806
	Adventure CurrentAdventure { get; }

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x06001E7F RID: 7807
	bool IsPlayer { get; }

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x06001E80 RID: 7808
	QualityGrade Grade { get; }

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x06001E81 RID: 7809
	List<Item> Items { get; }

	// Token: 0x06001E82 RID: 7810
	string GetId();

	// Token: 0x06001E83 RID: 7811
	UnitClass GetUnitType();

	// Token: 0x06001E84 RID: 7812
	UnitClassStyle GetUnitClassStyle();

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x06001E85 RID: 7813
	Dictionary<AttributeType, double> NakedAttributeValues { get; }

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x06001E86 RID: 7814
	Dictionary<AttributeType, double> GearedAttributeValues { get; }

	// Token: 0x06001E87 RID: 7815
	bool IsBoss();

	// Token: 0x170001A6 RID: 422
	// (get) Token: 0x06001E88 RID: 7816
	List<AdventureUnitSkill> Skills { get; }

	// Token: 0x170001A7 RID: 423
	// (get) Token: 0x06001E89 RID: 7817
	IEncounter CurrentEncounter { get; }

	// Token: 0x170001A8 RID: 424
	// (get) Token: 0x06001E8A RID: 7818
	double Level { get; }

	// Token: 0x06001E8B RID: 7819
	IEnumerable LeavesEncounter();

	// Token: 0x06001E8C RID: 7820
	IEnumerable SelfEventCallback(IBattleUnit battleUnit, AdventureEventType arg1, object arg2);

	// Token: 0x170001A9 RID: 425
	// (get) Token: 0x06001E8D RID: 7821
	List<ISpecialEffectDataLoad> SpecialEffects { get; }

	// Token: 0x06001E8E RID: 7822
	List<AttributeModifier> GetModifiers();
}
