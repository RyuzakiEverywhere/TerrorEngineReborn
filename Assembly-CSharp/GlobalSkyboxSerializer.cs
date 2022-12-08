using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001D6 RID: 470
[ProtoContract]
public class GlobalSkyboxSerializer
{
	// Token: 0x06000B8F RID: 2959 RVA: 0x0005F02C File Offset: 0x0005D42C
	public GlobalSkyboxSerializer(GameObject gameObject, GlobalSkyboxSerializer component)
	{
		GlobalSkybox x = gameObject.GetComponent<GlobalSkybox>();
		if (x == null)
		{
			x = gameObject.AddComponent<GlobalSkybox>();
		}
		RenderSettings.skybox = (Material)UniSave.TryLoadResource(component.MaterialName);
		RenderSettings.ambientLight = (Color)component.AmbientLight;
	}

	// Token: 0x06000B90 RID: 2960 RVA: 0x0005F080 File Offset: 0x0005D480
	public GlobalSkyboxSerializer(GameObject gameObject)
	{
		GlobalSkybox component = gameObject.GetComponent<GlobalSkybox>();
		if (component.Skybox != null)
		{
			this.MaterialName = component.Skybox.name;
		}
		this.AmbientLight = (ColorSerializer)component.AmbientLight;
	}

	// Token: 0x06000B91 RID: 2961 RVA: 0x0005F0CD File Offset: 0x0005D4CD
	private GlobalSkyboxSerializer()
	{
	}

	// Token: 0x17000123 RID: 291
	// (get) Token: 0x06000B92 RID: 2962 RVA: 0x0005F0D5 File Offset: 0x0005D4D5
	// (set) Token: 0x06000B93 RID: 2963 RVA: 0x0005F0DD File Offset: 0x0005D4DD
	[ProtoMember(1)]
	public string MaterialName { get; set; }

	// Token: 0x17000124 RID: 292
	// (get) Token: 0x06000B94 RID: 2964 RVA: 0x0005F0E6 File Offset: 0x0005D4E6
	// (set) Token: 0x06000B95 RID: 2965 RVA: 0x0005F0EE File Offset: 0x0005D4EE
	[ProtoMember(2)]
	public ColorSerializer AmbientLight { get; set; }
}
