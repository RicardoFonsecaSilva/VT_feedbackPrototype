﻿#if UNITY_ANDROID
using DeadMosquito.AndroidGoodies.Internal;
using MiniJSON;
using System.Collections.Generic;
using System.Linq;

namespace DeadMosquito.AndroidGoodies {
    /// <summary>
    /// Contact pick result.
    /// </summary>
    public sealed class ContactPickResult
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>The display name.</value>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets the photo URI. To load image as Texture2D use <see cref="AGFileUtils.ImageUriToTexture2D"/> passing this URI
        /// </summary>
        /// <value>The photo URI.</value>
        public string PhotoUri { get; private set; }

        /// <summary>
        /// Gets the phones.
        /// </summary>
        /// <value>The phones.</value>
        public List<string> Phones { get; private set; }

        /// <summary>
        /// Gets the emails.
        /// </summary>
        /// <value>The emails.</value>
        public List<string> Emails { get; private set; }

        ContactPickResult()
        {
            Phones = new List<string>();
            Emails = new List<string>();
        }

        public static ContactPickResult FromJson(string json)
        {
            var contact = new ContactPickResult();
            var dic = Json.Deserialize(json) as Dictionary<string, object>;

            contact.DisplayName = dic.GetStr("displayName");
            contact.PhotoUri = dic.GetStr("photoUri");
            contact.Phones = ((List<object>) dic["phones"]).OfType<string>().ToList();
            contact.Emails = ((List<object>) dic["emails"]).OfType<string>().ToList();

            return contact;
        }

        public override string ToString()
        {
            return string.Format("[ContactPickResult: DisplayName={0}]", DisplayName);
        }
    }
}
#endif
