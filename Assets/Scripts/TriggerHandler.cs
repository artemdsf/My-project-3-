using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] private AudioController _audioController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out _))
        {
            _audioController.StartAlarm();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out _))
        {
            _audioController.StopAlarm();
        }
    }
}
