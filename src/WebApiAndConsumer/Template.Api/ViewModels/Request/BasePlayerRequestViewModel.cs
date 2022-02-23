using System;

namespace Template.Api.ViewModels.Request
{
    /// <summary>
    /// Base Player Request View Model.
    /// </summary>
    public class BasePlayerRequestViewModel
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        /// <value>
        /// The name of the middle.
        /// </value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the name of the preferred.
        /// </summary>
        /// <value>
        /// The name of the preferred.
        /// </value>
        public string PreferredName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="BasePlayerRequestViewModel"/> is gender.
        /// </summary>
        /// <value>
        ///   <c>true</c> if gender; otherwise, <c>false</c>.
        /// </value>
        public bool Gender { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>
        /// The birth date.
        /// </value>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the registered date.
        /// </summary>
        /// <value>
        /// The registered date.
        /// </value>
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the height of the player.
        /// </summary>
        /// <value>
        /// The height of the player.
        /// </value>
        public int PlayerHeight { get; set; }

        /// <summary>
        /// Gets or sets the player weight.
        /// </summary>
        /// <value>
        /// The player weight.
        /// </value>
        public int PlayerWeight { get; set; }

        /// <summary>
        /// Gets or sets the color of the hair.
        /// </summary>
        /// <value>
        /// The color of the hair.
        /// </value>
        public string HairColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the eye.
        /// </summary>
        /// <value>
        /// The color of the eye.
        /// </value>
        public string EyeColor { get; set; }

        /// <summary>
        /// Gets or sets the player nationality.
        /// </summary>
        /// <value>
        /// The player nationality.
        /// </value>
        public string PlayerNationality { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [player vip].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [player vip]; otherwise, <c>false</c>.
        /// </value>
        public bool PlayerVip { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [player active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [player active]; otherwise, <c>false</c>.
        /// </value>
        public bool PlayerActive { get; set; }
    }
}