using UnityEngine;
using System.Collections;

public class AmmoPick : MonoBehaviour {

	public GameObject Ammo;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject == Ammo)
		{
			int randmovx = (int)Random.Range(0,4);
			int randmovy = (int)Random.Range(1,5);
			Ammo.transform.position = new Vector3(-randmovx*2, randmovy*2+1, 0.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
