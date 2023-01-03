using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class SceneData
{
    public static int SceneInst { set; get; }       // ��ǰ����ʵ��
    public static int SceneInstCount { set; get; }       // ������ʵ��
    public static List<int> SceneInstList = new List<int>();    // ����ʵ���б�
    public static List<int> ReachedScenes = new List<int>();    // ��Ҵﵽ���ĳ���

    private static Color ColorSceneNormal = Color.green;
    private static Color ColorSceneKillPower = Color.white;
    private static Color ColorSceneKillNoPower = Color.red;


    public static Color GetSceneNameColor(int scneneID)
    {
        if (!TeleportPoint.IsCanPK(scneneID))
        {
            return SceneData.ColorSceneNormal;
        }
        else
        {
            if (!TeleportPoint.IsIncPKValue(scneneID))
            {
                // PK��������
                return ColorSceneKillNoPower;
            }
            else
            {
                return ColorSceneKillPower;
            }
        }
    }

    /*public static void UpdateSceneInst(GC_UPDATE_SCENE_INSTACTIVATION packet)
    {
        SceneInstList.Clear();
        for (int i = 0; i < packet.sceneactivationCount; i++)
        {
            SceneInstList.Add(packet.sceneactivationList[i]);
        }
    }*/

    /*public static void UpdateReachedScenes(GC_SYNC_REACHEDSCENE packet)
    {
        ReachedScenes.Clear();
        for (int i = 0; i < packet.reachedSceneIDCount; i++)
        {
            ReachedScenes.Add(packet.reachedSceneIDList[i]);
        }
    }*/

    public static void RequestChangeScene(int nChangeType, int nTeleportID, int nSceneClassID, int nSceneInstID, int nPosX = 0, int nPosZ = 0)
    {
        //CG_REQ_CHANGE_SCENE packet = (CG_REQ_CHANGE_SCENE)PacketDistributed.CreatePacket(MessageID.PACKET_CG_REQ_CHANGE_SCENE);
        /*if (packet != null)
        {
            packet.Ctype = nChangeType;
            packet.Teleportid = nTeleportID;
            packet.Sceneclassid = nSceneClassID;
            packet.Sceneinstid = nSceneInstID;
            packet.PosX = nPosX;
            packet.PosZ = nPosZ;
            packet.SendPacket();
        }*/
    }
}
