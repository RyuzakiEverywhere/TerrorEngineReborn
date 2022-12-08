using System;
using System.IO;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x02000129 RID: 297
internal static class CustomTypes
{
	// Token: 0x060006B7 RID: 1719 RVA: 0x000429CC File Offset: 0x00040DCC
	internal static void Register()
	{
		Type typeFromHandle = typeof(Vector2);
		byte code = 87;
		if (CustomTypes.<>f__mg$cache0 == null)
		{
			CustomTypes.<>f__mg$cache0 = new SerializeMethod(CustomTypes.SerializeVector2);
		}
		SerializeMethod serializeMethod = CustomTypes.<>f__mg$cache0;
		if (CustomTypes.<>f__mg$cache1 == null)
		{
			CustomTypes.<>f__mg$cache1 = new DeserializeMethod(CustomTypes.DeserializeVector2);
		}
		PhotonPeer.RegisterType(typeFromHandle, code, serializeMethod, CustomTypes.<>f__mg$cache1);
		Type typeFromHandle2 = typeof(Vector3);
		byte code2 = 86;
		if (CustomTypes.<>f__mg$cache2 == null)
		{
			CustomTypes.<>f__mg$cache2 = new SerializeMethod(CustomTypes.SerializeVector3);
		}
		SerializeMethod serializeMethod2 = CustomTypes.<>f__mg$cache2;
		if (CustomTypes.<>f__mg$cache3 == null)
		{
			CustomTypes.<>f__mg$cache3 = new DeserializeMethod(CustomTypes.DeserializeVector3);
		}
		PhotonPeer.RegisterType(typeFromHandle2, code2, serializeMethod2, CustomTypes.<>f__mg$cache3);
		Type typeFromHandle3 = typeof(Transform);
		byte code3 = 84;
		if (CustomTypes.<>f__mg$cache4 == null)
		{
			CustomTypes.<>f__mg$cache4 = new SerializeMethod(CustomTypes.SerializeTransform);
		}
		SerializeMethod serializeMethod3 = CustomTypes.<>f__mg$cache4;
		if (CustomTypes.<>f__mg$cache5 == null)
		{
			CustomTypes.<>f__mg$cache5 = new DeserializeMethod(CustomTypes.DeserializeTransform);
		}
		PhotonPeer.RegisterType(typeFromHandle3, code3, serializeMethod3, CustomTypes.<>f__mg$cache5);
		Type typeFromHandle4 = typeof(Quaternion);
		byte code4 = 81;
		if (CustomTypes.<>f__mg$cache6 == null)
		{
			CustomTypes.<>f__mg$cache6 = new SerializeMethod(CustomTypes.SerializeQuaternion);
		}
		SerializeMethod serializeMethod4 = CustomTypes.<>f__mg$cache6;
		if (CustomTypes.<>f__mg$cache7 == null)
		{
			CustomTypes.<>f__mg$cache7 = new DeserializeMethod(CustomTypes.DeserializeQuaternion);
		}
		PhotonPeer.RegisterType(typeFromHandle4, code4, serializeMethod4, CustomTypes.<>f__mg$cache7);
		Type typeFromHandle5 = typeof(PhotonPlayer);
		byte code5 = 80;
		if (CustomTypes.<>f__mg$cache8 == null)
		{
			CustomTypes.<>f__mg$cache8 = new SerializeMethod(CustomTypes.SerializePhotonPlayer);
		}
		SerializeMethod serializeMethod5 = CustomTypes.<>f__mg$cache8;
		if (CustomTypes.<>f__mg$cache9 == null)
		{
			CustomTypes.<>f__mg$cache9 = new DeserializeMethod(CustomTypes.DeserializePhotonPlayer);
		}
		PhotonPeer.RegisterType(typeFromHandle5, code5, serializeMethod5, CustomTypes.<>f__mg$cache9);
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x00042B58 File Offset: 0x00040F58
	private static byte[] SerializeTransform(object customobject)
	{
		Transform transform = (Transform)customobject;
		return Protocol.Serialize(new Vector3[]
		{
			transform.position,
			transform.eulerAngles
		});
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x00042BA0 File Offset: 0x00040FA0
	private static object DeserializeTransform(byte[] serializedcustomobject)
	{
		return Protocol.Deserialize(serializedcustomobject);
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x00042BB8 File Offset: 0x00040FB8
	private static byte[] SerializeVector3(object customobject)
	{
		Vector3 vector = (Vector3)customobject;
		int num = 0;
		byte[] array = new byte[12];
		Protocol.Serialize(vector.x, array, ref num);
		Protocol.Serialize(vector.y, array, ref num);
		Protocol.Serialize(vector.z, array, ref num);
		return array;
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x00042C04 File Offset: 0x00041004
	private static object DeserializeVector3(byte[] bytes)
	{
		Vector3 vector = default(Vector3);
		int num = 0;
		Protocol.Deserialize(out vector.x, bytes, ref num);
		Protocol.Deserialize(out vector.y, bytes, ref num);
		Protocol.Deserialize(out vector.z, bytes, ref num);
		return vector;
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x00042C50 File Offset: 0x00041050
	private static byte[] SerializeVector2(object customobject)
	{
		Vector2 vector = (Vector2)customobject;
		MemoryStream memoryStream = new MemoryStream(8);
		memoryStream.Write(BitConverter.GetBytes(vector.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(vector.y), 0, 4);
		return memoryStream.ToArray();
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x00042C9C File Offset: 0x0004109C
	private static object DeserializeVector2(byte[] bytes)
	{
		return new Vector2
		{
			x = BitConverter.ToSingle(bytes, 0),
			y = BitConverter.ToSingle(bytes, 4)
		};
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x00042CD4 File Offset: 0x000410D4
	private static byte[] SerializeQuaternion(object obj)
	{
		Quaternion quaternion = (Quaternion)obj;
		MemoryStream memoryStream = new MemoryStream(16);
		memoryStream.Write(BitConverter.GetBytes(quaternion.w), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.x), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.y), 0, 4);
		memoryStream.Write(BitConverter.GetBytes(quaternion.z), 0, 4);
		return memoryStream.ToArray();
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x00042D48 File Offset: 0x00041148
	private static object DeserializeQuaternion(byte[] bytes)
	{
		return new Quaternion
		{
			w = BitConverter.ToSingle(bytes, 0),
			x = BitConverter.ToSingle(bytes, 4),
			y = BitConverter.ToSingle(bytes, 8),
			z = BitConverter.ToSingle(bytes, 12)
		};
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x00042D9C File Offset: 0x0004119C
	private static byte[] SerializePhotonPlayer(object customobject)
	{
		int id = ((PhotonPlayer)customobject).ID;
		return BitConverter.GetBytes(id);
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x00042DBC File Offset: 0x000411BC
	private static object DeserializePhotonPlayer(byte[] bytes)
	{
		int key = BitConverter.ToInt32(bytes, 0);
		if (PhotonNetwork.networkingPeer.mActors.ContainsKey(key))
		{
			return PhotonNetwork.networkingPeer.mActors[key];
		}
		return null;
	}

	// Token: 0x04000907 RID: 2311
	[CompilerGenerated]
	private static SerializeMethod <>f__mg$cache0;

	// Token: 0x04000908 RID: 2312
	[CompilerGenerated]
	private static DeserializeMethod <>f__mg$cache1;

	// Token: 0x04000909 RID: 2313
	[CompilerGenerated]
	private static SerializeMethod <>f__mg$cache2;

	// Token: 0x0400090A RID: 2314
	[CompilerGenerated]
	private static DeserializeMethod <>f__mg$cache3;

	// Token: 0x0400090B RID: 2315
	[CompilerGenerated]
	private static SerializeMethod <>f__mg$cache4;

	// Token: 0x0400090C RID: 2316
	[CompilerGenerated]
	private static DeserializeMethod <>f__mg$cache5;

	// Token: 0x0400090D RID: 2317
	[CompilerGenerated]
	private static SerializeMethod <>f__mg$cache6;

	// Token: 0x0400090E RID: 2318
	[CompilerGenerated]
	private static DeserializeMethod <>f__mg$cache7;

	// Token: 0x0400090F RID: 2319
	[CompilerGenerated]
	private static SerializeMethod <>f__mg$cache8;

	// Token: 0x04000910 RID: 2320
	[CompilerGenerated]
	private static DeserializeMethod <>f__mg$cache9;
}
