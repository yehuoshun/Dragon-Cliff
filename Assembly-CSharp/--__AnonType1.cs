using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Token: 0x02000D43 RID: 3395
[CompilerGenerated]
internal sealed class <>__AnonType1<<Effect>__T, <AsString>__T>
{
	// Token: 0x060056CC RID: 22220 RVA: 0x000021CA File Offset: 0x000005CA
	[DebuggerHidden]
	public <>__AnonType1(<Effect>__T Effect, <AsString>__T AsString)
	{
		this.<Effect> = Effect;
		this.<AsString> = AsString;
	}

	// Token: 0x1700124C RID: 4684
	// (get) Token: 0x060056CD RID: 22221 RVA: 0x000021E0 File Offset: 0x000005E0
	public <Effect>__T Effect
	{
		get
		{
			return this.<Effect>;
		}
	}

	// Token: 0x1700124D RID: 4685
	// (get) Token: 0x060056CE RID: 22222 RVA: 0x000021E8 File Offset: 0x000005E8
	public <AsString>__T AsString
	{
		get
		{
			return this.<AsString>;
		}
	}

	// Token: 0x060056CF RID: 22223 RVA: 0x000021F0 File Offset: 0x000005F0
	[DebuggerHidden]
	public override bool Equals(object obj)
	{
		var <>__AnonType = obj as <>__AnonType1<<Effect>__T, <AsString>__T>;
		return <>__AnonType != null && EqualityComparer<<Effect>__T>.Default.Equals(this.<Effect>, <>__AnonType.<Effect>) && EqualityComparer<<AsString>__T>.Default.Equals(this.<AsString>, <>__AnonType.<AsString>);
	}

	// Token: 0x060056D0 RID: 22224 RVA: 0x00002244 File Offset: 0x00000644
	[DebuggerHidden]
	public override int GetHashCode()
	{
		int num = ((-2128831035 ^ EqualityComparer<<Effect>__T>.Default.GetHashCode(this.<Effect>)) * 16777619 ^ EqualityComparer<<AsString>__T>.Default.GetHashCode(this.<AsString>)) * 16777619;
		num += num << 13;
		num ^= num >> 7;
		num += num << 3;
		num ^= num >> 17;
		return num + (num << 5);
	}

	// Token: 0x060056D1 RID: 22225 RVA: 0x000022A8 File Offset: 0x000006A8
	[DebuggerHidden]
	public override string ToString()
	{
		string[] array = new string[6];
		array[0] = "{";
		array[1] = " Effect = ";
		int num = 2;
		string text;
		if (this.<Effect> != null)
		{
			<Effect>__T <Effect>__T = this.<Effect>;
			text = <Effect>__T.ToString();
		}
		else
		{
			text = string.Empty;
		}
		array[num] = text;
		array[3] = ", AsString = ";
		int num2 = 4;
		string text2;
		if (this.<AsString> != null)
		{
			<AsString>__T <AsString>__T = this.<AsString>;
			text2 = <AsString>__T.ToString();
		}
		else
		{
			text2 = string.Empty;
		}
		array[num2] = text2;
		array[5] = " }";
		return string.Concat(array);
	}

	// Token: 0x04004597 RID: 17815
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <Effect>__T <Effect>;

	// Token: 0x04004598 RID: 17816
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly <AsString>__T <AsString>;
}
