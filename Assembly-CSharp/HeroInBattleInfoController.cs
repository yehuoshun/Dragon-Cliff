using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class HeroInBattleInfoController : MonoBehaviour
{
	// Token: 0x060016ED RID: 5869 RVA: 0x000B45C3 File Offset: 0x000B29C3
	public HeroInBattleInfoController()
	{
	}

	// Token: 0x060016EE RID: 5870 RVA: 0x000B45F7 File Offset: 0x000B29F7
	public void SetAdventure(Adventure Adventure)
	{
		this._adventure = Adventure;
		this.Setup();
		base.gameObject.SetActive(true);
	}

	// Token: 0x060016EF RID: 5871 RVA: 0x000B4614 File Offset: 0x000B2A14
	private void Setup()
	{
		for (int i = 0; i < this._adventure.Adventurers.Count; i++)
		{
			GameObject gameObject = GameObjectUtil.Instantiate(Resources.Load("Prefabs/Eric/Battle/PanelRelatedPrefabs/HeroInBattleInfoUpdateFinal") as GameObject, base.transform.position, this.HeroesPanel);
			gameObject.transform.SetParent(this.HeroesPanel.transform);
			gameObject.transform.localScale = Vector3.one;
			HeroInBattleObj component = gameObject.GetComponent<HeroInBattleObj>();
			if (component != null)
			{
				this._heroInBattleInfos.Add(component);
				component.SetAdventurer(this._adventure.Adventurers[i], this, this.ProgressIndicator);
			}
			gameObject.transform.SetSiblingIndex(i);
		}
	}

	// Token: 0x060016F0 RID: 5872 RVA: 0x000B46D7 File Offset: 0x000B2AD7
	public void UpdateHealth()
	{
		this._heroInBattleInfos.ForEach(delegate(HeroInBattleObj h)
		{
			h.UpdateUnitHealth();
		});
	}

	// Token: 0x060016F1 RID: 5873 RVA: 0x000B4704 File Offset: 0x000B2B04
	public IEnumerable UpdateCurrentEncouterOrder(IBattleUnit InTurnBattleUnit)
	{
		if (!this._indicatorInitialized)
		{
			this.SetupProgressIndicator();
		}
		this.UpdateRestOfSpeed();
		yield break;
	}

	// Token: 0x060016F2 RID: 5874 RVA: 0x000B4727 File Offset: 0x000B2B27
	public void EnterTurn(IBattleUnit unit)
	{
		this.ProgressIndicator.EnterTurn(unit);
	}

	// Token: 0x060016F3 RID: 5875 RVA: 0x000B4735 File Offset: 0x000B2B35
	public void TurnComplete(IBattleUnit InTurnBattleUnit)
	{
		this.ProgressIndicator.FinishTurn(InTurnBattleUnit);
	}

	// Token: 0x060016F4 RID: 5876 RVA: 0x000B4744 File Offset: 0x000B2B44
	public void UpdateRestOfSpeed()
	{
		List<IBattleUnit> currentOrder = this.GetCurrentOrder();
		if (currentOrder != null && this.ProgressIndicator != null)
		{
			this.ProgressIndicator.UpdatePosition();
		}
	}

	// Token: 0x060016F5 RID: 5877 RVA: 0x000B477C File Offset: 0x000B2B7C
	private void SetupProgressIndicator()
	{
		if (!this._indicatorInitialized)
		{
			List<IBattleUnit> currentOrder = this.GetCurrentOrder();
			if (currentOrder != null)
			{
				this._indicatorInitialized = true;
				this.ProgressIndicator.InitAllUnitSpeedPosition(currentOrder);
			}
		}
	}

	// Token: 0x060016F6 RID: 5878 RVA: 0x000B47B4 File Offset: 0x000B2BB4
	private List<IBattleUnit> GetCurrentOrder()
	{
		if (this._currentBattleEncounter == null)
		{
			return null;
		}
		List<IBattleUnit> list = new List<IBattleUnit>();
		list.AddRange((from p in this._currentBattleEncounter.PlayerUnits
		where p.Status == BattleUnitStatus.Active
		select p).ToList<IBattleUnit>());
		list.AddRange((from e in this._currentBattleEncounter.EnemyUnits
		where e.Status == BattleUnitStatus.Active
		select e).ToList<IBattleUnit>());
		return (from k in list
		orderby k.TurnProgress
		select k).ToList<IBattleUnit>();
	}

	// Token: 0x060016F7 RID: 5879 RVA: 0x000B486C File Offset: 0x000B2C6C
	public void LeavesEncouter()
	{
		this._currentBattleEncounter = null;
		this._EnemyInBattleInfos.ForEach(delegate(EnemyInBattleObj e)
		{
			e.AdventureFinished();
		});
		this._EnemyInBattleInfos.Clear();
		this._enemyInInvasionObjs.ForEach(delegate(EnemyInInvasionObj e)
		{
			e.AdventureFinished();
		});
		this._enemyInInvasionObjs.Clear();
	}

	// Token: 0x060016F8 RID: 5880 RVA: 0x000B48E8 File Offset: 0x000B2CE8
	public void AdventurerFinished()
	{
		this._currentBattleEncounter = null;
		this._heroInBattleInfos.ForEach(delegate(HeroInBattleObj a)
		{
			a.BattleFinished();
			a.AdventureFinished();
		});
		this._heroInBattleInfos.Clear();
		this.ProgressIndicator.EncouterFinished();
		this._indicatorInitialized = false;
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x000B4941 File Offset: 0x000B2D41
	[CompilerGenerated]
	private static void <UpdateHealth>m__0(HeroInBattleObj h)
	{
		h.UpdateUnitHealth();
	}

	// Token: 0x060016FA RID: 5882 RVA: 0x000B4949 File Offset: 0x000B2D49
	[CompilerGenerated]
	private static bool <GetCurrentOrder>m__1(IBattleUnit p)
	{
		return p.Status == BattleUnitStatus.Active;
	}

	// Token: 0x060016FB RID: 5883 RVA: 0x000B4954 File Offset: 0x000B2D54
	[CompilerGenerated]
	private static bool <GetCurrentOrder>m__2(IBattleUnit e)
	{
		return e.Status == BattleUnitStatus.Active;
	}

	// Token: 0x060016FC RID: 5884 RVA: 0x000B495F File Offset: 0x000B2D5F
	[CompilerGenerated]
	private static double <GetCurrentOrder>m__3(IBattleUnit k)
	{
		return k.TurnProgress;
	}

	// Token: 0x060016FD RID: 5885 RVA: 0x000B4967 File Offset: 0x000B2D67
	[CompilerGenerated]
	private static void <LeavesEncouter>m__4(EnemyInBattleObj e)
	{
		e.AdventureFinished();
	}

	// Token: 0x060016FE RID: 5886 RVA: 0x000B496F File Offset: 0x000B2D6F
	[CompilerGenerated]
	private static void <LeavesEncouter>m__5(EnemyInInvasionObj e)
	{
		e.AdventureFinished();
	}

	// Token: 0x060016FF RID: 5887 RVA: 0x000B4977 File Offset: 0x000B2D77
	[CompilerGenerated]
	private static void <AdventurerFinished>m__6(HeroInBattleObj a)
	{
		a.BattleFinished();
		a.AdventureFinished();
	}

	// Token: 0x040016FE RID: 5886
	public ProgressIndicatorController ProgressIndicator;

	// Token: 0x040016FF RID: 5887
	public GameObject HeroesPanel;

	// Token: 0x04001700 RID: 5888
	public GameObject EnemyPanel;

	// Token: 0x04001701 RID: 5889
	public GameObject EnemyPanelSecond;

	// Token: 0x04001702 RID: 5890
	public InBattleUnitCardLayout[] AdventurerInBattleAsCardControllers;

	// Token: 0x04001703 RID: 5891
	private Adventure _adventure;

	// Token: 0x04001704 RID: 5892
	private readonly List<HeroInBattleObj> _heroInBattleInfos = new List<HeroInBattleObj>();

	// Token: 0x04001705 RID: 5893
	private readonly List<EnemyInBattleObj> _EnemyInBattleInfos = new List<EnemyInBattleObj>();

	// Token: 0x04001706 RID: 5894
	private readonly List<EnemyInInvasionObj> _enemyInInvasionObjs = new List<EnemyInInvasionObj>();

	// Token: 0x04001707 RID: 5895
	private BattleEncounter _currentBattleEncounter;

	// Token: 0x04001708 RID: 5896
	private bool _indicatorInitialized;

	// Token: 0x04001709 RID: 5897
	public List<IBattleUnit> _currentOrder = new List<IBattleUnit>();

	// Token: 0x0400170A RID: 5898
	[CompilerGenerated]
	private static Action<HeroInBattleObj> <>f__am$cache0;

	// Token: 0x0400170B RID: 5899
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache1;

	// Token: 0x0400170C RID: 5900
	[CompilerGenerated]
	private static Func<IBattleUnit, bool> <>f__am$cache2;

	// Token: 0x0400170D RID: 5901
	[CompilerGenerated]
	private static Func<IBattleUnit, double> <>f__am$cache3;

	// Token: 0x0400170E RID: 5902
	[CompilerGenerated]
	private static Action<EnemyInBattleObj> <>f__am$cache4;

	// Token: 0x0400170F RID: 5903
	[CompilerGenerated]
	private static Action<EnemyInInvasionObj> <>f__am$cache5;

	// Token: 0x04001710 RID: 5904
	[CompilerGenerated]
	private static Action<HeroInBattleObj> <>f__am$cache6;

	// Token: 0x02000CB0 RID: 3248
	[CompilerGenerated]
	private sealed class <UpdateCurrentEncouterOrder>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005400 RID: 21504 RVA: 0x000B4985 File Offset: 0x000B2D85
		[DebuggerHidden]
		public <UpdateCurrentEncouterOrder>c__Iterator0()
		{
		}

		// Token: 0x06005401 RID: 21505 RVA: 0x000B498D File Offset: 0x000B2D8D
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				if (!this._indicatorInitialized)
				{
					base.SetupProgressIndicator();
				}
				base.UpdateRestOfSpeed();
			}
			return false;
		}

		// Token: 0x170011D0 RID: 4560
		// (get) Token: 0x06005402 RID: 21506 RVA: 0x000B49CD File Offset: 0x000B2DCD
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011D1 RID: 4561
		// (get) Token: 0x06005403 RID: 21507 RVA: 0x000B49D5 File Offset: 0x000B2DD5
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005404 RID: 21508 RVA: 0x000B49DD File Offset: 0x000B2DDD
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005405 RID: 21509 RVA: 0x000B49DF File Offset: 0x000B2DDF
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005406 RID: 21510 RVA: 0x000B49E6 File Offset: 0x000B2DE6
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005407 RID: 21511 RVA: 0x000B49F0 File Offset: 0x000B2DF0
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			HeroInBattleInfoController.<UpdateCurrentEncouterOrder>c__Iterator0 <UpdateCurrentEncouterOrder>c__Iterator = new HeroInBattleInfoController.<UpdateCurrentEncouterOrder>c__Iterator0();
			<UpdateCurrentEncouterOrder>c__Iterator.$this = this;
			return <UpdateCurrentEncouterOrder>c__Iterator;
		}

		// Token: 0x04004183 RID: 16771
		internal HeroInBattleInfoController $this;

		// Token: 0x04004184 RID: 16772
		internal object $current;

		// Token: 0x04004185 RID: 16773
		internal bool $disposing;

		// Token: 0x04004186 RID: 16774
		internal int $PC;
	}
}
