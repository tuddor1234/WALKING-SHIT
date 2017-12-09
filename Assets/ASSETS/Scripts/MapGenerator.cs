using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

//	public item[] items;

	struct colorPair{
		Color startColor,endColor;
	};

	 struct item{
		int numberOfItems;
		GameObject prefab;
		List<colorPair> materials;

	};

	ChangeMaterial cm = new ChangeMaterial();

	void Start () 
	{
		/*
		for (int i = 0; i < 4; i++) {
			items[i] = new item();
			for (int j = 1; j <= items[i].numberOfItems; j++) {
				int xPos = Random.Range (0, 100);
				int zPos = Random.Range (0, 100);
				int yRot = Random.Range (0, 360);
				Instantiate(items[i].prefab,new Vector3(xPos,0,zPos, new Quaternion(0,yRot,0)));
			}
		}
		*/
	}
	

}
