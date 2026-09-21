using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000561 RID: 1377
public class LightningRunnerFiveTemplate : AccessoryTemplateBase
{
	// Token: 0x060027BC RID: 10172 RVA: 0x00119311 File Offset: 0x00117711
	public LightningRunnerFiveTemplate()
	{
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x060027BD RID: 10173 RVA: 0x0011932C File Offset: 0x0011772C
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x060027BE RID: 10174 RVA: 0x00119334 File Offset: 0x00117734
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027BF RID: 10175 RVA: 0x0011933C File Offset: 0x0011773C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Agility, 500.0)
		};
	}

	// Token: 0x060027C0 RID: 10176 RVA: 0x00119368 File Offset: 0x00117768
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

	// Token: 0x060027C1 RID: 10177 RVA: 0x001193A8 File Offset: 0x001177A8
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double num = 0.05 + Convert.ToDouble((int)grade) * 0.01;
		return new List<ISpecialEffectDataLoad>
		{
			new FirstHandEffectData
			{
				IsStarEf = new bool?(false),
				StartProgress = num * (double)UnityEngine.Random.Range(0.8f, 1f)
			}
		};
	}

	// Token: 0x040021B8 RID: 8632
	private ResourceType _itemType = ResourceType.LightningRunnerFive;

	// Token: 0x040021B9 RID: 8633
	private int _itemTierNumber = 37;
}
