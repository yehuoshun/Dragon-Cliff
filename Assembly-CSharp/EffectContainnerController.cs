using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x02000124 RID: 292
public class EffectContainnerController : MonoBehaviour
{
	// Token: 0x060007FA RID: 2042 RVA: 0x00074285 File Offset: 0x00072685
	public EffectContainnerController()
	{
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x00074298 File Offset: 0x00072698
	public void ClearAllEffects()
	{
		this._currentEffectIcons.ForEach(delegate(EffectIconController e)
		{
			e.gameObject.PoolDestroy(PoolType.BattleEffectIcon);
		});
		this._currentEffectIcons.Clear();
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x000742D0 File Offset: 0x000726D0
	public void RefreshEffectIcons(List<BattleEffectBase> effects, bool isPlayer)
	{
		foreach (BattleEffectBase battleEffectBase in effects)
		{
			BattleEffectType effectType = battleEffectBase.BattleEffectType;
			EffectIconController effectIconController = this._currentEffectIcons.FirstOrDefault((EffectIconController e) => e.Effect.BattleEffectType == effectType);
			int num = effects.Count((BattleEffectBase e) => e.BattleEffectType == effectType);
			if (effectIconController != null)
			{
				int currentAmount = effectIconController.CurrentAmount;
				if (currentAmount > num)
				{
					for (int i = 0; i < currentAmount - num; i++)
					{
						this.RemoveEffectIcon(battleEffectBase);
					}
				}
				else if (currentAmount < num)
				{
					for (int j = 0; j < num - currentAmount; j++)
					{
						this.AddEffectIcon(battleEffectBase, isPlayer);
					}
				}
			}
			else
			{
				for (int k = 0; k < num; k++)
				{
					this.AddEffectIcon(battleEffectBase, isPlayer);
				}
			}
		}
		List<EffectIconController> list = (from e in this._currentEffectIcons
		where effects.All((BattleEffectBase ef) => ef.BattleEffectType != e.Effect.BattleEffectType)
		select e).ToList<EffectIconController>();
		foreach (EffectIconController effectIconController2 in list)
		{
			effectIconController2.gameObject.PoolDestroy(PoolType.BattleEffectIcon);
			this._currentEffectIcons.Remove(effectIconController2);
		}
	}

	// Token: 0x060007FD RID: 2045 RVA: 0x00074488 File Offset: 0x00072888
	public void AddEffectIcon(BattleEffectBase effect, bool isPlayer)
	{
		EffectIconController effectIconController = this._currentEffectIcons.FirstOrDefault((EffectIconController e) => e.Effect.BattleEffectType == effect.BattleEffectType);
		if (effectIconController != null)
		{
			effectIconController.IncreaseAmount();
		}
		else
		{
			EffectIconController component = this.PoolObject(PoolType.BattleEffectIcon, default(Vector3)).GetComponent<EffectIconController>();
			component.Init(effect, isPlayer);
			component.transform.SetParent(base.transform, false);
			this._currentEffectIcons.Add(component);
			this.OrderEffects();
		}
	}

	// Token: 0x060007FE RID: 2046 RVA: 0x0007451C File Offset: 0x0007291C
	public void RemoveEffectIcon(BattleEffectBase effect)
	{
		EffectIconController effectIconController = this._currentEffectIcons.FirstOrDefault((EffectIconController e) => e.Effect.BattleEffectType == effect.BattleEffectType);
		if (effectIconController != null)
		{
			if (effectIconController.CurrentAmount <= 1)
			{
				effectIconController.CurrentAmount = 0;
				this._currentEffectIcons.Remove(effectIconController);
				effectIconController.gameObject.PoolDestroy(PoolType.BattleEffectIcon);
				this.OrderEffects();
			}
			else
			{
				effectIconController.DecreaseAmount();
			}
		}
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x00074598 File Offset: 0x00072998
	public void OrderEffects()
	{
		this._currentEffectIcons = (from e in this._currentEffectIcons
		orderby e.Effect.BattleEffectNatureForWearer
		select e).ToList<EffectIconController>();
		List<Transform> list = new List<Transform>();
		for (int i = base.transform.childCount - 1; i >= 0; i--)
		{
			Transform child = base.transform.GetChild(i);
			list.Add(child);
			child.SetParent(null, false);
		}
		list.Sort((Transform t1, Transform t2) => t1.GetComponent<EffectIconController>().Effect.BattleEffectNatureForWearer.CompareTo(t2.GetComponent<EffectIconController>().Effect.BattleEffectNatureForWearer));
		foreach (Transform transform in list)
		{
			transform.SetParent(base.transform, false);
			transform.localScale = Vector3.one;
			transform.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
		}
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x000746A8 File Offset: 0x00072AA8
	[CompilerGenerated]
	private static void <ClearAllEffects>m__0(EffectIconController e)
	{
		e.gameObject.PoolDestroy(PoolType.BattleEffectIcon);
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x000746B7 File Offset: 0x00072AB7
	[CompilerGenerated]
	private static BattleEffectNature <OrderEffects>m__1(EffectIconController e)
	{
		return e.Effect.BattleEffectNatureForWearer;
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x000746C4 File Offset: 0x00072AC4
	[CompilerGenerated]
	private static int <OrderEffects>m__2(Transform t1, Transform t2)
	{
		return t1.GetComponent<EffectIconController>().Effect.BattleEffectNatureForWearer.CompareTo(t2.GetComponent<EffectIconController>().Effect.BattleEffectNatureForWearer);
	}

	// Token: 0x04000ACF RID: 2767
	private string _effectIconPath;

	// Token: 0x04000AD0 RID: 2768
	private List<EffectIconController> _currentEffectIcons = new List<EffectIconController>();

	// Token: 0x04000AD1 RID: 2769
	[CompilerGenerated]
	private static Action<EffectIconController> <>f__am$cache0;

	// Token: 0x04000AD2 RID: 2770
	[CompilerGenerated]
	private static Func<EffectIconController, BattleEffectNature> <>f__am$cache1;

	// Token: 0x04000AD3 RID: 2771
	[CompilerGenerated]
	private static Comparison<Transform> <>f__am$cache2;

	// Token: 0x02000BE4 RID: 3044
	[CompilerGenerated]
	private sealed class <RefreshEffectIcons>c__AnonStorey1
	{
		// Token: 0x060050B4 RID: 20660 RVA: 0x00074704 File Offset: 0x00072B04
		public <RefreshEffectIcons>c__AnonStorey1()
		{
		}

		// Token: 0x060050B5 RID: 20661 RVA: 0x0007470C File Offset: 0x00072B0C
		internal bool <>m__0(EffectIconController e)
		{
			return this.effects.All((BattleEffectBase ef) => ef.BattleEffectType != e.Effect.BattleEffectType);
		}

		// Token: 0x04003EAD RID: 16045
		internal List<BattleEffectBase> effects;

		// Token: 0x02000BE8 RID: 3048
		private sealed class <RefreshEffectIcons>c__AnonStorey2
		{
			// Token: 0x060050BD RID: 20669 RVA: 0x00074744 File Offset: 0x00072B44
			public <RefreshEffectIcons>c__AnonStorey2()
			{
			}

			// Token: 0x060050BE RID: 20670 RVA: 0x0007474C File Offset: 0x00072B4C
			internal bool <>m__0(BattleEffectBase ef)
			{
				return ef.BattleEffectType != this.e.Effect.BattleEffectType;
			}

			// Token: 0x04003EB1 RID: 16049
			internal EffectIconController e;

			// Token: 0x04003EB2 RID: 16050
			internal EffectContainnerController.<RefreshEffectIcons>c__AnonStorey1 <>f__ref$1;
		}
	}

	// Token: 0x02000BE5 RID: 3045
	[CompilerGenerated]
	private sealed class <RefreshEffectIcons>c__AnonStorey0
	{
		// Token: 0x060050B6 RID: 20662 RVA: 0x00074769 File Offset: 0x00072B69
		public <RefreshEffectIcons>c__AnonStorey0()
		{
		}

		// Token: 0x060050B7 RID: 20663 RVA: 0x00074771 File Offset: 0x00072B71
		internal bool <>m__0(EffectIconController e)
		{
			return e.Effect.BattleEffectType == this.effectType;
		}

		// Token: 0x060050B8 RID: 20664 RVA: 0x00074786 File Offset: 0x00072B86
		internal bool <>m__1(BattleEffectBase e)
		{
			return e.BattleEffectType == this.effectType;
		}

		// Token: 0x04003EAE RID: 16046
		internal BattleEffectType effectType;
	}

	// Token: 0x02000BE6 RID: 3046
	[CompilerGenerated]
	private sealed class <AddEffectIcon>c__AnonStorey3
	{
		// Token: 0x060050B9 RID: 20665 RVA: 0x00074796 File Offset: 0x00072B96
		public <AddEffectIcon>c__AnonStorey3()
		{
		}

		// Token: 0x060050BA RID: 20666 RVA: 0x0007479E File Offset: 0x00072B9E
		internal bool <>m__0(EffectIconController e)
		{
			return e.Effect.BattleEffectType == this.effect.BattleEffectType;
		}

		// Token: 0x04003EAF RID: 16047
		internal BattleEffectBase effect;
	}

	// Token: 0x02000BE7 RID: 3047
	[CompilerGenerated]
	private sealed class <RemoveEffectIcon>c__AnonStorey4
	{
		// Token: 0x060050BB RID: 20667 RVA: 0x000747B8 File Offset: 0x00072BB8
		public <RemoveEffectIcon>c__AnonStorey4()
		{
		}

		// Token: 0x060050BC RID: 20668 RVA: 0x000747C0 File Offset: 0x00072BC0
		internal bool <>m__0(EffectIconController e)
		{
			return e.Effect.BattleEffectType == this.effect.BattleEffectType;
		}

		// Token: 0x04003EB0 RID: 16048
		internal BattleEffectBase effect;
	}
}
