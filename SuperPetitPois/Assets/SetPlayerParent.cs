using UnityEngine;
using System.Collections;

public class SetPlayerParent : MonoBehaviour {

	void Start ()
	{
	    transform.SetParent(LevelManager.Player.transform);
	    transform.localPosition = Vector3.zero;
	}
}
