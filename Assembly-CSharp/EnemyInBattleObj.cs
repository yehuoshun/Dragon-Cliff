using System;
using System.Collections.Generic;
using System.Linq;

// Token: 0x02000358 RID: 856
public class EnemyInBattleObj : InBattleUnitPanelObj
{
	// Token: 0x060016E4 RID: 5860 RVA: 0x000B4210 File Offset: 0x000B2610
	public EnemyInBattleObj()
	{
	}

	// Token: 0x060016E5 RID: 5861 RVA: 0x000B4218 File Offset: 0x000B2618
	public void SetEnemy(EnemyBattleUnit EnemyBattleUnit, HeroInBattleInfoController controller, BattleEncounter encounter, ProgressIndicatorController progressIndicator, bool isInvasion = false)
	{
		this._enemyBattleUnit = EnemyBattleUnit;
		this.SetupEnemy();
		base.SetCorresponseBattleUnit(EnemyBattleUnit, controller, encounter, progressIndicator);
	}

	// Token: 0x060016E6 RID: 5862 RVA: 0x000B4234 File Offset: 0x000B2634
	private void SetupEnemy()
	{
		this.Avatar.gameObject.SetActive(true);
		this.Avatar.sprite = FilePath.GetEnemyAvatarByUnitType(this._enemyBattleUnit.BattleEnemyClass);
		List<AdventureUnitSkill> skillImages = this._enemyBattleUnit.Skills.ToList<AdventureUnitSkill>();
		this.SetSkillImages(skillImages);
	}

	// Token: 0x060016E7 RID: 5863 RVA: 0x000B4285 File Offset: 0x000B2685
	public override void UpdateUnitHealth()
	{
		this.EnemyAttackOutputInBattle.SetOutputCapacityOnly(this._enemyBattleUnit);
		this.EnemyAttackOutputInBattle.SetBasicValues(this._enemyBattleUnit.GetAttributeDisplayValues(AttributeRetrievalLevel.Skill));
		base.UpdateUnitHealth();
	}

	// Token: 0x040016FA RID: 5882
	private EnemyBattleUnit _enemyBattleUnit;

	// Token: 0x040016FB RID: 5883
	public ItemControl[] Items;

	// Token: 0x040016FC RID: 5884
	public AdventurerAttackOutputInBattle EnemyAttackOutputInBattle;
}
