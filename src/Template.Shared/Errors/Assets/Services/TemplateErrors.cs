using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.Errors.Assets
{
    /// <summary>
    /// Error Codes.
    /// </summary>
    public static partial class ErrorCodes
    {
        /// <summary>
        /// Template Errors.
        /// </summary>
        public static class TemplateErrors
        {
            /// <summary>
            ///     The Players Error Codes.
            /// </summary>
            public static class PlayersErrors
            {
                /// <summary>
                ///     The group not found error code.
                /// </summary>
                public const string NotFound = "003.001.001";

                /// <summary>
                ///     The required field error code.
                /// </summary>
                public const string FieldIsRequired = "003.001.002";

                /// <summary>
                ///     The minimum field length requirement error.
                /// </summary>
                public const string MinimumFieldLengthRequirement = "003.001.003";

                /// <summary>
                ///     The maximum field length requirement error.
                /// </summary>
                public const string MaximumFieldLengthRequirement = "003.001.004";
            }
        }
    }
}
