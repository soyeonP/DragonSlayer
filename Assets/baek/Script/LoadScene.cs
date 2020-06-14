using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    /* 
    [사용법]
    sceneName을 바꿔주고 싶은 씬의 이름으로 설정한 뒤, ChangeScene 함수를 실행합니다.

    로드될 씬의 이름을 설정하는 방법은 해당 스크립트가 들어간 SceneManager(가칭) 오브젝트의 인스펙터창에서 바꾸거나,
    SetChangeSceneName함수를 사용해서 바꾸시면 됩니다.

    버튼에서 사용할 경우: Button의 Onclick에서 SceneManager -> SetChangeSceneName, ChangeScene 함수 사용
    타 스크립트에서 사용할 경우: SceneManager를 불러온 후 SetChangeSceneName, ChangeScene 함수 사용
    */
    public string sceneName;

    public void SetChangeSceneName(string sceneName)
    {
        sceneName = this.sceneName;
    }

    public void ChangeScene()
    {
        if (sceneName != null) SceneManager.LoadScene(sceneName);
    }
}
