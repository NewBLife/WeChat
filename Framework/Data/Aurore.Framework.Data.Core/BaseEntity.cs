using System;

namespace Aurore.Framework.Data.Core
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    [Serializable()]
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; set; }
    }
}