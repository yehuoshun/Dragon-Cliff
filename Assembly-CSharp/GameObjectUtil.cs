using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class GameObjectUtil
{
	// Token: 0x060017AB RID: 6059 RVA: 0x000B6A48 File Offset: 0x000B4E48
	public GameObjectUtil()
	{
	}

	// Token: 0x060017AC RID: 6060 RVA: 0x000B6A50 File Offset: 0x000B4E50
	public static GameObject Instantiate(GameObject prefab, Vector3 pos, GameObject Container)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(prefab);
		if (Container != null)
		{
			gameObject.transform.SetParent(Container.transform, false);
		}
		gameObject.transform.position = pos;
		return gameObject;
	}

	// Token: 0x060017AD RID: 6061 RVA: 0x000B6A8F File Offset: 0x000B4E8F
	public static void RecycleDestroy(GameObject gameObject)
	{
		if (gameObject != null)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	// Token: 0x060017AE RID: 6062 RVA: 0x000B6AA4 File Offset: 0x000B4EA4
	public static IEnumerator WaitToRecycle(GameObject gameObject)
	{
		yield return new WaitForSeconds(3f);
		GameObjectUtil.RecycleDestroy(gameObject);
		yield break;
	}

	// Token: 0x060017AF RID: 6063 RVA: 0x000B6AC0 File Offset: 0x000B4EC0
	public static IEnumerable Recycling(GameObject gameObject)
	{
		yield return new WaitForSeconds(2f);
		GameObjectUtil.RecycleDestroy(gameObject);
		yield break;
	}

	// Token: 0x060017B0 RID: 6064 RVA: 0x000B6AE4 File Offset: 0x000B4EE4
	private static BattleObjectPool GetBattleObjectPool(RecycleGameObject reference, GameObject pooledContainer)
	{
		BattleObjectPool battleObjectPool;
		if (GameObjectUtil.pools.ContainsKey(reference))
		{
			battleObjectPool = GameObjectUtil.pools[reference];
		}
		else
		{
			GameObject gameObject = pooledContainer;
			if (pooledContainer == null)
			{
				gameObject = new GameObject(reference.gameObject.name + "BattleObjectPool");
			}
			battleObjectPool = gameObject.AddComponent<BattleObjectPool>();
			battleObjectPool.prefab = reference;
			GameObjectUtil.pools.Add(reference, battleObjectPool);
		}
		return battleObjectPool;
	}

	// Token: 0x060017B1 RID: 6065 RVA: 0x000B6B58 File Offset: 0x000B4F58
	public static TType GetComponentInChildren<TType>(GameObject objRoot) where TType : Component
	{
		TType ttype = objRoot.GetComponent<TType>();
		if (null == ttype)
		{
			Transform transform = objRoot.transform;
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				ttype = GameObjectUtil.GetComponentInChildren<TType>(transform.GetChild(i).gameObject);
				if (null != ttype)
				{
					break;
				}
			}
		}
		return ttype;
	}

	// Token: 0x060017B2 RID: 6066 RVA: 0x000B6BC6 File Offset: 0x000B4FC6
	// Note: this type is marked as 'beforefieldinit'.
	static GameObjectUtil()
	{
	}

	// Token: 0x0400178D RID: 6029
	private static Dictionary<RecycleGameObject, BattleObjectPool> pools = new Dictionary<RecycleGameObject, BattleObjectPool>();

	// Token: 0x02000CBD RID: 3261
	[CompilerGenerated]
	private sealed class <WaitToRecycle>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x0600543E RID: 21566 RVA: 0x000B6BD2 File Offset: 0x000B4FD2
		[DebuggerHidden]
		public <WaitToRecycle>c__Iterator0()
		{
		}

		// Token: 0x0600543F RID: 21567 RVA: 0x000B6BDC File Offset: 0x000B4FDC
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(3f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				GameObjectUtil.RecycleDestroy(gameObject);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011DE RID: 4574
		// (get) Token: 0x06005440 RID: 21568 RVA: 0x000B6C43 File Offset: 0x000B5043
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011DF RID: 4575
		// (get) Token: 0x06005441 RID: 21569 RVA: 0x000B6C4B File Offset: 0x000B504B
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005442 RID: 21570 RVA: 0x000B6C53 File Offset: 0x000B5053
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005443 RID: 21571 RVA: 0x000B6C63 File Offset: 0x000B5063
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040041BB RID: 16827
		internal GameObject gameObject;

		// Token: 0x040041BC RID: 16828
		internal object $current;

		// Token: 0x040041BD RID: 16829
		internal bool $disposing;

		// Token: 0x040041BE RID: 16830
		internal int $PC;
	}

	// Token: 0x02000CBE RID: 3262
	[CompilerGenerated]
	private sealed class <Recycling>c__Iterator1 : IEnumerable, IEnumerable<object>, IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005444 RID: 21572 RVA: 0x000B6C6A File Offset: 0x000B506A
		[DebuggerHidden]
		public <Recycling>c__Iterator1()
		{
		}

		// Token: 0x06005445 RID: 21573 RVA: 0x000B6C74 File Offset: 0x000B5074
		public bool MoveNext()
		{
			uint num = (uint)this.$PC;
			this.$PC = -1;
			switch (num)
			{
			case 0u:
				this.$current = new WaitForSeconds(2f);
				if (!this.$disposing)
				{
					this.$PC = 1;
				}
				return true;
			case 1u:
				GameObjectUtil.RecycleDestroy(gameObject);
				this.$PC = -1;
				break;
			}
			return false;
		}

		// Token: 0x170011E0 RID: 4576
		// (get) Token: 0x06005446 RID: 21574 RVA: 0x000B6CDB File Offset: 0x000B50DB
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x170011E1 RID: 4577
		// (get) Token: 0x06005447 RID: 21575 RVA: 0x000B6CE3 File Offset: 0x000B50E3
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005448 RID: 21576 RVA: 0x000B6CEB File Offset: 0x000B50EB
		[DebuggerHidden]
		public void Dispose()
		{
			this.$disposing = true;
			this.$PC = -1;
		}

		// Token: 0x06005449 RID: 21577 RVA: 0x000B6CFB File Offset: 0x000B50FB
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600544A RID: 21578 RVA: 0x000B6D02 File Offset: 0x000B5102
		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.System.Collections.Generic.IEnumerable<object>.GetEnumerator();
		}

		// Token: 0x0600544B RID: 21579 RVA: 0x000B6D0C File Offset: 0x000B510C
		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
			{
				return this;
			}
			GameObjectUtil.<Recycling>c__Iterator1 <Recycling>c__Iterator = new GameObjectUtil.<Recycling>c__Iterator1();
			<Recycling>c__Iterator.gameObject = gameObject;
			return <Recycling>c__Iterator;
		}

		// Token: 0x040041BF RID: 16831
		internal GameObject gameObject;

		// Token: 0x040041C0 RID: 16832
		internal object $current;

		// Token: 0x040041C1 RID: 16833
		internal bool $disposing;

		// Token: 0x040041C2 RID: 16834
		internal int $PC;
	}
}
