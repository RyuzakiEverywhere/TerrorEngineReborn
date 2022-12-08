using System;
using UnityEngine;

// Token: 0x0200014B RID: 331
public class RpcIndexComponent : MonoBehaviour
{
	// Token: 0x0600081E RID: 2078 RVA: 0x0004AE11 File Offset: 0x00049211
	public void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x0004AE1C File Offset: 0x0004921C
	public byte GetShortcut(string method)
	{
		for (int i = 0; i < this.RpcIndex.Length; i++)
		{
			string text = this.RpcIndex[i];
			if (text.Equals(method))
			{
				return (byte)i;
			}
		}
		return byte.MaxValue;
	}

	// Token: 0x04000A32 RID: 2610
	public string[] RpcIndex;
}
