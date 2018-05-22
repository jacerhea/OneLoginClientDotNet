using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OneLogin.Responses
{
    public class ActivateAnAuthenticationFactorResponse : BaseResponse<ActivatedFactor>
    {
    }

    [DataContract]
    public class ActivatedFactor
    {

        /// <summary>
        /// Authentication factor display name assigned by users when they register the device.
        /// </summary>
        [DataMember(Name = "user_display_name")]
        public string UserDisplayName { get; set; }

        /// <summary>
        /// true = enabled (used successfully for authentication at least once). false = pending (registered but never used).
        /// </summary>
        [DataMember(Name = "user_display_name")]

        public bool active { get; set; }

        /// <summary>
        /// A short lived token that is required to Verify the Factor. This token expires in 120 seconds.
        /// </summary>
        [DataMember(Name = "user_display_name")]
        public string state_token { get; set; }

        /// <summary>
        /// "Official" authentication factor name, as it appears to administrators in OneLogin.
        /// </summary>
        [DataMember(Name = "user_display_name")]
        public string auth_factor_name { get; set; }

        /// <summary>
        /// Authentication factor display name as it appears to users upon initial registration, as defined by admins at Settings > Authentication Factors.
        /// </summary>
        [DataMember(Name = "user_display_name")]
        public string type_display_name { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        [DataMember(Name = "user_display_name")]
        public int id { get; set; }

        /// <summary>
        /// MFA device identifier.
        /// </summary>
        [DataMember(Name = "user_display_name")]
        public int device_id { get; set; }
    }
}
