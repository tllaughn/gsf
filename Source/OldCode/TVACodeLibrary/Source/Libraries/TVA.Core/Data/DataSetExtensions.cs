﻿//*******************************************************************************************************
//  DataSetExtensions.cs - Gbtc
//
//  Tennessee Valley Authority, 2009
//  No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.
//
//  This software is made freely available under the TVA Open Source Agreement (see below).
//  Code in this file licensed to TVA under one or more contributor license agreements listed below.
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  02/07/2013 - J. Ritchie Carroll
//       Generated original version of source code.
//
//*******************************************************************************************************

#region [ TVA Open Source Agreement ]
/*

 THIS OPEN SOURCE AGREEMENT ("AGREEMENT") DEFINES THE RIGHTS OF USE,REPRODUCTION, DISTRIBUTION,
 MODIFICATION AND REDISTRIBUTION OF CERTAIN COMPUTER SOFTWARE ORIGINALLY RELEASED BY THE
 TENNESSEE VALLEY AUTHORITY, A CORPORATE AGENCY AND INSTRUMENTALITY OF THE UNITED STATES GOVERNMENT
 ("GOVERNMENT AGENCY"). GOVERNMENT AGENCY IS AN INTENDED THIRD-PARTY BENEFICIARY OF ALL SUBSEQUENT
 DISTRIBUTIONS OR REDISTRIBUTIONS OF THE SUBJECT SOFTWARE. ANYONE WHO USES, REPRODUCES, DISTRIBUTES,
 MODIFIES OR REDISTRIBUTES THE SUBJECT SOFTWARE, AS DEFINED HEREIN, OR ANY PART THEREOF, IS, BY THAT
 ACTION, ACCEPTING IN FULL THE RESPONSIBILITIES AND OBLIGATIONS CONTAINED IN THIS AGREEMENT.

 Original Software Designation: openPDC
 Original Software Title: The TVA Open Source Phasor Data Concentrator
 User Registration Requested. Please Visit https://naspi.tva.com/Registration/
 Point of Contact for Original Software: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>

 1. DEFINITIONS

 A. "Contributor" means Government Agency, as the developer of the Original Software, and any entity
 that makes a Modification.

 B. "Covered Patents" mean patent claims licensable by a Contributor that are necessarily infringed by
 the use or sale of its Modification alone or when combined with the Subject Software.

 C. "Display" means the showing of a copy of the Subject Software, either directly or by means of an
 image, or any other device.

 D. "Distribution" means conveyance or transfer of the Subject Software, regardless of means, to
 another.

 E. "Larger Work" means computer software that combines Subject Software, or portions thereof, with
 software separate from the Subject Software that is not governed by the terms of this Agreement.

 F. "Modification" means any alteration of, including addition to or deletion from, the substance or
 structure of either the Original Software or Subject Software, and includes derivative works, as that
 term is defined in the Copyright Statute, 17 USC § 101. However, the act of including Subject Software
 as part of a Larger Work does not in and of itself constitute a Modification.

 G. "Original Software" means the computer software first released under this Agreement by Government
 Agency entitled openPDC, including source code, object code and accompanying documentation, if any.

 H. "Recipient" means anyone who acquires the Subject Software under this Agreement, including all
 Contributors.

 I. "Redistribution" means Distribution of the Subject Software after a Modification has been made.

 J. "Reproduction" means the making of a counterpart, image or copy of the Subject Software.

 K. "Sale" means the exchange of the Subject Software for money or equivalent value.

 L. "Subject Software" means the Original Software, Modifications, or any respective parts thereof.

 M. "Use" means the application or employment of the Subject Software for any purpose.

 2. GRANT OF RIGHTS

 A. Under Non-Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor,
 with respect to its own contribution to the Subject Software, hereby grants to each Recipient a
 non-exclusive, world-wide, royalty-free license to engage in the following activities pertaining to
 the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Modification

 5. Redistribution

 6. Display

 B. Under Patent Rights: Subject to the terms and conditions of this Agreement, each Contributor, with
 respect to its own contribution to the Subject Software, hereby grants to each Recipient under Covered
 Patents a non-exclusive, world-wide, royalty-free license to engage in the following activities
 pertaining to the Subject Software:

 1. Use

 2. Distribution

 3. Reproduction

 4. Sale

 5. Offer for Sale

 C. The rights granted under Paragraph B. also apply to the combination of a Contributor's Modification
 and the Subject Software if, at the time the Modification is added by the Contributor, the addition of
 such Modification causes the combination to be covered by the Covered Patents. It does not apply to
 any other combinations that include a Modification. 

 D. The rights granted in Paragraphs A. and B. allow the Recipient to sublicense those same rights.
 Such sublicense must be under the same terms and conditions of this Agreement.

 3. OBLIGATIONS OF RECIPIENT

 A. Distribution or Redistribution of the Subject Software must be made under this Agreement except for
 additions covered under paragraph 3H. 

 1. Whenever a Recipient distributes or redistributes the Subject Software, a copy of this Agreement
 must be included with each copy of the Subject Software; and

 2. If Recipient distributes or redistributes the Subject Software in any form other than source code,
 Recipient must also make the source code freely available, and must provide with each copy of the
 Subject Software information on how to obtain the source code in a reasonable manner on or through a
 medium customarily used for software exchange.

 B. Each Recipient must ensure that the following copyright notice appears prominently in the Subject
 Software:

          No copyright is claimed pursuant to 17 USC § 105.  All Other Rights Reserved.

 C. Each Contributor must characterize its alteration of the Subject Software as a Modification and
 must identify itself as the originator of its Modification in a manner that reasonably allows
 subsequent Recipients to identify the originator of the Modification. In fulfillment of these
 requirements, Contributor must include a file (e.g., a change log file) that describes the alterations
 made and the date of the alterations, identifies Contributor as originator of the alterations, and
 consents to characterization of the alterations as a Modification, for example, by including a
 statement that the Modification is derived, directly or indirectly, from Original Software provided by
 Government Agency. Once consent is granted, it may not thereafter be revoked.

 D. A Contributor may add its own copyright notice to the Subject Software. Once a copyright notice has
 been added to the Subject Software, a Recipient may not remove it without the express permission of
 the Contributor who added the notice.

 E. A Recipient may not make any representation in the Subject Software or in any promotional,
 advertising or other material that may be construed as an endorsement by Government Agency or by any
 prior Recipient of any product or service provided by Recipient, or that may seek to obtain commercial
 advantage by the fact of Government Agency's or a prior Recipient's participation in this Agreement.

 F. In an effort to track usage and maintain accurate records of the Subject Software, each Recipient,
 upon receipt of the Subject Software, is requested to register with Government Agency by visiting the
 following website: https://naspi.tva.com/Registration/. Recipient's name and personal information
 shall be used for statistical purposes only. Once a Recipient makes a Modification available, it is
 requested that the Recipient inform Government Agency at the web site provided above how to access the
 Modification.

 G. Each Contributor represents that that its Modification does not violate any existing agreements,
 regulations, statutes or rules, and further that Contributor has sufficient rights to grant the rights
 conveyed by this Agreement.

 H. A Recipient may choose to offer, and to charge a fee for, warranty, support, indemnity and/or
 liability obligations to one or more other Recipients of the Subject Software. A Recipient may do so,
 however, only on its own behalf and not on behalf of Government Agency or any other Recipient. Such a
 Recipient must make it absolutely clear that any such warranty, support, indemnity and/or liability
 obligation is offered by that Recipient alone. Further, such Recipient agrees to indemnify Government
 Agency and every other Recipient for any liability incurred by them as a result of warranty, support,
 indemnity and/or liability offered by such Recipient.

 I. A Recipient may create a Larger Work by combining Subject Software with separate software not
 governed by the terms of this agreement and distribute the Larger Work as a single product. In such
 case, the Recipient must make sure Subject Software, or portions thereof, included in the Larger Work
 is subject to this Agreement.

 J. Notwithstanding any provisions contained herein, Recipient is hereby put on notice that export of
 any goods or technical data from the United States may require some form of export license from the
 U.S. Government. Failure to obtain necessary export licenses may result in criminal liability under
 U.S. laws. Government Agency neither represents that a license shall not be required nor that, if
 required, it shall be issued. Nothing granted herein provides any such export license.

 4. DISCLAIMER OF WARRANTIES AND LIABILITIES; WAIVER AND INDEMNIFICATION

 A. No Warranty: THE SUBJECT SOFTWARE IS PROVIDED "AS IS" WITHOUT ANY WARRANTY OF ANY KIND, EITHER
 EXPRESSED, IMPLIED, OR STATUTORY, INCLUDING, BUT NOT LIMITED TO, ANY WARRANTY THAT THE SUBJECT
 SOFTWARE WILL CONFORM TO SPECIFICATIONS, ANY IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 PARTICULAR PURPOSE, OR FREEDOM FROM INFRINGEMENT, ANY WARRANTY THAT THE SUBJECT SOFTWARE WILL BE ERROR
 FREE, OR ANY WARRANTY THAT DOCUMENTATION, IF PROVIDED, WILL CONFORM TO THE SUBJECT SOFTWARE. THIS
 AGREEMENT DOES NOT, IN ANY MANNER, CONSTITUTE AN ENDORSEMENT BY GOVERNMENT AGENCY OR ANY PRIOR
 RECIPIENT OF ANY RESULTS, RESULTING DESIGNS, HARDWARE, SOFTWARE PRODUCTS OR ANY OTHER APPLICATIONS
 RESULTING FROM USE OF THE SUBJECT SOFTWARE. FURTHER, GOVERNMENT AGENCY DISCLAIMS ALL WARRANTIES AND
 LIABILITIES REGARDING THIRD-PARTY SOFTWARE, IF PRESENT IN THE ORIGINAL SOFTWARE, AND DISTRIBUTES IT
 "AS IS."

 B. Waiver and Indemnity: RECIPIENT AGREES TO WAIVE ANY AND ALL CLAIMS AGAINST GOVERNMENT AGENCY, ITS
 AGENTS, EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT. IF RECIPIENT'S USE
 OF THE SUBJECT SOFTWARE RESULTS IN ANY LIABILITIES, DEMANDS, DAMAGES, EXPENSES OR LOSSES ARISING FROM
 SUCH USE, INCLUDING ANY DAMAGES FROM PRODUCTS BASED ON, OR RESULTING FROM, RECIPIENT'S USE OF THE
 SUBJECT SOFTWARE, RECIPIENT SHALL INDEMNIFY AND HOLD HARMLESS  GOVERNMENT AGENCY, ITS AGENTS,
 EMPLOYEES, CONTRACTORS AND SUBCONTRACTORS, AS WELL AS ANY PRIOR RECIPIENT, TO THE EXTENT PERMITTED BY
 LAW.  THE FOREGOING RELEASE AND INDEMNIFICATION SHALL APPLY EVEN IF THE LIABILITIES, DEMANDS, DAMAGES,
 EXPENSES OR LOSSES ARE CAUSED, OCCASIONED, OR CONTRIBUTED TO BY THE NEGLIGENCE, SOLE OR CONCURRENT, OF
 GOVERNMENT AGENCY OR ANY PRIOR RECIPIENT.  RECIPIENT'S SOLE REMEDY FOR ANY SUCH MATTER SHALL BE THE
 IMMEDIATE, UNILATERAL TERMINATION OF THIS AGREEMENT.

 5. GENERAL TERMS

 A. Termination: This Agreement and the rights granted hereunder will terminate automatically if a
 Recipient fails to comply with these terms and conditions, and fails to cure such noncompliance within
 thirty (30) days of becoming aware of such noncompliance. Upon termination, a Recipient agrees to
 immediately cease use and distribution of the Subject Software. All sublicenses to the Subject
 Software properly granted by the breaching Recipient shall survive any such termination of this
 Agreement.

 B. Severability: If any provision of this Agreement is invalid or unenforceable under applicable law,
 it shall not affect the validity or enforceability of the remainder of the terms of this Agreement.

 C. Applicable Law: This Agreement shall be subject to United States federal law only for all purposes,
 including, but not limited to, determining the validity of this Agreement, the meaning of its
 provisions and the rights, obligations and remedies of the parties.

 D. Entire Understanding: This Agreement constitutes the entire understanding and agreement of the
 parties relating to release of the Subject Software and may not be superseded, modified or amended
 except by further written agreement duly executed by the parties.

 E. Binding Authority: By accepting and using the Subject Software under this Agreement, a Recipient
 affirms its authority to bind the Recipient to all terms and conditions of this Agreement and that
 Recipient hereby agrees to all terms and conditions herein.

 F. Point of Contact: Any Recipient contact with Government Agency is to be directed to the designated
 representative as follows: J. Ritchie Carroll <mailto:jrcarrol@tva.gov>.

*/
#endregion

#region [ Contributor License Agreements ]

//******************************************************************************************************
//
//  Copyright © 2013, Grid Protection Alliance.  All Rights Reserved.
//
//  The GPA licenses this file to you under the Eclipse Public License -v 1.0 (the "License"); you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://www.opensource.org/licenses/eclipse-1.0.php
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//******************************************************************************************************

#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace TVA.Data
{
    /// <summary>
    /// Data types available to a <see cref="DataSet"/> object.
    /// </summary>
    public enum DataType : byte
    {
        /// <summary>
        /// Boolean data type, <see cref="Boolean"/>.
        /// </summary>
        Boolean,
        /// <summary>
        /// Unsigned 8-bit byte data type, <see cref="Byte"/>.
        /// </summary>
        Byte,
        /// <summary>
        /// 16-bit character data type, <see cref="Char"/>.
        /// </summary>
        Char,
        /// <summary>
        /// Date/time data type, <see cref="DateTime"/>.
        /// </summary>
        DateTime,
        /// <summary>
        /// Decimal data type, <see cref="Decimal"/>.
        /// </summary>
        Decimal,
        /// <summary>
        /// 64-dit double precision floating point numeric data type, <see cref="Double"/>.
        /// </summary>
        Double,
        /// <summary>
        /// Unisgned 128-bit Guid integer data type, <see cref="Guid"/>.
        /// </summary>
        Guid,
        /// <summary>
        /// Signed 16-bit integer data type, <see cref="Int16"/>.
        /// </summary>
        Int16,
        /// <summary>
        /// Signed 32-bit integer data type, <see cref="Int32"/>.
        /// </summary>
        Int32,
        /// <summary>
        /// Signed 64-bit integer data type, <see cref="Int64"/>
        /// </summary>
        Int64,
        /// <summary>
        /// Signed byte data type, <see cref="SByte"/>.
        /// </summary>
        SByte,
        /// <summary>
        /// 32-bit single precision floating point numeric data type, <see cref="Single"/>.
        /// </summary>
        Single,
        /// <summary>
        /// Character array data type, <see cref="String"/>.
        /// </summary>
        String,
        /// <summary>
        /// Timespan data type, <see cref="TimeSpan"/>.
        /// </summary>
        TimeSpan,
        /// <summary>
        /// Unsigned 16-bit integer data type, <see cref="UInt16"/>.
        /// </summary>
        UInt16,
        /// <summary>
        /// Unsigned 32-bit integer data type, <see cref="UInt32"/>.
        /// </summary>
        UInt32,
        /// <summary>
        /// Unsigned 64-bit integer data type, <see cref="UInt64"/>.
        /// </summary>
        UInt64,
        /// <summary>
        /// Unsigned byte array data type.
        /// </summary>
        Blob,
        /// <summary>
        /// User defined/other data type.
        /// </summary>
        Object
    }

    /// <summary>
    /// Defines extension functions related to <see cref="DataSet"/> instances.
    /// </summary>
    public static class DataSetExtensions
    {
        // Constant array of supported data types
        private readonly static Type[] s_supportedDataTypes = new[]
        {
            // This must match DataType enum order
            typeof(bool),
            typeof(byte),
            typeof(char),
            typeof(DateTime),
            typeof(decimal),
            typeof(double),
            typeof(Guid),
            typeof(short),
            typeof(int),
            typeof(long),
            typeof(sbyte),
            typeof(float),
            typeof(string),
            typeof(TimeSpan),
            typeof(ushort),
            typeof(uint),
            typeof(ulong),
            typeof(byte[]),
            typeof(object)
        };

        /// <summary>
        /// Serializes a <see cref="DataSet"/> to a destination <see cref="Stream"/>.
        /// </summary>
        /// <param name="source"><see cref="DataSet"/> to serialize.</param>
        /// <param name="destination"><see cref="Stream"/> to seralize <see cref="DataSet"/> on.</param>
        public static void SerializeToStream(this DataSet source, Stream destination)
        {
            if ((object)source == null)
                throw new ArgumentNullException("source");

            if ((object)destination == null)
                throw new ArgumentNullException("destination");

            if (!destination.CanWrite)
                throw new InvalidOperationException("Cannot write to a read-only stream");

            BinaryWriter output = new BinaryWriter(destination);

            // Serialize dataset name and table count
            output.Write(source.DataSetName);
            output.Write(source.Tables.Count);

            // Serialize tables
            foreach (DataTable table in source.Tables)
            {
                List<int> columnIndices = new List<int>();
                List<DataType> columnDataTypes = new List<DataType>();
                DataType dataType;

                // Serialize table name and column count
                output.Write(table.TableName);
                output.Write(table.Columns.Count);

                // Serialize column metadata
                foreach (DataColumn column in table.Columns)
                {
                    // Get column data type, unknown types will be represented as object
                    dataType = GetDataType(column.DataType);

                    // Only objects of a known type can be properly serialized
                    if (dataType != DataType.Object)
                    {
                        // Serialize column name and type
                        output.Write(column.ColumnName);
                        output.Write((byte)dataType);

                        // Track data types and column indicies in parallel lists for faster DataRow serialization
                        columnIndices.Add(column.Ordinal);
                        columnDataTypes.Add(dataType);
                    }
                }

                // Serialize row count
                output.Write(table.Rows.Count);

                // Serialize rows
                foreach (DataRow row in table.Rows)
                {
                    object value;

                    // Serialize column data
                    for (int i = 0; i < columnIndices.Count; i++)
                    {
                        value = row[columnIndices[i]];

                        switch (columnDataTypes[i])
                        {
                            case DataType.Boolean:
                                output.Write(value.NotDBNull<bool>());
                                break;
                            case DataType.Byte:
                                output.Write(value.NotDBNull<byte>());
                                break;
                            case DataType.Char:
                                output.Write(value.NotDBNull<char>());
                                break;
                            case DataType.DateTime:
                                output.Write(value.NotDBNull<DateTime>().Ticks);
                                break;
                            case DataType.Decimal:
                                output.Write(value.NotDBNull<decimal>());
                                break;
                            case DataType.Double:
                                output.Write(value.NotDBNull<double>());
                                break;
                            case DataType.Guid:
                                output.Write(value.NotDBNull<Guid>().ToByteArray());
                                break;
                            case DataType.Int16:
                                output.Write(value.NotDBNull<short>());
                                break;
                            case DataType.Int32:
                                output.Write(value.NotDBNull<int>());
                                break;
                            case DataType.Int64:
                                output.Write(value.NotDBNull<long>());
                                break;
                            case DataType.SByte:
                                output.Write(value.NotDBNull<sbyte>());
                                break;
                            case DataType.Single:
                                output.Write(value.NotDBNull<float>());
                                break;
                            case DataType.String:
                                output.Write(value.NotDBNull(""));
                                break;
                            case DataType.TimeSpan:
                                output.Write(value.NotDBNull<TimeSpan>().Ticks);
                                break;
                            case DataType.UInt16:
                                output.Write(value.NotDBNull<ushort>());
                                break;
                            case DataType.UInt32:
                                output.Write(value.NotDBNull<uint>());
                                break;
                            case DataType.UInt64:
                                output.Write(value.NotDBNull<ulong>());
                                break;
                            case DataType.Blob:
                                byte[] blob = value.NotDBNull<byte[]>();

                                if ((object)blob == null || blob.Length == 0)
                                {
                                    output.Write(0);
                                }
                                else
                                {
                                    output.Write(blob.Length);
                                    output.Write(blob);
                                }

                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Deserializes a <see cref="DataSet"/> from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="source"><see cref="Stream"/> to deseralize <see cref="DataSet"/> from.</param>
        public static DataSet DeserializeToDataSet(this Stream source)
        {
            if ((object)source == null)
                throw new ArgumentNullException("source");

            if (!source.CanRead)
                throw new InvalidOperationException("Cannot read from a write-only stream");

            DataSet dataset = new DataSet();
            DataRow row;
            object value;

            BinaryReader input = new BinaryReader(source);
            int tableCount;

            // Deserialize dataset name and table count
            dataset.DataSetName = input.ReadString();
            tableCount = input.ReadInt32();

            // Deserialize tables
            for (int i = 0; i < tableCount; i++)
            {
                List<int> columnIndices = new List<int>();
                List<DataType> columnDataTypes = new List<DataType>();
                DataType dataType;
                int columnCount, rowCount;

                DataTable table = dataset.Tables.Add();

                // Deserialize table name and column count
                table.TableName = input.ReadString();
                columnCount = input.ReadInt32();

                // Deserialize column metadata
                for (int j = 0; j < columnCount; j++)
                {
                    DataColumn column = table.Columns.Add();

                    // Deserialize column name and type
                    column.ColumnName = input.ReadString();
                    dataType = (DataType)input.ReadByte();
                    column.DataType = dataType.DeriveColumnType();

                    // Track data types and column indicies in parallel lists for faster DataRow deserialization
                    columnIndices.Add(column.Ordinal);
                    columnDataTypes.Add(dataType);
                }

                // Deserialize row count
                rowCount = input.ReadInt32();

                // Deserialize rows
                for (int j = 0; j < rowCount; j++)
                {
                    row = table.NewRow();

                    // Deserialize column data
                    for (int k = 0; k < columnIndices.Count; k++)
                    {
                        value = null;

                        switch (columnDataTypes[k])
                        {
                            case DataType.Boolean:
                                value = input.ReadBoolean();
                                break;
                            case DataType.Byte:
                                value = input.ReadByte();
                                break;
                            case DataType.Char:
                                value = input.ReadChar();
                                break;
                            case DataType.DateTime:
                                value = new DateTime(input.ReadInt64());
                                break;
                            case DataType.Decimal:
                                value = input.ReadDecimal();
                                break;
                            case DataType.Double:
                                value = input.ReadDouble();
                                break;
                            case DataType.Guid:
                                value = new Guid(input.ReadBytes(16));
                                break;
                            case DataType.Int16:
                                value = input.ReadInt16();
                                break;
                            case DataType.Int32:
                                value = input.ReadInt32();
                                break;
                            case DataType.Int64:
                                value = input.ReadInt64();
                                break;
                            case DataType.SByte:
                                value = input.ReadSByte();
                                break;
                            case DataType.Single:
                                value = input.ReadSingle();
                                break;
                            case DataType.String:
                                value = input.ReadString();
                                break;
                            case DataType.TimeSpan:
                                value = new TimeSpan(input.ReadInt64());
                                break;
                            case DataType.UInt16:
                                value = input.ReadUInt16();
                                break;
                            case DataType.UInt32:
                                value = input.ReadUInt32();
                                break;
                            case DataType.UInt64:
                                value = input.ReadUInt64();
                                break;
                            case DataType.Blob:
                                int byteCount = input.ReadInt32();

                                if (byteCount > 0)
                                    value = input.ReadBytes(byteCount);

                                break;
                        }

                        // Update column value
                        row[columnIndices[k]] = value;
                    }

                    // Add new row to table
                    table.Rows.Add(row);
                }
            }

            return dataset;
        }

        /// <summary>
        /// Attempts to derive <see cref="DataType"/> based on object <see cref="Type"/>.
        /// </summary>
        /// <param name="objectType"><see cref="Type"/> of object to test.</param>
        /// <returns>Derived <see cref="DataType"/> based on object <see cref="Type"/> if matched; otherse <see cref="DataType.Object"/>.</returns>
        public static DataType GetDataType(this Type objectType)
        {
            for (int i = 0; i < s_supportedDataTypes.Length; i++)
            {
                if (objectType == s_supportedDataTypes[i])
                    return (DataType)i;
            }

            return DataType.Object;
        }

        /// <summary>
        /// Gets column object <see cref="Type"/> from given <see cref="DataType"/>.
        /// </summary>
        /// <param name="dataType"><see cref="DataType"/> to derive object <see cref="Type"/> from.</param>
        /// <returns>Object <see cref="Type"/> derived from given <see cref="DataType"/>.</returns>
        public static Type DeriveColumnType(this DataType dataType)
        {
            return s_supportedDataTypes[(int)dataType];
        }

        private static T NotDBNull<T>(this object value, T defaultValue)
        {
            return value == DBNull.Value ? defaultValue : (T)value;
        }

        private static T NotDBNull<T>(this object value)
        {
            return value.NotDBNull(default(T));
        }
    }
}