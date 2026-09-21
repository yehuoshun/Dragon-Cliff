using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Town.ObjectPool;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class ResidentPanelController : MonoBehaviour
{
	// Token: 0x06000F61 RID: 3937 RVA: 0x0009431D File Offset: 0x0009271D
	public ResidentPanelController()
	{
	}

	// Token: 0x06000F62 RID: 3938 RVA: 0x00094330 File Offset: 0x00092730
	public void Init(List<Resident> residents, bool isResident)
	{
		this._residents = residents;
		IEnumerator enumerator = this.CardContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.GetComponent<ResidentItemBaseController>().ClearChildren();
				transform.gameObject.PoolDestroy((!isResident) ? PoolType.CandidateItem : PoolType.ResidentItem);
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
		foreach (Resident resident in residents)
		{
			GameObject gameObject = this.PoolObject((!isResident) ? PoolType.CandidateItem : PoolType.ResidentItem, default(Vector3));
			gameObject.GetComponent<ResidentItemBaseController>().Init(resident);
			gameObject.transform.SetParent(this.CardContainer, false);
			gameObject.transform.localScale = Vector3.one;
			gameObject.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
		}
	}

	// Token: 0x06000F63 RID: 3939 RVA: 0x00094460 File Offset: 0x00092860
	public void AddNew(Resident resident, bool isResident)
	{
		this._residents.Add(resident);
		GameObject gameObject = this.PoolObject((!isResident) ? PoolType.CandidateItem : PoolType.ResidentItem, default(Vector3));
		gameObject.GetComponent<ResidentItemBaseController>().Init(resident);
		gameObject.transform.SetParent(this.CardContainer, false);
		gameObject.transform.localScale = Vector3.one;
		gameObject.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
	}

	// Token: 0x06000F64 RID: 3940 RVA: 0x000944D8 File Offset: 0x000928D8
	public void Remove(string id, bool isResident)
	{
		IEnumerator enumerator = this.CardContainer.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				ResidentItemBaseController component = transform.GetComponent<ResidentItemBaseController>();
				if (component.Resident.Id == id)
				{
					component.ClearChildren();
					transform.gameObject.PoolDestroy((!isResident) ? PoolType.CandidateItem : PoolType.ResidentItem);
					transform.SetParent(null, false);
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
	}

	// Token: 0x06000F65 RID: 3941 RVA: 0x00094580 File Offset: 0x00092980
	public void OrderItems(ResidentEffectType effectType)
	{
		if (this._residents == null)
		{
			return;
		}
		List<Transform> list = new List<Transform>();
		for (int i = this.CardContainer.childCount - 1; i >= 0; i--)
		{
			Transform child = this.CardContainer.GetChild(i);
			list.Add(child);
		}
		List<Transform> list2 = (from c in list
		where c.GetComponent<ResidentItemBaseController>().Resident.Effects.Any((IResidentEffect e) => e.CorrespondingEffectType == effectType)
		select c).ToList<Transform>();
		List<Transform> list3 = (from c in list
		where c.GetComponent<ResidentItemBaseController>().Resident.Effects.All((IResidentEffect e) => e.CorrespondingEffectType != effectType)
		select c).ToList<Transform>();
		list2.Sort((Transform r1, Transform r2) => r1.GetComponent<ResidentItemBaseController>().Resident.Effects.First((IResidentEffect e) => e.CorrespondingEffectType == effectType).GetEffectValue().CompareTo(r2.GetComponent<ResidentItemBaseController>().Resident.Effects.First((IResidentEffect e) => e.CorrespondingEffectType == effectType).GetEffectValue()));
		for (int j = 0; j < list2.Count; j++)
		{
			list2[j].SetSiblingIndex(j);
		}
		for (int k = list2.Count; k < list3.Count; k++)
		{
			list3[k].SetSiblingIndex(k);
		}
	}

	// Token: 0x040010B0 RID: 4272
	public Transform CardContainer;

	// Token: 0x040010B1 RID: 4273
	public ResidentItemBaseController ResidentItemBase;

	// Token: 0x040010B2 RID: 4274
	private List<Resident> _residents = new List<Resident>();

	// Token: 0x02000C53 RID: 3155
	[CompilerGenerated]
	private sealed class <OrderItems>c__AnonStorey0
	{
		// Token: 0x060052A1 RID: 21153 RVA: 0x00094681 File Offset: 0x00092A81
		public <OrderItems>c__AnonStorey0()
		{
		}

		// Token: 0x060052A2 RID: 21154 RVA: 0x00094689 File Offset: 0x00092A89
		internal bool <>m__0(Transform c)
		{
			return c.GetComponent<ResidentItemBaseController>().Resident.Effects.Any((IResidentEffect e) => e.CorrespondingEffectType == this.effectType);
		}

		// Token: 0x060052A3 RID: 21155 RVA: 0x000946AC File Offset: 0x00092AAC
		internal bool <>m__1(Transform c)
		{
			return c.GetComponent<ResidentItemBaseController>().Resident.Effects.All((IResidentEffect e) => e.CorrespondingEffectType != this.effectType);
		}

		// Token: 0x060052A4 RID: 21156 RVA: 0x000946D0 File Offset: 0x00092AD0
		internal int <>m__2(Transform r1, Transform r2)
		{
			return r1.GetComponent<ResidentItemBaseController>().Resident.Effects.First((IResidentEffect e) => e.CorrespondingEffectType == this.effectType).GetEffectValue().CompareTo(r2.GetComponent<ResidentItemBaseController>().Resident.Effects.First((IResidentEffect e) => e.CorrespondingEffectType == this.effectType).GetEffectValue());
		}

		// Token: 0x060052A5 RID: 21157 RVA: 0x00094731 File Offset: 0x00092B31
		internal bool <>m__3(IResidentEffect e)
		{
			return e.CorrespondingEffectType == this.effectType;
		}

		// Token: 0x060052A6 RID: 21158 RVA: 0x00094741 File Offset: 0x00092B41
		internal bool <>m__4(IResidentEffect e)
		{
			return e.CorrespondingEffectType != this.effectType;
		}

		// Token: 0x060052A7 RID: 21159 RVA: 0x00094754 File Offset: 0x00092B54
		internal bool <>m__5(IResidentEffect e)
		{
			return e.CorrespondingEffectType == this.effectType;
		}

		// Token: 0x060052A8 RID: 21160 RVA: 0x00094764 File Offset: 0x00092B64
		internal bool <>m__6(IResidentEffect e)
		{
			return e.CorrespondingEffectType == this.effectType;
		}

		// Token: 0x04004079 RID: 16505
		internal ResidentEffectType effectType;
	}
}
