using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : BaseScene
{
	GameObject _uiObject;

    
	void Start()
    {
		// 프리팹을 가져온다
		_uiObject = Managers.Resource.NewPrefab("SceneChange");
		Texture2D texture = Managers.Resource.Load<Texture2D>("Images/MenuSceneImage");
		_uiObject.GetOrderComponent<MeshRenderer>().material.mainTexture = texture;

		Camera.main.transform.position = new Vector3(0.0f, 10.0f, 0.0f);
		Camera.main.transform.Rotate(new Vector3(90.0f, 0.0f, 180.0f));
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space)) {
			Managers.Scene.LoadScene(Define.Scene.SingleScene);
		}
		
	}

	// ★ 풀링 확인은 Unity에 Destroy영역에 Pool_Root -> TestCube_Root를 펼쳐보면 확인가능 ★

	public override void Clear()
    {

    }
}
