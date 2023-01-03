using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public enum Scene_Const_Value
{
    MAX_SCENE_MUSIC_NUM = 3,
}
public class SceneLogic : MonoBehaviour
{
#if UNITY_ANDROID && !UNITY_EDITOR
        public void SetCameraMain()
        {
            if (Camera.main == null) return;

            float m_CameraXOffset = 7.8f;            //�����������ǵ�Xƫ��
            float m_CameraYOffset = 8.0f;           //�����������ǵ�Yƫ��
            float m_CameraZOffset = -9.0f;          //�����������ǵ�Zƫ��
            float m_CameraXOffsetMax = 7.8f;            //�����������ǵ�Xƫ��
            float m_CameraYOffsetMax = 8.0f;           //�����������ǵ�Yƫ��
            float m_CameraZOffsetMax = -9.0f;          //�����������ǵ�Zƫ��
            float m_CameraXOffsetMin = 4.0f;
            float m_CameraYOffsetMin = 4.0f;
            float m_CameraZOffsetMin = -5.0f;
            float m_Scale = 1.0f;
            float m_pinchSpeed = 100.0f;

            float m_CenterOffest = 0.6f;
            float m_CenterOffsetMax = 0.9f;
            float m_CenterOffsetMin = 0.6f;
            float m_PinchMax = 10.0f;

            Transform m_CameraTran = Camera.main.transform;

            Vector3 camInitPos = GameManager.gameManager.PlayerDataPool.EnterSceneCache.EnterScenePos;
            camInitPos = ActiveScene.GetTerrainPosition(camInitPos, false);


            //����������ĽǶ�
            m_CameraXOffset = (m_CameraXOffsetMax - m_CameraXOffsetMin) * m_Scale + m_CameraXOffsetMin;
            m_CameraYOffset = (m_CameraYOffsetMax - m_CameraYOffsetMin) * m_Scale + m_CameraYOffsetMin;
            m_CameraZOffset = (m_CameraZOffsetMax - m_CameraZOffsetMin) * m_Scale + m_CameraZOffsetMin;
            m_CenterOffest = (m_CenterOffsetMax - m_CenterOffsetMin) * (1 - m_Scale) + m_CenterOffsetMin;
            Vector3 dir = new Vector3(m_CameraXOffset, m_CameraYOffset, m_CameraZOffset);
            m_CameraTran.position = camInitPos + dir;

            Vector3 pos = camInitPos;
            pos.y += m_CenterOffest;
            Vector3 lookPos = pos - m_CameraTran.position;
            lookPos.Normalize();
            m_CameraTran.rotation = Quaternion.LookRotation(lookPos);
        }
#endif

    void Awake()
    {
        //���õ�ǰ����
        /*if (null == GameManager.gameManager)
        {
            ResourceManager.InstantiateResource("Prefab/Logic/GameManager", "GameManagerObject");
        }*/

#if UNITY_ANDROID && !UNITY_EDITOR

            if (null != Camera.main)
            {
                SetCameraMain();
            }

#endif

        //if (null == PlatformListener.Instance())
        //{
        //    ResourceManager.InstantiateResource("Prefab/Logic/PlatformListener", "PlatformListener");
        //}

        //if (null == AndroidHelper.Instance())
        //{
        //    ResourceManager.InstantiateResource("Prefab/Logic/AndroidHelper", "AndroidHelper");
        //}

        //����ǰ����SceneLogic����GameManager�ݴ�
        ///GameManager.gameManager.SceneLogic = this;

        //by dys ��������ܱ仯
        ///ResourceManager.InstantiateResource("Prefab/Logic/FingerGestures", "FingerGestures");
        //GameManager.gameManager.ActiveScene.CurSceneID = GameManager.gameManager.RunningScene;
        //GameManager.gameManager.ActiveScene.UIRoot = GameObject.Find("UI Root");
        // ��Debug���߹��볡�����緢����ʽ�棬ע�͵����д���
        // DebugHelper.CreateDebugHelper();
        ///Singleton<ObjManager>.GetInstance().OnEnterScene();

#if UNITY_ANDROID && !UNITY_EDITOR
            GameManager.gameManager.initDataCallback = GonoAwake;
            GameManager.gameManager.ActiveScene.Init();
            return;
#endif

        // ��̬���س����޷�����SHADER����
        //#if UNITY_EDITOR
        GameObject SceneObj = GameObject.Find("Scene");
        /*if (null != SceneObj && SceneObj.GetComponent<ShaderFix>() == null)
        {
            SceneObj.AddComponent<ShaderFix>();
        }*/

        TeleportPoint[] Teleports = GameObject.FindObjectsOfType<TeleportPoint>();
        /*foreach (TeleportPoint curTeleport in Teleports)
        {
            if (curTeleport.gameObject.GetComponent<ShaderFix>() == null)
            {
                curTeleport.gameObject.AddComponent<ShaderFix>();
            }
        }*/

        //#endif
        ///GameManager.gameManager.ActiveScene.Init();

        //Ϊ�˷�ֹ�Ͷ˻����ڳ����л���ɺ����ﴴ�����֮����յ��հ׵ĵط��������ȵ���һ���������λ��
        /*if (null != Camera.main)
        {
            Vector3 camInitPos = GameManager.gameManager.PlayerDataPool.EnterSceneCache.EnterScenePos;
            camInitPos = ActiveScene.GetTerrainPosition(camInitPos);
            camInitPos.y += 8.0f;
            Camera.main.transform.position = camInitPos;
        }*/
        //Init Scene Obj(NPC) data from tables
        //InitSceneObjData(GameManager.gameManager.RunningScene);

        //��ʼ������ͨ·ͼ
        /*if (null != GameManager.gameManager.AutoSearch)
        {
            GameManager.gameManager.AutoSearch.InitMapConnectPath();
        }*/

        //�����б��ش�������
        //if ((int)GameDefine_Globe.SCENE_DEFINE.SCENE_LOGIN != GameManager.gameManager.RunningScene)
        //{
        //    Singleton<ObjManager>.GetInstance().CreateMainPlayer();
        //}

        //�����Ƿ�ɴ�����Ϣ��
        ///NetWorkLogic.GetMe().CanProcessPacket = true;
    }

    /// <summary>
    /// ������Դ���� �ص�
    /// </summary>
    private void GonoAwake()
    {
        /*GameManager.gameManager.initDataCallback -= GonoAwake;

        //��ʼ������ͨ·ͼ
        if (null != GameManager.gameManager.AutoSearch)
        {
            GameManager.gameManager.AutoSearch.InitMapConnectPath();
        }

        //�����Ƿ�ɴ�����Ϣ��
        NetWorkLogic.GetMe().CanProcessPacket = true;*/
    }

    // Use this for initialization
    //�����ڲ���ʼ���ڴ˽���
    void Start()
    {
        /*if ((int)GameDefine_Globe.SCENE_DEFINE.SCENE_LOGIN != GameManager.gameManager.RunningScene)
        {
            // login scene will call play bg self
            PlaySceneMusic();
            Singleton<CollectItem>.GetInstance().InitCollectItem(GameManager.gameManager.RunningScene);
            Singleton<JuQingItemMgr>.GetInstance().InitJuqingItem(GameManager.gameManager.RunningScene);
        }*/

        //StartCoroutine(BundleManager.BundleQueueLoadTick());
    }

    public void PlaySceneMusic()
    {
        /*if (null == GameManager.gameManager.SoundManager)
        {
            return;
        }

        Tab_SceneClass tab = TableManager.GetSceneClassByID(GameManager.gameManager.RunningScene, 0);
        if (tab == null)
        {
            return;
        }

        if (tab.BGMusic < 0)
        {
            return;
        }

        Tab_Sounds soundsTab = TableManager.GetSoundsByID(tab.BGMusic, 0);
        if (soundsTab == null)
        {
            //  
            LogModule.DebugLog("sound name " + tab.BGMusic.ToString() + " is null");
            return;
        }

        GameManager.gameManager.SoundManager.PlayBGMusic(tab.BGMusic, soundsTab.FadeOutTime, soundsTab.FadeInTime);*/
    }

    // Update is called once per frame
    void Update()
    {
        //�������Ϊ�գ�����������ȷ�Ļ�����������
        //if (null == Singleton<ObjManager>.GetInstance().MainPlayer)
        {
            //�жϷ����������Ƿ��Ѿ��������
            //if (GameManager.gameManager.OnLineState)
            {
                //if (GameManager.gameManager.RunningScene == GameManager.gameManager.PlayerDataPool.EnterSceneCache.EnterSceneSceneID &&
                //    GameManager.gameManager.PlayerDataPool.EnterSceneCache.EnterSceneServerID != -1 &&
                //    GameManager.gameManager.PlayerDataPool.EnterSceneCache.EnterSceneRoleBaseID != -1)
                //{
                //    //����MainPlayer
                //    if ((int)GameDefine_Globe.SCENE_DEFINE.SCENE_LOGIN != GameManager.gameManager.RunningScene)
                //    {
                //        Singleton<ObjManager>.GetInstance().CreateMainPlayer();
                //    }
                //}
            }
            //else
            {
                //���Դ��룬��֤�����¿��Դ�������
                /*if ((int)GameDefine_Globe.SCENE_DEFINE.SCENE_LOGIN != GameManager.gameManager.RunningScene)
                {
                    GameManager.gameManager.PlayerDataPool.EnterSceneCache.EnterSceneCharModelID = (int)CharacterDefine.PROFESSION.XIAOYAO;
                    Singleton<ObjManager>.GetInstance().CreateMainPlayer();
                }*/
            }

            //��������Ѿ�������������������ݣ���ֹ�ظ�����������׼���´��л�����ʹ��
            /*if (null != Singleton<ObjManager>.GetInstance().MainPlayer)
            {
                GameManager.gameManager.PlayerDataPool.EnterSceneCache.ClearEnterSceneInfo();
            }*/
        }

#if UNITY_ANDROID
            if (Time.time - m_npcTime > 0)
            {
                Singleton<ObjManager>.GetInstance().ShowNPC();
                m_npcTime = Time.time + GameManager.gameManager.m_NPCRefreshTime;
            }

            if (_wheelTime == 0) _wheelTime = Time.time;

            if (Time.time - _wheelTime >= m_cacheTime)
            {
                Singleton<ObjManager>.GetInstance().DeleteNPCGameObject();
                _wheelTime = Time.time;
            }
#endif
    }

    private float m_cacheTime = 20.0f;
    private float _wheelTime;
    private float m_npcTime = 0.0f;

    void FixedUpdate()
    {
        ///BundleManager.BundleQueueLoadTick(this);
    }

    void Destroy()
    {
        /*if (null != GameManager.gameManager)
        {
            if (null != GameManager.gameManager.ActiveScene)
            {
                GameManager.gameManager.ActiveScene.RelaseActiveSceneData();
            }

            //��յ�ǰ����SceneLogic����
            GameManager.gameManager.SceneLogic = null;
        }*/
    }
    void OnApplicationPause(bool paused)
    {
        /*if (!paused)
        {
            //����Ӻ�̨����ǰ̨ʱ
            PushNotification.CleanNotification();

            Obj_MainPlayer mainPlayer = Singleton<ObjManager>.Instance.MainPlayer;
            if (null != mainPlayer)
            {
                mainPlayer.LastHeartBeatTime = UnityEngine.Time.time;
            }
        }*/
        /*if (GlobeVar.s_FirstInitGame)
        {
            // ��ʱ�����û�г�ʼ��
            return;
        }*/
        //��������̨ʱ
        if (paused)
        {
            /*PushNotification.CleanNotification();
            PushNotification.NotificationMessage2Clinet();
            LogModule.DebugLog("OnApplicationPause:NotificationMessage2Server");
            PushNotification.NotificationMessage2Server();*/
        }

    }
}
