using System;
using UnityEngine;

// Token: 0x020000C0 RID: 192
public class LOD_Model : MonoBehaviour
{
	// Token: 0x06000391 RID: 913 RVA: 0x00020CFC File Offset: 0x0001F0FC
	private void Update()
	{
		this.CurrentDistance = Vector3.Distance(this.Player.position, base.transform.position);
		if (this.Meshrenderer)
		{
			if (this.veryclose)
			{
				base.GetComponent<MeshFilter>().mesh = this.veryclose_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.veryclose_texture;
				}
			}
			if (this.close)
			{
				base.GetComponent<MeshFilter>().mesh = this.close_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.close_texture;
				}
			}
			if (this.nearby)
			{
				base.GetComponent<MeshFilter>().mesh = this.nearby_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.nearby_texture;
				}
			}
			if (this.far)
			{
				base.GetComponent<MeshFilter>().mesh = this.far_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.far_texture;
				}
			}
			if (this.veryfar)
			{
				base.GetComponent<MeshFilter>().mesh = this.veryfar_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.veryfar_texture;
				}
			}
		}
		if (this.Skinnedmeshrenderer)
		{
			if (this.veryclose)
			{
				base.gameObject.AddComponent<SkinnedMeshRenderer>().sharedMesh = this.veryclose_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.veryclose_texture;
				}
			}
			if (this.close)
			{
				base.gameObject.AddComponent<SkinnedMeshRenderer>().sharedMesh = this.close_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.close_texture;
				}
			}
			if (this.nearby)
			{
				base.gameObject.AddComponent<SkinnedMeshRenderer>().sharedMesh = this.nearby_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.nearby_texture;
				}
			}
			if (this.far)
			{
				base.gameObject.AddComponent<SkinnedMeshRenderer>().sharedMesh = this.far_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.far_texture;
				}
			}
			if (this.veryfar)
			{
				base.gameObject.AddComponent<SkinnedMeshRenderer>().sharedMesh = this.veryfar_mesh;
				if (this.change_main_texture)
				{
					base.GetComponent<Renderer>().material.mainTexture = this.veryfar_texture;
				}
			}
		}
		if (this.CurrentDistance <= this.veryclose_distance)
		{
			this.veryclose = true;
			this.close = false;
			this.nearby = false;
			this.far = false;
			this.veryfar = false;
		}
		if (this.CurrentDistance >= this.veryclose_distance && this.CurrentDistance <= this.close_distance)
		{
			this.veryclose = false;
			this.close = true;
			this.nearby = false;
			this.far = false;
			this.veryfar = false;
		}
		if (this.CurrentDistance >= this.close_distance && this.CurrentDistance <= this.nearby_distance)
		{
			this.veryclose = false;
			this.close = false;
			this.nearby = true;
			this.far = false;
			this.veryfar = false;
		}
		if (this.CurrentDistance >= this.nearby_distance && this.CurrentDistance <= this.far_distance)
		{
			this.veryclose = false;
			this.close = false;
			this.nearby = false;
			this.far = true;
			this.veryfar = false;
		}
		if (this.CurrentDistance >= this.veryfar_distance)
		{
			this.veryclose = false;
			this.close = false;
			this.nearby = false;
			this.far = false;
			this.veryfar = true;
		}
	}

	// Token: 0x040003E5 RID: 997
	public Transform Player;

	// Token: 0x040003E6 RID: 998
	public bool Meshrenderer = true;

	// Token: 0x040003E7 RID: 999
	public bool Skinnedmeshrenderer;

	// Token: 0x040003E8 RID: 1000
	public float veryclose_distance = 5f;

	// Token: 0x040003E9 RID: 1001
	public float close_distance = 10f;

	// Token: 0x040003EA RID: 1002
	public float nearby_distance = 15f;

	// Token: 0x040003EB RID: 1003
	public float far_distance = 20f;

	// Token: 0x040003EC RID: 1004
	public float veryfar_distance = 21f;

	// Token: 0x040003ED RID: 1005
	public Mesh veryclose_mesh;

	// Token: 0x040003EE RID: 1006
	public Mesh close_mesh;

	// Token: 0x040003EF RID: 1007
	public Mesh nearby_mesh;

	// Token: 0x040003F0 RID: 1008
	public Mesh far_mesh;

	// Token: 0x040003F1 RID: 1009
	public Mesh veryfar_mesh;

	// Token: 0x040003F2 RID: 1010
	public bool change_main_texture;

	// Token: 0x040003F3 RID: 1011
	public Texture2D veryclose_texture;

	// Token: 0x040003F4 RID: 1012
	public Texture2D close_texture;

	// Token: 0x040003F5 RID: 1013
	public Texture2D nearby_texture;

	// Token: 0x040003F6 RID: 1014
	public Texture2D far_texture;

	// Token: 0x040003F7 RID: 1015
	public Texture2D veryfar_texture;

	// Token: 0x040003F8 RID: 1016
	private bool veryclose;

	// Token: 0x040003F9 RID: 1017
	private bool close;

	// Token: 0x040003FA RID: 1018
	private bool nearby;

	// Token: 0x040003FB RID: 1019
	private bool far;

	// Token: 0x040003FC RID: 1020
	private bool veryfar;

	// Token: 0x040003FD RID: 1021
	public float CurrentDistance;
}
