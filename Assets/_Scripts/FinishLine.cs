using UnityEngine;
using System;

public class FinishLine : MonoBehaviour
{
    private readonly string _playerTag = "Player";
	public static Action OnWin;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(_playerTag))
		{
            print("Player wins!");
            OnWin?.Invoke();
		}
	}
}
