using System;

// Token: 0x02000472 RID: 1138
[Serializable]
public class ProductionBuildingRateModifier
{
	// Token: 0x0600204D RID: 8269 RVA: 0x000E0F55 File Offset: 0x000DF355
	public ProductionBuildingRateModifier()
	{
	}

	// Token: 0x0600204E RID: 8270 RVA: 0x000E0F60 File Offset: 0x000DF360
	public double GetWorkRate(double originalWorkRate, BuildingType type)
	{
		if (type == this.BuildingType)
		{
			if (this.ModificationType == ModificationType.Addition)
			{
				return originalWorkRate + this.WorkRateValue;
			}
			if (this.ModificationType == ModificationType.Multiplication)
			{
				return originalWorkRate * (1.0 + this.WorkRateValue);
			}
			if (this.ModificationType == ModificationType.Replacement)
			{
				return this.WorkRateValue;
			}
		}
		return originalWorkRate;
	}

	// Token: 0x04001CCC RID: 7372
	public ModificationType ModificationType;

	// Token: 0x04001CCD RID: 7373
	public double WorkRateValue;

	// Token: 0x04001CCE RID: 7374
	public BuildingType BuildingType;
}
