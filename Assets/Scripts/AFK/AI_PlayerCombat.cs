using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AI_PlayerCombat : AI_BaseCombat
{
    Obj_MainPlayer_AFK m_player = null;
    private int m_nLastUseSkill = 0;

    //����
    public override void OnActive()
    {
        base.OnActive();
        UpdateAI();
    }

    //ˢ��AI
    public override void UpdateAI()
    {
        base.UpdateAI();
        if (m_player == null || m_player.Controller == null)
        {
            return;
        }
        //if (m_player.IsDie())
        //{
        //    return;
        //}
        if (m_player.Controller.CombatFlag == false)
        {
            return;
        }
        if (m_player.AutoComabat == false)
        {
            return;
        }
        //�Ṧ״̬�� ���һ�
        //if (m_player.QingGongState)
        //{
        //    return;
        //}
        //if (m_player.AcceleratedMotion != null && m_player.AcceleratedMotion.Going == true)
        //{
        //    return;
        //}
        //���鲥���в��һ�
        //if (m_player.IsInModelStory)
        //{
        //    return;
        //}
        //if (m_player.SkillCore.IsUsingSkill)
        //{
        //    if (m_player.SkillCore.UsingSkillBaseInfo != null)
        //    {
        //        //����ʹ��ף���� �����µ�ǰĿ���Ƿ񻹴��� ������������ѡȡĿ��
        //        if (m_player.SkillCore.UsingSkillBaseInfo.Id == (int)SKILLBASEID.ZLZ)
        //        {
        //            if (m_player.SelectTarget == null || m_player.SelectTarget.IsDie())
        //            {
        //                Obj_Character _NewAttackCharacter = GetCanAttackTar();
        //                if (_NewAttackCharacter != null)
        //                {
        //                    //�����µ�ѡ��Ŀ��
        //                    m_player.OnSelectTarget(_NewAttackCharacter.gameObject, false);
        //                    m_player.MoveTo(_NewAttackCharacter.transform.position, _NewAttackCharacter.gameObject, 1.0f);
        //                }
        //            }
        //        }

        //        if ((m_player.SkillCore.UsingSkillBaseInfo.SkillClass & (int)SKILLCLASS.AUTOREPEAT) == 0)
        //        {
        //            return;
        //        }
        //        return;
        //    }
        //}
        //else
        //{
        //    if (m_fLastUseEndTime <= 0.1f)
        //    {
        //        m_fLastUseEndTime = Time.time;
        //    }
        //}
        //            //��������ʱ��
        //            if (Time.time -m_fLastUseEndTime <0.1f)
        //            {
        //                return;
        //            }
        //���Ṧ���˳����� ���Ṧ���ƶ�
        //if (m_player.AutoMovetoQGPointId != -1)
        //{
        //    //��Ϲһ�״̬
        //    m_player.BreakAutoCombatState();
        //    if (GameManager.gameManager.RunningScene == (int)GameDefine_Globe.SCENE_DEFINE.SCENE_HUSONGMEIREN)
        //    {
        //        //�������Ṧ���ƶ�
        //        m_player.AutoFightFlyInYanZiWu();
        //    }
        //    m_player.AutoMovetoQGPointId = -1;
        //    return;
        //}
        //m_fLastUseEndTime = 0.0f;
        int skillId = SeleSkill();
        if (skillId == -1)
        {
            return;
        }
        //Tab_SkillEx skillExInfo = TableManager.GetSkillExByID(skillId, 0);
        //if (skillExInfo == null)
        //{
        //    return;
        //}
        //Tab_SkillBase skillBaseInfo = TableManager.GetSkillBaseByID(skillExInfo.BaseId, 0);
        //if (skillBaseInfo == null)
        //{
        //    return;
        //}
        //Obj_Character CanAttackCharacter = null;
        //if (m_player.SelectTarget == null)
        //{
        //    CanAttackCharacter = GetCanAttackTar();
        //}
        //else
        //{
        //    if (Reputation.IsEnemy(m_player.SelectTarget) || Reputation.IsNeutral(m_player.SelectTarget))//�����Npc�����һ�Ҳ�ż��ܵ�����
        //        CanAttackCharacter = m_player.SelectTarget;
        //}
        //�Ƿ��й���Ŀ��
        //if (CanAttackCharacter == null)
        //{
        //    return;
        //}
        //����Ϊѡ��Ŀ��
        //m_player.OnSelectTarget(CanAttackCharacter.gameObject, false);
        //���벻�� ���ܹ�ȥ
        //float skillRadius = skillExInfo.Radius;
        //float dis = Vector3.Distance(m_player.Position, CanAttackCharacter.Position);

        //Tab_RoleBaseAttr role = TableManager.GetRoleBaseAttrByID(
        //    CanAttackCharacter.BaseAttr.RoleBaseID, 0);
        //float roleradio = 0.0f;
        //if (role != null)
        //    roleradio = role.SelectRadius;

        //float diffDistance = dis - skillRadius - roleradio;
        //m_player.CurUseSkillId = skillId;
        //m_nLastUseSkill = skillId;
        //��Ҫ��Ŀ���ƶ� ����Ŀ���ƶ�
        //if (diffDistance > 0 && skillBaseInfo.IsMoveToTarInAutoCombat == 1)
        //{
        //    //move
        //    if (m_player.IsMoving == false && m_player.IsCanOperate_Move())
        //    {
        //        // m_player.MoveTo(CanAttackCharacter.Position, CanAttackCharacter.gameObject, skillRadius - 1.0f);


        //        //					if(m_player.Profession==(int)CharacterDefine.PROFESSION.XIAOYAO||skillExInfo.CheckTime<=0)
        //        //					{
        //        //						if(diffDistance>=0)
        //        //						{
        //        //							m_player.MoveTo(CanAttackCharacter.Position, CanAttackCharacter.gameObject,skillRadius +roleradio- 0.5f);
        //        //							
        //        //							return ;
        //        //						}
        //        //					}
        //        //					else
        //        {
        //            //						if(diffDistance>=3)
        //            //						{
        //            //							m_player.MoveTo(CanAttackCharacter.Position, CanAttackCharacter.gameObject,  skillRadius +roleradio- 0.5f+3.0f);
        //            //							
        //            //							return ;
        //            //						}
        //            if (diffDistance > 0)
        //            {

        //                m_player.FaceTo(CanAttackCharacter.Position);
        //                m_player.MoveTo(CanAttackCharacter.Position, CanAttackCharacter.gameObject, skillRadius + roleradio - 0.5f);
        //                //AttackFly(10,5,1.0f);
        //                //m_player.AttackPGCF(CanAttackCharacter);
        //                //MoveTo(Target.Position, Target.gameObject, skillRadius +roleradio- 0.5f);
        //            }
        //            return;

        //        }

        //        return;


        //    }
        //m_player.UseSkillOpt(skillId, null);
        return;

    }

      
    //��ù�������
    //public game GetCanAttackTar()
    //{
    //    //8�뷶Χ�� �пɹ�����Ŀ�� 
    //    Dictionary<string, Obj> targets = Singleton<ObjManager>.GetInstance().ObjPools;

    //    float fMinDis = 8.0f;
    //    if (GameManager.gameManager.ActiveScene.IsCopyScene())
    //    {
    //        fMinDis = 100.0f;
    //    }
    //    Obj_Character selCharacter = null;
    //    foreach (Obj targetObj in targets.Values)
    //    {
    //        if (targetObj != null)
    //        {
    //            Obj_Character targeObjCharacter = targetObj as Obj_Character;
    //            if (targeObjCharacter == null)
    //            {
    //                continue;
    //            }
    //            if (targeObjCharacter.IsDie())
    //            {
    //                continue;
    //            }
    //            if (Reputation.IsEnemy(targeObjCharacter) == false &&
    //                Reputation.IsNeutral(targeObjCharacter) == false)
    //            {
    //                continue;
    //            }
    //            float distance = Vector3.Distance(m_player.Position, targeObjCharacter.Position);
    //            //ѡ�������һ��Ŀ��
    //            if (distance < fMinDis)
    //            {
    //                fMinDis = distance;
    //                selCharacter = targeObjCharacter;
    //            }
    //        }
    //    }
    //            if (selCharacter == null)
    //            {
    //                if (GameManager.gameManager.RunningScene == (int)GameDefine_Globe.SCENE_DEFINE.SCENE_ZHENLONGQIJU)
    //                {
    //                    Vector3 pos = new Vector3(18, m_player.gameObject.transform.position.y, 16);
    //                    m_player.MoveTo(pos, null, 0.0f);
    //
    //                }
    //                if (GameManager.gameManager.RunningScene == (int)GameDefine_Globe.SCENE_DEFINE.SCENE_YANGWANGGUMU)
    //                {
    //                    Vector3 pos = new Vector3(20, m_player.gameObject.transform.position.y, 21);
    //                    m_player.MoveTo(pos, null, 0.0f);
    //                }
    //
    //                if (GameManager.gameManager.RunningScene == (int)GameDefine_Globe.SCENE_DEFINE.SCENE_YANZIWU)
    //                {
    //                    Singleton<ObjManager>.Instance.MainPlayer.AutoFightInYanziwu();
    //                }
    //                
    //            }
    //return selCharacter;
    //    return null;
    //}

    //�ҵ���ʹ�õļ���
    public int SeleSkill()
    {
    //for (int i = 0; i < (int)SKILLDEFINE.MAX_SKILLNUM; i++)
    //{
    //    m_canSeleSkill[i].CleanUp();
    //}
    ////Ĭ��ʹ���չ�
    //int UseSkillId = m_player.OwnSkillInfo[0].SkillId;
    //int nLastSkillIndex = -1;
    //for (int i = 0; i < m_player.OwnSkillInfo.Length; i++)
    //{
    //    if (m_player.OwnSkillInfo[i].SkillId == m_nLastUseSkill)
    //    {
    //        nLastSkillIndex = i;
    //        break;
    //    }
    //}
    //if (nLastSkillIndex != -1)
    //{
    //    int validSelIndex = 0;
    //    //ɸѡ�������õļ���
    //    for (int skillIndex = nLastSkillIndex; skillIndex < m_player.OwnSkillInfo.Length; skillIndex++)
    //    {
    //        int skillId = m_player.OwnSkillInfo[skillIndex].SkillId;
    //        if (skillId != m_nLastUseSkill && skillId != -1)
    //        {
    //            //XP ���� ����
    //            Tab_SkillEx _skillEx = TableManager.GetSkillExByID(skillId, 0);
    //            if (_skillEx != null)
    //            {
    //                Tab_SkillBase _skillBase = TableManager.GetSkillBaseByID(_skillEx.BaseId, 0);
    //                if (_skillBase != null)
    //                {
    //                    if ((_skillBase.SkillClass & (int)SKILLCLASS.XP) != 0 &&
    //                        m_player.BaseAttr.XP < m_player.BaseAttr.MaxXP)
    //                    {
    //                        //XP�������� �޷��ͷ�
    //                        continue;
    //                    }
    //                    if ((_skillBase.SkillClass & (int)SKILLCLASS.XP) != 0 &&
    //                       (m_isUseXp == false))
    //                    {
    //                        //XP�������� �޷��ͷ�
    //                        continue;
    //                    }
    //                    if (m_player.OwnSkillInfo[skillIndex].CDTime <= 0 &&
    //                        m_player.OwnSkillInfo[skillIndex].PriorityAutoCombat != -1 && m_player.OwnAutoSkillInfo[skillIndex].CanAutoCombat) //-1��ʾ �һ��в�����ʹ��
    //                    {
    //                        m_canSeleSkill[validSelIndex++] = m_player.OwnSkillInfo[skillIndex];
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    //�ӿ�ѡ�������������ȼ���ߵ��Ǹ�
    //    int nMaxPriority = -1;
    //    for (int nIndex = 0; nIndex < m_canSeleSkill.Length; nIndex++)
    //    {
    //        if (m_canSeleSkill[nIndex].IsValid())
    //        {
    //            if (m_canSeleSkill[nIndex].PriorityAutoCombat > nMaxPriority)
    //            {
    //                nMaxPriority = m_canSeleSkill[nIndex].PriorityAutoCombat;
    //                UseSkillId = m_canSeleSkill[nIndex].SkillId;
    //            }
    //        }
    //    }
    //}
    //return UseSkillId;
        return 0;
    }

}
