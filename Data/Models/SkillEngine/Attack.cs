using Data.Enums;
using Data.Models.Player;
using System;
using System.Collections.Generic;
using Utility;

namespace Data.Models.SkillEngine
{
    public class Attack
    {
        public UseSkillArgs Args;
        public int Stage = 0;
        public int AttackAction;
        public List<int> Results = new List<int>(5);
        protected AttackStatus Status = AttackStatus.Init;
        public long StartUtc = Funcs.GetCurrentMilliseconds();
        public Creature.Creature Creature;

        protected Action OnStageEnd;
        protected Action OnFinish;

        public int Count
        {
            get
            {
                int i = 0;
                foreach(int a in Results)
                    if(a != 0)
                        i++;

                return i;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="args"></param>
        /// <param name="onStageEnd"></param>
        /// <param name="onFinish"></param>
        public Attack(Creature.Creature creature, UseSkillArgs args, Action onStageEnd, Action onFinish)
        {
            if (creature.Attack != null)
                creature.Attack.Release();

            Args = args;

            Creature = creature;
            OnStageEnd = onStageEnd;
            OnFinish = onFinish;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AttackStatus GetStatus()
        {
            return Status;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Inited()
        {
            Status = AttackStatus.Inited;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Wait()
        {
            Status = AttackStatus.Wait;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Process()
        {
            Status = AttackStatus.Process;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Charge()
        {
            Status = AttackStatus.Charge;
        }

        /// <summary>
        /// 
        /// </summary>
        public void NextStage()
        {
            if (OnStageEnd != null)
            {
                Stage++;
                OnStageEnd();

                //if (!Args.IsDelaySkill)
                //Uid = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Finish()
        {
            if (Status == AttackStatus.Finished)
                return;

            Status = AttackStatus.Finished;

            if (OnFinish != null)
                OnFinish.Invoke();
        }

        public void Release()
        {
            if (Creature == null)
                return;

            if (Args != null)
                Args.Release();

            Args = null;
            Creature = null;
            OnStageEnd = null;
            OnFinish = null;
        }
    }
}
