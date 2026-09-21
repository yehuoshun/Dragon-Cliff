using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x02000329 RID: 809
public class ObjectPool : MonoBehaviour
{
	// Token: 0x06001594 RID: 5524 RVA: 0x000AB9D8 File Offset: 0x000A9DD8
	public ObjectPool(GameObject gameObject, int initialCapacity, Action<GameObject> initAction)
	{
		this._poolGameObject = gameObject;
		this._initAction = initAction;
		this._availableGameObjects = new Stack<GameObject>();
		this._allGameObjects = new List<GameObject>();
		for (int i = 0; i < initialCapacity; i++)
		{
			GameObject gameObject2 = this.GetGameObject();
			this._allGameObjects.Add(gameObject2);
			this._availableGameObjects.Push(gameObject2);
		}
	}

	// Token: 0x06001595 RID: 5525 RVA: 0x000ABA4C File Offset: 0x000A9E4C
	public GameObject GetObject()
	{
		GameObject gameObject;
		if (this.inactiveInstances != null && this.inactiveInstances.Count > 0)
		{
			gameObject = this.inactiveInstances.Pop();
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.prefab);
			PooledObject pooledObject = gameObject.AddComponent<PooledObject>();
			pooledObject.pool = this;
		}
		gameObject.transform.SetParent(null);
		gameObject.SetActive(true);
		return gameObject;
	}

	// Token: 0x06001596 RID: 5526 RVA: 0x000ABAB4 File Offset: 0x000A9EB4
	public void ReturnObject(GameObject toReturn)
	{
		PooledObject component = toReturn.GetComponent<PooledObject>();
		if (component != null && component.pool == this)
		{
			toReturn.transform.SetParent(base.transform);
			toReturn.SetActive(false);
			this.inactiveInstances.Push(toReturn);
		}
		else
		{
			Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from! Destroying.");
			this.Destroy(toReturn);
		}
	}

	// Token: 0x06001597 RID: 5527 RVA: 0x000ABB2C File Offset: 0x000A9F2C
	private GameObject GetGameObject()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this._poolGameObject);
		gameObject.name = this._poolGameObject.name + "_" + (this._allGameObjects.Count + 1).ToString();
		if (this._initAction != null)
		{
			this._initAction(gameObject);
		}
		gameObject.SetActive(false);
		return gameObject;
	}

	// Token: 0x06001598 RID: 5528 RVA: 0x000ABB9C File Offset: 0x000A9F9C
	public GameObject Spawn(Vector3 position, Quaternion rotation)
	{
		while (this._availableGameObjects.Any<GameObject>() && this._availableGameObjects.Peek() == null)
		{
			this._availableGameObjects.Pop();
		}
		GameObject gameObject;
		if (!this._availableGameObjects.Any<GameObject>())
		{
			gameObject = this.GetGameObject();
			this._allGameObjects.Add(gameObject);
			this._availableGameObjects.Push(gameObject);
		}
		gameObject = this._availableGameObjects.Pop();
		Transform transform = gameObject.transform;
		transform.position = position;
		transform.rotation = rotation;
		this.SetActive(gameObject, true);
		gameObject.SendMessage("Start", SendMessageOptions.DontRequireReceiver);
		return gameObject;
	}

	// Token: 0x06001599 RID: 5529 RVA: 0x000ABC47 File Offset: 0x000AA047
	public bool Destroy(GameObject target)
	{
		this._availableGameObjects.Push(target);
		this.SetActive(target, false);
		return true;
	}

	// Token: 0x0600159A RID: 5530 RVA: 0x000ABC60 File Offset: 0x000AA060
	public void Clear()
	{
		foreach (GameObject obj in this._availableGameObjects)
		{
			UnityEngine.Object.Destroy(obj);
		}
		foreach (GameObject obj2 in this._allGameObjects)
		{
			UnityEngine.Object.Destroy(obj2);
		}
		this._availableGameObjects.Clear();
		this._allGameObjects.Clear();
	}

	// Token: 0x0600159B RID: 5531 RVA: 0x000ABD1C File Offset: 0x000AA11C
	public void Reset()
	{
		this._availableGameObjects.Clear();
		foreach (GameObject gameObject in this._allGameObjects)
		{
			gameObject.SetActive(false);
			this._availableGameObjects.Push(gameObject);
		}
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x000ABD90 File Offset: 0x000AA190
	protected void SetActive(GameObject target, bool value)
	{
		target.SetActive(value);
	}

	// Token: 0x040015A0 RID: 5536
	public GameObject prefab;

	// Token: 0x040015A1 RID: 5537
	private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

	// Token: 0x040015A2 RID: 5538
	private readonly GameObject _poolGameObject;

	// Token: 0x040015A3 RID: 5539
	private readonly Stack<GameObject> _availableGameObjects;

	// Token: 0x040015A4 RID: 5540
	private readonly List<GameObject> _allGameObjects;

	// Token: 0x040015A5 RID: 5541
	private readonly Action<GameObject> _initAction;
}
