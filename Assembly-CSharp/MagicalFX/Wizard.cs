using System;
using UnityEngine;

namespace MagicalFX
{
	// Token: 0x020000F1 RID: 241
	public class Wizard : MonoBehaviour
	{
		// Token: 0x060006B5 RID: 1717 RVA: 0x00068D09 File Offset: 0x00067109
		public Wizard()
		{
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00068D27 File Offset: 0x00067127
		private void Start()
		{
			this.timeTemp = Time.time;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00068D34 File Offset: 0x00067134
		private void Update()
		{
			if (this.Showtime)
			{
				if (Time.time >= this.timeTemp + this.Delay)
				{
					Ray ray = new Ray(base.transform.position + new Vector3(UnityEngine.Random.Range(-this.RandomSize, this.RandomSize), 0f, UnityEngine.Random.Range(-this.RandomSize, this.RandomSize)), -Vector3.up);
					RaycastHit raycastHit;
					if (Physics.Raycast(ray, out raycastHit, 100f))
					{
						this.positionLook = raycastHit.point;
					}
					Quaternion rotation = Quaternion.LookRotation((this.positionLook - base.transform.position).normalized);
					rotation.eulerAngles = new Vector3(0f, rotation.eulerAngles.y, 0f);
					base.transform.rotation = rotation;
					if (this.RandomSkill)
					{
						this.Index = UnityEngine.Random.Range(0, this.Skills.Length);
					}
					else
					{
						this.Index++;
					}
					this.Deploy();
					this.timeTemp = Time.time;
				}
			}
			else
			{
				this.Aim();
				if (Input.GetMouseButtonDown(0))
				{
					this.Deploy();
				}
			}
			this.KeyUpdate();
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00068E8C File Offset: 0x0006728C
		private void KeyUpdate()
		{
			if (Input.GetKeyDown(KeyCode.A))
			{
				this.Index--;
			}
			if (Input.GetKeyDown(KeyCode.D))
			{
				this.Index++;
			}
			if (this.Index < 0)
			{
				this.Index = this.Skills.Length - 1;
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00068EEC File Offset: 0x000672EC
		private void Deploy()
		{
			if (this.Index >= this.Skills.Length || this.Index < 0)
			{
				this.Index = 0;
			}
			FX_Position component = this.Skills[this.Index].GetComponent<FX_Position>();
			if (component)
			{
				if (component.Mode == SpawnMode.Static)
				{
					this.Place(this.Skills[this.Index]);
				}
				if (component.Mode == SpawnMode.OnDirection)
				{
					this.PlaceDirection(this.Skills[this.Index]);
				}
			}
			else
			{
				this.Shoot(this.Skills[this.Index]);
			}
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00068F94 File Offset: 0x00067394
		private void Aim()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit, 100f))
			{
				this.positionLook = raycastHit.point;
			}
			Quaternion b = Quaternion.LookRotation((this.positionLook - base.transform.position).normalized);
			b.eulerAngles = new Vector3(0f, b.eulerAngles.y, 0f);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, 0.5f);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0006903C File Offset: 0x0006743C
		private void Shoot(GameObject skill)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(skill, base.transform.position + Vector3.up * 0.5f + base.transform.forward, skill.transform.rotation);
			gameObject.transform.forward = (this.positionLook - base.transform.position).normalized;
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x000690B3 File Offset: 0x000674B3
		private void Place(GameObject skill)
		{
			UnityEngine.Object.Instantiate<GameObject>(skill, this.positionLook, skill.transform.rotation);
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x000690D0 File Offset: 0x000674D0
		private void PlaceDirection(GameObject skill)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(skill, base.transform.position + base.transform.forward, skill.transform.rotation);
			FX_Position component = gameObject.GetComponent<FX_Position>();
			if (component.Mode == SpawnMode.OnDirection)
			{
				component.transform.forward = base.transform.forward;
			}
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00069134 File Offset: 0x00067534
		private void OnGUI()
		{
			string str = string.Empty;
			if (this.Index >= 0 && this.Index < this.Skills.Length && this.Skills.Length > 0)
			{
				str = this.Skills[this.Index].name;
			}
			GUI.Label(new Rect(30f, 30f, (float)Screen.width, 100f), string.Empty + str);
			if (GUI.Button(new Rect(30f, (float)(Screen.height - 40), 100f, 30f), "Prev"))
			{
				this.Index--;
			}
			if (GUI.Button(new Rect(140f, (float)(Screen.height - 40), 100f, 30f), "Next"))
			{
				this.Index++;
			}
			if (GUI.Button(new Rect(250f, (float)(Screen.height - 40), 100f, 30f), "Show time"))
			{
				this.Showtime = !this.Showtime;
			}
			if (this.Index < 0)
			{
				this.Index = this.Skills.Length - 1;
			}
		}

		// Token: 0x040009B9 RID: 2489
		public GameObject[] Skills;

		// Token: 0x040009BA RID: 2490
		private Vector3 positionLook;

		// Token: 0x040009BB RID: 2491
		public int Index;

		// Token: 0x040009BC RID: 2492
		public bool Showtime;

		// Token: 0x040009BD RID: 2493
		public float Delay = 1f;

		// Token: 0x040009BE RID: 2494
		public float RandomSize = 10f;

		// Token: 0x040009BF RID: 2495
		public bool RandomSkill;

		// Token: 0x040009C0 RID: 2496
		private float timeTemp;
	}
}
