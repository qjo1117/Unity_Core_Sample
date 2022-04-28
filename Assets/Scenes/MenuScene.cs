using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : BaseScene
{
	GameObject _uiObject;

    
	void Start()
    {
		// �������� �����´�
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

	// �� Ǯ�� Ȯ���� Unity�� Destroy������ Pool_Root -> TestCube_Root�� ���ĺ��� Ȯ�ΰ��� ��

	public override void Clear()
    {

    }
}
