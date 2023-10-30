using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
	[SerializeField] private string _intruderTag = "Intruder";
	[SerializeField] private AudioController _audioController;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(_intruderTag))
		{
			_audioController.StartAlarm();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag(_intruderTag))
		{
			_audioController.StopAlarm();
		}
	}
}
