namespace Data.Structures
{
    public abstract class RxjhObject : Uid
    {
        public RxjhObject Parent;

        public override void Release()
        {
            base.Release();

            Parent = null;
        }
    }
}
