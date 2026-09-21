using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

// Token: 0x0200072D RID: 1837
public class ReleaseableHeal : IReleaseable
{
	// Token: 0x06003397 RID: 13207 RVA: 0x0015A0F3 File Offset: 0x001584F3
	public ReleaseableHeal(List<BattleHeal> battleHeals, IBattleUnit healer)
	{
		this.BattleHeals = battleHeals;
		this.Healer = healer;
		this.Status = ReleaseStatus.NotReleased;
	}

	// Token: 0x170007FF RID: 2047
	// (get) Token: 0x06003398 RID: 13208 RVA: 0x0015A110 File Offset: 0x00158510
	// (set) Token: 0x06003399 RID: 13209 RVA: 0x0015A118 File Offset: 0x00158518
	public ReleaseStatus Status
	{
		[CompilerGenerated]
		get
		{
			return this.<Status>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Status>k__BackingField = value;
		}
	}

	// Token: 0x17000800 RID: 2048
	// (get) Token: 0x0600339A RID: 13210 RVA: 0x0015A121 File Offset: 0x00158521
	// (set) Token: 0x0600339B RID: 13211 RVA: 0x0015A129 File Offset: 0x00158529
	public List<BattleHeal> BattleHeals
	{
		[CompilerGenerated]
		get
		{
			return this.<BattleHeals>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<BattleHeals>k__BackingField = value;
		}
	}

	// Token: 0x17000801 RID: 2049
	// (get) Token: 0x0600339C RID: 13212 RVA: 0x0015A132 File Offset: 0x00158532
	// (set) Token: 0x0600339D RID: 13213 RVA: 0x0015A13A File Offset: 0x0015853A
	public IBattleUnit Healer
	{
		[CompilerGenerated]
		get
		{
			return this.<Healer>k__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			this.<Healer>k__BackingField = value;
		}
	}

	// Token: 0x0600339E RID: 13214 RVA: 0x0015A144 File Offset: 0x00158544
	public IEnumerable Release()
	{
		this.Status = ReleaseStatus.Releasing;
		IEnumerator enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(this.Healer, AdventureEventType.UnitReleasesHeal, this)).GetEnumerator();
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
		foreach (BattleHeal heal in this.BattleHeals)
		{
			if (heal.Target.Status == BattleUnitStatus.Active || heal.ApplicableToDeadUnit)
			{
				IEnumerator enumerator3 = heal.Target.ReceivesHeal(heal).GetEnumerator();
				try
				{
					while (enumerator3.MoveNext())
					{
						object _2 = enumerator3.Current;
						yield return _2;
					}
				}
				finally
				{
					IDisposable disposable2;
					if ((disposable2 = (enumerator3 as IDisposable)) != null)
					{
						disposable2.Dispose();
					}
				}
			}
		}
		IEnumerator enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(this.Healer, AdventureEventType.PostHealRelease, this)).GetEnumerator();
		try
		{
			while (enumerator4.MoveNext())
			{
				object _3 = enumerator4.Current;
				yield return _3;
			}
		}
		finally
		{
			IDisposable disposable3;
			if ((disposable3 = (enumerator4 as IDisposable)) != null)
			{
				disposable3.Dispose();
			}
		}
		this.Status = ReleaseStatus.Released;
		yield break;
	}

	// Token: 0x04002834 RID: 10292
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ReleaseStatus <Status>k__BackingField;

	// Token: 0x04002835 RID: 10293
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<BattleHeal> <BattleHeals>k__BackingField;

	// Token: 0x04002836 RID: 10294
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IBattleUnit <Healer>k__BackingField;

	// Token: 0x02000E8B RID: 3723
	[CompilerGenerated]
	private sealed class <Release>c__Iterator0 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005DB4 RID: 23988 RVA: 0x0015A167 File Offset: 0x00158567
		[DebuggerHidden]
		public <Release>c__Iterator0()
		{
		}

		// Token: 0x06005DB5 RID: 23989 RVA: 0x0015A170 File Offset: 0x00158570
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				base.Status = ReleaseStatus.Releasing;
				enumerator = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(base.Healer, AdventureEventType.UnitReleasesHeal, this)).GetEnumerator();
				num = 4294967293u;
				break;
			case 1u:
				break;
			case 2u:
				goto IL_102;
			case 3u:
				goto IL_24B;
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
			enumerator2 = base.BattleHeals.GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_102:
				switch (num)
				{
				case 2u:
					Block_13:
					try
					{
						switch (num)
						{
						}
						if (enumerator3.MoveNext())
						{
							_2 = enumerator3.Current;
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
							if ((disposable2 = (enumerator3 as IDisposable)) != null)
							{
								disposable2.Dispose();
							}
						}
					}
					break;
				}
				while (enumerator2.MoveNext())
				{
					heal = enumerator2.Current;
					if (heal.Target.Status == BattleUnitStatus.Active || heal.ApplicableToDeadUnit)
					{
						enumerator3 = heal.Target.ReceivesHeal(heal).GetEnumerator();
						num = 4294967293u;
						goto Block_13;
					}
				}
			}
			finally
			{
				if (!flag)
				{
					((IDisposable)enumerator2).Dispose();
				}
			}
			enumerator4 = GameWorld.instance.BroadCastAdventureEvent(new BroadcastEvent(base.Healer, AdventureEventType.PostHealRelease, this)).GetEnumerator();
			num = 4294967293u;
			try
			{
				IL_24B:
				switch (num)
				{
				}
				if (enumerator4.MoveNext())
				{
					_3 = enumerator4.Current;
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
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
			}
			base.Status = ReleaseStatus.Released;
			this.$PC = -1;
			return false;
		}

		// Token: 0x17001390 RID: 5008
		// (get) Token: 0x06005DB6 RID: 23990 RVA: 0x0015A4C4 File Offset: 0x001588C4
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x17001391 RID: 5009
		// (get) Token: 0x06005DB7 RID: 23991 RVA: 0x0015A4CC File Offset: 0x001588CC
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005DB8 RID: 23992 RVA: 0x0015A4D4 File Offset: 0x001588D4
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
					try
					{
					}
					finally
					{
						if ((disposable2 = (enumerator3 as IDisposable)) != null)
						{
							disposable2.Dispose();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2).Dispose();
				}
				break;
			case 3u:
				try
				{
				}
				finally
				{
					if ((disposable3 = (enumerator4 as IDisposable)) != null)
					{
						disposable3.Dispose();
					}
				}
				break;
			}
		}

		// Token: 0x06005DB9 RID: 23993 RVA: 0x0015A5E4 File Offset: 0x001589E4
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06005DBA RID: 23994 RVA: 0x0015A5EB File Offset: 0x001589EB
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x06005DBB RID: 23995 RVA: 0x0015A5F4 File Offset: 0x001589F4
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			ReleaseableHeal.<Release>c__Iterator0 <Release>c__Iterator = new ReleaseableHeal.<Release>c__Iterator0();
			<Release>c__Iterator.$this = this;
			return <Release>c__Iterator;
		}

		// Token: 0x04005129 RID: 20777
		internal IEnumerator $locvar0;

		// Token: 0x0400512A RID: 20778
		internal object <_>__1;

		// Token: 0x0400512B RID: 20779
		internal IDisposable $locvar1;

		// Token: 0x0400512C RID: 20780
		internal List<BattleHeal>.Enumerator $locvar2;

		// Token: 0x0400512D RID: 20781
		internal BattleHeal <heal>__2;

		// Token: 0x0400512E RID: 20782
		internal IEnumerator $locvar3;

		// Token: 0x0400512F RID: 20783
		internal object <_>__3;

		// Token: 0x04005130 RID: 20784
		internal IDisposable $locvar4;

		// Token: 0x04005131 RID: 20785
		internal IEnumerator $locvar5;

		// Token: 0x04005132 RID: 20786
		internal object <_>__4;

		// Token: 0x04005133 RID: 20787
		internal IDisposable $locvar6;

		// Token: 0x04005134 RID: 20788
		internal ReleaseableHeal $this;

		// Token: 0x04005135 RID: 20789
		internal object $current;

		// Token: 0x04005136 RID: 20790
		internal bool $disposing;

		// Token: 0x04005137 RID: 20791
		internal int $PC;
	}
}
