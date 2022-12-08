using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

// Token: 0x02000090 RID: 144
public class SendEmail : MonoBehaviour
{
	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000282 RID: 642 RVA: 0x000182CE File Offset: 0x000166CE
	// (set) Token: 0x06000283 RID: 643 RVA: 0x000182DB File Offset: 0x000166DB
	public string _Email_Address
	{
		get
		{
			return SC.ToString(this.Email_Address);
		}
		set
		{
			this.Email_Address = SC.FromString(value);
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000284 RID: 644 RVA: 0x000182E9 File Offset: 0x000166E9
	// (set) Token: 0x06000285 RID: 645 RVA: 0x000182F6 File Offset: 0x000166F6
	public string _Email_Password
	{
		get
		{
			return SC.ToString(this.Email_Password);
		}
		set
		{
			this.Email_Password = SC.FromString(value);
		}
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00018304 File Offset: 0x00016704
	private void Start()
	{
		this.Gui = base.GetComponent<GUIEmail>();
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00018314 File Offset: 0x00016714
	private void Update()
	{
		if (this.Ready)
		{
			MailMessage mailMessage = new MailMessage();
			mailMessage.From = new MailAddress(this.Email_Address);
			mailMessage.To.Add(this.Email_Address);
			mailMessage.Subject = this.Gui.Subject + " - " + this.Gui.address;
			mailMessage.Body = string.Concat(new object[]
			{
				this.Gui.Body,
				"\n\n System Type: ",
				SystemInfo.operatingSystem,
				"\n RAM: ",
				SystemInfo.systemMemorySize,
				"MB\n CPU: ",
				SystemInfo.processorType
			});
			SmtpClient smtpClient = new SmtpClient("gator2023.hostgator.com");
			smtpClient.Port = 26;
			smtpClient.Credentials = (new NetworkCredential(this.Email_Address, this.Email_Password) as ICredentialsByHost);
			smtpClient.EnableSsl = true;
			ServicePointManager.ServerCertificateValidationCallback = ((object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true);
			smtpClient.Send(mailMessage);
			Debug.Log("Success");
			this.Ready = false;
		}
	}

	// Token: 0x0400030D RID: 781
	protected string Email_Address = "support@zeoworks.com";

	// Token: 0x0400030E RID: 782
	protected string Email_Password = "001001001";

	// Token: 0x0400030F RID: 783
	public bool Ready;

	// Token: 0x04000310 RID: 784
	private GUIEmail Gui;
}
