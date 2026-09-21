using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200073D RID: 1853
public abstract class BattleEffectBase : IBattleEffectSource
{
	// Token: 0x06003496 RID: 13462 RVA: 0x0015A63C File Offset: 0x00158A3C
	protected BattleEffectBase()
	{
		this.Id = Guid.NewGuid().ToString();
	}

	// Token: 0x17000880 RID: 2176
	// (get) Token: 0x06003497 RID: 13463 RVA: 0x0015A668 File Offset: 0x00158A68
	// (set) Token: 0x06003498 RID: 13464 RVA: 0x0015A670 File Offset: 0x00158A70
	public string Id
	{
		[CompilerGenerated]
		get
		{
			return this.<Id>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Id>k__BackingField = value;
		}
	}

	// Token: 0x06003499 RID: 13465
	public abstract List<AdventureEventType> CorrespondingEvents();

	// Token: 0x17000881 RID: 2177
	// (get) Token: 0x0600349A RID: 13466
	public abstract string EffectSourceIdentityCode { get; }

	// Token: 0x17000882 RID: 2178
	// (get) Token: 0x0600349B RID: 13467
	public abstract BattleEffectType BattleEffectType { get; }

	// Token: 0x17000883 RID: 2179
	// (get) Token: 0x0600349C RID: 13468
	// (set) Token: 0x0600349D RID: 13469
	public abstract float? MaxNumberOfLastingSeconds { get; set; }

	// Token: 0x0600349E RID: 13470 RVA: 0x0015A679 File Offset: 0x00158A79
	public virtual bool IsDeadly()
	{
		return false;
	}

	// Token: 0x0600349F RID: 13471 RVA: 0x0015A67C File Offset: 0x00158A7C
	public IEnumerable Process(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		if (eventType == AdventureEventType.UnitReadyInBattle && eventTriggerUnit == listener)
		{
			this.Timer = 0f;
		}
		if (eventType == AdventureEventType.BattleEffectTurnProgresses && data is BattleEffectBase && data == this)
		{
			if (listener.IsAliveInBattle())
			{
				IEnumerator enumerator = this.PerTurnProgressesLogic_ActiveUnit().GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object _ = enumerator.Current;
						yield return _;
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
			}
			else
			{
				IEnumerator enumerator2 = this.PerTurnProgressesLogic_InactiveUnit().GetEnumerator();
				try
				{
					while (enumerator2.MoveNext())
					{
						object _2 = enumerator2.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		if (listener.IsAliveInBattle())
		{
			IEnumerator enumerator3 = this.ProcessEvent_ExtraLogic_ActiveUnit(eventTriggerUnit, listener, eventType, data).GetEnumerator();
			try
			{
				while (enumerator3.MoveNext())
				{
					object _3 = enumerator3.Current;
					yield return _3;
				}
			}
			finally
			{
				IDisposable disposable3;
				if ((disposable3 = (enumerator3 as IDisposable)) != null)
				{
					disposable3.Dispose();
				}
			}
		}
		else
		{
			IEnumerator enumerator4 = this.ProcessEvent_ExtraLogic_InactiveUnit(eventTriggerUnit, listener, eventType, data).GetEnumerator();
			try
			{
				while (enumerator4.MoveNext())
				{
					object _4 = enumerator4.Current;
					yield return _4;
				}
			}
			finally
			{
				IDisposable disposable4;
				if ((disposable4 = (enumerator4 as IDisposable)) != null)
				{
					disposable4.Dispose();
				}
			}
		}
		yield break;
	}

	// Token: 0x060034A0 RID: 13472 RVA: 0x0015A6BC File Offset: 0x00158ABC
	public int? GetRemainingSeconds()
	{
		if (this.MaxNumberOfLastingSeconds != null)
		{
			int num = (int)Math.Ceiling((double)((this.MaxNumberOfLastingSeconds.GetValueOrDefault() - this.Timer) / BattleEffectBase.PerSecondGap));
			if (num < 0)
			{
				num = 0;
			}
			return new int?(num);
		}
		return null;
	}

	// Token: 0x060034A1 RID: 13473 RVA: 0x0015A718 File Offset: 0x00158B18
	public virtual IEnumerable PosWearsOffProcess_ActiveUnit(IBattleUnit effectWearer, EffectWearsOffType wearsOffType)
	{
		yield break;
	}

	// Token: 0x060034A2 RID: 13474 RVA: 0x0015A734 File Offset: 0x00158B34
	public virtual IEnumerable PosWearsOffProcess_InactiveUnit(IBattleUnit effectWearer, EffectWearsOffType wearsOffType)
	{
		yield break;
	}

	// Token: 0x060034A3 RID: 13475 RVA: 0x0015A750 File Offset: 0x00158B50
	public virtual IEnumerable PerTurnProgressesLogic_ActiveUnit()
	{
		yield break;
	}

	// Token: 0x060034A4 RID: 13476 RVA: 0x0015A76C File Offset: 0x00158B6C
	public virtual IEnumerable PerTurnProgressesLogic_InactiveUnit()
	{
		yield break;
	}

	// Token: 0x060034A5 RID: 13477 RVA: 0x0015A788 File Offset: 0x00158B88
	public virtual IEnumerable PerSecondLogic_ActiveUnit(IBattleUnit listener)
	{
		yield break;
	}

	// Token: 0x060034A6 RID: 13478 RVA: 0x0015A7A4 File Offset: 0x00158BA4
	public virtual IEnumerable PerSecondLogic_InactiveUnit(IBattleUnit listener)
	{
		yield break;
	}

	// Token: 0x060034A7 RID: 13479 RVA: 0x0015A7C0 File Offset: 0x00158BC0
	public virtual IEnumerable ProcessEvent_ExtraLogic_ActiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		yield break;
	}

	// Token: 0x060034A8 RID: 13480 RVA: 0x0015A7DC File Offset: 0x00158BDC
	public virtual IEnumerable ProcessEvent_ExtraLogic_InactiveUnit(IBattleUnit eventTriggerUnit, IBattleUnit listener, AdventureEventType eventType, object data)
	{
		yield break;
	}

	// Token: 0x17000884 RID: 2180
	// (get) Token: 0x060034A9 RID: 13481
	public abstract IBattleEffectSource EffectSource { get; }

	// Token: 0x17000885 RID: 2181
	// (get) Token: 0x060034AA RID: 13482 RVA: 0x0015A7F8 File Offset: 0x00158BF8
	// (set) Token: 0x060034AB RID: 13483 RVA: 0x0015A800 File Offset: 0x00158C00
	public List<AdventureEventType> TurnEventsCollected
	{
		[CompilerGenerated]
		get
		{
			return this.<TurnEventsCollected>k__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			this.<TurnEventsCollected>k__BackingField = value;
		}
	}

	// Token: 0x17000886 RID: 2182
	// (get) Token: 0x060034AC RID: 13484
	// (set) Token: 0x060034AD RID: 13485
	public abstract int? NumberOfLastingTurns { get; set; }

	// Token: 0x060034AE RID: 13486 RVA: 0x0015A809 File Offset: 0x00158C09
	public virtual List<AttributeModifier> GetAdditionalModifiers(IBattleUnit wearer, IEncounter encounter)
	{
		return new List<AttributeModifier>();
	}

	// Token: 0x17000887 RID: 2183
	// (get) Token: 0x060034AF RID: 13487
	public abstract bool IsThroughEffect { get; }

	// Token: 0x17000888 RID: 2184
	// (get) Token: 0x060034B0 RID: 13488
	public abstract bool CanBeImmuned { get; }

	// Token: 0x17000889 RID: 2185
	// (get) Token: 0x060034B1 RID: 13489
	// (set) Token: 0x060034B2 RID: 13490
	public abstract bool CanBeDispersed { get; set; }

	// Token: 0x1700088A RID: 2186
	// (get) Token: 0x060034B3 RID: 13491
	public abstract int? MaxStackableInstances { get; }

	// Token: 0x1700088B RID: 2187
	// (get) Token: 0x060034B4 RID: 13492
	public abstract BattleEffectNature BattleEffectNatureForWearer { get; }

	// Token: 0x1700088C RID: 2188
	// (get) Token: 0x060034B5 RID: 13493 RVA: 0x0015A810 File Offset: 0x00158C10
	// (set) Token: 0x060034B6 RID: 13494 RVA: 0x0015A818 File Offset: 0x00158C18
	public Description Description
	{
		[CompilerGenerated]
		get
		{
			return this.<Description>k__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			this.<Description>k__BackingField = value;
		}
	}

	// Token: 0x1700088D RID: 2189
	// (get) Token: 0x060034B7 RID: 13495 RVA: 0x0015A821 File Offset: 0x00158C21
	public virtual List<string> EffectBattlePopupDetails
	{
		get
		{
			return this.Description.Details2.Split(new char[]
			{
				';'
			}).ToList<string>();
		}
	}

	// Token: 0x060034B8 RID: 13496 RVA: 0x0015A844 File Offset: 0x00158C44
	public virtual IEnumerable Triggered(IBattleUnit effectWearer)
	{
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectWearer, AdventureEventType.UnitEffectTriggered, this)).GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object _ = enumerator.Current;
				yield return _;
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
		yield break;
	}

	// Token: 0x1700088E RID: 2190
	// (get) Token: 0x060034B9 RID: 13497 RVA: 0x0015A86E File Offset: 0x00158C6E
	public IBattleUnit SourceUnit
	{
		get
		{
			return this.EffectSource.SourceUnit;
		}
	}

	// Token: 0x060034BA RID: 13498 RVA: 0x0015A87C File Offset: 0x00158C7C
	public void Refresh()
	{
		if (this.MaxNumberOfLastingSeconds != null)
		{
			this.Timer = 0f;
		}
		if (this.NumberOfLastingTurns != null)
		{
			this.TurnEventsCollected = new List<AdventureEventType>();
		}
	}

	// Token: 0x060034BB RID: 13499 RVA: 0x0015A8C5 File Offset: 0x00158CC5
	// Note: this type is marked as 'beforefieldinit'.
	static BattleEffectBase()
	{
	}

	// Token: 0x040028C9 RID: 10441
	public float Timer;

	// Token: 0x040028CA RID: 10442
	public static float PerSecondGap = 1f;

	// Token: 0x040028CB RID: 10443
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string <Id>k__BackingField;

	// Token: 0x040028CC RID: 10444
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<AdventureEventType> <TurnEventsCollected>k__BackingField;

	// Token: 0x040028CD RID: 10445
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Description <Description>k__BackingField;

	// Token: 0x02000E90 RID: 3728
	[CompilerGenerated]
	private sealed class <Process>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DD8 RID: 24024 RVA: 0x0015A8D1 File Offset: 0x00158CD1
		[DebuggerHidden]
		public <Process>c__Iterator0()
		{
		}

		// Token: 0x06005DD9 RID: 24025 RVA: 0x0015A8DC File Offset: 0x00158CDC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				if (eventType == AdventureEventType.UnitReadyInBattle && eventTriggerUnit == listener)
				{
					this.Timer = 0f;
				}
				if (eventType != AdventureEventType.BattleEffectTurnProgresses || !(data is BattleEffectBase) || data != this)
				{
					goto IL_1D6;
				}
				if (!listener.IsAliveInBattle())
				{
					enumerator2 = this.PerTurnProgressesLogic_InactiveUnit().GetEnumerator();
					num = 4294967293u;
					goto Block_9;
				}
				enumerator = this.PerTurnProgressesLogic_ActiveUnit().GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_154;
			case 3u:
				Block_11:
				try
				{
					switch (num)
					{
					}
					if (enumerator3.MoveNext())
					{
						_3 = enumerator3.Current;
						this.$current = _3;
						if (!this.$disposing)
						{
							this.$PC = 3;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable3 = (enumerator3 as IDisposable)) != null)
						{
							disposable3.Dispose();
						}
					}
				}
				goto IL_351;
			case 4u:
				Block_12:
				try
				{
					switch (num)
					{
					}
					if (enumerator4.MoveNext())
					{
						_4 = enumerator4.Current;
						this.$current = _4;
						if (!this.$disposing)
						{
							this.$PC = 4;
						}
						flag = true;
						return true;
					}
				}
				finally
				{
					if (!flag)
					{
						if ((disposable4 = (enumerator4 as IDisposable)) != null)
						{
							disposable4.Dispose();
						}
					}
				}
				goto IL_351;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			goto IL_1D6;
			Block_9:
			try
			{
				IL_154:
				switch (num)
				{
				}
				if (enumerator2.MoveNext())
				{
					_2 = enumerator2.Current;
					this.$current = _2;
					if (!this.$disposing)
					{
						this.$PC = 2;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
			IL_1D6:
			if (listener.IsAliveInBattle())
			{
				enumerator3 = this.ProcessEvent_ExtraLogic_ActiveUnit(eventTriggerUnit, listener, eventType, data).GetEnumerator();
				num = 4294967293u;
				goto Block_11;
			}
			enumerator4 = this.ProcessEvent_ExtraLogic_InactiveUnit(eventTriggerUnit, listener, eventType, data).GetEnumerator();
			num = 4294967293u;
			goto Block_12;
			IL_351:
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001398 RID: 5016
		// (get) Token: 0x06005DDA RID: 24026 RVA: 0x0015AC78 File Offset: 0x00159078
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001399 RID: 5017
		// (get) Token: 0x06005DDB RID: 24027 RVA: 0x0015AC80 File Offset: 0x00159080
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DDC RID: 24028 RVA: 0x0015AC88 File Offset: 0x00159088
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			case 2u:
				try
				{
				}
				finally
				{
					if ((disposable2 = (enumerator2 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator3 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			case 4u:
				try
				{
				}
				finally
				{
					if ((disposable4 = (enumerator4 as IDisposable)) != null)
					{
						disposable4.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005DDD RID: 24029 RVA: 0x0015ADB4 File Offset: 0x001591B4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DDE RID: 24030 RVA: 0x0015ADBB File Offset: 0x001591BB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DDF RID: 24031 RVA: 0x0015ADC4 File Offset: 0x001591C4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEffectBase.<Process>c__Iterator0 <Process>c__Iterator = new BattleEffectBase.<Process>c__Iterator0();
			<Process>c__Iterator.$this = this;
			<Process>c__Iterator.eventType = eventType;
			<Process>c__Iterator.eventTriggerUnit = eventTriggerUnit;
			<Process>c__Iterator.listener = listener;
			<Process>c__Iterator.data = data;
			return <Process>c__Iterator;
		}

		// Token: 0x04005166 RID: 20838
		internal AdventureEventType eventType;

		// Token: 0x04005167 RID: 20839
		internal IBattleUnit eventTriggerUnit;

		// Token: 0x04005168 RID: 20840
		internal IBattleUnit listener;

		// Token: 0x04005169 RID: 20841
		internal object data;

		// Token: 0x0400516A RID: 20842
		internal IEnumerator $locvar0;

		// Token: 0x0400516B RID: 20843
		internal object <_>__1;

		// Token: 0x0400516C RID: 20844
		internal IDisposable $locvar1;

		// Token: 0x0400516D RID: 20845
		internal IEnumerator $locvar2;

		// Token: 0x0400516E RID: 20846
		internal object <_>__2;

		// Token: 0x0400516F RID: 20847
		internal IDisposable $locvar3;

		// Token: 0x04005170 RID: 20848
		internal IEnumerator $locvar4;

		// Token: 0x04005171 RID: 20849
		internal object <_>__3;

		// Token: 0x04005172 RID: 20850
		internal IDisposable $locvar5;

		// Token: 0x04005173 RID: 20851
		internal IEnumerator $locvar6;

		// Token: 0x04005174 RID: 20852
		internal object <_>__4;

		// Token: 0x04005175 RID: 20853
		internal IDisposable $locvar7;

		// Token: 0x04005176 RID: 20854
		internal BattleEffectBase $this;

		// Token: 0x04005177 RID: 20855
		internal object $current;

		// Token: 0x04005178 RID: 20856
		internal bool $disposing;

		// Token: 0x04005179 RID: 20857
		internal int $PC;
	}

	// Token: 0x02000E91 RID: 3729
	[CompilerGenerated]
	private sealed class <PosWearsOffProcess_ActiveUnit>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DE0 RID: 24032 RVA: 0x0015AE28 File Offset: 0x00159228
		[DebuggerHidden]
		public <PosWearsOffProcess_ActiveUnit>c__Iterator1()
		{
		}

		// Token: 0x06005DE1 RID: 24033 RVA: 0x0015AE30 File Offset: 0x00159230
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700139A RID: 5018
		// (get) Token: 0x06005DE2 RID: 24034 RVA: 0x0015AE4A File Offset: 0x0015924A
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700139B RID: 5019
		// (get) Token: 0x06005DE3 RID: 24035 RVA: 0x0015AE52 File Offset: 0x00159252
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DE4 RID: 24036 RVA: 0x0015AE5A File Offset: 0x0015925A
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005DE5 RID: 24037 RVA: 0x0015AE5C File Offset: 0x0015925C
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DE6 RID: 24038 RVA: 0x0015AE63 File Offset: 0x00159263
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DE7 RID: 24039 RVA: 0x0015AE6B File Offset: 0x0015926B
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEffectBase.<PosWearsOffProcess_ActiveUnit>c__Iterator1();
		}

		// Token: 0x0400517A RID: 20858
		internal object $current;

		// Token: 0x0400517B RID: 20859
		internal bool $disposing;

		// Token: 0x0400517C RID: 20860
		internal int $PC;
	}

	// Token: 0x02000E92 RID: 3730
	[CompilerGenerated]
	private sealed class <PosWearsOffProcess_InactiveUnit>c__Iterator2 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DE8 RID: 24040 RVA: 0x0015AE86 File Offset: 0x00159286
		[DebuggerHidden]
		public <PosWearsOffProcess_InactiveUnit>c__Iterator2()
		{
		}

		// Token: 0x06005DE9 RID: 24041 RVA: 0x0015AE8E File Offset: 0x0015928E
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700139C RID: 5020
		// (get) Token: 0x06005DEA RID: 24042 RVA: 0x0015AEA8 File Offset: 0x001592A8
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700139D RID: 5021
		// (get) Token: 0x06005DEB RID: 24043 RVA: 0x0015AEB0 File Offset: 0x001592B0
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DEC RID: 24044 RVA: 0x0015AEB8 File Offset: 0x001592B8
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005DED RID: 24045 RVA: 0x0015AEBA File Offset: 0x001592BA
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DEE RID: 24046 RVA: 0x0015AEC1 File Offset: 0x001592C1
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DEF RID: 24047 RVA: 0x0015AEC9 File Offset: 0x001592C9
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEffectBase.<PosWearsOffProcess_InactiveUnit>c__Iterator2();
		}

		// Token: 0x0400517D RID: 20861
		internal object $current;

		// Token: 0x0400517E RID: 20862
		internal bool $disposing;

		// Token: 0x0400517F RID: 20863
		internal int $PC;
	}

	// Token: 0x02000E93 RID: 3731
	[CompilerGenerated]
	private sealed class <PerTurnProgressesLogic_ActiveUnit>c__Iterator3 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DF0 RID: 24048 RVA: 0x0015AEE4 File Offset: 0x001592E4
		[DebuggerHidden]
		public <PerTurnProgressesLogic_ActiveUnit>c__Iterator3()
		{
		}

		// Token: 0x06005DF1 RID: 24049 RVA: 0x0015AEEC File Offset: 0x001592EC
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x1700139E RID: 5022
		// (get) Token: 0x06005DF2 RID: 24050 RVA: 0x0015AF06 File Offset: 0x00159306
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700139F RID: 5023
		// (get) Token: 0x06005DF3 RID: 24051 RVA: 0x0015AF0E File Offset: 0x0015930E
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DF4 RID: 24052 RVA: 0x0015AF16 File Offset: 0x00159316
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005DF5 RID: 24053 RVA: 0x0015AF18 File Offset: 0x00159318
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DF6 RID: 24054 RVA: 0x0015AF1F File Offset: 0x0015931F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DF7 RID: 24055 RVA: 0x0015AF27 File Offset: 0x00159327
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEffectBase.<PerTurnProgressesLogic_ActiveUnit>c__Iterator3();
		}

		// Token: 0x04005180 RID: 20864
		internal object $current;

		// Token: 0x04005181 RID: 20865
		internal bool $disposing;

		// Token: 0x04005182 RID: 20866
		internal int $PC;
	}

	// Token: 0x02000E94 RID: 3732
	[CompilerGenerated]
	private sealed class <PerTurnProgressesLogic_InactiveUnit>c__Iterator4 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DF8 RID: 24056 RVA: 0x0015AF42 File Offset: 0x00159342
		[DebuggerHidden]
		public <PerTurnProgressesLogic_InactiveUnit>c__Iterator4()
		{
		}

		// Token: 0x06005DF9 RID: 24057 RVA: 0x0015AF4A File Offset: 0x0015934A
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170013A0 RID: 5024
		// (get) Token: 0x06005DFA RID: 24058 RVA: 0x0015AF64 File Offset: 0x00159364
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013A1 RID: 5025
		// (get) Token: 0x06005DFB RID: 24059 RVA: 0x0015AF6C File Offset: 0x0015936C
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DFC RID: 24060 RVA: 0x0015AF74 File Offset: 0x00159374
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005DFD RID: 24061 RVA: 0x0015AF76 File Offset: 0x00159376
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DFE RID: 24062 RVA: 0x0015AF7D File Offset: 0x0015937D
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DFF RID: 24063 RVA: 0x0015AF85 File Offset: 0x00159385
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEffectBase.<PerTurnProgressesLogic_InactiveUnit>c__Iterator4();
		}

		// Token: 0x04005183 RID: 20867
		internal object $current;

		// Token: 0x04005184 RID: 20868
		internal bool $disposing;

		// Token: 0x04005185 RID: 20869
		internal int $PC;
	}

	// Token: 0x02000E95 RID: 3733
	[CompilerGenerated]
	private sealed class <PerSecondLogic_ActiveUnit>c__Iterator5 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E00 RID: 24064 RVA: 0x0015AFA0 File Offset: 0x001593A0
		[DebuggerHidden]
		public <PerSecondLogic_ActiveUnit>c__Iterator5()
		{
		}

		// Token: 0x06005E01 RID: 24065 RVA: 0x0015AFA8 File Offset: 0x001593A8
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170013A2 RID: 5026
		// (get) Token: 0x06005E02 RID: 24066 RVA: 0x0015AFC2 File Offset: 0x001593C2
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013A3 RID: 5027
		// (get) Token: 0x06005E03 RID: 24067 RVA: 0x0015AFCA File Offset: 0x001593CA
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E04 RID: 24068 RVA: 0x0015AFD2 File Offset: 0x001593D2
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005E05 RID: 24069 RVA: 0x0015AFD4 File Offset: 0x001593D4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E06 RID: 24070 RVA: 0x0015AFDB File Offset: 0x001593DB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E07 RID: 24071 RVA: 0x0015AFE3 File Offset: 0x001593E3
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEffectBase.<PerSecondLogic_ActiveUnit>c__Iterator5();
		}

		// Token: 0x04005186 RID: 20870
		internal object $current;

		// Token: 0x04005187 RID: 20871
		internal bool $disposing;

		// Token: 0x04005188 RID: 20872
		internal int $PC;
	}

	// Token: 0x02000E96 RID: 3734
	[CompilerGenerated]
	private sealed class <PerSecondLogic_InactiveUnit>c__Iterator6 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E08 RID: 24072 RVA: 0x0015AFFE File Offset: 0x001593FE
		[DebuggerHidden]
		public <PerSecondLogic_InactiveUnit>c__Iterator6()
		{
		}

		// Token: 0x06005E09 RID: 24073 RVA: 0x0015B006 File Offset: 0x00159406
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170013A4 RID: 5028
		// (get) Token: 0x06005E0A RID: 24074 RVA: 0x0015B020 File Offset: 0x00159420
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013A5 RID: 5029
		// (get) Token: 0x06005E0B RID: 24075 RVA: 0x0015B028 File Offset: 0x00159428
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E0C RID: 24076 RVA: 0x0015B030 File Offset: 0x00159430
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005E0D RID: 24077 RVA: 0x0015B032 File Offset: 0x00159432
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E0E RID: 24078 RVA: 0x0015B039 File Offset: 0x00159439
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E0F RID: 24079 RVA: 0x0015B041 File Offset: 0x00159441
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEffectBase.<PerSecondLogic_InactiveUnit>c__Iterator6();
		}

		// Token: 0x04005189 RID: 20873
		internal object $current;

		// Token: 0x0400518A RID: 20874
		internal bool $disposing;

		// Token: 0x0400518B RID: 20875
		internal int $PC;
	}

	// Token: 0x02000E97 RID: 3735
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator7 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E10 RID: 24080 RVA: 0x0015B05C File Offset: 0x0015945C
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator7()
		{
		}

		// Token: 0x06005E11 RID: 24081 RVA: 0x0015B064 File Offset: 0x00159464
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170013A6 RID: 5030
		// (get) Token: 0x06005E12 RID: 24082 RVA: 0x0015B07E File Offset: 0x0015947E
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013A7 RID: 5031
		// (get) Token: 0x06005E13 RID: 24083 RVA: 0x0015B086 File Offset: 0x00159486
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E14 RID: 24084 RVA: 0x0015B08E File Offset: 0x0015948E
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005E15 RID: 24085 RVA: 0x0015B090 File Offset: 0x00159490
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E16 RID: 24086 RVA: 0x0015B097 File Offset: 0x00159497
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E17 RID: 24087 RVA: 0x0015B09F File Offset: 0x0015949F
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEffectBase.<ProcessEvent_ExtraLogic_ActiveUnit>c__Iterator7();
		}

		// Token: 0x0400518C RID: 20876
		internal object $current;

		// Token: 0x0400518D RID: 20877
		internal bool $disposing;

		// Token: 0x0400518E RID: 20878
		internal int $PC;
	}

	// Token: 0x02000E98 RID: 3736
	[CompilerGenerated]
	private sealed class <ProcessEvent_ExtraLogic_InactiveUnit>c__Iterator8 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E18 RID: 24088 RVA: 0x0015B0BA File Offset: 0x001594BA
		[DebuggerHidden]
		public <ProcessEvent_ExtraLogic_InactiveUnit>c__Iterator8()
		{
		}

		// Token: 0x06005E19 RID: 24089 RVA: 0x0015B0C2 File Offset: 0x001594C2
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
			}
			return false;
		}

		// Token: 0x170013A8 RID: 5032
		// (get) Token: 0x06005E1A RID: 24090 RVA: 0x0015B0DC File Offset: 0x001594DC
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013A9 RID: 5033
		// (get) Token: 0x06005E1B RID: 24091 RVA: 0x0015B0E4 File Offset: 0x001594E4
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E1C RID: 24092 RVA: 0x0015B0EC File Offset: 0x001594EC
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x06005E1D RID: 24093 RVA: 0x0015B0EE File Offset: 0x001594EE
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E1E RID: 24094 RVA: 0x0015B0F5 File Offset: 0x001594F5
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E1F RID: 24095 RVA: 0x0015B0FD File Offset: 0x001594FD
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			return new BattleEffectBase.<ProcessEvent_ExtraLogic_InactiveUnit>c__Iterator8();
		}

		// Token: 0x0400518F RID: 20879
		internal object $current;

		// Token: 0x04005190 RID: 20880
		internal bool $disposing;

		// Token: 0x04005191 RID: 20881
		internal int $PC;
	}

	// Token: 0x02000E99 RID: 3737
	[CompilerGenerated]
	private sealed class <Triggered>c__Iterator9 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005E20 RID: 24096 RVA: 0x0015B118 File Offset: 0x00159518
		[DebuggerHidden]
		public <Triggered>c__Iterator9()
		{
		}

		// Token: 0x06005E21 RID: 24097 RVA: 0x0015B120 File Offset: 0x00159520
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(effectWearer, AdventureEventType.UnitEffectTriggered, this)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			default:
				return false;
			}
			try
			{
				switch (num)
				{
				}
				if (enumerator.MoveNext())
				{
					_ = enumerator.Current;
					this.$current = _;
					if (!this.$disposing)
					{
						this.$PC = 1;
					}
					flag = true;
					return true;
				}
			}
			finally
			{
				if (!flag)
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
			}
			this.$PC = -1;
			return false;
		}

		// Token: 0x170013AA RID: 5034
		// (get) Token: 0x06005E22 RID: 24098 RVA: 0x0015B218 File Offset: 0x00159618
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170013AB RID: 5035
		// (get) Token: 0x06005E23 RID: 24099 RVA: 0x0015B220 File Offset: 0x00159620
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005E24 RID: 24100 RVA: 0x0015B228 File Offset: 0x00159628
		[DebuggerHidden]
		public void Dispose()
		{
			uint num = (uint)this.$PC;
			this.$disposing = true;
			this.$PC = -1;
			switch (num)
			{
			case 1u:
				try
				{
				}
				finally
				{
					if ((disposable = (enumerator as IDisposable)) != null)
					{
						disposable.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005E25 RID: 24101 RVA: 0x0015B298 File Offset: 0x00159698
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005E26 RID: 24102 RVA: 0x0015B29F File Offset: 0x0015969F
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005E27 RID: 24103 RVA: 0x0015B2A8 File Offset: 0x001596A8
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			BattleEffectBase.<Triggered>c__Iterator9 <Triggered>c__Iterator = new BattleEffectBase.<Triggered>c__Iterator9();
			<Triggered>c__Iterator.$this = this;
			<Triggered>c__Iterator.effectWearer = effectWearer;
			return <Triggered>c__Iterator;
		}

		// Token: 0x04005192 RID: 20882
		internal IBattleUnit effectWearer;

		// Token: 0x04005193 RID: 20883
		internal IEnumerator $locvar0;

		// Token: 0x04005194 RID: 20884
		internal object <_>__1;

		// Token: 0x04005195 RID: 20885
		internal IDisposable $locvar1;

		// Token: 0x04005196 RID: 20886
		internal BattleEffectBase $this;

		// Token: 0x04005197 RID: 20887
		internal object $current;

		// Token: 0x04005198 RID: 20888
		internal bool $disposing;

		// Token: 0x04005199 RID: 20889
		internal int $PC;
	}
}
