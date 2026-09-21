using System;
using UnityEngine;

// Token: 0x020006B5 RID: 1717
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	// Token: 0x06002D8B RID: 11659 RVA: 0x001291B3 File Offset: 0x001275B3
	public Singleton()
	{
	}

	// Token: 0x170005C7 RID: 1479
	// (get) Token: 0x06002D8C RID: 11660 RVA: 0x001291BC File Offset: 0x001275BC
	public static T Instance
	{
		get
		{
			if (Singleton<T>.instance == null)
			{
				Singleton<T>.instance = (T)((object)UnityEngine.Object.FindObjectOfType(typeof(T)));
				if (Singleton<T>.instance == null)
				{
					Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
				}
			}
			return Singleton<T>.instance;
		}
	}

	// Token: 0x040026D4 RID: 9940
	protected static T instance;
}
