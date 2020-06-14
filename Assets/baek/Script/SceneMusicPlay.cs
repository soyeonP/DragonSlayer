using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicPlay //타 스크립트에서 사용하기 위한 용도
{
    //사용법 : 특정 스크립트에서 해당 스크립트를 객체로 생성한 뒤, MusicChange 함수를 사용해서 음악을 바꿀수 있다.
    //사용 예시는 OpenInventory.cs에서 볼 수 있다.

    /*
    [자세한 사용법]
    타 스크립트에서 BGMmanager 또는 SEManager를 제어하기 위해 사용합니다.

    SceneMusicPlay 변수명;
    변수명 = new SceneMusicPlay(제어할 manager object); 
    위와 같이 선언하며, 생성자는 필수입니다.

    이후 MusicChange 함수를 이용해 실행할 AudioClip을 바꾸고
    MusicStart 함수를 콜하시면 됩니다.
    소리를 멈추고 싶으신 경우에는 MusicStop 함수를 이용해주세요.

    본 스크립트는 MusicChange 함수가 호출될때, 직전까지 타겟이 되던 AudioClip을 ex_Music에 저장합니다.
    RewindMusic은 한 스크립트에서 음악을 여러번 바꾸고 싶을때 사용합니다.
    사용시 타겟이 되는 AudioClip이 돌아올 것입니다. (Play는 별개로 함수를 실행해주셔야합니다)
     */

    public AudioClip Music;
    AudioClip ex_Music;
    public GameObject GameObjectWithAudioSource; //오디오 소스를 가지고있는 게임오브젝트 불러오기
    AudioSource thisObjectAudioSource; //오디오 소스

    public SceneMusicPlay(GameObject gameObjectWithAudioSource) //생성자
    {
        GameObjectWithAudioSource = gameObjectWithAudioSource;
        thisObjectAudioSource = GameObjectWithAudioSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //등록한 BGM과 현재 AudioSource의 BGM이 다르다면 체인지

        //현재 AudioSource의 Clip이 비어있지 않고, 스크립트에도 음악이 등록되어 있다면
        if (thisObjectAudioSource.clip != null && Music != null)
        {
            //음악 이름이 다르다면 바꿈
            if (thisObjectAudioSource.clip.name != Music.name)
            {
                thisObjectAudioSource.clip = Music;
                thisObjectAudioSource.Play();
            }
            
        }else if(Music != null) {
            //AudioSource의 클립은 비어있지만 스크립트에는 음악이 등록되어 있는경우
            thisObjectAudioSource.clip = Music;
            thisObjectAudioSource.Play();
        }
        
    }

    public void MusicChange(AudioClip music)
    {
        //해당 함수를 사용하면 선택한 Object의 AudioClip이 바뀌게 된다.
        if(music != null)
        {
            ex_Music = Music; //바뀌기 전 음악을 기억
            this.Music = music;
            thisObjectAudioSource.clip = music;
        }
    }

    public void MusicStart()
    {
        if (thisObjectAudioSource != null)
        {
            thisObjectAudioSource.Play();
        }
    }
    public void MusicStop()
    {
        //음악을 멈춘다
        thisObjectAudioSource.Stop();
    }
    public void RewindMusic()
    {
        if(ex_Music != null)
        {
            this.Music = ex_Music;
        }
        else
        {
            Debug.LogWarning("변수 ex_Music이 null입니다. (이전 음악이 등록되어 있지 않습니다)");
        }
    }
}
