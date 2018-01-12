using UnityEngine;
using System.Collections;

public class ClockAnimator : MonoBehaviour {
	public Transform hours, minutes, seconds;
	
	void Update () {

		hours.localRotation = Quaternion.Euler(0, Time.time * 10, 0);
		minutes.localRotation = Quaternion.Euler(0, Time.time * 30, 0);
		seconds.localRotation = Quaternion.Euler(0, Time.time * 90, 0);
	}
}
	