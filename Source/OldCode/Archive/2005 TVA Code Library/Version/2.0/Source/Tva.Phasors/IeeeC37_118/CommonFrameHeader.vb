'*******************************************************************************************************
'  CommonFrameHeader.vb - IEEE C37.118 Common frame header functions
'  Copyright � 2005 - TVA, all rights reserved - Gbtc
'
'  Build Environment: VB.NET, Visual Studio 2005
'  Primary Developer: James R Carroll, Operations Data Architecture [TVA]
'      Office: COO - TRNS/PWR ELEC SYS O, CHATTANOOGA, TN - MR 2W-C
'       Phone: 423/751-2827
'       Email: jrcarrol@tva.gov
'
'  Code Modification History:
'  -----------------------------------------------------------------------------------------------------
'  11/12/2004 - James R Carroll
'       Initial version of source generated
'
'*******************************************************************************************************

Imports Tva.DateTime
Imports Tva.Interop
Imports Tva.Phasors.Common
Imports Tva.Phasors.IeeeC37_118.Common

Namespace IeeeC37_118

    ' This class generates and parses a frame header specfic to C37.118
    <CLSCompliant(False)> _
    Public NotInheritable Class CommonFrameHeader

#Region " Internal Common Frame Header Instance Class "

        ' This class is used to temporarily hold parsed frame header
        Private Class CommonFrameHeaderInstance

            Implements ICommonFrameHeader

            Private m_revisionNumber As RevisionNumber
            Private m_frameType As FrameType
            Private m_version As Byte
            Private m_frameLength As Int16
            Private m_idCode As UInt16
            Private m_ticks As Long
            Private m_timeQualityFlags As Int32

            Public Sub New(ByVal revisionNumber As RevisionNumber)

                m_revisionNumber = revisionNumber

            End Sub

            Public ReadOnly Property This() As IChannel Implements IChannel.This
                Get
                    Return Me
                End Get
            End Property

            Private ReadOnly Property IFrameThis() As Measurements.IFrame Implements Measurements.IFrame.This
                Get
                    Return Me
                End Get
            End Property

            Public ReadOnly Property InheritedType() As System.Type Implements IChannel.InheritedType
                Get
                    Return Me.GetType()
                End Get
            End Property

            Public Property RevisionNumber() As RevisionNumber Implements ICommonFrameHeader.RevisionNumber
                Get
                    Return m_revisionNumber
                End Get
                Set(ByVal Value As RevisionNumber)
                    m_revisionNumber = Value
                End Set
            End Property

            Public Property FrameType() As FrameType Implements ICommonFrameHeader.FrameType
                Get
                    Return m_frameType
                End Get
                Set(ByVal value As FrameType)
                    m_frameType = value
                End Set
            End Property

            Public Property Version() As Byte Implements ICommonFrameHeader.Version
                Get
                    Return m_version
                End Get
                Set(ByVal value As Byte)
                    m_version = value
                End Set
            End Property

            Public Property FrameLength() As Int16 Implements ICommonFrameHeader.FrameLength
                Get
                    Return m_frameLength
                End Get
                Set(ByVal value As Int16)
                    m_frameLength = value
                End Set
            End Property

            Public Property IDCode() As UInt16 Implements IChannelFrame.IDCode
                Get
                    Return m_idCode
                End Get
                Set(ByVal value As UInt16)
                    m_idCode = value
                End Set
            End Property

            Public Property Ticks() As Long Implements IChannelFrame.Ticks
                Get
                    Return m_ticks
                End Get
                Set(ByVal value As Long)
                    m_ticks = value
                End Set
            End Property

            Public Property InternalTimeQualityFlags() As Int32 Implements ICommonFrameHeader.InternalTimeQualityFlags
                Get
                    Return m_timeQualityFlags
                End Get
                Set(ByVal value As Int32)
                    m_timeQualityFlags = value
                End Set
            End Property

            Public ReadOnly Property SecondOfCentury() As UInt32 Implements ICommonFrameHeader.SecondOfCentury
                Get
                    Return CommonFrameHeader.SecondOfCentury(Me)
                End Get
            End Property

            Public ReadOnly Property FractionOfSecond() As Int32 Implements ICommonFrameHeader.FractionOfSecond
                Get
                    Return CommonFrameHeader.FractionOfSecond(Me)
                End Get
            End Property

            Public Property TimeQualityFlags() As TimeQualityFlags Implements ICommonFrameHeader.TimeQualityFlags
                Get
                    Return CommonFrameHeader.TimeQualityFlags(Me)
                End Get
                Set(ByVal value As TimeQualityFlags)
                    CommonFrameHeader.TimeQualityFlags(Me) = value
                End Set
            End Property

            Public Property TimeQualityIndicatorCode() As TimeQualityIndicatorCode Implements ICommonFrameHeader.TimeQualityIndicatorCode
                Get
                    Return CommonFrameHeader.TimeQualityIndicatorCode(Me)
                End Get
                Set(ByVal value As TimeQualityIndicatorCode)
                    CommonFrameHeader.TimeQualityIndicatorCode(Me) = value
                End Set
            End Property

            Public ReadOnly Property TimeBase() As Int32 Implements ICommonFrameHeader.TimeBase
                Get
                    Return Int32.MaxValue And Not TimeQualityFlagsMask
                End Get
            End Property

            Public ReadOnly Property BinaryImage() As Byte() Implements IChannel.BinaryImage
                Get
                    Throw New NotImplementedException()
                End Get
            End Property

            Public ReadOnly Property BinaryLength() As UInt16 Implements IChannel.BinaryLength
                Get
                    Return 0
                End Get
            End Property

            Public Sub ParseBinaryImage(ByVal state As IChannelParsingState, ByVal binaryImage() As Byte, ByVal startIndex As Integer) Implements IChannel.ParseBinaryImage

                Throw New NotImplementedException()

            End Sub

            Public ReadOnly Property Cells() As Object Implements IChannelFrame.Cells
                Get
                    Return Nothing
                End Get
            End Property

            Private ReadOnly Property IChannelFrameFrameType() As FundamentalFrameType Implements IChannelFrame.FrameType
                Get
                    ' Translate IEEE C37.118 specific frame type to fundamental frame type
                    Select Case m_frameType
                        Case IeeeC37_118.FrameType.DataFrame
                            Return FundamentalFrameType.DataFrame
                        Case IeeeC37_118.FrameType.ConfigurationFrame1, IeeeC37_118.FrameType.ConfigurationFrame2
                            Return FundamentalFrameType.ConfigurationFrame
                        Case IeeeC37_118.FrameType.HeaderFrame
                            Return FundamentalFrameType.HeaderFrame
                        Case IeeeC37_118.FrameType.CommandFrame
                            Return FundamentalFrameType.CommandFrame
                        Case Else
                            Return FundamentalFrameType.Undetermined
                    End Select
                End Get
            End Property

            Public Property Published() As Boolean Implements IChannelFrame.Published
                Get
                    Return False
                End Get
                Set(ByVal value As Boolean)
                    Throw New NotImplementedException()
                End Set
            End Property

            ' This frame is not complete - it only represents the parsed common "header" for frames
            Public ReadOnly Property IsPartial() As Boolean Implements IChannelFrame.IsPartial
                Get
                    Return True
                End Get
            End Property

            Public ReadOnly Property Timestamp() As Date Implements IChannelFrame.Timestamp
                Get
                    Return New Date(m_ticks)
                End Get
            End Property

            Public ReadOnly Property TimeTag() As DateTime.UnixTimeTag Implements IChannelFrame.TimeTag
                Get
                    Return New UnixTimeTag(Timestamp)
                End Get
            End Property

            Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo

                If TypeOf obj Is IChannelFrame Then
                    Return m_ticks.CompareTo(DirectCast(obj, IChannelFrame).Ticks)
                Else
                    Throw New ArgumentException(InheritedType.Name & " can only be compared with other IChannelFrames...")
                End If
            End Function

            Private ReadOnly Property IFrameMeasurements() As System.Collections.Generic.IDictionary(Of Integer, Measurements.IMeasurement) Implements Measurements.IFrame.Measurements
                Get
                    Throw New NotImplementedException()
                End Get
            End Property

        End Class

#End Region

        Public Const BinaryLength As UInt16 = 14

        Private Sub New()

            ' This class contains only global functions and is not meant to be instantiated

        End Sub

        Public Shared Function ParseBinaryImage(ByVal revisionNumber As RevisionNumber, ByVal configurationFrame As ConfigurationFrame, ByVal binaryImage As Byte(), ByVal startIndex As Int32) As ICommonFrameHeader

            If binaryImage(startIndex) <> SyncByte Then Throw New InvalidOperationException("Bad Data Stream: Expected sync byte &HAA as first byte in IEEE C37.118 frame, got " & binaryImage(startIndex).ToString("x"c).PadLeft(2, "0"c))

            With New CommonFrameHeaderInstance(revisionNumber)
                ' Strip out frame type and version information...
                .FrameType = (binaryImage(startIndex + 1) And Not FrameType.VersionNumberMask)
                .Version = (binaryImage(startIndex + 1) And FrameType.VersionNumberMask)

                .FrameLength = EndianOrder.BigEndian.ToInt16(binaryImage, startIndex + 2)
                .IDCode = EndianOrder.BigEndian.ToUInt16(binaryImage, startIndex + 4)

                Dim secondOfCentury As UInt32 = EndianOrder.BigEndian.ToUInt32(binaryImage, startIndex + 6)
                Dim fractionOfSecond As Int32 = EndianOrder.BigEndian.ToInt32(binaryImage, startIndex + 10)

                If configurationFrame Is Nothing OrElse .FrameType = FrameType.ConfigurationFrame1 OrElse .FrameType = FrameType.ConfigurationFrame2 Then
                    ' Without timebase, the best timestamp you can get is down to the whole second
                    .Ticks = (New UnixTimeTag(secondOfCentury)).ToDateTime.Ticks
                Else
                    .Ticks = (New UnixTimeTag(secondOfCentury + (fractionOfSecond And Not TimeQualityFlagsMask) / configurationFrame.TimeBase)).ToDateTime.Ticks
                End If

                .InternalTimeQualityFlags = fractionOfSecond And TimeQualityFlagsMask

                Return .This
            End With

        End Function

        Public Shared Function BinaryImage(ByVal frameHeader As ICommonFrameHeader) As Byte()

            Dim buffer As Byte() = Array.CreateInstance(GetType(Byte), BinaryLength)

            With frameHeader
                buffer(0) = SyncByte
                buffer(1) = .FrameType Or .Version
                EndianOrder.BigEndian.CopyBytes(.FrameLength, buffer, 2)
                EndianOrder.BigEndian.CopyBytes(.IDCode, buffer, 4)
                EndianOrder.BigEndian.CopyBytes(.SecondOfCentury, buffer, 6)
                EndianOrder.BigEndian.CopyBytes(.FractionOfSecond Or .TimeQualityFlags, buffer, 10)
            End With

            Return buffer

        End Function

        Public Shared Sub Clone(ByVal sourceFrameHeader As ICommonFrameHeader, ByVal destinationFrameHeader As ICommonFrameHeader)

            With destinationFrameHeader
                .RevisionNumber = sourceFrameHeader.RevisionNumber
                .FrameType = sourceFrameHeader.FrameType
                .Version = sourceFrameHeader.Version
                .FrameLength = sourceFrameHeader.FrameLength
                .IDCode = sourceFrameHeader.IDCode
                .Ticks = sourceFrameHeader.Ticks
                .InternalTimeQualityFlags = sourceFrameHeader.InternalTimeQualityFlags
            End With

        End Sub

        Public Shared ReadOnly Property Version(ByVal frameHeader As ICommonFrameHeader, ByVal newVersion As Byte) As Byte
            Get
                Return newVersion And FrameType.VersionNumberMask
            End Get
        End Property

        Public Shared ReadOnly Property SecondOfCentury(ByVal frameHeader As ICommonFrameHeader) As UInt32
            Get
                Return System.Math.Floor(TimeTag(frameHeader).Value)
            End Get
        End Property

        Public Shared ReadOnly Property FractionOfSecond(ByVal frameHeader As ICommonFrameHeader) As Int32
            Get
                Dim seconds As Single = TimeTag(frameHeader).Value
                Return (seconds - System.Math.Floor(seconds)) * frameHeader.TimeBase
            End Get
        End Property

        Public Shared ReadOnly Property TimeTag(ByVal frameHeader As ICommonFrameHeader) As UnixTimeTag
            Get
                Return New UnixTimeTag(New Date(frameHeader.Ticks))
            End Get
        End Property

        Public Shared Property TimeQualityFlags(ByVal frameHeader As ICommonFrameHeader) As IeeeC37_118.TimeQualityFlags
            Get
                Return frameHeader.InternalTimeQualityFlags And Not TimeQualityFlags.TimeQualityIndicatorCodeMask
            End Get
            Set(ByVal value As IeeeC37_118.TimeQualityFlags)
                With frameHeader
                    .InternalTimeQualityFlags = (.InternalTimeQualityFlags And IeeeC37_118.TimeQualityFlags.TimeQualityIndicatorCodeMask) Or value
                End With
            End Set
        End Property

        Public Shared Property TimeQualityIndicatorCode(ByVal frameHeader As ICommonFrameHeader) As IeeeC37_118.TimeQualityIndicatorCode
            Get
                Return frameHeader.InternalTimeQualityFlags And IeeeC37_118.TimeQualityFlags.TimeQualityIndicatorCodeMask
            End Get
            Set(ByVal value As IeeeC37_118.TimeQualityIndicatorCode)
                With frameHeader
                    .InternalTimeQualityFlags = (.InternalTimeQualityFlags And Not IeeeC37_118.TimeQualityFlags.TimeQualityIndicatorCodeMask) Or value
                End With
            End Set
        End Property

    End Class

End Namespace
