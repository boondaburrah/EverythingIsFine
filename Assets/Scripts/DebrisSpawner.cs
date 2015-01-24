using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebrisSpawner : MonoBehaviour {
	public int spawnCap;
	public int spawnCount;
	public float xRangeMin;
	public float xRangeMax;
	public float zRangeMin;
	public float zRangeMax;
	Vector3 spawnPos;
	DataNode type;	
	List<Vector3> noGo;
	public Sprite[] spriteVault;
	public float spriteScale;
	public GameObject prefab;

//DataNode Lists and TextAssets
	List<DataNode> commDeb;
	List<DataNode> unComDeb;
	List<DataNode> rareDeb;
	public TextAsset common;
	public TextAsset uncommon;
	public TextAsset rare;
	
	void Awake () {
		spawnPos = new Vector3();
		spriteVault = Resources.LoadAll<Sprite>("Sprites");
		type = new DataNode();
		noGo = new List<Vector3>();
		commDeb = new List<DataNode>();
		unComDeb = new List<DataNode>();
		rareDeb = new List<DataNode>();
		commDeb = PullData (commDeb, common);
		unComDeb = PullData (unComDeb, uncommon);
		rareDeb = PullData (rareDeb, rare);
	}	
		
	void Start () {	
		GameObject newDrop;
		spawnCount = 0;
		while (spawnCount < spawnCap){
			spawnPos = GetPos();
			newDrop = Instantiate(prefab, spawnPos,transform.rotation) as GameObject;
			type = PullType();
			newDrop = PrefabUpdate(newDrop, type);
			spawnCount++;
		}	
	}

	Vector3 GetPos () {
		Vector3 retval = new Vector3();
		bool good = false;
		while(!good){
			retval = GetVector();
			if(!IsNoGo(retval)){
				noGo.Add(retval);
				good = true;
			}	
		}	
		return retval;
	}
	
	GameObject PrefabUpdate(GameObject prefab, DataNode type) {
		prefab.tag = type.tagVal;
		prefab.GetComponent<SpriteRenderer>().sprite =  FindSprite(type.spriteName);
		prefab.GetComponent<Transform>().localScale = new Vector3 (spriteScale, spriteScale, spriteScale); 
		prefab.GetComponent<EarthDebris>().sanityBoost = type.sanityBoost;
		prefab.GetComponent<EarthDebris>().materialsMod = type.materialsMod;
		prefab.GetComponent<EarthDebris>().useText = type.useText;
		prefab.GetComponent<EarthDebris>().pickupText = type.pickupText;
		return prefab;
	}
	
	DataNode PullType () {
		int commonality;
		DataNode retval;
		commonality = Random.Range(0, 20);
		if(commonality < 10) {
			retval = Select(commDeb);
		}
		 else if (commonality < 17) {
			retval = Select(unComDeb);
		}
		else {
			retval = Select(rareDeb);
		}
		return retval;
	}	

//Helper Functions
	Vector3 GetVector () {
		Vector3 retval;
		float x;
		float y = (float) 1.5;
		float z;
		x = Random.Range (xRangeMin, xRangeMax);
		z = Random.Range (zRangeMin, zRangeMax);
		retval = new Vector3 (x, y, z);
		return retval;
	}
	bool IsNoGo (Vector3 loc) {
		bool retval = false;
		for (int i = 0; i < noGo.Count; i++) {
			if ((float)noGo[i].x == loc.x && (float)noGo[i].z == loc.z) {
				retval = true;
			}	
		}
		return retval;
	}
	DataNode Select (List<DataNode> pool) {
		DataNode retval;
		int i = Random.Range(0, pool.Count);
		retval = pool[i];
		return retval;
	}

	List<DataNode> PullData (List<DataNode> list, TextAsset data) {
		string [] source = data.text.Split('\n');
		DataNode temp = new DataNode();
		for (int i =1; i < source.Length-1; i++) {
			string [] values = source[i].Split(',');
			temp.spriteName = values[0];
			temp.tagVal = values[1];
			temp.sanityBoost = float.Parse (values[2]);
			temp.materialsMod = float.Parse (values[3]);
			temp.pickupText = values[4];
			temp.useText = values[5];
			list.Add(temp);
		}
		return list;
	}	
	Sprite FindSprite (string name) {
		Sprite retval = new Sprite();
		for (int i = 0; i < spriteVault.Length; i++){
			if (spriteVault[i].name == name) {
				retval = spriteVault[i];
			}
		}
		return retval;
	}
		
	
}
