#region License
// The PostgreSQL License
//
// Copyright (C) 2017 The Npgsql Development Team
//
// Permission to use, copy, modify, and distribute this software and its
// documentation for any purpose, without fee, and without a written
// agreement is hereby granted, provided that the above copyright notice
// and this paragraph and the following two paragraphs appear in all copies.
//
// IN NO EVENT SHALL THE NPGSQL DEVELOPMENT TEAM BE LIABLE TO ANY PARTY
// FOR DIRECT, INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES,
// INCLUDING LOST PROFITS, ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS
// DOCUMENTATION, EVEN IF THE NPGSQL DEVELOPMENT TEAM HAS BEEN ADVISED OF
// THE POSSIBILITY OF SUCH DAMAGE.
//
// THE NPGSQL DEVELOPMENT TEAM SPECIFICALLY DISCLAIMS ANY WARRANTIES,
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY
// AND FITNESS FOR A PARTICULAR PURPOSE. THE SOFTWARE PROVIDED HEREUNDER IS
// ON AN "AS IS" BASIS, AND THE NPGSQL DEVELOPMENT TEAM HAS NO OBLIGATIONS
// TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR MODIFICATIONS.
#endregion

using System;

namespace EntityWorker.Core.Postgres
{
    /// <summary>
    /// EventArgs class to send Notification parameters.
    /// </summary>
    public sealed class NpgsqlNotificationEventArgs : EventArgs
    {
        /// <summary>
        /// Process ID of the PostgreSQL backend that sent this notification.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int PID { get; }

        /// <summary>
        /// Condition that triggered that notification.
        /// </summary>
        public string Condition { get; }

        /// <summary>
        /// Additional information.
        /// </summary>
        public string AdditionalInformation { get; }

        internal NpgsqlNotificationEventArgs(NpgsqlReadBuffer buf)
        {
            PID = buf.ReadInt32();
            Condition = buf.ReadNullTerminatedString();
            AdditionalInformation = buf.ReadNullTerminatedString();
        }
    }
}
