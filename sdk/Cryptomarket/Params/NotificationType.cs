using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static Cryptomarket.Params.AccountType;
using static Cryptomarket.Params.ContingencyType;
using static Cryptomarket.Params.Depth;
using static Cryptomarket.Params.IdentifyBy;
using static Cryptomarket.Params.NotificationType;

namespace Cryptomarket.Params
{
    /// <summary>
    /// Notification type of a websocket subscription
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// Snapshot notification type
        /// </summary>
        // /**
        //  * Snapshot notification type
        //  */
        // SNAPSHOT("snapshot")
        SNAPSHOT,
        /// <summary>
        /// Update notification type
        /// </summary>
        // /**
        //  * Update notification type
        //  */
        // UPDATE("update")
        UPDATE,
        /// <summary>
        /// Data notification type
        /// </summary>
        // /**
        //  * Data notification type
        //  */
        // DATA("data")
        DATA,
        /// <summary>
        /// Type used to signal parse erroors
        /// </summary>
        // /**
        //  * Type used to signal parse erroors
        //  */
        // PARSE_ERROR("error")
        PARSE_ERROR 

        // --------------------
        // TODO enum body members
        // private final String label;
        // private NotificationType(String label) {
        //     this.label = label;
        // }
        // @Override
        // public String toString() {
        //     return label;
        // }
        // /**
        //  * True if it is snapshot
        //  */
        // public boolean isSnapshot() {
        //     return this == NotificationType.SNAPSHOT;
        // }
        // /**
        //  * True if it is update
        //  */
        // public boolean isUpdate() {
        //     return this == NotificationType.UPDATE;
        // }
        // /**
        //  * True if it is data
        //  */
        // public boolean isData() {
        //     return this == NotificationType.DATA;
        // }
        // /**
        //  * True if it is a type of error
        //  */
        // public boolean isError() {
        //     return this == NotificationType.PARSE_ERROR;
        // }
        // --------------------
    }
}