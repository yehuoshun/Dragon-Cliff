using System;
using System.Collections.Generic;

// Token: 0x02000586 RID: 1414
public class LeatherOfDisciplineTemplate : RecipeProducedGearTemplateBase
{
	// Token: 0x06002867 RID: 10343 RVA: 0x0011ABAB File Offset: 0x00118FAB
	public LeatherOfDisciplineTemplate()
	{
	}

	// Token: 0x170003A0 RID: 928
	// (get) Token: 0x06002868 RID: 10344 RVA: 0x0011ABC6 File Offset: 0x00118FC6
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x170003A1 RID: 929
	// (get) Token: 0x06002869 RID: 10345 RVA: 0x0011ABCE File Offset: 0x00118FCE
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x0600286A RID: 10346 RVA: 0x0011ABD8 File Offset: 0x00118FD8
	public override List<AttributeType> ExtraGuarranteedSecondaryGradedAttributes(int itemTierNumber)
	{
		return new List<AttributeType>
		{
			AttributeType.ReflectiveDamage
		};
	}

	// Token: 0x040021EF RID: 8687
	private ResourceType _itemType = ResourceType.LeatherOfDiscipline;

	// Token: 0x040021F0 RID: 8688
	private int _itemTierNumber = 9;
}
