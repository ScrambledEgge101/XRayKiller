using UnityEngine;
using System.Collections;

public class XRay : MonoBehaviour {

	public Material ClearMaterial;
	public Material CrateMaterial;
	public GameObject AmmoPicker;
	GameObject[] Crates;
	int g_seethroughlevel = 0;

	// Use this for initialization
	void Start () {
		Crates = GameObject.FindGameObjectsWithTag("Crate");
	}
	
	void MakeCratesSeeThrough(int seethroughlevel)
	{
		if (seethroughlevel == 2)
		{
			g_seethroughlevel = 2;
			for (int i = 0; i < Crates.Length; i++)
			{
				Crates[i].renderer.material.Lerp (ClearMaterial, CrateMaterial, 0.15f);
			}
		}
		else if (seethroughlevel == 1)
		{
			g_seethroughlevel = 1;
			for (int i = 0; i < Crates.Length; i++)
			{
				Crates[i].renderer.material.Lerp (ClearMaterial, CrateMaterial, 0.55f);
			}
		}
		else if (seethroughlevel == 0)
		{
			g_seethroughlevel = 0;
			for (int i = 0; i < Crates.Length; i++)
			{
				Crates[i].renderer.material = CrateMaterial;
			}
		}
	}
	
	void CheckPicker()
	{
		if (Input.GetKeyUp(KeyCode.W))
		{
			if (AmmoPicker.transform.position.y < 8)
			{
				AmmoPicker.transform.Translate (0.0f, 2.0f, 0.0f);
			}
		}
		if (Input.GetKeyUp (KeyCode.S))
		{
			if (AmmoPicker.transform.position.y > 1)
			{
				AmmoPicker.transform.Translate(0.0f, -2.0f, 0.0f);
			}
		}
		if (Input.GetKeyUp (KeyCode.A))
		{
			if (AmmoPicker.transform.position.x < 0)
			{
				AmmoPicker.transform.Translate (2.0f, 0.0f, 0.0f);
			}
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			if (AmmoPicker.transform.position.x  > -8)
			{
				AmmoPicker.transform.Translate (-2.0f, 0.0f, 0.0f);
			}
		}
	}
	
	void TestInput()
	{
		if (Input.GetKeyUp (KeyCode.Alpha1))
		{
			MakeCratesSeeThrough(0);
		}
		if (Input.GetKeyUp (KeyCode.Alpha2))
		{
			MakeCratesSeeThrough(1);
		}
		if (Input.GetKeyUp (KeyCode.Alpha3))
		{
			MakeCratesSeeThrough(2);
		}
		if (g_seethroughlevel == 1)
		{
			CheckPicker();
		}
	}
	
	// Update is called once per frame
	void Update () {
		TestInput ();
	}
}
