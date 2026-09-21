using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000C8 RID: 200
public class CFX_SpawnSystem : MonoBehaviour
{
	// Token: 0x06000615 RID: 1557 RVA: 0x0006158D File Offset: 0x0005F98D
	public CFX_SpawnSystem()
	{
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x000615CC File Offset: 0x0005F9CC
	public static GameObject GetNextObject(GameObject sourceObj, bool activateObject = true)
	{
		int instanceID = sourceObj.GetInstanceID();
		if (!CFX_SpawnSystem.instance.poolCursors.ContainsKey(instanceID))
		{
			Debug.LogError(string.Concat(new object[]
			{
				"[CFX_SpawnSystem.GetNextObject()] Object hasn't been preloaded: ",
				sourceObj.name,
				" (ID:",
				instanceID,
				")\n"
			}), CFX_SpawnSystem.instance);
			return null;
		}
		int num = CFX_SpawnSystem.instance.poolCursors[instanceID];
		GameObject gameObject;
		if (CFX_SpawnSystem.instance.onlyGetInactiveObjects)
		{
			int num2 = num;
			for (;;)
			{
				gameObject = CFX_SpawnSystem.instance.instantiatedObjects[instanceID][num];
				CFX_SpawnSystem.instance.increasePoolCursor(instanceID);
				num = CFX_SpawnSystem.instance.poolCursors[instanceID];
				if (gameObject != null && !gameObject.activeSelf)
				{
					break;
				}
				if (num == num2)
				{
					goto Block_5;
				}
			}
			goto IL_15A;
			Block_5:
			if (!CFX_SpawnSystem.instance.instantiateIfNeeded)
			{
				Debug.LogWarning("[CFX_SpawnSystem.GetNextObject()] There are no active instances available in the pool for \"" + sourceObj.name + "\"\nYou may need to increase the preloaded object count for this prefab?", CFX_SpawnSystem.instance);
				return null;
			}
			Debug.Log("[CFX_SpawnSystem.GetNextObject()] A new instance has been created for \"" + sourceObj.name + "\" because no active instance were found in the pool.\n", CFX_SpawnSystem.instance);
			CFX_SpawnSystem.PreloadObject(sourceObj, 1);
			List<GameObject> list = CFX_SpawnSystem.instance.instantiatedObjects[instanceID];
			gameObject = list[list.Count - 1];
			IL_15A:;
		}
		else
		{
			gameObject = CFX_SpawnSystem.instance.instantiatedObjects[instanceID][num];
			CFX_SpawnSystem.instance.increasePoolCursor(instanceID);
		}
		if (activateObject && gameObject != null)
		{
			gameObject.SetActive(true);
		}
		return gameObject;
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x00061774 File Offset: 0x0005FB74
	public static void PreloadObject(GameObject sourceObj, int poolSize = 1)
	{
		CFX_SpawnSystem.instance.addObjectToPool(sourceObj, poolSize);
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x00061782 File Offset: 0x0005FB82
	public static void UnloadObjects(GameObject sourceObj)
	{
		CFX_SpawnSystem.instance.removeObjectsFromPool(sourceObj);
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000619 RID: 1561 RVA: 0x0006178F File Offset: 0x0005FB8F
	public static bool AllObjectsLoaded
	{
		get
		{
			return CFX_SpawnSystem.instance.allObjectsLoaded;
		}
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x0006179C File Offset: 0x0005FB9C
	private void addObjectToPool(GameObject sourceObject, int number)
	{
		int instanceID = sourceObject.GetInstanceID();
		if (!this.instantiatedObjects.ContainsKey(instanceID))
		{
			this.instantiatedObjects.Add(instanceID, new List<GameObject>());
			this.poolCursors.Add(instanceID, 0);
		}
		for (int i = 0; i < number; i++)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(sourceObject);
			gameObject.SetActive(false);
			CFX_AutoDestructShuriken[] componentsInChildren = gameObject.GetComponentsInChildren<CFX_AutoDestructShuriken>(true);
			foreach (CFX_AutoDestructShuriken cfx_AutoDestructShuriken in componentsInChildren)
			{
				cfx_AutoDestructShuriken.OnlyDeactivate = true;
			}
			CFX_LightIntensityFade[] componentsInChildren2 = gameObject.GetComponentsInChildren<CFX_LightIntensityFade>(true);
			foreach (CFX_LightIntensityFade cfx_LightIntensityFade in componentsInChildren2)
			{
				cfx_LightIntensityFade.autodestruct = false;
			}
			this.instantiatedObjects[instanceID].Add(gameObject);
			if (this.hideObjectsInHierarchy)
			{
				gameObject.hideFlags = HideFlags.HideInHierarchy;
			}
			if (this.spawnAsChildren)
			{
				gameObject.transform.SetParent(base.transform, false);
			}
		}
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x000618A8 File Offset: 0x0005FCA8
	private void removeObjectsFromPool(GameObject sourceObject)
	{
		int instanceID = sourceObject.GetInstanceID();
		if (!this.instantiatedObjects.ContainsKey(instanceID))
		{
			Debug.LogWarning(string.Concat(new object[]
			{
				"[CFX_SpawnSystem.removeObjectsFromPool()] There aren't any preloaded object for: ",
				sourceObject.name,
				" (ID:",
				instanceID,
				")\n"
			}), base.gameObject);
			return;
		}
		for (int i = this.instantiatedObjects[instanceID].Count - 1; i >= 0; i--)
		{
			GameObject obj = this.instantiatedObjects[instanceID][i];
			this.instantiatedObjects[instanceID].RemoveAt(i);
			UnityEngine.Object.Destroy(obj);
		}
		this.instantiatedObjects.Remove(instanceID);
		this.poolCursors.Remove(instanceID);
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x00061978 File Offset: 0x0005FD78
	private void increasePoolCursor(int uniqueId)
	{
		Dictionary<int, int> dictionary;
		(dictionary = CFX_SpawnSystem.instance.poolCursors)[uniqueId] = dictionary[uniqueId] + 1;
		if (CFX_SpawnSystem.instance.poolCursors[uniqueId] >= CFX_SpawnSystem.instance.instantiatedObjects[uniqueId].Count)
		{
			CFX_SpawnSystem.instance.poolCursors[uniqueId] = 0;
		}
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x000619DD File Offset: 0x0005FDDD
	private void Awake()
	{
		if (CFX_SpawnSystem.instance != null)
		{
			Debug.LogWarning("CFX_SpawnSystem: There should only be one instance of CFX_SpawnSystem per Scene!\n", base.gameObject);
		}
		CFX_SpawnSystem.instance = this;
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x00061A08 File Offset: 0x0005FE08
	private void Start()
	{
		this.allObjectsLoaded = false;
		for (int i = 0; i < this.objectsToPreload.Length; i++)
		{
			CFX_SpawnSystem.PreloadObject(this.objectsToPreload[i], this.objectsToPreloadTimes[i]);
		}
		this.allObjectsLoaded = true;
	}

	// Token: 0x04000918 RID: 2328
	private static CFX_SpawnSystem instance;

	// Token: 0x04000919 RID: 2329
	public GameObject[] objectsToPreload = new GameObject[0];

	// Token: 0x0400091A RID: 2330
	public int[] objectsToPreloadTimes = new int[0];

	// Token: 0x0400091B RID: 2331
	public bool hideObjectsInHierarchy;

	// Token: 0x0400091C RID: 2332
	public bool spawnAsChildren = true;

	// Token: 0x0400091D RID: 2333
	public bool onlyGetInactiveObjects;

	// Token: 0x0400091E RID: 2334
	public bool instantiateIfNeeded;

	// Token: 0x0400091F RID: 2335
	private bool allObjectsLoaded;

	// Token: 0x04000920 RID: 2336
	private Dictionary<int, List<GameObject>> instantiatedObjects = new Dictionary<int, List<GameObject>>();

	// Token: 0x04000921 RID: 2337
	private Dictionary<int, int> poolCursors = new Dictionary<int, int>();
}
