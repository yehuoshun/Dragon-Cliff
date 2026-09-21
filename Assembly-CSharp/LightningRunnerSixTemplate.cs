using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000563 RID: 1379
public class LightningRunnerSixTemplate : AccessoryTemplateBase
{
	// Token: 0x060027C8 RID: 10184 RVA: 0x00119500 File Offset: 0x00117900
	public LightningRunnerSixTemplate()
	{
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x060027C9 RID: 10185 RVA: 0x0011951B File Offset: 0x0011791B
	public override ResourceType ItemType
	{
		get
		{
			return this._itemType;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x060027CA RID: 10186 RVA: 0x00119523 File Offset: 0x00117923
	public override int ItemTierNumber
	{
		get
		{
			return this._itemTierNumber;
		}
	}

	// Token: 0x060027CB RID: 10187 RVA: 0x0011952C File Offset: 0x0011792C
	public override List<ItemPropertyPotential> PropertyPotentials(int itemTierNumber)
	{
		return new List<ItemPropertyPotential>
		{
			ItemPropertyPotential.CreatePrimaryGuarranteedProperty_Addition(AttributeType.Agility, 700.0)
		};
	}

	// Token: 0x060027CC RID: 10188 RVA: 0x00119558 File Offset: 0x00117958
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

	// Token: 0x060027CD RID: 10189 RVA: 0x00119598 File Offset: 0x00117998
	public override List<ISpecialEffectDataLoad> GetNormalLevelSpecialEffectDataLoads(QualityGrade grade)
	{
		double num = 0.1 + Convert.ToDouble((int)grade) * 0.02;
		return new List<ISpecialEffectDataLoad>
		{
			new FirstHandEffectData
			{
				IsStarEf = new bool?(false),
				StartProgress = num * (double)UnityEngine.Random.Range(0.8f, 1f)
			}
		};
	}

	// Token: 0x040021BC RID: 8636
	private ResourceType _itemType = ResourceType.LightningRunnerSix;

	// Token: 0x040021BD RID: 8637
	private int _itemTierNumber = 45;
}
