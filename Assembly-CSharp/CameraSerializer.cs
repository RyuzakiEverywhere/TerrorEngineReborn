using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x0200020C RID: 524
[ProtoContract]
public sealed class CameraSerializer
{
	// Token: 0x06000E9F RID: 3743 RVA: 0x00065434 File Offset: 0x00063834
	public CameraSerializer(GameObject gameObject, CameraSerializer component)
	{
		Camera camera = gameObject.GetComponent<Camera>();
		if (camera == null)
		{
			camera = gameObject.AddComponent<Camera>();
		}
		camera.fov = component.FOV;
		camera.fieldOfView = component.FieldOfView;
		camera.nearClipPlane = component.NearClipPlane;
		camera.farClipPlane = component.FarClipPlane;
		camera.renderingPath = (RenderingPath)component.RenderingPath;
		camera.orthographicSize = component.OrthographicSize;
		camera.orthographic = component.Orthographic;
		camera.orthographic = component.IsOrthoGraphic;
		camera.depth = component.Depth;
		camera.cullingMask = component.CullingMask;
		camera.backgroundColor = (Color)component.BackgroundColor;
		camera.rect = (Rect)component.Rect;
		camera.hdr = component.HDR;
		camera.layerCullSpherical = component.LayerCullSpherical;
		camera.useOcclusionCulling = component.UseOcclusionCulling;
		if (!string.IsNullOrEmpty(component.TargetTextureName))
		{
			camera.targetTexture = (RenderTexture)UniSave.TryLoadResource(component.TargetTextureName);
		}
		camera.worldToCameraMatrix = (Matrix4x4)component.WorldToCameraMatrix;
		camera.ResetWorldToCameraMatrix();
		camera.projectionMatrix = (Matrix4x4)component.ProjectionMatrix;
		camera.ResetProjectionMatrix();
		camera.clearFlags = (CameraClearFlags)component.ClearFlags;
		camera.layerCullDistances = component.LayerCullDistances;
		camera.depthTextureMode = (DepthTextureMode)component.DepthTextureMode;
		camera.enabled = component.Enabled;
	}

	// Token: 0x06000EA0 RID: 3744 RVA: 0x000655A4 File Offset: 0x000639A4
	public CameraSerializer(GameObject gameObject)
	{
		Camera component = gameObject.GetComponent<Camera>();
		this.FOV = component.fov;
		this.FieldOfView = component.fieldOfView;
		this.NearClipPlane = component.nearClipPlane;
		this.FarClipPlane = component.farClipPlane;
		this.RenderingPath = (RenderingPathSerializer)component.renderingPath;
		this.HDR = component.hdr;
		this.LayerCullSpherical = component.layerCullSpherical;
		this.UseOcclusionCulling = component.useOcclusionCulling;
		this.OrthographicSize = component.orthographicSize;
		this.Orthographic = component.orthographic;
		this.IsOrthoGraphic = component.orthographic;
		this.Depth = component.depth;
		this.CullingMask = component.cullingMask;
		this.BackgroundColor = (ColorSerializer)component.backgroundColor;
		this.Rect = (RectSerializer)component.rect;
		if (component.targetTexture != null)
		{
			this.TargetTextureName = component.targetTexture.name;
		}
		this.WorldToCameraMatrix = (Matrix4x4Serializer)component.worldToCameraMatrix;
		this.ProjectionMatrix = (Matrix4x4Serializer)component.projectionMatrix;
		this.ClearFlags = (CameraClearFlagsSerializer)component.clearFlags;
		this.LayerCullDistances = component.layerCullDistances;
		this.DepthTextureMode = (DepthTextureModeSerializer)component.depthTextureMode;
		this.Enabled = component.enabled;
	}

	// Token: 0x06000EA1 RID: 3745 RVA: 0x000656F0 File Offset: 0x00063AF0
	private CameraSerializer()
	{
	}

	// Token: 0x17000254 RID: 596
	// (get) Token: 0x06000EA2 RID: 3746 RVA: 0x000656F8 File Offset: 0x00063AF8
	// (set) Token: 0x06000EA3 RID: 3747 RVA: 0x00065700 File Offset: 0x00063B00
	[ProtoMember(1)]
	public float FOV { get; set; }

	// Token: 0x17000255 RID: 597
	// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x00065709 File Offset: 0x00063B09
	// (set) Token: 0x06000EA5 RID: 3749 RVA: 0x00065711 File Offset: 0x00063B11
	[ProtoMember(2)]
	public float Near { get; set; }

	// Token: 0x17000256 RID: 598
	// (get) Token: 0x06000EA6 RID: 3750 RVA: 0x0006571A File Offset: 0x00063B1A
	// (set) Token: 0x06000EA7 RID: 3751 RVA: 0x00065722 File Offset: 0x00063B22
	[ProtoMember(3)]
	public float Far { get; set; }

	// Token: 0x17000257 RID: 599
	// (get) Token: 0x06000EA8 RID: 3752 RVA: 0x0006572B File Offset: 0x00063B2B
	// (set) Token: 0x06000EA9 RID: 3753 RVA: 0x00065733 File Offset: 0x00063B33
	[ProtoMember(4)]
	public float FieldOfView { get; set; }

	// Token: 0x17000258 RID: 600
	// (get) Token: 0x06000EAA RID: 3754 RVA: 0x0006573C File Offset: 0x00063B3C
	// (set) Token: 0x06000EAB RID: 3755 RVA: 0x00065744 File Offset: 0x00063B44
	[ProtoMember(5)]
	public float NearClipPlane { get; set; }

	// Token: 0x17000259 RID: 601
	// (get) Token: 0x06000EAC RID: 3756 RVA: 0x0006574D File Offset: 0x00063B4D
	// (set) Token: 0x06000EAD RID: 3757 RVA: 0x00065755 File Offset: 0x00063B55
	[ProtoMember(6)]
	public float FarClipPlane { get; set; }

	// Token: 0x1700025A RID: 602
	// (get) Token: 0x06000EAE RID: 3758 RVA: 0x0006575E File Offset: 0x00063B5E
	// (set) Token: 0x06000EAF RID: 3759 RVA: 0x00065766 File Offset: 0x00063B66
	[ProtoMember(7)]
	public RenderingPathSerializer RenderingPath { get; set; }

	// Token: 0x1700025B RID: 603
	// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0006576F File Offset: 0x00063B6F
	// (set) Token: 0x06000EB1 RID: 3761 RVA: 0x00065777 File Offset: 0x00063B77
	[ProtoMember(8)]
	public bool HDR { get; set; }

	// Token: 0x1700025C RID: 604
	// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x00065780 File Offset: 0x00063B80
	// (set) Token: 0x06000EB3 RID: 3763 RVA: 0x00065788 File Offset: 0x00063B88
	[ProtoMember(9)]
	public float OrthographicSize { get; set; }

	// Token: 0x1700025D RID: 605
	// (get) Token: 0x06000EB4 RID: 3764 RVA: 0x00065791 File Offset: 0x00063B91
	// (set) Token: 0x06000EB5 RID: 3765 RVA: 0x00065799 File Offset: 0x00063B99
	[ProtoMember(10)]
	public bool Orthographic { get; set; }

	// Token: 0x1700025E RID: 606
	// (get) Token: 0x06000EB6 RID: 3766 RVA: 0x000657A2 File Offset: 0x00063BA2
	// (set) Token: 0x06000EB7 RID: 3767 RVA: 0x000657AA File Offset: 0x00063BAA
	[ProtoMember(11)]
	public bool IsOrthoGraphic { get; set; }

	// Token: 0x1700025F RID: 607
	// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x000657B3 File Offset: 0x00063BB3
	// (set) Token: 0x06000EB9 RID: 3769 RVA: 0x000657BB File Offset: 0x00063BBB
	[ProtoMember(12)]
	public float Depth { get; set; }

	// Token: 0x17000260 RID: 608
	// (get) Token: 0x06000EBA RID: 3770 RVA: 0x000657C4 File Offset: 0x00063BC4
	// (set) Token: 0x06000EBB RID: 3771 RVA: 0x000657CC File Offset: 0x00063BCC
	[ProtoMember(14)]
	public int CullingMask { get; set; }

	// Token: 0x17000261 RID: 609
	// (get) Token: 0x06000EBC RID: 3772 RVA: 0x000657D5 File Offset: 0x00063BD5
	// (set) Token: 0x06000EBD RID: 3773 RVA: 0x000657DD File Offset: 0x00063BDD
	[ProtoMember(15)]
	public ColorSerializer BackgroundColor { get; set; }

	// Token: 0x17000262 RID: 610
	// (get) Token: 0x06000EBE RID: 3774 RVA: 0x000657E6 File Offset: 0x00063BE6
	// (set) Token: 0x06000EBF RID: 3775 RVA: 0x000657EE File Offset: 0x00063BEE
	[ProtoMember(16)]
	public RectSerializer Rect { get; set; }

	// Token: 0x17000263 RID: 611
	// (get) Token: 0x06000EC0 RID: 3776 RVA: 0x000657F7 File Offset: 0x00063BF7
	// (set) Token: 0x06000EC1 RID: 3777 RVA: 0x000657FF File Offset: 0x00063BFF
	[ProtoMember(18)]
	public string TargetTextureName { get; set; }

	// Token: 0x17000264 RID: 612
	// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x00065808 File Offset: 0x00063C08
	// (set) Token: 0x06000EC3 RID: 3779 RVA: 0x00065810 File Offset: 0x00063C10
	[ProtoMember(19)]
	public Matrix4x4Serializer WorldToCameraMatrix { get; set; }

	// Token: 0x17000265 RID: 613
	// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x00065819 File Offset: 0x00063C19
	// (set) Token: 0x06000EC5 RID: 3781 RVA: 0x00065821 File Offset: 0x00063C21
	[ProtoMember(20)]
	public Matrix4x4Serializer ProjectionMatrix { get; set; }

	// Token: 0x17000266 RID: 614
	// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x0006582A File Offset: 0x00063C2A
	// (set) Token: 0x06000EC7 RID: 3783 RVA: 0x00065832 File Offset: 0x00063C32
	[ProtoMember(21)]
	public CameraClearFlagsSerializer ClearFlags { get; set; }

	// Token: 0x17000267 RID: 615
	// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x0006583B File Offset: 0x00063C3B
	// (set) Token: 0x06000EC9 RID: 3785 RVA: 0x00065843 File Offset: 0x00063C43
	[ProtoMember(22)]
	public bool UseOcclusionCulling { get; set; }

	// Token: 0x17000268 RID: 616
	// (get) Token: 0x06000ECA RID: 3786 RVA: 0x0006584C File Offset: 0x00063C4C
	// (set) Token: 0x06000ECB RID: 3787 RVA: 0x00065854 File Offset: 0x00063C54
	[ProtoMember(23)]
	public float[] LayerCullDistances { get; set; }

	// Token: 0x17000269 RID: 617
	// (get) Token: 0x06000ECC RID: 3788 RVA: 0x0006585D File Offset: 0x00063C5D
	// (set) Token: 0x06000ECD RID: 3789 RVA: 0x00065865 File Offset: 0x00063C65
	[ProtoMember(24)]
	public bool LayerCullSpherical { get; set; }

	// Token: 0x1700026A RID: 618
	// (get) Token: 0x06000ECE RID: 3790 RVA: 0x0006586E File Offset: 0x00063C6E
	// (set) Token: 0x06000ECF RID: 3791 RVA: 0x00065876 File Offset: 0x00063C76
	[ProtoMember(25)]
	public DepthTextureModeSerializer DepthTextureMode { get; set; }

	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x0006587F File Offset: 0x00063C7F
	// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x00065887 File Offset: 0x00063C87
	[ProtoMember(26)]
	public bool Enabled { get; set; }

	// Token: 0x04000F86 RID: 3974
	[ProtoMember(27)]
	public TransparencySortModeSerializer TransparencySortMode;
}
