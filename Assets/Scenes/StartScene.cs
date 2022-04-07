using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : BaseScene
{
    // 이제 각 씬마다 해줘야할 초기화 작업들이 있을꺼야
    // Login이면 Login씬을 띄어주는 작업과 서버상태 변화등이 있을꺼닌깐 각각 나눠서 작업을 해주기 위해 씬을
    // 나눠놓은 거닌깐         알아두면 편함 (Unreal은 Level이라는 용어를 씀)

    // 씬은 BaseScene 상속받는데 이유는 BaseScene에 @EvenetSystem를 호출하는 기능(UI 전용 객체)
    // @EventSystem을 만들면서 @Manager(Core, Content) 객체를 생성함.

    // 결론적으로 @Scene객체와 Component를 잘 맞춰주면 기본적인 Core들은 사용이 원할하게 진행됨


    // 따로 매니저에서 맵핑해야할 Queue
    Queue<GameObject> queGo = new Queue<GameObject>();

	void Start()
    {
        // 테스트겸 매니저를 이용한 오브젝트 생성및 삭제 예제

        // Pool로 대상된 녀석은 Poolable 컴포넌트를 넣어주고 Resources/Prefabs/TestCube 로 위치하고 있음
        GameObject obj = Managers.Resource.NewPrefab("TestCube");       // 객체를 가져옴
        Managers.Pool.CreatePool(obj);                                  // 풀링 생성
        Managers.Resource.DelPrefab(obj);                               // 생성된거 삭제
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.A))
		{
			// 풀링에서 가져오는 작업과 생성하는 함수가 같아서 크게 신경 안쓰게 만든거임
			GameObject obj = Managers.Resource.NewPrefab("TestCube");
			obj.transform.position = new Vector3(Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f));
			queGo.Enqueue(obj);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			if (queGo.Count > 0)
			{
				// 풀링된 객체라서 반납하는 작업임.           풀링이 안된거면 삭제를 해주게 됨
				Managers.Resource.DelPrefab(queGo.Dequeue());
			}
		}
	}

	// ★ 풀링 확인은 Unity에 Destroy영역에 Pool_Root -> TestCube_Root를 펼쳐보면 확인가능 ★

	public override void Clear()
    {

    }
}
