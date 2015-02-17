using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Threading;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

public class IL2CPPCompatible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ThreadPoolTest ();
		SSLAuthenticateTest ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ThreadPoolTest()
	{
		ThreadPool.QueueUserWorkItem (new WaitCallback ((a) => {
			Debug.Log("Thread from tread pool started");
		}));
	}

	void SSLAuthenticateTest()
	{
		var client = new TcpClient ();
		String hosturl = "115.239.211.112";//www.baidu.com;
		client.Connect (hosturl, 443);
		
		using (var stream = client.GetStream ()) 
		{
			Debug.Log("CONNECTING ");
			var ostream = stream as Stream;
			if (true) 
			{
				ostream = new SslStream (stream, false, new RemoteCertificateValidationCallback (ValidateServerCertificate));
				

				try 
				{
					var ssl = ostream as SslStream;
					ssl.AuthenticateAsClient (hosturl);
				} 
				catch (Exception e) 
				{
					Debug.Log ("Exception: " + e.Message);
				}
			}
		}
	}

	public static bool ValidateServerCertificate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		Debug.LogWarning ("SSL Cert Error:" + sslPolicyErrors.ToString ());
		return true;
	}
}
