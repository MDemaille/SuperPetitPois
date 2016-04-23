using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByBoundary : MonoBehaviour
{
    public List<string> ExcludedTagList;

	void OnTriggerExit2D(Collider2D collider)
	{
		if (!ExcludedTagList.Contains(collider.gameObject.tag))
			Destroy(collider.gameObject);
	}
}
