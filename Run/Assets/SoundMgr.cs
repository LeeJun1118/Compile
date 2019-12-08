using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class SoundMgr : MonoBehaviour
{

	private static SoundMgr Instance = null;
	public static SoundMgr GetInstance
	{
		get
		{
			if(Instance == null)
			{
				GameObject container = new GameObject();
				container.name = "SoundManager";
				Instance = container.AddComponent(typeof(SoundMgr)) as SoundMgr;
			}

			return Instance;
		}
	}



	void Start()
	{

	}


	void Update()
	{

	}
}
