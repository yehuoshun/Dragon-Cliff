using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200035B RID: 859
public class HeroInBattleObj : InBattleUnitPanelObj
{
	// Token: 0x06001700 RID: 5888 RVA: 0x000B42B5 File Offset: 0x000B26B5
	public HeroInBattleObj()
	{
	}

	// Token: 0x06001701 RID: 5889 RVA: 0x000B42BD File Offset: 0x000B26BD
	public void SetAdventurer(AdventurerBattleUnit battleUnit, HeroInBattleInfoController controller, ProgressIndicatorController progressIndicator)
	{
		base.SetCorresponseBattleUnit(battleUnit, controller, null, progressIndicator);
		this._adventurerBattleUnit = battleUnit;
		this.SetupHero();
	}

	// Token: 0x06001702 RID: 5890 RVA: 0x000B42D6 File Offset: 0x000B26D6
	public void ResetAvatar()
	{
		this.Avatar.sprite = Resources.Load<Sprite>(FilePath.GetAdventurerAvatar(this._adventurerBattleUnit.GetUnitType()));
	}

	// Token: 0x06001703 RID: 5891 RVA: 0x000B42F8 File Offset: 0x000B26F8
	private void SetupHero()
	{
		this.Avatar.sprite = Resources.Load<Sprite>(FilePath.GetAdventurerAvatar(this._adventurerBattleUnit.GetUnitType()));
		this.Attackoutput.SetDisplayValues(this._adventurerBattleUnit);
		this.SetItemsImages();
	}

	// Token: 0x06001704 RID: 5892 RVA: 0x000B4331 File Offset: 0x000B2731
	public override void UpdateUnitHealth()
	{
		if (this._adventurerBattleUnit != null)
		{
		}
		this.UpdateAttackOutputValues();
		base.UpdateUnitHealth();
	}

	// Token: 0x06001705 RID: 5893 RVA: 0x000B434C File Offset: 0x000B274C
	public override void AdventureFinished()
	{
		foreach (ItemControl itemControl in this.Items)
		{
			itemControl.AdventurerFinished();
		}
		base.AdventureFinished();
	}

	// Token: 0x06001706 RID: 5894 RVA: 0x000B4384 File Offset: 0x000B2784
	public override void SetItemsImages()
	{
		List<Item> equipments = this._adventurerBattleUnit.AdventurerProfile.GetEquipments();
		int i;
		for (i = 0; i < this.Items.Length; i++)
		{
			Item item = equipments.FirstOrDefault((Item e) => e.SlotType == i + ItemType.Weapon);
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

	// Token: 0x06001707 RID: 5895 RVA: 0x000B4421 File Offset: 0x000B2821
	public virtual void UpdateAttackOutputValues()
	{
		this.Attackoutput.SetOutputCapacityOnly(this._adventurerBattleUnit);
		this.Attackoutput.SetBasicValues(this._adventurerBattleUnit.GetAttributeDisplayValues(AttributeRetrievalLevel.Skill));
	}

	// Token: 0x04001711 RID: 5905
	public Text Defense;

	// Token: 0x04001712 RID: 5906
	public Text MagicDefense;

	// Token: 0x04001713 RID: 5907
	public ItemControl[] Items;

	// Token: 0x04001714 RID: 5908
	public AdventurerAttackOutputInBattle Attackoutput;

	// Token: 0x04001715 RID: 5909
	private AdventurerBattleUnit _adventurerBattleUnit;

	// Token: 0x02000CB1 RID: 3249
	[CompilerGenerated]
	private sealed class <SetItemsImages>c__AnonStorey0
	{
		// Token: 0x06005408 RID: 21512 RVA: 0x000B444B File Offset: 0x000B284B
		public <SetItemsImages>c__AnonStorey0()
		{
		}

		// Token: 0x06005409 RID: 21513 RVA: 0x000B4453 File Offset: 0x000B2853
		internal bool <>m__0(Item e)
		{
			return e.SlotType == this.i + ItemType.Weapon;
		}

		// Token: 0x04004187 RID: 16775
		internal int i;
	}
}
