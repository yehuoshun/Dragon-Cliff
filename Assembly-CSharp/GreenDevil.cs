using System;

// Token: 0x02000AF7 RID: 2807
public class GreenDevil : MinionUnitConfigurationBase
{
	// Token: 0x06004B7C RID: 19324 RVA: 0x001F1256 File Offset: 0x001EF656
	public GreenDevil()
	{
	}

	// Token: 0x17000FF3 RID: 4083
	// (get) Token: 0x06004B7D RID: 19325 RVA: 0x001F1271 File Offset: 0x001EF671
	public override UnitClass CorrespondingUnitClass
	{
		get
		{
			return this._correspondingUnitClass;
		}
	}

	// Token: 0x17000FF4 RID: 4084
	// (get) Token: 0x06004B7E RID: 19326 RVA: 0x001F1279 File Offset: 0x001EF679
	public override UnitClassStyle CorrespondingClassStyle
	{
		get
		{
			return this._correspondingClassStyle;
		}
	}

	// Token: 0x04003AC0 RID: 15040
	private readonly UnitClass _correspondingUnitClass = UnitClass.GreenDevil;

	// Token: 0x04003AC1 RID: 15041
	private readonly UnitClassStyle _correspondingClassStyle = UnitClassStyle.Healer;
}
