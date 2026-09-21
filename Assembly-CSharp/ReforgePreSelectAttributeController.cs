using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200019B RID: 411
public class ReforgePreSelectAttributeController : MonoBehaviour
{
	// Token: 0x06000AF3 RID: 2803 RVA: 0x00083C32 File Offset: 0x00082032
	public ReforgePreSelectAttributeController()
	{
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x00083C3A File Offset: 0x0008203A
	// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x00083C42 File Offset: 0x00082042
	public List<ReforgeAttributeItemController> Attributes
	{
		[CompilerGenerated]
		get
		{
			return this.<Attributes>k__BackingField;
		}
		[CompilerGenerated]
		set
		{
			this.<Attributes>k__BackingField = value;
		}
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x00083C4C File Offset: 0x0008204C
	public void Init(List<AttributeModifier> attributes)
	{
		this.Attributes = new List<ReforgeAttributeItemController>();
		IEnumerator enumerator = this.AttributesContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
		foreach (AttributeModifier attribute in attributes)
		{
			ReforgeAttributeItemController reforgeAttributeItemController = UnityEngine.Object.Instantiate<ReforgeAttributeItemController>(this.AttributePre);
			reforgeAttributeItemController.Init(attribute);
			reforgeAttributeItemController.transform.SetParent(this.AttributesContainer, false);
			this.Attributes.Add(reforgeAttributeItemController);
		}
		if (this.Attributes.Count == 1)
		{
			this.Attributes[0].SelectAttribute();
		}
	}

	// Token: 0x06000AF7 RID: 2807 RVA: 0x00083D58 File Offset: 0x00082158
	public void SelectAttributes(AttributeModifier selectedAttribute)
	{
		this.Attributes.ForEach(delegate(ReforgeAttributeItemController a)
		{
			a.ChangeFrame(selectedAttribute);
		});
	}

	// Token: 0x04000D8C RID: 3468
	public Transform AttributesContainer;

	// Token: 0x04000D8D RID: 3469
	public ReforgeAttributeItemController AttributePre;

	// Token: 0x04000D8E RID: 3470
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<ReforgeAttributeItemController> <Attributes>k__BackingField;

	// Token: 0x02000C27 RID: 3111
	[CompilerGenerated]
	private sealed class <SelectAttributes>c__AnonStorey0
	{
		// Token: 0x0600521B RID: 21019 RVA: 0x00083D89 File Offset: 0x00082189
		public <SelectAttributes>c__AnonStorey0()
		{
		}

		// Token: 0x0600521C RID: 21020 RVA: 0x00083D91 File Offset: 0x00082191
		internal void <>m__0(ReforgeAttributeItemController a)
		{
			a.ChangeFrame(this.selectedAttribute);
		}

		// Token: 0x0400401E RID: 16414
		internal AttributeModifier selectedAttribute;
	}
}
