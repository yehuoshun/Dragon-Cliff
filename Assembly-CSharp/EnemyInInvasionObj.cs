using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000359 RID: 857
public class EnemyInInvasionObj : HeroInBattleObj
{
	// Token: 0x060016E8 RID: 5864 RVA: 0x000B4465 File Offset: 0x000B2865
	public EnemyInInvasionObj()
	{
	}

	// Token: 0x060016E9 RID: 5865 RVA: 0x000B446D File Offset: 0x000B286D
	public void SetInvasionEnemy(EnemyBattleUnit EnemyBattleUnit, HeroInBattleInfoController controller, BattleEncounter encounter, ProgressIndicatorController progressIndicator)
	{
		this._enemyBattleUnit = EnemyBattleUnit;
		this.UpdateAttackOutputValues();
		base.SetCorresponseBattleUnit(EnemyBattleUnit, controller, encounter, progressIndicator);
		this.SetItemsImages();
		this.SetAdventurerSkillImages();
	}

	// Token: 0x060016EA RID: 5866 RVA: 0x000B4494 File Offset: 0x000B2894
	public override void SetItemsImages()
	{
		List<Item> items = this._enemyBattleUnit.Items;
		int i;
		for (i = 0; i < this.Items.Length; i++)
		{
			Item item = items.FirstOrDefault((Item e) => e.SlotType == i + ItemType.Weapon);
			if (item != null)
			{
				this.Items[i].SetItem(item, false);
			}
			else
			{
				this.Items[i].SetDefaultItem(i + EquipmentType.Weapon);
			}
		}
	}

	// Token: 0x060016EB RID: 5867 RVA: 0x000B452C File Offset: 0x000B292C
	private void SetAdventurerSkillImages()
	{
		List<AdventureUnitSkill> skillImages = this._enemyBattleUnit.Skills.ToList<AdventureUnitSkill>();
		base.SetSkillImages(skillImages);
	}

	// Token: 0x060016EC RID: 5868 RVA: 0x000B4554 File Offset: 0x000B2954
	public override void UpdateAttackOutputValues()
	{
		this.Attackoutput.SetOutputCapacityOnly(this._enemyBattleUnit);
		this.Attackoutput.SetBasicValues(this._enemyBattleUnit.GetAttributeDisplayValues(AttributeRetrievalLevel.Skill));
		this.Avatar.sprite = Resources.Load<Sprite>(FilePath.GetAdventurerAvatar(this._enemyBattleUnit.GetUnitType()));
	}

	// Token: 0x040016FD RID: 5885
	private EnemyBattleUnit _enemyBattleUnit;

	// Token: 0x02000CAF RID: 3247
	[CompilerGenerated]
	private sealed class <SetItemsImages>c__AnonStorey0
	{
		// Token: 0x060053FE RID: 21502 RVA: 0x000B45A9 File Offset: 0x000B29A9
		public <SetItemsImages>c__AnonStorey0()
		{
		}

		// Token: 0x060053FF RID: 21503 RVA: 0x000B45B1 File Offset: 0x000B29B1
		internal bool <>m__0(Item e)
		{
			return e.SlotType == this.i + ItemType.Weapon;
		}

		// Token: 0x04004182 RID: 16770
		internal int i;
	}
}
