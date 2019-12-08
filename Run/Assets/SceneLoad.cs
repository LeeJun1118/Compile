using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
	private static SceneLoad Instance = null;
	public static SceneLoad GetInstance
	{
		get
		{
			if (Instance == null)
			{
				GameObject container = new GameObject();
				container.name = "SceneManager";
				Instance = container.AddComponent(typeof(SceneLoad)) as SceneLoad;
				DontDestroyOnLoad(container);
			}

			return Instance;
		}
	}


	public Slider progressbar;
	public Text loadtext;
	public static string loadScene;
	public static int loadType;



	private void Start()
	{
		StartCoroutine(LoadScene());
	}


	public static void LoadSceneHandle(string _name, int _loadType)
	{
		loadScene = _name;
		loadType = _loadType;
		SceneManager.LoadScene("Loading");
	}



	IEnumerator LoadScene()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync("Play");
		operation.allowSceneActivation = false;
		progressbar.value = 0.0f;


		if (loadType == 0)
			Debug.Log("새게임");
		else if (loadType == 1)
			Debug.Log("헌게임");


		if (progressbar.value < 0.9f)
		{
			progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
		}
		else if (progressbar.value >= 0.9f && progressbar.value < 1.0f)
		{
			progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
		}
		else
		{
			loadtext.text = "Press SpaceBar";
			
			if (Input.GetKeyDown(KeyCode.Space) &&
			progressbar.value >= 1f &&
			operation.progress >= 0.9f)
			{
				operation.allowSceneActivation = true;
				yield return new WaitForSeconds( 0.01f );
			}
		}
	}
}
