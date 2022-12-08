using System;
using ProtoBuf;
using UnityEngine;

// Token: 0x020001E8 RID: 488
[ProtoContract]
public sealed class SettingsSerializer
{
	// Token: 0x06000BC9 RID: 3017 RVA: 0x00060124 File Offset: 0x0005E524
	public SettingsSerializer(GameObject gameObject)
	{
		SettingsProperties component = gameObject.GetComponent<SettingsProperties>();
		this.escape = component.escape;
		this.collect = component.collect;
		this.collectandescape = component.collectandescape;
		this.versus = component.versus;
		this.skyboxnull = component.skyboxnull;
		this.skybox1 = component.skybox1;
		this.skybox2 = component.skybox2;
		this.skybox3 = component.skybox3;
		this.skybox4 = component.skybox4;
		this.skybox5 = component.skybox5;
		this.skybox6 = component.skybox6;
		this.skybox7 = component.skybox7;
		this.skybox8 = component.skybox8;
		this.gridsize = component.gridsize;
		this.rlight = component.rlight;
		this.glight = component.glight;
		this.blight = component.blight;
		this.dust = component.dust;
		this.hail = component.hail;
		this.rain = component.rain;
		this.snow = component.snow;
		this.flurries = component.flurries;
		this.Crease = component.Crease;
		this.blur = component.blur;
		this.greyscale = component.greyscale;
		this.sepiatone = component.sepiatone;
		this.noise = component.noise;
		this.enhancecontrast = component.enhancecontrast;
		this.fov = component.fov;
		this.nofog = component.nofog;
		this.neargrey = component.neargrey;
		this.nearblack = component.nearblack;
		this.fargrey = component.fargrey;
		this.farblack = component.farblack;
		this.rfog = component.rfog;
		this.gfog = component.gfog;
		this.bfog = component.bfog;
		this.fogdens = component.fogdens;
		this.FakeSSAO = component.FakeSSAO;
		this.CrossHatch = component.CrossHatch;
		this.Charcoal = component.Charcoal;
		this.FourBit = component.FourBit;
		this.SobelOutlineV2 = component.SobelOutlineV2;
		this.HDR = component.HDR;
		this.LightWave = component.LightWave;
		this.SecurityCamera = component.SecurityCamera;
		this.BlackAndWhite = component.BlackAndWhite;
		this.Holywood = component.Holywood;
		this.RadialBlur = component.RadialBlur;
		this.Goodrays1 = component.Goodrays1;
		this.Amnesia = component.Amnesia;
		this.Noise = component.Noise;
		this.FoggyScreen = component.FoggyScreen;
		this.ThermalVision = component.ThermalVision;
		this.NightVision = component.NightVision;
		this.Bleach = component.Bleach;
		this.Scanlines = component.Scanlines;
		this.Vignette = component.Vignette;
		this.Wiggle = component.Wiggle;
		this.SobelEdge = component.SobelEdge;
		this.SinCity = component.SinCity;
		this.Pulse = component.Pulse;
		this.Posterize = component.Posterize;
		this.Pixelated = component.Pixelated;
		this.Negative = component.Negative;
		this.LensCircle = component.LensCircle;
		this.Frost = component.Frost;
		this.EdgeDetect = component.EdgeDetect;
		this.Desaturate = component.Desaturate;
		this.lockstory = component.lockstory;
		this.authorname = component.authorname;
		this.gameovername = component.gameovername;
		this.winname = component.winname;
		this.footsteps = component.footsteps;
		this.sa = component.sa;
		this.canrespawn = component.canrespawn;
		this.killnpc = component.killnpc;
		this.camtype = component.camtype;
		this.useinv = component.useinv;
		this.usesunshine = component.usesunshine;
		this.rsun = component.rsun;
		this.gsun = component.gsun;
		this.bsun = component.bsun;
		this.rsunlight = component.rsunlight;
		this.gsunlight = component.gsunlight;
		this.bsunlight = component.bsunlight;
		this.sunrotx = component.sunrotx;
		this.sunroty = component.sunroty;
		this.sunrotz = component.sunrotz;
	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x0006056C File Offset: 0x0005E96C
	public SettingsSerializer(GameObject gameObject, SettingsSerializer component)
	{
		SettingsProperties settingsProperties = gameObject.GetComponent<SettingsProperties>();
		if (settingsProperties == null)
		{
			settingsProperties = gameObject.AddComponent<SettingsProperties>();
		}
		settingsProperties.escape = component.escape;
		settingsProperties.collect = component.collect;
		settingsProperties.collectandescape = component.collectandescape;
		settingsProperties.versus = component.versus;
		settingsProperties.skyboxnull = component.skyboxnull;
		settingsProperties.skybox1 = component.skybox1;
		settingsProperties.skybox2 = component.skybox2;
		settingsProperties.skybox3 = component.skybox3;
		settingsProperties.skybox4 = component.skybox4;
		settingsProperties.skybox5 = component.skybox5;
		settingsProperties.skybox6 = component.skybox6;
		settingsProperties.skybox7 = component.skybox7;
		settingsProperties.skybox8 = component.skybox8;
		settingsProperties.gridsize = component.gridsize;
		settingsProperties.rlight = component.rlight;
		settingsProperties.glight = component.glight;
		settingsProperties.blight = component.blight;
		settingsProperties.dust = component.dust;
		settingsProperties.hail = component.hail;
		settingsProperties.rain = component.rain;
		settingsProperties.snow = component.snow;
		settingsProperties.flurries = component.flurries;
		settingsProperties.Crease = component.Crease;
		settingsProperties.blur = component.blur;
		settingsProperties.greyscale = component.greyscale;
		settingsProperties.sepiatone = component.sepiatone;
		settingsProperties.noise = component.noise;
		settingsProperties.enhancecontrast = component.enhancecontrast;
		settingsProperties.fov = component.fov;
		settingsProperties.nofog = component.nofog;
		settingsProperties.neargrey = component.neargrey;
		settingsProperties.nearblack = component.nearblack;
		settingsProperties.fargrey = component.fargrey;
		settingsProperties.farblack = component.farblack;
		settingsProperties.rfog = component.rfog;
		settingsProperties.gfog = component.gfog;
		settingsProperties.bfog = component.bfog;
		settingsProperties.fogdens = component.fogdens;
		settingsProperties.FakeSSAO = component.FakeSSAO;
		settingsProperties.CrossHatch = component.CrossHatch;
		settingsProperties.Charcoal = component.Charcoal;
		settingsProperties.FourBit = component.FourBit;
		settingsProperties.SobelOutlineV2 = component.SobelOutlineV2;
		settingsProperties.HDR = component.HDR;
		settingsProperties.LightWave = component.LightWave;
		settingsProperties.SecurityCamera = component.SecurityCamera;
		settingsProperties.BlackAndWhite = component.BlackAndWhite;
		settingsProperties.Holywood = component.Holywood;
		settingsProperties.RadialBlur = component.RadialBlur;
		settingsProperties.Goodrays1 = component.Goodrays1;
		settingsProperties.Amnesia = component.Amnesia;
		settingsProperties.Noise = component.Noise;
		settingsProperties.FoggyScreen = component.FoggyScreen;
		settingsProperties.ThermalVision = component.ThermalVision;
		settingsProperties.NightVision = component.NightVision;
		settingsProperties.Bleach = component.Bleach;
		settingsProperties.Scanlines = component.Scanlines;
		settingsProperties.Vignette = component.Vignette;
		settingsProperties.Wiggle = component.Wiggle;
		settingsProperties.SobelEdge = component.SobelEdge;
		settingsProperties.SinCity = component.SinCity;
		settingsProperties.Pulse = component.Pulse;
		settingsProperties.Posterize = component.Posterize;
		settingsProperties.Pixelated = component.Pixelated;
		settingsProperties.Negative = component.Negative;
		settingsProperties.LensCircle = component.LensCircle;
		settingsProperties.Frost = component.Frost;
		settingsProperties.EdgeDetect = component.EdgeDetect;
		settingsProperties.Desaturate = component.Desaturate;
		settingsProperties.lockstory = component.lockstory;
		settingsProperties.authorname = component.authorname;
		settingsProperties.gameovername = component.gameovername;
		settingsProperties.winname = component.winname;
		settingsProperties.footsteps = component.footsteps;
		settingsProperties.sa = component.sa;
		settingsProperties.canrespawn = component.canrespawn;
		settingsProperties.killnpc = component.killnpc;
		settingsProperties.camtype = component.camtype;
		settingsProperties.useinv = component.useinv;
		settingsProperties.usesunshine = component.usesunshine;
		settingsProperties.rsun = component.rsun;
		settingsProperties.gsun = component.gsun;
		settingsProperties.bsun = component.bsun;
		settingsProperties.rsunlight = component.rsunlight;
		settingsProperties.gsunlight = component.gsunlight;
		settingsProperties.bsunlight = component.bsunlight;
		settingsProperties.sunrotx = component.sunrotx;
		settingsProperties.sunroty = component.sunroty;
		settingsProperties.sunrotz = component.sunrotz;
	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x000609C5 File Offset: 0x0005EDC5
	public SettingsSerializer()
	{
	}

	// Token: 0x04000D8E RID: 3470
	[ProtoMember(1)]
	public bool escape;

	// Token: 0x04000D8F RID: 3471
	[ProtoMember(2)]
	public bool collect;

	// Token: 0x04000D90 RID: 3472
	[ProtoMember(3)]
	public bool collectandescape;

	// Token: 0x04000D91 RID: 3473
	[ProtoMember(4)]
	public bool versus;

	// Token: 0x04000D92 RID: 3474
	[ProtoMember(5)]
	public bool skyboxnull;

	// Token: 0x04000D93 RID: 3475
	[ProtoMember(6)]
	public bool skybox1;

	// Token: 0x04000D94 RID: 3476
	[ProtoMember(7)]
	public bool skybox2;

	// Token: 0x04000D95 RID: 3477
	[ProtoMember(8)]
	public bool skybox3;

	// Token: 0x04000D96 RID: 3478
	[ProtoMember(9)]
	public bool skybox4;

	// Token: 0x04000D97 RID: 3479
	[ProtoMember(10)]
	public bool skybox5;

	// Token: 0x04000D98 RID: 3480
	[ProtoMember(11)]
	public bool skybox6;

	// Token: 0x04000D99 RID: 3481
	[ProtoMember(12)]
	public bool skybox7;

	// Token: 0x04000D9A RID: 3482
	[ProtoMember(13)]
	public bool skybox8;

	// Token: 0x04000D9B RID: 3483
	[ProtoMember(14)]
	public int gridsize;

	// Token: 0x04000D9C RID: 3484
	[ProtoMember(15)]
	public float rlight;

	// Token: 0x04000D9D RID: 3485
	[ProtoMember(16)]
	public float glight;

	// Token: 0x04000D9E RID: 3486
	[ProtoMember(17)]
	public float blight;

	// Token: 0x04000D9F RID: 3487
	[ProtoMember(18)]
	public bool dust;

	// Token: 0x04000DA0 RID: 3488
	[ProtoMember(19)]
	public bool hail;

	// Token: 0x04000DA1 RID: 3489
	[ProtoMember(20)]
	public bool rain;

	// Token: 0x04000DA2 RID: 3490
	[ProtoMember(21)]
	public bool snow;

	// Token: 0x04000DA3 RID: 3491
	[ProtoMember(22)]
	public bool flurries;

	// Token: 0x04000DA4 RID: 3492
	[ProtoMember(23)]
	public bool Crease;

	// Token: 0x04000DA5 RID: 3493
	[ProtoMember(24)]
	public bool blur;

	// Token: 0x04000DA6 RID: 3494
	[ProtoMember(25)]
	public bool greyscale;

	// Token: 0x04000DA7 RID: 3495
	[ProtoMember(26)]
	public bool sepiatone;

	// Token: 0x04000DA8 RID: 3496
	[ProtoMember(27)]
	public bool noise;

	// Token: 0x04000DA9 RID: 3497
	[ProtoMember(28)]
	public bool enhancecontrast;

	// Token: 0x04000DAA RID: 3498
	[ProtoMember(29)]
	public float fov;

	// Token: 0x04000DAB RID: 3499
	[ProtoMember(30)]
	public bool nofog;

	// Token: 0x04000DAC RID: 3500
	[ProtoMember(31)]
	public bool neargrey;

	// Token: 0x04000DAD RID: 3501
	[ProtoMember(32)]
	public bool nearblack;

	// Token: 0x04000DAE RID: 3502
	[ProtoMember(33)]
	public bool fargrey;

	// Token: 0x04000DAF RID: 3503
	[ProtoMember(34)]
	public bool farblack;

	// Token: 0x04000DB0 RID: 3504
	[ProtoMember(35)]
	public float rfog;

	// Token: 0x04000DB1 RID: 3505
	[ProtoMember(36)]
	public float gfog;

	// Token: 0x04000DB2 RID: 3506
	[ProtoMember(37)]
	public float bfog;

	// Token: 0x04000DB3 RID: 3507
	[ProtoMember(38)]
	public float fogdens;

	// Token: 0x04000DB4 RID: 3508
	[ProtoMember(39)]
	public bool FakeSSAO;

	// Token: 0x04000DB5 RID: 3509
	[ProtoMember(40)]
	public bool CrossHatch;

	// Token: 0x04000DB6 RID: 3510
	[ProtoMember(41)]
	public bool Charcoal;

	// Token: 0x04000DB7 RID: 3511
	[ProtoMember(42)]
	public bool FourBit;

	// Token: 0x04000DB8 RID: 3512
	[ProtoMember(43)]
	public bool SobelOutlineV2;

	// Token: 0x04000DB9 RID: 3513
	[ProtoMember(44)]
	public bool HDR;

	// Token: 0x04000DBA RID: 3514
	[ProtoMember(45)]
	public bool LightWave;

	// Token: 0x04000DBB RID: 3515
	[ProtoMember(46)]
	public bool SecurityCamera;

	// Token: 0x04000DBC RID: 3516
	[ProtoMember(47)]
	public bool BlackAndWhite;

	// Token: 0x04000DBD RID: 3517
	[ProtoMember(48)]
	public bool Holywood;

	// Token: 0x04000DBE RID: 3518
	[ProtoMember(49)]
	public bool RadialBlur;

	// Token: 0x04000DBF RID: 3519
	[ProtoMember(50)]
	public bool Goodrays1;

	// Token: 0x04000DC0 RID: 3520
	[ProtoMember(51)]
	public bool Amnesia;

	// Token: 0x04000DC1 RID: 3521
	[ProtoMember(52)]
	public bool Noise;

	// Token: 0x04000DC2 RID: 3522
	[ProtoMember(53)]
	public bool FoggyScreen;

	// Token: 0x04000DC3 RID: 3523
	[ProtoMember(54)]
	public bool ThermalVision;

	// Token: 0x04000DC4 RID: 3524
	[ProtoMember(55)]
	public bool NightVision;

	// Token: 0x04000DC5 RID: 3525
	[ProtoMember(56)]
	public bool Bleach;

	// Token: 0x04000DC6 RID: 3526
	[ProtoMember(57)]
	public bool Scanlines;

	// Token: 0x04000DC7 RID: 3527
	[ProtoMember(58)]
	public bool Vignette;

	// Token: 0x04000DC8 RID: 3528
	[ProtoMember(59)]
	public bool Wiggle;

	// Token: 0x04000DC9 RID: 3529
	[ProtoMember(60)]
	public bool SobelEdge;

	// Token: 0x04000DCA RID: 3530
	[ProtoMember(61)]
	public bool SinCity;

	// Token: 0x04000DCB RID: 3531
	[ProtoMember(62)]
	public bool Pulse;

	// Token: 0x04000DCC RID: 3532
	[ProtoMember(63)]
	public bool Posterize;

	// Token: 0x04000DCD RID: 3533
	[ProtoMember(64)]
	public bool Pixelated;

	// Token: 0x04000DCE RID: 3534
	[ProtoMember(65)]
	public bool Negative;

	// Token: 0x04000DCF RID: 3535
	[ProtoMember(66)]
	public bool LensCircle;

	// Token: 0x04000DD0 RID: 3536
	[ProtoMember(67)]
	public bool Frost;

	// Token: 0x04000DD1 RID: 3537
	[ProtoMember(68)]
	public bool EdgeDetect;

	// Token: 0x04000DD2 RID: 3538
	[ProtoMember(69)]
	public bool Desaturate;

	// Token: 0x04000DD3 RID: 3539
	[ProtoMember(70)]
	public bool lockstory;

	// Token: 0x04000DD4 RID: 3540
	[ProtoMember(71)]
	public string authorname;

	// Token: 0x04000DD5 RID: 3541
	[ProtoMember(72)]
	public string gameovername;

	// Token: 0x04000DD6 RID: 3542
	[ProtoMember(73)]
	public string winname;

	// Token: 0x04000DD7 RID: 3543
	[ProtoMember(74)]
	public string footsteps;

	// Token: 0x04000DD8 RID: 3544
	[ProtoMember(75)]
	public bool sa;

	// Token: 0x04000DD9 RID: 3545
	[ProtoMember(76)]
	public bool canrespawn;

	// Token: 0x04000DDA RID: 3546
	[ProtoMember(77)]
	public bool killnpc;

	// Token: 0x04000DDB RID: 3547
	[ProtoMember(78)]
	public int camtype;

	// Token: 0x04000DDC RID: 3548
	[ProtoMember(79)]
	public bool useinv;

	// Token: 0x04000DDD RID: 3549
	[ProtoMember(80)]
	public bool usesunshine;

	// Token: 0x04000DDE RID: 3550
	[ProtoMember(81)]
	public float rsun;

	// Token: 0x04000DDF RID: 3551
	[ProtoMember(82)]
	public float gsun;

	// Token: 0x04000DE0 RID: 3552
	[ProtoMember(83)]
	public float bsun;

	// Token: 0x04000DE1 RID: 3553
	[ProtoMember(84)]
	public float rsunlight;

	// Token: 0x04000DE2 RID: 3554
	[ProtoMember(85)]
	public float gsunlight;

	// Token: 0x04000DE3 RID: 3555
	[ProtoMember(86)]
	public float bsunlight;

	// Token: 0x04000DE4 RID: 3556
	[ProtoMember(87)]
	public string sunrotx;

	// Token: 0x04000DE5 RID: 3557
	[ProtoMember(88)]
	public string sunroty;

	// Token: 0x04000DE6 RID: 3558
	[ProtoMember(89)]
	public string sunrotz;
}
