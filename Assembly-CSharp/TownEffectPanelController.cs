using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x020002DB RID: 731
public class TownEffectPanelController : MonoBehaviour
{
	// Token: 0x0600136F RID: 4975 RVA: 0x000A328B File Offset: 0x000A168B
	public TownEffectPanelController()
	{
	}

	// Token: 0x06001370 RID: 4976 RVA: 0x000A3294 File Offset: 0x000A1694
	private void Start()
	{
		List<TownEffectBase> townEffects = GameWorld.instance.PlayerProfile.GetTownEffects();
		foreach (TownEffectBase effect in townEffects)
		{
			this.TownEffectAdded(effect);
		}
		this.EffectContainer.gameObject.SetActive(townEffects.Count > 0);
	}

	// Token: 0x06001371 RID: 4977 RVA: 0x000A3314 File Offset: 0x000A1714
	public void Init()
	{
		List<TownEffectBase> townEffects = GameWorld.instance.PlayerProfile.TownEffects;
		IEnumerator enumerator = this.EffectContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.gameObject.PoolDestroy(PoolType.TownEffectItem);
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
		foreach (TownEffectBase townEffect in townEffects)
		{
			GameObject gameObject = this.PoolObject(PoolType.TownEffectItem, default(Vector3));
			gameObject.GetComponent<TownEffectItemController>().Init(townEffect);
			gameObject.transform.SetParent(this.EffectContainer, false);
			gameObject.transform.localScale = Vector3.one;
			gameObject.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
		}
	}

	// Token: 0x06001372 RID: 4978 RVA: 0x000A3428 File Offset: 0x000A1828
	public void TownEffectAdded(TownEffectBase effect)
	{
		this.EffectContainer.gameObject.SetActive(true);
		GameObject gameObject = this.PoolObject(PoolType.TownEffectItem, default(Vector3));
		gameObject.GetComponent<TownEffectItemController>().Init(effect);
		gameObject.transform.SetParent(this.EffectContainer, false);
		gameObject.transform.localScale = Vector3.one;
	}

	// Token: 0x06001373 RID: 4979 RVA: 0x000A3488 File Offset: 0x000A1888
	public void TownEffectRemoved(TownEffectBase effect)
	{
		IEnumerator enumerator = this.EffectContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				TownEffectItemController component = transform.GetComponent<TownEffectItemController>();
				if (component != null && component.TownEffect == effect)
				{
					if (component.MouseOvered)
					{
						this.CloseTooltip();
					}
					transform.gameObject.PoolDestroy(PoolType.TownEffectItem);
					break;
				}
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
		List<TownEffectBase> townEffects = GameWorld.instance.PlayerProfile.GetTownEffects();
		if (townEffects.Count <= 0)
		{
			this.EffectContainer.gameObject.SetActive(false);
		}
	}

	// Token: 0x040013FE RID: 5118
	public Transform EffectContainer;
}
