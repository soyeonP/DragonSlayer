using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicPlay
{
    //사용법 : 특정 스크립트에서 해당 스크립트를 객체로 생성한 뒤, MusicChange 함수를 사용해서 음악을 바꿀수 있다.
    //사용 예시는 OpenInventory.cs에서 볼 수 있다.

    public AudioClip Music;
    public GameObject GameObjectWithAudioSource; //오디오 소스를 가지고있는 게임오브젝트 불러오기
    private AudioSource thisObjectAudioSource; //오디오 소스

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

    public void MusicChange(AudioClip BGM)
    {
        //해당 함수를 사용하면 선택한 Object의 AudioClip이 바뀌게 된다.
        if(BGM != null)
        {
            this.Music = BGM;
            thisObjectAudioSource.clip = BGM;
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
}
