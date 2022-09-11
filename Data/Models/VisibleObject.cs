using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Models
{
    public class VisibleObject : IVisible
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public long ObjectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public VisibleObject Parent;
        /// <summary>
        /// 
        /// </summary>
        private bool _visible;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsVisible()
        {
            return _visible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visible"></param>
        public void setVisible(bool visible)
        {
            _visible = visible;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Release()
        {
            Parent = null;
        }
    }
}
