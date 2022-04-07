using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : BaseScene
{
    // ���� �� ������ ������� �ʱ�ȭ �۾����� ��������
    // Login�̸� Login���� ����ִ� �۾��� �������� ��ȭ���� �������ѱ� ���� ������ �۾��� ���ֱ� ���� ����
    // �������� �Ŵѱ�         �˾Ƶθ� ���� (Unreal�� Level�̶�� �� ��)

    // ���� BaseScene ��ӹ޴µ� ������ BaseScene�� @EvenetSystem�� ȣ���ϴ� ���(UI ���� ��ü)
    // @EventSystem�� ����鼭 @Manager(Core, Content) ��ü�� ������.

    // ��������� @Scene��ü�� Component�� �� �����ָ� �⺻���� Core���� ����� �����ϰ� �����


    // ���� �Ŵ������� �����ؾ��� Queue
    Queue<GameObject> queGo = new Queue<GameObject>();

	void Start()
    {
        // �׽�Ʈ�� �Ŵ����� �̿��� ������Ʈ ������ ���� ����

        // Pool�� ���� �༮�� Poolable ������Ʈ�� �־��ְ� Resources/Prefabs/TestCube �� ��ġ�ϰ� ����
        GameObject obj = Managers.Resource.NewPrefab("TestCube");       // ��ü�� ������
        Managers.Pool.CreatePool(obj);                                  // Ǯ�� ����
        Managers.Resource.DelPrefab(obj);                               // �����Ȱ� ����
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetKeyDown(KeyCode.A))
		{
			// Ǯ������ �������� �۾��� �����ϴ� �Լ��� ���Ƽ� ũ�� �Ű� �Ⱦ��� �������
			GameObject obj = Managers.Resource.NewPrefab("TestCube");
			obj.transform.position = new Vector3(Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f), Random.Range(-50.0f, 50.0f));
			queGo.Enqueue(obj);
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			if (queGo.Count > 0)
			{
				// Ǯ���� ��ü�� �ݳ��ϴ� �۾���.           Ǯ���� �ȵȰŸ� ������ ���ְ� ��
				Managers.Resource.DelPrefab(queGo.Dequeue());
			}
		}
	}

	// �� Ǯ�� Ȯ���� Unity�� Destroy������ Pool_Root -> TestCube_Root�� ���ĺ��� Ȯ�ΰ��� ��

	public override void Clear()
    {

    }
}
