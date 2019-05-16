using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class spawnBehaviorFile : MonoBehaviour {

	public float beatLength = 1.0f;
	private List<int> spawnOrder = new List<int>();
	private int length = 0;
	// Use this for initialization
	void Start () {
		string spawnIndex = "";
		string path = "";
		if (gameObject.CompareTag ("spawnerLeft")) {
			path = "Assets/Resources/songOneLeft.txt";
			Debug.Log("left found");
		}
		if (gameObject.CompareTag ("spawnerMiddle")) {
			path = "Assets/Resources/songOneCenter.txt"; 
			Debug.Log("middle found");
		}
		if (gameObject.CompareTag ("spawnerRight")) {
			path = "Assets/Resources/songOneRight.txt";
			Debug.Log("right found");
		}
		StreamReader reader = new StreamReader(path);
		while (!reader.EndOfStream) {
			string str = reader.ReadLine ();
			spawnOrder.Add (int.Parse (str));
		}
		reader.Close ();
	}
	
	// Update is called once per frame
	void Update () {
		beatLength -= Time.deltaTime;
		if (beatLength <= 0) {
			// 0 = blanks
			// 1 = score1
			// 2 = score2
			// 3 = score3
			// 4 = enemy
			// 5 = health
			if (spawnOrder[length] == 1) {
				GameObject go = (GameObject)Instantiate (Resources.Load ("scores1"));
				go.transform.position = transform.position;
			} else if (spawnOrder[length] == 2) {
				GameObject go = (GameObject)Instantiate (Resources.Load ("scores2"));
				go.transform.position = transform.position;
			} else if (spawnOrder[length] == 3) {
				GameObject go = (GameObject)Instantiate (Resources.Load ("scores3"));
				go.transform.position = transform.position;
			} else if (spawnOrder[length] == 4) {
				GameObject go = (GameObject)Instantiate (Resources.Load ("enemy"));
				go.transform.position = transform.position;
			} else if (spawnOrder[length] == 5) {
				GameObject go = (GameObject)Instantiate (Resources.Load ("health"));
				go.transform.position = transform.position;
			}
			length++;
			beatLength = 1f;
		}
	}
}
