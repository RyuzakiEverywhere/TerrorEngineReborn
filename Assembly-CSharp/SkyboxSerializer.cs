using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000216 RID: 534
[ProtoContract]
public sealed class SkyboxSerializer
{
	// Token: 0x06000F39 RID: 3897 RVA: 0x0006636C File Offset: 0x0006476C
	public SkyboxSerializer(GameObject gameObject, SkyboxSerializer component)
	{
		Skybox skybox = gameObject.GetComponent<Skybox>();
		if (skybox == null)
		{
			skybox = gameObject.AddComponent<Skybox>();
		}
		if (!string.IsNullOrEmpty(component.MaterialName))
		{
			skybox.material = (Material)UniSave.TryLoadResource(component.MaterialName);
		}
	}

	// Token: 0x06000F3A RID: 3898 RVA: 0x000663C0 File Offset: 0x000647C0
	public SkyboxSerializer(GameObject gameObject)
	{
		Skybox component = gameObject.GetComponent<Skybox>();
		if (component.material != null)
		{
			this.MaterialName = component.material.name;
		}
	}

	// Token: 0x06000F3B RID: 3899 RVA: 0x000663FC File Offset: 0x000647FC
	private SkyboxSerializer()
	{
	}

	// Token: 0x17000291 RID: 657
	// (get) Token: 0x06000F3C RID: 3900 RVA: 0x00066404 File Offset: 0x00064804
	// (set) Token: 0x06000F3D RID: 3901 RVA: 0x0006640C File Offset: 0x0006480C
	[ProtoMember(1)]
	public string MaterialName { get; set; }
}
