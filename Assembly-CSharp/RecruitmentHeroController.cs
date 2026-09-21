using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x0200030E RID: 782
public class RecruitmentHeroController : MovingCharacterController
{
	// Token: 0x060014E5 RID: 5349 RVA: 0x000A8DDF File Offset: 0x000A71DF
	public RecruitmentHeroController()
	{
	}

	// Token: 0x060014E6 RID: 5350 RVA: 0x000A8DFC File Offset: 0x000A71FC
	private void Update()
	{
		if (base.FollowPath)
		{
			base.Moving();
		}
		if (this._startToCount)
		{
			this._t += Time.deltaTime;
			if (this._t >= this.StopTime)
			{
				this._startToCount = false;
				this._facingTime = 1;
				this._t = 0f;
				NodeController nodeController = this._reachablePoints[UnityEngine.Random.Range(0, this._reachablePoints.Count)];
				base.StartToMove(PathPointsManager.Instance.GetPath(this._currentNode, nodeController));
				this._currentNode = nodeController;
			}
			if (this._t >= (float)this._facingTime)
			{
				this._facingTime = Mathf.FloorToInt(this._t) + 1;
				base.AnimateIdle();
			}
		}
	}

	// Token: 0x060014E7 RID: 5351 RVA: 0x000A8EC8 File Offset: 0x000A72C8
	public void Init(AdventurerProfile profile, TownSlot recruitmentSlot)
	{
		base.UpdateSprites(FilePath.GetCharacterBasicAppearance(profile.UnitClass, false));
		this._reachablePoints = new List<NodeController>();
		NodeController node = UnityEngine.Object.FindObjectOfType<PathPointsManager>().GetNode(recruitmentSlot);
		this._reachablePoints.AddRange(node.Neighbours);
		foreach (NodeController nodeController in node.Neighbours)
		{
			this._reachablePoints.AddRange(nodeController.Neighbours);
		}
		this._currentNode = this._reachablePoints[UnityEngine.Random.Range(0, this._reachablePoints.Count - 1)];
		NodeController destination = this._reachablePoints[UnityEngine.Random.Range(0, this._reachablePoints.Count - 1)];
		base.transform.position = this._currentNode.transform.position;
		base.StartToMove(PathPointsManager.Instance.GetPath(this._currentNode, destination));
	}

	// Token: 0x060014E8 RID: 5352 RVA: 0x000A8FE0 File Offset: 0x000A73E0
	public override IEnumerator ArrivedDestination()
	{
		base.FollowPath = false;
		this._startToCount = true;
		base.AnimateIdle();
		yield break;
	}

	// Token: 0x040014FD RID: 5373
	public float StopTime = 4f;

	// Token: 0x040014FE RID: 5374
	public GameObject LightObj;

	// Token: 0x040014FF RID: 5375
	private List<NodeController> _reachablePoints;

	// Token: 0x04001500 RID: 5376
	private NodeController _currentNode;

	// Token: 0x04001501 RID: 5377
	private bool _startToCount;

	// Token: 0x04001502 RID: 5378
	private float _t;

	// Token: 0x04001503 RID: 5379
	private int _facingTime = 1;

	// Token: 0x02000C88 RID: 3208
	[CompilerGenerated]
	private sealed class <ArrivedDestination>c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		// Token: 0x06005325 RID: 21285 RVA: 0x000A8FFB File Offset: 0x000A73FB
		[DebuggerHidden]
		public <ArrivedDestination>c__Iterator0()
		{
		}

		// Token: 0x06005326 RID: 21286 RVA: 0x000A9003 File Offset: 0x000A7403
		public bool MoveNext()
		{
			bool flag = this.$PC != 0;
			this.$PC = -1;
			if (!flag)
			{
				base.FollowPath = false;
				this._startToCount = true;
				base.AnimateIdle();
			}
			return false;
		}

		// Token: 0x1700119C RID: 4508
		// (get) Token: 0x06005327 RID: 21287 RVA: 0x000A9040 File Offset: 0x000A7440
		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x1700119D RID: 4509
		// (get) Token: 0x06005328 RID: 21288 RVA: 0x000A9048 File Offset: 0x000A7448
		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return this.$current;
			}
		}

		// Token: 0x06005329 RID: 21289 RVA: 0x000A9050 File Offset: 0x000A7450
		[DebuggerHidden]
		public void Dispose()
		{
		}

		// Token: 0x0600532A RID: 21290 RVA: 0x000A9052 File Offset: 0x000A7452
		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040040BD RID: 16573
		internal RecruitmentHeroController $this;

		// Token: 0x040040BE RID: 16574
		internal object $current;

		// Token: 0x040040BF RID: 16575
		internal bool $disposing;

		// Token: 0x040040C0 RID: 16576
		internal int $PC;
	}
}
