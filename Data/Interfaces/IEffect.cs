namespace Data.Interfaces
{
    public interface IEffect
    {
        void Action();
        void SetActive(bool active);
        //void SetImpact(CreatureEffectsImpact impact);
        void Release();
    }
}
