using System;
using System.Linq;
using ProtoBuf;
using UnityEngine;

// Token: 0x02000253 RID: 595
[ProtoContract]
public sealed class ExampleComponentSerializer
{
	// Token: 0x060010C7 RID: 4295 RVA: 0x0006AD88 File Offset: 0x00069188
	public ExampleComponentSerializer(GameObject gameObject)
	{
		ExampleComponent component = gameObject.GetComponent<ExampleComponent>();
		this.Text = component.Text;
		this.Number = component.Number;
		this.OneVector3 = (Vector3Serializer)component.OneVector3;
		this.MultipleVector3 = Array.ConvertAll<Vector3, Vector3Serializer>(component.MultipleVector3, (Vector3 element) => (Vector3Serializer)element);
		this.MaterialNames = (from material in component.Materials
		select material.name).ToArray<string>();
	}

	// Token: 0x060010C8 RID: 4296 RVA: 0x0006AE2C File Offset: 0x0006922C
	public ExampleComponentSerializer(GameObject gameObject, ExampleComponentSerializer component)
	{
		ExampleComponent exampleComponent = gameObject.GetComponent<ExampleComponent>();
		if (exampleComponent == null)
		{
			exampleComponent = gameObject.AddComponent<ExampleComponent>();
		}
		exampleComponent.Text = component.Text;
		exampleComponent.Number = component.Number;
		exampleComponent.OneVector3 = (Vector3)component.OneVector3;
		exampleComponent.MultipleVector3 = Array.ConvertAll<Vector3Serializer, Vector3>(component.MultipleVector3, (Vector3Serializer element) => (Vector3)element);
		exampleComponent.Materials = (from materialName in component.MaterialNames
		select (Material)UniSave.TryLoadResource(materialName)).ToArray<Material>();
	}

	// Token: 0x060010C9 RID: 4297 RVA: 0x0006AEE3 File Offset: 0x000692E3
	private ExampleComponentSerializer()
	{
	}

	// Token: 0x1700030A RID: 778
	// (get) Token: 0x060010CA RID: 4298 RVA: 0x0006AEEB File Offset: 0x000692EB
	// (set) Token: 0x060010CB RID: 4299 RVA: 0x0006AEF3 File Offset: 0x000692F3
	[ProtoMember(1)]
	public string Text { get; set; }

	// Token: 0x1700030B RID: 779
	// (get) Token: 0x060010CC RID: 4300 RVA: 0x0006AEFC File Offset: 0x000692FC
	// (set) Token: 0x060010CD RID: 4301 RVA: 0x0006AF04 File Offset: 0x00069304
	[ProtoMember(2)]
	public int Number { get; set; }

	// Token: 0x1700030C RID: 780
	// (get) Token: 0x060010CE RID: 4302 RVA: 0x0006AF0D File Offset: 0x0006930D
	// (set) Token: 0x060010CF RID: 4303 RVA: 0x0006AF15 File Offset: 0x00069315
	[ProtoMember(3)]
	public Vector3Serializer OneVector3 { get; set; }

	// Token: 0x1700030D RID: 781
	// (get) Token: 0x060010D0 RID: 4304 RVA: 0x0006AF1E File Offset: 0x0006931E
	// (set) Token: 0x060010D1 RID: 4305 RVA: 0x0006AF26 File Offset: 0x00069326
	[ProtoMember(4)]
	public Vector3Serializer[] MultipleVector3 { get; set; }

	// Token: 0x1700030E RID: 782
	// (get) Token: 0x060010D2 RID: 4306 RVA: 0x0006AF2F File Offset: 0x0006932F
	// (set) Token: 0x060010D3 RID: 4307 RVA: 0x0006AF37 File Offset: 0x00069337
	[ProtoMember(5)]
	public string[] MaterialNames { get; set; }
}
