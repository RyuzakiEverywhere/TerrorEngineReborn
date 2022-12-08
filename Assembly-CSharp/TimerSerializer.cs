using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001EB RID: 491
[ProtoContract]
public sealed class TimerSerializer
{
	// Token: 0x06000BD2 RID: 3026 RVA: 0x00060BF8 File Offset: 0x0005EFF8
	public TimerSerializer(GameObject gameObject)
	{
		TimerProperties component = gameObject.GetComponent<TimerProperties>();
		this.triggerid = component.triggerid;
		this.oneshot = component.oneshot;
		this.togglevisible = component.togglevisible;
		this.repeat = component.repeat;
		this.duration = component.duration;
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

	// Token: 0x06000BD3 RID: 3027 RVA: 0x00060D58 File Offset: 0x0005F158
	public TimerSerializer(GameObject gameObject, TimerSerializer component)
	{
		TimerProperties timerProperties = gameObject.GetComponent<TimerProperties>();
		if (timerProperties == null)
		{
			timerProperties = gameObject.AddComponent<TimerProperties>();
		}
		timerProperties.triggerid = component.triggerid;
		timerProperties.oneshot = component.oneshot;
		timerProperties.togglevisible = component.togglevisible;
		timerProperties.repeat = component.repeat;
		timerProperties.duration = component.duration;
		timerProperties.imessage = component.imessage;
		timerProperties.toggleobj = component.toggleobj;
		timerProperties.toggleid = component.toggleid;
		timerProperties.playsound = component.playsound;
		timerProperties.soundpath = component.soundpath;
		timerProperties.soundloop = component.soundloop;
		timerProperties.playvideo = component.playvideo;
		timerProperties.videopath = component.videopath;
		timerProperties.displayimg = component.displayimg;
		timerProperties.imgpath = component.imgpath;
		timerProperties.imgmanually = component.imgmanually;
		timerProperties.imgduration = component.imgduration;
		timerProperties.teleport = component.teleport;
		timerProperties.nodename = component.nodename;
		timerProperties.door = component.door;
		timerProperties.doorname = component.doorname;
		timerProperties.enablecam = component.enablecam;
		timerProperties.camname = component.camname;
		timerProperties.camduration = component.camduration;
		timerProperties.displaytext = component.displaytext;
		timerProperties.text = component.text;
		timerProperties.textduration = component.textduration;
	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x00060EC9 File Offset: 0x0005F2C9
	public TimerSerializer()
	{
	}

	// Token: 0x04000DF4 RID: 3572
	[ProtoMember(1)]
	public string triggerid;

	// Token: 0x04000DF5 RID: 3573
	[ProtoMember(2)]
	public bool oneshot;

	// Token: 0x04000DF6 RID: 3574
	[ProtoMember(3)]
	public bool togglevisible;

	// Token: 0x04000DF7 RID: 3575
	[ProtoMember(4)]
	public bool repeat;

	// Token: 0x04000DF8 RID: 3576
	[ProtoMember(5)]
	public string duration;

	// Token: 0x04000DF9 RID: 3577
	[ProtoMember(6)]
	public string imessage;

	// Token: 0x04000DFA RID: 3578
	[ProtoMember(7)]
	public bool toggleobj;

	// Token: 0x04000DFB RID: 3579
	[ProtoMember(8)]
	public string toggleid;

	// Token: 0x04000DFC RID: 3580
	[ProtoMember(9)]
	public bool playsound;

	// Token: 0x04000DFD RID: 3581
	[ProtoMember(10)]
	public string soundpath;

	// Token: 0x04000DFE RID: 3582
	[ProtoMember(11)]
	public bool soundloop;

	// Token: 0x04000DFF RID: 3583
	[ProtoMember(12)]
	public bool playvideo;

	// Token: 0x04000E00 RID: 3584
	[ProtoMember(13)]
	public string videopath;

	// Token: 0x04000E01 RID: 3585
	[ProtoMember(14)]
	public bool displayimg;

	// Token: 0x04000E02 RID: 3586
	[ProtoMember(15)]
	public string imgpath;

	// Token: 0x04000E03 RID: 3587
	[ProtoMember(16)]
	public bool imgmanually;

	// Token: 0x04000E04 RID: 3588
	[ProtoMember(17)]
	public string imgduration;

	// Token: 0x04000E05 RID: 3589
	[ProtoMember(18)]
	public bool teleport;

	// Token: 0x04000E06 RID: 3590
	[ProtoMember(19)]
	public string nodename;

	// Token: 0x04000E07 RID: 3591
	[ProtoMember(20)]
	public bool door;

	// Token: 0x04000E08 RID: 3592
	[ProtoMember(21)]
	public string doorname;

	// Token: 0x04000E09 RID: 3593
	[ProtoMember(22)]
	public bool enablecam;

	// Token: 0x04000E0A RID: 3594
	[ProtoMember(23)]
	public string camname;

	// Token: 0x04000E0B RID: 3595
	[ProtoMember(24)]
	public string camduration;

	// Token: 0x04000E0C RID: 3596
	[ProtoMember(25)]
	public bool displaytext;

	// Token: 0x04000E0D RID: 3597
	[ProtoMember(26)]
	public string text;

	// Token: 0x04000E0E RID: 3598
	[ProtoMember(27)]
	public string textduration;
}
