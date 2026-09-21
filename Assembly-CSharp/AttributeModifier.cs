using System;
using System.Collections.Generic;

// Token: 0x02000520 RID: 1312
[Serializable]
public class AttributeModifier
{
	// Token: 0x0600269F RID: 9887 RVA: 0x00113C66 File Offset: 0x00112066
	public AttributeModifier()
	{
	}

	// Token: 0x060026A0 RID: 9888 RVA: 0x00113C6E File Offset: 0x0011206E
	public bool IsEnchanted()
	{
		return this.Key == "enchanted";
	}

	// Token: 0x060026A1 RID: 9889 RVA: 0x00113C80 File Offset: 0x00112080
	public bool IsReforged()
	{
		return this.Key == "reforged";
	}

	// Token: 0x060026A2 RID: 9890 RVA: 0x00113C94 File Offset: 0x00112094
	public static AttributeModifier CreateAdditionModifier_System(AttributeType type, double value)
	{
		return new AttributeModifier
		{
			AttributeType = type,
			Value = value,
			ModificationType = ModificationType.Addition,
			AttributeModifierType = AttributeModifierType.Normal
		};
	}

	// Token: 0x060026A3 RID: 9891 RVA: 0x00113CC4 File Offset: 0x001120C4
	public AttributeDisplayValue GetDisplayValue()
	{
		return new AttributeDisplayValue
		{
			AttributeType = this.AttributeType,
			Value = this.Value,
			ModificationType = this.ModificationType
		};
	}

	// Token: 0x060026A4 RID: 9892 RVA: 0x00113CFC File Offset: 0x001120FC
	public static List<AttributeModifier> InitializeAttributes()
	{
		List<AttributeModifier> list = new List<AttributeModifier>();
		List<AttributeType> allAttributeTypes = ItemExtensions.AllAttributeTypes;
		foreach (AttributeType attributeType in allAttributeTypes)
		{
			list.Add(new AttributeModifier
			{
				AttributeType = attributeType,
				Value = 0.0,
				ModificationType = ModificationType.Addition,
				AttributeModifierType = AttributeModifierType.Normal,
				Key = string.Empty
			});
		}
		return list;
	}

	// Token: 0x04002101 RID: 8449
	public AttributeType AttributeType;

	// Token: 0x04002102 RID: 8450
	public ModificationType ModificationType;

	// Token: 0x04002103 RID: 8451
	public double Value;

	// Token: 0x04002104 RID: 8452
	public string Key;

	// Token: 0x04002105 RID: 8453
	public AttributeModifierType AttributeModifierType;
}
