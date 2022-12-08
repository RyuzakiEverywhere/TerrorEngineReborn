using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001CF RID: 463
[ProtoContract]
public sealed class CameraObjSerializer
{
	// Token: 0x06000B7A RID: 2938 RVA: 0x0005EAC8 File Offset: 0x0005CEC8
	public CameraObjSerializer(GameObject gameObject)
	{
		CameraProperties component = gameObject.GetComponent<CameraProperties>();
		this.camname = component.camname;
	}

	// Token: 0x06000B7B RID: 2939 RVA: 0x0005EAF0 File Offset: 0x0005CEF0
	public CameraObjSerializer(GameObject gameObject, CameraObjSerializer component)
	{
		CameraProperties cameraProperties = gameObject.GetComponent<CameraProperties>();
		if (cameraProperties == null)
		{
			cameraProperties = gameObject.AddComponent<CameraProperties>();
		}
		cameraProperties.camname = component.camname;
	}

	// Token: 0x06000B7C RID: 2940 RVA: 0x0005EB29 File Offset: 0x0005CF29
	public CameraObjSerializer()
	{
	}

	// Token: 0x04000CF8 RID: 3320
	[ProtoMember(1)]
	public string camname;
}
