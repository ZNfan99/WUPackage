using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

/// <summary>
/// 挂机 需要继承Obj
/// </summary>
public class Obj_MainPlayer_AFK : MonoBehaviour
{
    private AIController m_aiController = null;
    public AIController Controller
    {
        get { return m_aiController; }
        set { m_aiController = value; }
    }

    public PlayerHeadInfo m_playerHeadInfo;

    //是否开始自动战斗
    public bool AutoComabat
    {
        get { return true; }//} GameManager.gameManager.PlayerDataPool.AutoComabat; }
        set {  value = true; }
    }

    //是否开启挂机模式
    public bool IsOpenAutoCombat
    {
        get { return true; }//} GameManager.gameManager.PlayerDataPool.AutoComabat; }
        set { value = true; }
        //get { return GameManager.gameManager.PlayerDataPool.IsOpenAutoCombat; }
        //set { GameManager.gameManager.PlayerDataPool.IsOpenAutoCombat = value; }
    }
    
    //进入自动战斗
    public void EnterAutoCombat()
    {
        if (Controller)
        {
            m_playerHeadInfo.ToggleGuaJi(true);
            Controller.EnterCombat();
            AutoComabat = true;
            IsOpenAutoCombat = true;
            LeaveTeamFollow();
            UpdateSellItem();       //自动卖药
        }
    }
    //结束组队跟随状态
    public void LeaveTeamFollow()
    {
        //if (m_nFollowServerID != GlobeVar.INVALID_ID)
        //{
        //    m_nFollowServerID = GlobeVar.INVALID_ID;
        //    m_nFollowPlayerId = GlobeVar.INVALID_GUID;
        //    m_followObjChar = Singleton<ObjManager>.GetInstance().FindObjCharacterInScene(m_nFollowServerID);
        //    //
        //    if (null != MissionDialogAndLeftTabsLogic.Instance())
        //    {
        //        MissionDialogAndLeftTabsLogic.Instance().LeaveTeamFollow();
        //    }

        //    SendNoticMsg(false, "#{4742}");
        //}
    }
    //更新
    public void UpdateSellItem()
    {
        //if (BaseAttr.Level < GlobeVar.MAX_AUTOEQUIT_LIVE)
        //{
        //    return;
        //}
        //if (IsOpenAutoCombat == false)
        //{
        //    return;
        //}
        //GameItemContainer BackPack = GameManager.gameManager.PlayerDataPool.BackPack;
        //List<ulong> selllist = new List<ulong>();


        //for (int index = 0; index < BackPack.ContainerSize; ++index)
        //{
        //    GameItem eItem = BackPack.GetItem(index);
        //    if (eItem != null) //身上有这个药
        //    {
        //        Tab_CommonItem line = TableManager.GetCommonItemByID(eItem.DataID, 0);
        //        if (line != null)
        //        {
        //            //计算品级及拾取规则                           
        //            if (line.ClassID == (int)ItemClass.EQUIP && GetAutoPickUpFlag(line.Quality)
        //                 /* && eItem.EnchanceLevel <= 0 && eItem.EnchanceExp <= 0 && eItem.StarLevel <= 0*/
        //                 && EquipStrengthenLogic.IsAutoEnchanceMaterial(eItem)
        //                && AutoEquipGuid != GlobeVar.INVALID_GUID)
        //            {
        //                selllist.Add(eItem.Guid);
        //            }
        //        }
        //    }
        //}
        ////做自动强化物品            
        //if (selllist.Count > 0)
        //{
        //    //SysShopController.SellItem((int)GameItemContainer.Type.TYPE_BACKPACK, selllist);
        //    CG_EQUIP_ENCHANCE equipEnchance = (CG_EQUIP_ENCHANCE)PacketDistributed.CreatePacket(MessageID.PACKET_CG_EQUIP_ENCHANCE);
        //    //发送消息包
        //    equipEnchance.SetPacktype(1);
        //    equipEnchance.SetEquipguid(AutoEquipGuid);
        //    for (int i = 0; i < selllist.Count; ++i)
        //    {
        //        equipEnchance.AddMaterialguid(selllist[i]);
        //    }
        //    equipEnchance.SendPacket();
        //}
    }
}
