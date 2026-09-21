using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x0200100B RID: 4107
[CompilerGenerated]
internal sealed class <>__AnonType7<<file>__T, <time>__T>
{
	// Token: 0x060067DA RID: 26586 RVA: 0x00002922 File Offset: 0x00000D22
	[DebuggerHidden]
	public <>__AnonType7(<file>__T file, <time>__T time)
	{
		this.<file> = file;
		this.<time> = time;
	}

	// Token: 0x170015C5 RID: 5573
	// (get) Token: 0x060067DB RID: 26587 RVA: 0x00002938 File Offset: 0x00000D38
	public <file>__T file
	{
		get
		{
			return this.<file>;
		}
	}

	// Token: 0x170015C6 RID: 5574
	// (get) Token: 0x060067DC RID: 26588 RVA: 0x00002940 File Offset: 0x00000D40
	public <time>__T time
	{
		get
		{
			return this.<time>;
		}
	}

	// Token: 0x060067DD RID: 26589 RVA: 0x00002948 File Offset: 0x00000D48
	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		var <>__AnonType = obj as <>__AnonType7<<file>__T, <time>__T>;
		return <>__AnonType != null && EqualityComparer<<file>__T>.Default.Equals(this.<file>, <>__AnonType.<file>) && EqualityComparer<<time>__T>.Default.Equals(this.<time>, <>__AnonType.<time>);
	}

	// Token: 0x060067DE RID: 26590 RVA: 0x0000299C File Offset: 0x00000D9C
	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = ((-2128831035 ^ EqualityComparer<<file>__T>.Default.GetHashCode(this.<file>)) * 16777619 ^ EqualityComparer<<time>__T>.Default.GetHashCode(this.<time>)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	// Token: 0x060067DF RID: 26591 RVA: 0x00002A00 File Offset: 0x00000E00
	[DebuggerHidden]
	public override string ToString()
	{
		string[] array = new string[6];
		array[0] = "{";
		array[1] = " file = ";
		int num = 2;
		string text;
		if (this.<file> != null)
		{
			<file>__T <file>__T = this.<file>;
			text = <file>__T.ToString();
		}
		else
		{
			text = string.Empty;
		}
		array[num] = text;
		array[3] = ", time = ";
		int num2 = 4;
		string text2;
		if (this.<time> != null)
		{
			<time>__T <time>__T = this.<time>;
			text2 = <time>__T.ToString();
		}
		else
		{
			text2 = string.Empty;
		}
		array[num2] = text2;
		array[5] = " }";
		return string.Concat(array);
	}

	// Token: 0x040061D5 RID: 25045
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <file>__T <file>;

	// Token: 0x040061D6 RID: 25046
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <time>__T <time>;
}
