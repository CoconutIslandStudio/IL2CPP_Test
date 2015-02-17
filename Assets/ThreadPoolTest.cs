using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Threading;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

public class ThreadPoolTest : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
		Thread a =new Thread(delegate(object state) {
			Debug.Log ("+++++++QueueUserWorkItem+++++++");
		});

		a.Start ();

		var client = new TcpClient ();
		String hosturl = "https://cn.avoscloud.com/1";
		client.Connect (hosturl, 443);

		using (var stream = client.GetStream ()) 
		{
			//Debug.Log("CONNECTING ");
			var ostream = stream as Stream;
			if (true) {
				//ostream = new SslStream (stream, false, new RemoteCertificateValidationCallback (ValidateServerCertificate));

				/*
				try {
					var ssl = ostream as SslStream;
					ssl.AuthenticateAsClient (hosturl);
				} catch (Exception e) {
					Debug.LogError ("Exception: " + e.Message);
					//									return;
				}
				*/

				/*
				Debug.Log("CONNECTING.... ");
				var tlsClient = new LegacyTlsClient (new AlwaysValidVerifyer ());
				var handler = new TlsProtocolHandler (ostream);
				handler.Connect (tlsClient);
				Debug.Log("CONNECTING End");
				*/

			}
		}

	}

	public static bool ValidateServerCertificate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		Debug.LogWarning ("SSL Cert Error:" + sslPolicyErrors.ToString ());
		return true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
