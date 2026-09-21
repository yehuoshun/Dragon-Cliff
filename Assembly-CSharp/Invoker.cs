using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000A1C RID: 2588
public class Invoker : MonoBehaviour
{
	// Token: 0x060046A0 RID: 18080 RVA: 0x001CF063 File Offset: 0x001CD463
	public Invoker()
	{
	}

	// Token: 0x17000DC0 RID: 3520
	// (get) Token: 0x060046A1 RID: 18081 RVA: 0x001CF08C File Offset: 0x001CD48C
	public static Invoker Instance
	{
		get
		{
			if (Invoker._instance == null)
			{
				GameObject gameObject = new GameObject();
				gameObject.AddComponent<Invoker>();
				gameObject.name = "_FunoniumInvoker";
				Invoker._instance = gameObject.GetComponent<Invoker>();
			}
			return Invoker._instance;
		}
	}

	// Token: 0x060046A2 RID: 18082 RVA: 0x001CF0D1 File Offset: 0x001CD4D1
	public float RealDeltaTime()
	{
		return this.fRealDeltaTime;
	}

	// Token: 0x060046A3 RID: 18083 RVA: 0x001CF0D9 File Offset: 0x001CD4D9
	public static void InvokeDelayed(Invokable func, float delaySeconds)
	{
		Invoker.Instance.invokeListPendingAddition.Add(new Invoker.InvokableItem(func, delaySeconds));
	}

	// Token: 0x060046A4 RID: 18084 RVA: 0x001CF0F4 File Offset: 0x001CD4F4
	public void Update()
	{
		this.fRealDeltaTime = Time.realtimeSinceStartup - this.fRealTimeLastFrame;
		this.fRealTimeLastFrame = Time.realtimeSinceStartup;
		foreach (Invoker.InvokableItem item in this.invokeListPendingAddition)
		{
			this.invokeList.Add(item);
		}
		this.invokeListPendingAddition.Clear();
		foreach (Invoker.InvokableItem item2 in this.invokeList)
		{
			if (item2.executeAtTime <= Time.realtimeSinceStartup)
			{
				if (item2.func != null)
				{
					item2.func();
				}
				this.invokeListExecuted.Add(item2);
			}
		}
		foreach (Invoker.InvokableItem item3 in this.invokeListExecuted)
		{
			this.invokeList.Remove(item3);
		}
		this.invokeListExecuted.Clear();
	}

	// Token: 0x060046A5 RID: 18085 RVA: 0x001CF258 File Offset: 0x001CD658
	// Note: this type is marked as 'beforefieldinit'.
	static Invoker()
	{
	}

	// Token: 0x040035C2 RID: 13762
	private static Invoker _instance;

	// Token: 0x040035C3 RID: 13763
	private float fRealTimeLastFrame;

	// Token: 0x040035C4 RID: 13764
	private float fRealDeltaTime;

	// Token: 0x040035C5 RID: 13765
	private List<Invoker.InvokableItem> invokeList = new List<Invoker.InvokableItem>();

	// Token: 0x040035C6 RID: 13766
	private List<Invoker.InvokableItem> invokeListPendingAddition = new List<Invoker.InvokableItem>();

	// Token: 0x040035C7 RID: 13767
	private List<Invoker.InvokableItem> invokeListExecuted = new List<Invoker.InvokableItem>();

	// Token: 0x02000A1D RID: 2589
	private struct InvokableItem
	{
		// Token: 0x060046A6 RID: 18086 RVA: 0x001CF25A File Offset: 0x001CD65A
		public InvokableItem(Invokable func, float delaySeconds)
		{
			this.func = func;
			if (Time.time == 0f)
			{
				this.executeAtTime = delaySeconds;
			}
			else
			{
				this.executeAtTime = Time.realtimeSinceStartup + delaySeconds;
			}
		}

		// Token: 0x060046A7 RID: 18087 RVA: 0x001CF28B File Offset: 0x001CD68B
		// Note: this type is marked as 'beforefieldinit'.
		static InvokableItem()
		{
		}

		// Token: 0x040035C8 RID: 13768
		public Invokable func;

		// Token: 0x040035C9 RID: 13769
		public float executeAtTime;

		// Token: 0x040035CA RID: 13770
		public static Invoker _instance;
	}
}
