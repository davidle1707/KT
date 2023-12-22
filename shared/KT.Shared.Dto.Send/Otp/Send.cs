using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace KT.Shared.Dto.Send
{
    [Serializable]
    public class SendOtpRequest : KT.Common.Dto.BaseRequest
    {
        #region Transaction

        public ObjectId? TransactionId { get; set; }

        public string TransactionDesc { get; set; }

        /// <summary>
        /// Optional, if empty -> use caller ip-address
        /// </summary>
        public string TransactionIpAddress { get; set; }

        #endregion

        #region Otp

        public string OtpSettingName { get; set; }

        public OtpMethod? OtpMethod { get; set; }

        /// <summary>
        /// Optional, keys: #OTP#, #OTP_EXPIRED#
        /// </summary>
        public string OtpMessageFormat { get; set; }

        #endregion

        #region Email

        public string EmailSettingName { get; set; }

        /// <summary>
        /// If empty -> use default in setting
        /// </summary>
        public EmailAddress EmailFromAddress { get; set; }

        /// <summary>
        /// Required if Method = Email or SmsAndEmail
        /// </summary>
        public EmailAddress EmailToAddress { get; set; }

        #endregion

        #region Sms

        public string SmsSettingName { get; set; }

        /// <summary>
        /// If empty -> use default in setting
        /// </summary>
        public string SmsFromPhoneNumber { get; set; }

        /// <summary>
        /// Required if Method = Sms or SmsAndEmail
        /// </summary>
        public string SmsToPhoneNumber { get; set; }

        #endregion

        public List<string> Categories { get; set; } = new List<string>();
    }

    [Serializable]
    public class SendOtpResponse : KT.Common.Dto.BaseResponse
    {
        public ObjectId TransactionId { get; set; }

        public string Otp { get; set; }

        public int? OtpExpiredMinutes { get; set; }

        public int? OtpVerifyFailedTimes { get; set; }

        public string SentToSmsNumber { get; set; }

        public string SentToEmailAddress { get; set; }
    }
}
