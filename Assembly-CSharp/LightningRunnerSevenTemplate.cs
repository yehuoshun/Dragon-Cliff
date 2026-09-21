using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000562 RID: 1378
public class LightningRunnerSevenTemplate : AccessoryTemplateBase
{
	// Token: 0x060027C2 RID: 10178 RVA: 0x00119408 File Offset: 0x00117808
	public LightningRunnerSevenTemplate()
	{
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x060027C3 RID: 10179 RVA: 0x00119423 File Offset: 0x00117823
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x060027C4 RID: 10180 RVA: 0x0011942B File Offset: 0x0011782B
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027C5 RID: 10181 RVA: 0x00119434 File Offset: 0x00117834
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Agility, 900.0)
		};
	}

	// Token: 0x060027C6 RID: 10182 RVA: 0x00119460 File Offset: 0x00117860
	public override List<ISpecialEffectDataLoad> GenerateStarEffects(QualityGrade grade, int itemTierNumber)
	{
		return new List<ISpecialEffectDataLoad>
		{
			new PushOnHitData
			{
				IsStar = true,
				PushBackRate = (double)UnityEngine.Random.Range(0.2f, 0.25f)
			}
		};
	}

	// Token: 0x060027C7 RID: 10183 RVA: 0x001194A0 File Offset: 0x001178A0
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double num = 0.15 + Convert.ToDouble((int)grade) * 0.05;
		return new List<ISpecialEffectDataLoad>
		{
			new FirstHandEffectData
			{
				IsStarEf = new bool?(false),
				StartProgress = num * (double)UnityEngine.Random.Range(0.8f, 1f)
			}
		};
	}

	// Token: 0x040021BA RID: 8634
	private ResourceType _itemType = ResourceType.LightningRunnerSeven;

	// Token: 0x040021BB RID: 8635
	private int _itemTierNumber = 53;
}
