using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace GameLibCommon.GameSrc.State
{
    public struct GameScreenExecutionId
    {
        // data
        private readonly Guid mGuid;
        private readonly Int32 mCachedHashCode;


        #region ++ Public Interface ++

        /// <summary>
        /// Gets the Guid that is being wrapped.
        /// </summary>
        public Guid Guid => mGuid;


        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        ///
        /// <param name="guid">
        /// The Guid that should be wrapped.</param>
        public GameScreenExecutionId(Guid guid)
        {
            mGuid = guid;
            mCachedHashCode = mGuid.GetHashCode();
        }


        /// <summary>
        /// Returns a string that represents the current instance. This method returns a string in upper case
        /// to make returned strings equatable.
        /// </summary>
        ///
        /// <returns>
        /// A string that represents the current instance.</returns>
        public override String ToString()
        {
            return mGuid.ToString("B", CultureInfo.InvariantCulture).ToUpperInvariant();
        }

        #endregion

        #region ++ Public Interface (Equality) ++

        /// <summary>
        /// Returns the hash code for the current instance.
        /// </summary>
        ///
        /// <returns>
        /// A 32-bit signed integer hash code.</returns>
        public override Int32 GetHashCode()
        {
            return mCachedHashCode;
        }


        /// <summary>
        /// Determines whether the specified instance is equal to the current instance.
        /// </summary>
        ///
        /// <param name="other">
        /// The instance to compare with the current instance.</param>
        ///
        /// <returns>
        /// True, if the specified instance is equal to the current instance; otherwise, False.</returns>
        public override Boolean Equals(Object other)
        {
            return other is GameScreenExecutionId && Equals((GameScreenExecutionId)other);
        }

        /// <summary>
        /// Determines whether the specified instance is equal to the current instance.
        /// </summary>
        ///
        /// <param name="other">
        /// The instance to compare with the current instance.</param>
        ///
        /// <returns>
        /// True, if the specified instance is equal to the current instance; otherwise, False.</returns>
        public Boolean Equals(GameScreenExecutionId other)
        {
            // fast check: different hash codes?
            if (mCachedHashCode != other.mCachedHashCode)
                return false;

            // determine equality from fields
            return mGuid.Equals(other.mGuid);
        }


        /// <summary>
        /// Determines whether the specified instances are equal.
        /// </summary>
        ///
        /// <param name="a">
        /// The first instance to compare.</param>
        /// <param name="b">
        /// The second instance to compare.</param>
        /// <returns>
        /// True, if the specified instances are equal; otherwise, False.</returns>
        public static Boolean operator ==(GameScreenExecutionId a, GameScreenExecutionId b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Determines whether the specified instances are unequal.
        /// </summary>
        ///
        /// <param name="a">
        /// The first instance to compare.</param>
        /// <param name="b">
        /// The second instance to compare.</param>
        /// <returns>
        /// True, if the specified instances are unequal; otherwise, False.</returns>
        public static Boolean operator !=(GameScreenExecutionId a, GameScreenExecutionId b)
        {
            return !a.Equals(b);
        }

        #endregion

        #region ~~ Internal Interface ~~

        /// <summary>
        /// This member serves the infrastructure and is not intended to be used directly.
        /// </summary>
        internal String DebuggerDisplay => this.ToString();

        #endregion
    }
}
