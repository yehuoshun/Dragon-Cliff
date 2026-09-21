using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000EE8 RID: 3816
[CompilerGenerated]
internal sealed class <>__AnonType4<<life>__T, <u>__T>
{
	// Token: 0x06006048 RID: 24648 RVA: 0x00002632 File Offset: 0x00000A32
	[DebuggerHidden]
	public <>__AnonType4(<life>__T life, <u>__T u)
	{
		this.<life> = life;
		this.<u> = u;
	}

	// Token: 0x17001422 RID: 5154
	// (get) Token: 0x06006049 RID: 24649 RVA: 0x00002648 File Offset: 0x00000A48
	public <life>__T life
	{
		get
		{
			return this.<life>;
		}
	}

	// Token: 0x17001423 RID: 5155
	// (get) Token: 0x0600604A RID: 24650 RVA: 0x00002650 File Offset: 0x00000A50
	public <u>__T u
	{
		get
		{
			return this.<u>;
		}
	}

	// Token: 0x0600604B RID: 24651 RVA: 0x00002658 File Offset: 0x00000A58
	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		var <>__AnonType = obj as <>__AnonType4<<life>__T, <u>__T>;
		return <>__AnonType != null && EqualityComparer<<life>__T>.Default.Equals(this.<life>, <>__AnonType.<life>) && EqualityComparer<<u>__T>.Default.Equals(this.<u>, <>__AnonType.<u>);
	}

	// Token: 0x0600604C RID: 24652 RVA: 0x000026AC File Offset: 0x00000AAC
	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = ((-2128831035 ^ EqualityComparer<<life>__T>.Default.GetHashCode(this.<life>)) * 16777619 ^ EqualityComparer<<u>__T>.Default.GetHashCode(this.<u>)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	// Token: 0x0600604D RID: 24653 RVA: 0x00002710 File Offset: 0x00000B10
	[DebuggerHidden]
	public override string ToString()
	{
		string[] array = new string[6];
		array[0] = "{";
		array[1] = " life = ";
		int num = 2;
		string text;
		if (this.<life> != null)
		{
			<life>__T <life>__T = this.<life>;
			text = <life>__T.ToString();
		}
		else
		{
			text = string.Empty;
		}
		array[num] = text;
		array[3] = ", u = ";
		int num2 = 4;
		string text2;
		if (this.<u> != null)
		{
			<u>__T <u>__T = this.<u>;
			text2 = <u>__T.ToString();
		}
		else
		{
			text2 = string.Empty;
		}
		array[num2] = text2;
		array[5] = " }";
		return string.Concat(array);
	}

	// Token: 0x04005563 RID: 21859
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <life>__T <life>;

	// Token: 0x04005564 RID: 21860
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <u>__T <u>;
}
