using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000536 RID: 1334
public class ItemGenerationQuality
{
	// Token: 0x060026F9 RID: 9977 RVA: 0x00116601 File Offset: 0x00114A01
	private ItemGenerationQuality()
	{
	}

	// Token: 0x17000303 RID: 771
	// (get) Token: 0x060026FA RID: 9978 RVA: 0x00116609 File Offset: 0x00114A09
	// (set) Token: 0x060026FB RID: 9979 RVA: 0x00116611 File Offset: 0x00114A11
	public QualityGrade QualityGrade
	{
		[CompilerGenerated]
		get
		{
			return this.<QualityGrade>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<QualityGrade>k__BackingField = value;
		}
	}

	// Token: 0x17000304 RID: 772
	// (get) Token: 0x060026FC RID: 9980 RVA: 0x0011661A File Offset: 0x00114A1A
	// (set) Token: 0x060026FD RID: 9981 RVA: 0x00116622 File Offset: 0x00114A22
	public bool IsStar
	{
		[CompilerGenerated]
		get
		{
			return this.<IsStar>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<IsStar>k__BackingField = value;
		}
	}

	// Token: 0x060026FE RID: 9982 RVA: 0x0011662C File Offset: 0x00114A2C
	public static ItemGenerationQuality CreateGraded(QualityGrade grade)
	{
		return new ItemGenerationQuality
		{
			QualityGrade = grade,
			IsStar = false
		};
	}

	// Token: 0x060026FF RID: 9983 RVA: 0x00116650 File Offset: 0x00114A50
	public static ItemGenerationQuality CreateStar()
	{
		return new ItemGenerationQuality
		{
			QualityGrade = QualityGrade.Ancient,
			IsStar = true
		};
	}

	// Token: 0x0400216B RID: 8555
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private QualityGrade <QualityGrade>k__BackingField;

	// Token: 0x0400216C RID: 8556
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool <IsStar>k__BackingField;
}
