using System;
using UnityEngine;

// Token: 0x020000BE RID: 190
public class FireParticleEffect : MonoBehaviour
{
	// Token: 0x060005F8 RID: 1528 RVA: 0x00060E25 File Offset: 0x0005F225
	public FireParticleEffect()
	{
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x00060E38 File Offset: 0x0005F238
	private void Start()
	{
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x00060E3C File Offset: 0x0005F23C
	private void Update()
	{
		this.timeSinceLastSpawn += Time.deltaTime;
		float num = 1f / this.Rate;
		while (this.timeSinceLastSpawn > num)
		{
			this.SpawnFireAlongOutline();
			this.timeSinceLastSpawn -= num;
		}
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x00060E90 File Offset: 0x0005F290
	private void SpawnFireAlongOutline()
	{
		PolygonCollider2D component = base.GetComponent<PolygonCollider2D>();
		int index = UnityEngine.Random.Range(0, component.pathCount);
		Vector2[] path = component.GetPath(index);
		int num = UnityEngine.Random.Range(0, path.Length);
		Vector2 a = path[num];
		Vector2 b = path[(num + 1) % path.Length];
		Vector2 a2 = Vector2.Lerp(a, b, UnityEngine.Random.Range(0f, 1f));
		this.SpawnFireAtPosition(a2 + base.transform.position);
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x00060F1C File Offset: 0x0005F31C
	private void SpawnFireAtPosition(Vector2 position)
	{
		SimplePool.Spawn(this.ParticlePrefab, position, Quaternion.identity, base.gameObject.transform);
	}

	// Token: 0x04000901 RID: 2305
	public GameObject ParticlePrefab;

	// Token: 0x04000902 RID: 2306
	public float Rate = 500f;

	// Token: 0x04000903 RID: 2307
	private float timeSinceLastSpawn;
}
