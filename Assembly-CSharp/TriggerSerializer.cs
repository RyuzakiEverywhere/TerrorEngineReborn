using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001EC RID: 492
[ProtoContract]
public sealed class TriggerSerializer
{
	// Token: 0x06000BD5 RID: 3029 RVA: 0x00060ED4 File Offset: 0x0005F2D4
	public TriggerSerializer(GameObject gameObject)
	{
		TriggerProperties component = gameObject.GetComponent<TriggerProperties>();
		this.triggerid = component.triggerid;
		this.onenter = component.onenter;
		this.togglevisible = component.togglevisible;
		this.interactive = component.interactive;
		this.destroyonexit = component.destroyonexit;
		this.imessage = component.imessage;
		this.toggleobj = component.toggleobj;
		this.toggleid = component.toggleid;
		this.playsound = component.playsound;
		this.soundpath = component.soundpath;
		this.soundloop = component.soundloop;
		this.playvideo = component.playvideo;
		this.videopath = component.videopath;
		this.displayimg = component.displayimg;
		this.imgpath = component.imgpath;
		this.imgmanually = component.imgmanually;
		this.imgduration = component.imgduration;
		this.teleport = component.teleport;
		this.nodename = component.nodename;
		this.door = component.door;
		this.doorname = component.doorname;
		this.enablecam = component.enablecam;
		this.camname = component.camname;
		this.camduration = component.camduration;
		this.displaytext = component.displaytext;
		this.text = component.text;
		this.textduration = component.textduration;
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x00061034 File Offset: 0x0005F434
	public TriggerSerializer(GameObject gameObject, TriggerSerializer component)
	{
		TriggerProperties triggerProperties = gameObject.GetComponent<TriggerProperties>();
		if (triggerProperties == null)
		{
			triggerProperties = gameObject.AddComponent<TriggerProperties>();
		}
		triggerProperties.triggerid = component.triggerid;
		triggerProperties.onenter = component.onenter;
		triggerProperties.togglevisible = component.togglevisible;
		triggerProperties.interactive = component.interactive;
		triggerProperties.destroyonexit = component.destroyonexit;
		triggerProperties.imessage = component.imessage;
		triggerProperties.toggleobj = component.toggleobj;
		triggerProperties.toggleid = component.toggleid;
		triggerProperties.playsound = component.playsound;
		triggerProperties.soundpath = component.soundpath;
		triggerProperties.soundloop = component.soundloop;
		triggerProperties.playvideo = component.playvideo;
		triggerProperties.videopath = component.videopath;
		triggerProperties.displayimg = component.displayimg;
		triggerProperties.imgpath = component.imgpath;
		triggerProperties.imgmanually = component.imgmanually;
		triggerProperties.imgduration = component.imgduration;
		triggerProperties.teleport = component.teleport;
		triggerProperties.nodename = component.nodename;
		triggerProperties.door = component.door;
		triggerProperties.doorname = component.doorname;
		triggerProperties.enablecam = component.enablecam;
		triggerProperties.camname = component.camname;
		triggerProperties.camduration = component.camduration;
		triggerProperties.displaytext = component.displaytext;
		triggerProperties.text = component.text;
		triggerProperties.textduration = component.textduration;
	}

	// Token: 0x06000BD7 RID: 3031 RVA: 0x000611A5 File Offset: 0x0005F5A5
	public TriggerSerializer()
	{
	}

	// Token: 0x04000E0F RID: 3599
	[ProtoMember(1)]
	public string triggerid;

	// Token: 0x04000E10 RID: 3600
	[ProtoMember(2)]
	public bool onenter;

	// Token: 0x04000E11 RID: 3601
	[ProtoMember(3)]
	public bool togglevisible;

	// Token: 0x04000E12 RID: 3602
	[ProtoMember(4)]
	public bool interactive;

	// Token: 0x04000E13 RID: 3603
	[ProtoMember(5)]
	public bool destroyonexit;

	// Token: 0x04000E14 RID: 3604
	[ProtoMember(6)]
	public string imessage;

	// Token: 0x04000E15 RID: 3605
	[ProtoMember(7)]
	public bool toggleobj;

	// Token: 0x04000E16 RID: 3606
	[ProtoMember(8)]
	public string toggleid;

	// Token: 0x04000E17 RID: 3607
	[ProtoMember(9)]
	public bool playsound;

	// Token: 0x04000E18 RID: 3608
	[ProtoMember(10)]
	public string soundpath;

	// Token: 0x04000E19 RID: 3609
	[ProtoMember(11)]
	public bool soundloop;

	// Token: 0x04000E1A RID: 3610
	[ProtoMember(12)]
	public bool playvideo;

	// Token: 0x04000E1B RID: 3611
	[ProtoMember(13)]
	public string videopath;

	// Token: 0x04000E1C RID: 3612
	[ProtoMember(14)]
	public bool displayimg;

	// Token: 0x04000E1D RID: 3613
	[ProtoMember(15)]
	public string imgpath;

	// Token: 0x04000E1E RID: 3614
	[ProtoMember(16)]
	public bool imgmanually;

	// Token: 0x04000E1F RID: 3615
	[ProtoMember(17)]
	public string imgduration;

	// Token: 0x04000E20 RID: 3616
	[ProtoMember(18)]
	public bool teleport;

	// Token: 0x04000E21 RID: 3617
	[ProtoMember(19)]
	public string nodename;

	// Token: 0x04000E22 RID: 3618
	[ProtoMember(20)]
	public bool door;

	// Token: 0x04000E23 RID: 3619
	[ProtoMember(21)]
	public string doorname;

	// Token: 0x04000E24 RID: 3620
	[ProtoMember(22)]
	public bool enablecam;

	// Token: 0x04000E25 RID: 3621
	[ProtoMember(23)]
	public string camname;

	// Token: 0x04000E26 RID: 3622
	[ProtoMember(24)]
	public string camduration;

	// Token: 0x04000E27 RID: 3623
	[ProtoMember(25)]
	public bool displaytext;

	// Token: 0x04000E28 RID: 3624
	[ProtoMember(26)]
	public string text;

	// Token: 0x04000E29 RID: 3625
	[ProtoMember(27)]
	public string textduration;
}
