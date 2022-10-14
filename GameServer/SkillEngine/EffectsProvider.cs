using Data.Structures.World;
using GameServer.SkillEngine.Effects;

namespace GameServer.SkillEngine
{
    class EffectsProvider
    {
        protected static void Add(Abnormal abnormal, EfDefault effect, int effectIndex)
        {
            abnormal.Effects.Add(effect);

            effect.Creature = abnormal.Creature;
            effect.Abnormality = abnormal.Abnormality;
            effect.Effect = abnormal.Abnormality.Effects[effectIndex];

            effect.Init();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="abnormal"></param>
        public static void ProvideEffects(Abnormal abnormal)
        {
            switch (abnormal.Abnormality.Id)
            {
                #region Blademan Ability
                // http://fate.netgame.com/gameinfo/character/bladesman
                case 10:
                    //Add(abnormal, new EfImprovedGrip(), 0);
                    break;
                case 11:
                    //Add(abnormal, new EfPreciseness());
                    break;
                case 12:
                    //Add(abnormal, new EfFlowingBlade());
                    break;
                case 13:
                    //Add(abnormal, new EfLethalBlow());
                    break;
                case 14:
                    //Add(abnormal, new EfBurningWrath());
                    break;
                case 15:
                    //Add(abnormal, new EfReflectionWall());
                    break;
                case 16:
                    //Add(abnormal, new EfArmorCrush());
                    break;
                case 17:
                    //Add(abnormal, new EfPointPiercing());
                    break;
                case 18:
                    //Add(abnormal, new EfHiddenAftermath());
                    break;
                case 19:
                    //Add(abnormal, new EfIronSkin());
                    break;
                #endregion

                #region Swordman Ability
                // http://fate.netgame.com/gameinfo/character/swordman
                case 20:
                    //Add(abnormal, new EfSharpenedSwords());
                    break;
                case 21:
                    //Add(abnormal, new EfSwordDrift());
                    break;
                case 22:
                    //Add(abnormal, new EfFlowingBlade());
                    break;
                case 23:
                    //Add(abnormal, new EfLethalBlow());
                    break;
                case 24:
                    //Add(abnormal, new EfBurningWrath());
                    break;
                case 25:
                    //Add(abnormal, new EfChiArmor());
                    break;
                case 26:
                    //Add(abnormal, new EfLifeDrainer());
                    break;
                case 27:
                    //Add(abnormal, new EfInstantReflex());
                    break;
                case 28:
                    //Add(abnormal, new EfAuroralSword());
                    break;
                case 29:
                    //Add(abnormal, new EfTigersRage());
                    break;
                #endregion

                #region Spearman Ability
                // http://fate.netgame.com/gameinfo/character/spearman
                case 33:
                    //Add(abnormal, new EfLethalBlow());
                    break;
                #endregion

                #region Bowman Ability
                // http://fate.netgame.com/gameinfo/character/bowman
                case 43:
                    //Add(abnormal, new EfLethalBlow());
                    break;
                #endregion

                #region Healer Ability
                // http://fate.netgame.com/gameinfo/character/healer
                #endregion

                #region Ninja Ability
                // http://fate.netgame.com/gameinfo/character/ninja
                #endregion

                #region Busker Ability
                // http://fate.netgame.com/gameinfo/character/busker
                #endregion

                #region Hanbia Ability

                #endregion
            }
        }
    }
}
