using System;
using UnityEngine;

namespace FireParticle
{
	// Token: 0x020000BD RID: 189
	public class FireParticle : MonoBehaviour
	{
		// Token: 0x060005F4 RID: 1524 RVA: 0x00060C2C File Offset: 0x0005F02C
		public FireParticle()
		{
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x00060C7B File Offset: 0x0005F07B
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.originalColor = this.spriteRenderer.color;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00060C9C File Offset: 0x0005F09C
		private void OnEnable()
		{
			this.velocity = new Vector2(UnityEngine.Random.Range(this.MinVelocity.x, this.MaxVelocity.x), UnityEngine.Random.Range(this.MinVelocity.y, this.MaxVelocity.y));
			this.actualLifeSpan = this.LifeSpan * UnityEngine.Random.Range(0.9f, 1.1f);
			this.timeAlive = 0f;
			this.spriteRenderer.color = this.originalColor;
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00060D24 File Offset: 0x0005F124
		private void Update()
		{
			this.timeAlive += Time.deltaTime;
			if (this.DestroysSelf && this.timeAlive >= this.actualLifeSpan)
			{
				SimplePool.Despawn(base.gameObject);
				return;
			}
			if (this.AlphaFalloff == AlphaFalloff.LINEAR)
			{
				float num = Mathf.Clamp01(1f - this.timeAlive / this.actualLifeSpan);
				Color color = this.originalColor;
				color.a *= num;
				this.spriteRenderer.color = color;
			}
			else if (this.AlphaFalloff == AlphaFalloff.SQRT)
			{
				float num2 = Mathf.Clamp01(1f - this.timeAlive / this.actualLifeSpan);
				num2 = Mathf.Sqrt(num2);
				Color color2 = this.originalColor;
				color2.a *= num2;
				this.spriteRenderer.color = color2;
			}
			base.transform.Translate(this.velocity * Time.deltaTime);
		}

		// Token: 0x040008F7 RID: 2295
		public Vector2 MinVelocity = new Vector2(-0.05f, 0.1f);

		// Token: 0x040008F8 RID: 2296
		public Vector2 MaxVelocity = new Vector2(0.05f, 0.2f);

		// Token: 0x040008F9 RID: 2297
		public float LifeSpan = 2f;

		// Token: 0x040008FA RID: 2298
		public bool DestroysSelf = true;

		// Token: 0x040008FB RID: 2299
		public AlphaFalloff AlphaFalloff;

		// Token: 0x040008FC RID: 2300
		private float actualLifeSpan;

		// Token: 0x040008FD RID: 2301
		private float timeAlive;

		// Token: 0x040008FE RID: 2302
		private SpriteRenderer spriteRenderer;

		// Token: 0x040008FF RID: 2303
		private Color originalColor;

		// Token: 0x04000900 RID: 2304
		private Vector2 velocity;
	}
}
