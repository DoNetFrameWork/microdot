using System;

namespace Gigya.Microdot.ServiceDiscovery.Config
{
    /// <summary>
    /// Caching Configuration for specific service. Used by CachingProxy.
    /// </summary>
    [Serializable]
    public class CachingPolicyConfig 
    {
        /// <summary>
        /// Specifies whether caching is enabled for this service
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// The amount of time after which a request of an item triggers a background refresh from the data source.
        /// </summary>
        public TimeSpan RefreshTime { get; set; } = TimeSpan.FromMinutes(1);

        /// <summary>
        /// Specifies the max period time for data to be kept in the cache before it is removed. Successful refreshes
        /// extend the time.
        /// </summary>
        public TimeSpan ExpirationTime { get; set; } = TimeSpan.FromHours(6);

        /// <summary>
        /// The amount of time to wait before attempting another refresh after the previous refresh failed.
        /// </summary>
        public TimeSpan FailedRefreshDelay { get; set; } = TimeSpan.FromSeconds(1);


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            CachingPolicyConfig other = obj as CachingPolicyConfig;

            if (other == null)
                return false;

            return Enabled == other.Enabled 
                   && RefreshTime == other.RefreshTime
                   && ExpirationTime == other.ExpirationTime;
        }


        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Enabled.GetHashCode();
                hashCode = (hashCode * 397) ^ RefreshTime.GetHashCode();
                hashCode = (hashCode * 397) ^ ExpirationTime.GetHashCode();
                return hashCode;
            }
        }
    }
}