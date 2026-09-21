using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000E6 RID: 230
	public class FX_ParticlePreview : MonoBehaviour
	{
		// Token: 0x06000693 RID: 1683 RVA: 0x00068124 File Offset: 0x00066524
		public FX_ParticlePreview()
		{
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00068137 File Offset: 0x00066537
		private void Start()
		{
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0006813C File Offset: 0x0006653C
		public void AddParticle(Vector3 position)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				this.Index++;
				if (this.Index >= this.Particles.Length || this.Index < 0)
				{
					this.Index = 0;
				}
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				this.Index--;
				if (this.Index < 0)
				{
					this.Index = this.Particles.Length - 1;
				}
			}
			if (this.Index >= this.Particles.Length || this.Index < 0)
			{
				this.Index = 0;
			}
			if (this.Index >= 0 && this.Index < this.Particles.Length && this.Particles.Length > 0)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Particles[this.Index], position, this.Particles[this.Index].transform.rotation);
			}
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00068244 File Offset: 0x00066644
		private void Update()
		{
			base.transform.Rotate(Vector3.up * this.RotationSpeed * Time.deltaTime);
			RaycastHit raycastHit = default(RaycastHit);
			if (Input.GetButtonDown("Fire1"))
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out raycastHit, 1000f))
				{
					this.AddParticle(raycastHit.point + Vector3.up);
				}
			}
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x000682C8 File Offset: 0x000666C8
		private void OnGUI()
		{
			string str = string.Empty;
			if (this.Index >= 0 && this.Index < this.Particles.Length && this.Particles.Length > 0)
			{
				str = this.Particles[this.Index].name;
			}
			GUI.Label(new Rect(30f, 30f, (float)Screen.width, 100f), "Change FX : Key Up / Down \nCurrent FX " + str);
			if (GUI.Button(new Rect(30f, 90f, 200f, 30f), "Next"))
			{
				this.Index++;
				this.AddParticle(Vector3.up);
			}
			if (GUI.Button(new Rect(30f, 130f, 200f, 30f), "Prev"))
			{
				this.Index--;
				this.AddParticle(Vector3.up);
			}
			if (this.logo)
			{
				GUI.DrawTexture(new Rect((float)(Screen.width - this.logo.width - 30), 30f, (float)this.logo.width, (float)this.logo.height), this.logo);
			}
		}

		// Token: 0x04000989 RID: 2441
		public GameObject[] Particles;

		// Token: 0x0400098A RID: 2442
		public float RotationSpeed = 3f;

		// Token: 0x0400098B RID: 2443
		public int Index;

		// Token: 0x0400098C RID: 2444
		public Texture2D logo;
	}
}
