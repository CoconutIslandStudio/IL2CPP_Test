using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;

public class CoconutClassStudy
{
	public int inta;
	public int intb;

	public int Add()
	{
		return inta + intb;
	}

	public CoconutClassStudy(int a, int b)
	{
		inta = a;
		intb = b;
	}

	public void IOTest(string filename)
	{
		if (File.Exists (filename)) {
			FileStream fs = File.Open(filename, FileMode.Create);
			fs.Close();

		}
	}

	public void ThreadTest()
	{
		Thread a =new Thread(delegate(object state) {
			Debug.Log ("Thread Started");
		});
		
		a.Start ();
	}
}


public class IL2CPPStudy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (CoconutFuncStudy (10 , 20));
		CoconutClassStudy cc = new CoconutClassStudy (50, 60);
		Debug.Log (cc.Add ());
		cc.IOTest("test.txt");
		cc.ThreadTest ();
		Debug.Log (cc.GetType ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	int CoconutFuncStudy(int a, int b)
	{
		return a + b;
	}
}
