//*******************************************************************************************************
//  DateTimeExtensions.cs
//  Copyright © 2008 - TVA, all rights reserved - Gbtc
//
//  Build Environment: C#, Visual Studio 2008
//  Primary Developer: James R Carroll
//      Office: PSO TRAN & REL, CHATTANOOGA - MR 2W-C
//       Phone: 423/751-2827
//       Email: jrcarrol@tva.gov
//
//  Code Modification History:
//  -----------------------------------------------------------------------------------------------------
//  02/23/2003 - J. Ritchie Carroll
//       Generated original version of source code.
//  06/10/2004 - J. Ritchie Carroll
//       Added SecondsToText overload to allow custom time names, e.g., 1 Min 2 Secs.
//  01/05/2005 - J. Ritchie Carroll
//       Added BaselinedTimestamp function.
//  12/21/2005 - J. Ritchie Carroll
//       Migrated 2.0 version of source code from 1.1 source (TVA.Shared.DateTime).
//  08/28/2006 - J. Ritchie Carroll
//       Added TimeIsValid, LocalTimeIsValid and UtcTimeIsValid functions.
//  09/15/2006 - J. Ritchie Carroll
//       Updated BaselinedTimestamp function to support multiple time intervals.
//  09/18/2006 - J. Ritchie Carroll
//       Added TicksBeyondSecond function to support high-resolution timestamp intervals.
//  07/17/2007 - J. Ritchie Carroll
//       Exposed TicksPerSecond as public shared constant.
//  08/31/2007 - Darrell Zuercher
//       Edited code comments.
//  08/22/2008 - J. Ritchie Carroll
//       Added TicksPerMillisecond constant and TicksToMilliseconds property.
//  09/08/2008 - J. Ritchie Carroll
//      Converted to C# extensions.
//
//*******************************************************************************************************

using System;
using System.Text;

/// <summary>Defines common global functions related to Date/Time manipulation.</summary>
public static class DateTimeExtensions
{
    /// <summary>Determines if the specified UTC time is valid, by comparing it to the system clock.</summary>
    /// <param name="utcTime">UTC time to test for validity.</param>
    /// <param name="lagTime">The allowed lag time, in seconds, before assuming time is too old to be valid.</param>
    /// <param name="leadTime">The allowed lead time, in seconds, before assuming time is too advanced to be
    /// valid.</param>
    /// <returns>True, if time is within the specified range.</returns>
    /// <remarks>
    /// <para>Time is considered valid if it exists within the specified lag time/lead time range of current
    /// time.</para>
    /// <para>Note that lag time and lead time must be greater than zero, but can be set to sub-second
    /// intervals.</para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">LagTime and LeadTime must be greater than zero, but can
    /// be less than one.</exception>
    public static bool UtcTimeIsValid(this DateTime utcTime, double lagTime, double leadTime)
    {
        return utcTime.Ticks.UtcTimeIsValid(lagTime, leadTime);
    }

    /// <summary>Determines if the specified UTC time ticks are valid, by comparing them to the system clock.</summary>
    /// <param name="utcTicks">Ticks of time to test for validity.</param>
    /// <param name="lagTime">The allowed lag time, in seconds, before assuming time is too old to be valid.</param>
    /// <param name="leadTime">The allowed lead time, in seconds, before assuming time is too advanced to be
    /// valid.</param>
    /// <returns>True, if time is within the specified range.</returns>
    /// <remarks>
    /// <para>Time is considered valid if it exists within the specified lag time/lead time range of current
    /// time.</para>
    /// <para>Note that lag time and lead time must be greater than zero, but can be set to sub-second
    /// intervals.</para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">LagTime and LeadTime must be greater than zero, but can
    /// be less than one.</exception>
    public static bool UtcTimeIsValid(this long utcTicks, double lagTime, double leadTime)
    {
        return utcTicks.TimeIsValid(DateTime.UtcNow.Ticks, lagTime, leadTime);
    }

    /// <summary>Determines if the specified local time is valid, by comparing it to the system clock.</summary>
    /// <param name="localTime">Time to test for validity.</param>
    /// <param name="lagTime">The allowed lag time, in seconds, before assuming time is too old to be valid.</param>
    /// <param name="leadTime">The allowed lead time, in seconds, before assuming time is too advanced to be
    /// valid.</param>
    /// <returns>True, if time is within the specified range.</returns>
    /// <remarks>
    /// <para>Time is considered valid if it exists within the specified lag time/lead time range of current
    /// time.</para>
    /// <para>Note that lag time and lead time must be greater than zero, but can be set to sub-second
    /// intervals.</para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">LagTime and LeadTime must be greater than zero, but can
    /// be less than one.</exception>
    public static bool LocalTimeIsValid(this DateTime localTime, double lagTime, double leadTime)
    {
        return localTime.Ticks.LocalTimeIsValid(lagTime, leadTime);
    }

    /// <summary>Determines if the specified local time ticks are valid, by comparing them to the system clock.</summary>
    /// <param name="localTicks">Ticks of time to test for validity.</param>
    /// <param name="lagTime">The allowed lag time, in seconds, before assuming time is too old to be valid.</param>
    /// <param name="leadTime">The allowed lead time, in seconds, before assuming time is too advanced to be
    /// valid.</param>
    /// <returns>True, if time is within the specified range.</returns>
    /// <remarks>
    /// <para>Time is considered valid if it exists within the specified lag time/lead time range of current
    /// time.</para>
    /// <para>Note that lag time and lead time must be greater than zero, but can be set to sub-second
    /// intervals.</para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">LagTime and LeadTime must be greater than zero, but can
    /// be less than one.</exception>
    public static bool LocalTimeIsValid(this long localTicks, double lagTime, double leadTime)
    {
        return localTicks.TimeIsValid(DateTime.Now.Ticks, lagTime, leadTime);
    }

    /// <summary>Determines if time is valid, by comparing it to the specified current time.</summary>
    /// <param name="currentTime">Specified current time (e.g., could be Date.Now or Date.UtcNow).</param>
    /// <param name="testTime">Time to test for validity.</param>
    /// <param name="lagTime">The allowed lag time, in seconds, before assuming time is too old to be valid.</param>
    /// <param name="leadTime">The allowed lead time, in seconds, before assuming time is too advanced to be
    /// valid.</param>
    /// <returns>True, if time is within the specified range.</returns>
    /// <remarks>
    /// <para>Time is considered valid if it exists within the specified lag time/lead time range of current
    /// time.</para>
    /// <para>Note that lag time and lead time must be greater than zero, but can be set to sub-second
    /// intervals.</para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">LagTime and LeadTime must be greater than zero, but can
    /// be less than one.</exception>
    public static bool TimeIsValid(this DateTime testTime, DateTime currentTime, double lagTime, double leadTime)
    {
        return testTime.Ticks.TimeIsValid(currentTime.Ticks, lagTime, leadTime);
    }

    /// <summary>Determines if time is valid, by comparing it to the specified current time.</summary>
    /// <param name="currentTicks">Specified ticks of current time (e.g., could be Date.Now.Ticks or
    /// Date.UtcNow.Ticks).</param>
    /// <param name="testTicks">Ticks of time to test for validity.</param>
    /// <param name="lagTime">The allowed lag time, in seconds, before assuming time is too old to be valid.</param>
    /// <param name="leadTime">The allowed lead time, in seconds, before assuming time is too advanced to be
    /// valid.</param>
    /// <returns>True, if time is within the specified range.</returns>
    /// <remarks>
    /// <para>Time is considered valid if it exists within the specified lag time/lead time range of current
    /// time.</para>
    /// <para>Note that lag time and lead time must be greater than zero, but can be set to sub-second
    /// intervals.</para>
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">LagTime and LeadTime must be greater than zero, but can
    /// be less than one.</exception>
    public static bool TimeIsValid(this long testTicks, long currentTicks, double lagTime, double leadTime)
    {
        if (lagTime <= 0) throw new ArgumentOutOfRangeException("lagTime", "lagTime must be greater than zero, but it can be less than one");
        if (leadTime <= 0) throw new ArgumentOutOfRangeException("leadTime", "leadTime must be greater than zero, but it can be less than one");

        double distance = Common.TicksToSeconds(currentTicks - testTicks);

        return (distance >= -leadTime && distance <= lagTime);
    }

    /// <summary>Gets the distance, in ticks, beyond the top of the timestamp second.</summary>
    /// <param name="ticks">Ticks of timestamp to evaluate.</param>
    /// <returns>Timestamp's tick distance from the top of the second.</returns>
    public static long TicksBeyondSecond(this long ticks)
    {
        return ticks - BaselinedTimestamp(new DateTime(ticks), BaselineTimeInterval.Second).Ticks;
    }

    /// <summary>Gets the distance, in ticks, beyond the top of the timestamp second.</summary>
    /// <param name="timestamp">Timestamp to evaluate.</param>
    /// <returns>Timestamp's tick distance from the top of the second.</returns>
    public static long TicksBeyondSecond(this DateTime timestamp)
    {
        return timestamp.Ticks - BaselinedTimestamp(timestamp, BaselineTimeInterval.Second).Ticks;
    }

    /// <summary>Removes any milliseconds from a timestamp value, to baseline the time at the bottom of the
    /// second.</summary>
    /// <param name="ticks">Ticks of timestamp to baseline.</param>
    /// <param name="baselineTo">Time interval to which timestamp should be baselined.</param>
    public static DateTime BaselinedTimestamp(this long ticks, BaselineTimeInterval baselineTo)
    {
        return BaselinedTimestamp(new DateTime(ticks), baselineTo);
    }

    /// <summary>Creates a baselined timestamp which begins at the specified time interval.</summary>
    /// <param name="timestamp">Timestamp to baseline.</param>
    /// <param name="baselineTo">Time interval to which timestamp should be baselined.</param>
    /// <returns>Baselined timestamp which begins at the specified time interval.</returns>
    /// <remarks>
    /// <para>Baselining to the second would return the timestamp starting at zero milliseconds.</para>
    /// <para>Baselining to the minute would return the timestamp starting at zero seconds and milliseconds.</para>
    /// <para>Baselining to the hour would return the timestamp starting at zero minutes, seconds and
    /// milliseconds.</para>
    /// <para>Baselining to the day would return the timestamp starting at zero hours, minutes, seconds and
    /// milliseconds.</para>
    /// <para>Baselining to the month would return the timestamp starting at day one, zero hours, minutes,
    /// seconds and milliseconds.</para>
    /// <para>Baselining to the year would return the timestamp starting at month one, day one, zero hours,
    /// minutes, seconds and milliseconds.</para>
    /// </remarks>
    public static DateTime BaselinedTimestamp(this DateTime timestamp, BaselineTimeInterval baselineTo)
    {
        switch (baselineTo)
        {
            case BaselineTimeInterval.Second:
                return new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, timestamp.Hour, timestamp.Minute, timestamp.Second, 0);
            case BaselineTimeInterval.Minute:
                return new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, timestamp.Hour, timestamp.Minute, 0, 0);
            case BaselineTimeInterval.Hour:
                return new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, timestamp.Hour, 0, 0, 0);
            case BaselineTimeInterval.Day:
                return new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 0, 0, 0, 0);
            case BaselineTimeInterval.Month:
                return new DateTime(timestamp.Year, timestamp.Month, 1, 0, 0, 0, 0);
            case BaselineTimeInterval.Year:
                return new DateTime(timestamp.Year, 1, 1, 0, 0, 0, 0);
            default:
                return timestamp;
        }
    }

    /// <summary>Converts given local time to Eastern time.</summary>
    /// <param name="localTimestamp">Timestamp in local time to be converted to Eastern time.</param>
    /// <returns>
    /// <para>Timestamp in Eastern time.</para>
    /// </returns>
    public static DateTime LocalTimeToEasternTime(this DateTime localTimeStamp)
    {
        return TimeZoneInfo.ConvertTime(localTimeStamp, TimeZoneInfo.Local, USTimeZones.EasternTimeZone);
    }

    /// <summary>Converts given local time to Central time.</summary>
    /// <param name="localTimestamp">Timestamp in local time to be converted to Central time.</param>
    /// <returns>
    /// <para>Timestamp in Central time.</para>
    /// </returns>
    public static DateTime LocalTimeToCentralTime(this DateTime localTimeStamp)
    {
        return TimeZoneInfo.ConvertTime(localTimeStamp, TimeZoneInfo.Local, USTimeZones.CentralTimeZone);
    }

    /// <summary>Converts given local time to Mountain time.</summary>
    /// <param name="localTimestamp">Timestamp in local time to be converted to Mountain time.</param>
    /// <returns>
    /// <para>Timestamp in Mountain time.</para>
    /// </returns>
    public static DateTime LocalTimeToMountainTime(this DateTime localTimeStamp)
    {
        return TimeZoneInfo.ConvertTime(localTimeStamp, TimeZoneInfo.Local, USTimeZones.MountainTimeZone);
    }

    /// <summary>Converts given local time to Pacific time.</summary>
    /// <param name="localTimestamp">Timestamp in local time to be converted to Pacific time.</param>
    /// <returns>
    /// <para>Timestamp in Pacific time.</para>
    /// </returns>
    public static DateTime LocalTimeToPacificTime(this DateTime localTimeStamp)
    {
        return TimeZoneInfo.ConvertTime(localTimeStamp, TimeZoneInfo.Local, USTimeZones.PacificTimeZone);
    }

    /// <summary>Converts given local time to Universally Coordinated Time (a.k.a., Greenwich Meridian Time).</summary>
    /// <remarks>This function is only provided for the sake of completeness. All it does is call the
    /// "ToUniversalTime" property on the given timestamp.</remarks>
    /// <param name="localTimestamp">Timestamp in local time to be converted to Universal time.</param>
    /// <returns>
    /// <para>Timestamp in UniversalTime (a.k.a., GMT).</para>
    /// </returns>
    public static DateTime LocalTimeToUniversalTime(this DateTime localTimestamp)
    {
        return localTimestamp.ToUniversalTime();
    }

    /// <summary>Converts given local time to time in specified time zone.</summary>
    /// <param name="localTimestamp">Timestamp in local time to be converted to time in specified time zone.</param>
    /// <param name="destinationTimeZoneStandardName">Standard name of desired end time zone for given
    /// timestamp.</param>
    /// <returns>
    /// <para>Timestamp in specified time zone.</para>
    /// </returns>
    public static DateTime LocalTimeTo(this DateTime localTimestamp, string destinationTimeZoneStandardName)
    {
        return TimeZoneInfo.ConvertTime(localTimestamp, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneStandardName));
    }

    /// <summary>Converts given local time to time in specified time zone.</summary>
    /// <param name="localTimestamp">Timestamp in local time to be converted to time in specified time zone.</param>
    /// <param name="destinationTimeZone">Desired end time zone for given timestamp.</param>
    /// <returns>
    /// <para>Timestamp in specified time zone.</para>
    /// </returns>
    public static DateTime LocalTimeTo(this DateTime localTimestamp, TimeZoneInfo destinationTimeZone)
    {
        return TimeZoneInfo.ConvertTime(localTimestamp, TimeZoneInfo.Local, destinationTimeZone);
    }

    /// <summary>
    /// Converts the specified Universally Coordinated Time timestamp to Eastern time timestamp.
    /// </summary>
    /// <param name="universalTimestamp">The Universally Coordinated Time timestamp that is to be converted.</param>
    /// <returns>The timestamp in Eastern time.</returns>
    public static DateTime UniversalTimeToEasternTime(this DateTime universalTimestamp)
    {
        return TimeZoneInfo.ConvertTime(universalTimestamp, TimeZoneInfo.Utc, USTimeZones.EasternTimeZone);
    }

    /// <summary>
    /// Converts the specified Universally Coordinated Time timestamp to Central time timestamp.
    /// </summary>
    /// <param name="universalTimestamp">The Universally Coordinated Time timestamp that is to be converted.</param>
    /// <returns>The timestamp in Central time.</returns>
    public static DateTime UniversalTimeToCentralTime(this DateTime universalTimestamp)
    {
        return TimeZoneInfo.ConvertTime(universalTimestamp, TimeZoneInfo.Utc, USTimeZones.CentralTimeZone);
    }

    /// <summary>
    /// Converts the specified Universally Coordinated Time timestamp to Mountain time timestamp.
    /// </summary>
    /// <param name="universalTimestamp">The Universally Coordinated Time timestamp that is to be converted.</param>
    /// <returns>The timestamp in Mountain time.</returns>
    public static DateTime UniversalTimeToMountainTime(this DateTime universalTimestamp)
    {
        return TimeZoneInfo.ConvertTime(universalTimestamp, TimeZoneInfo.Utc, USTimeZones.MountainTimeZone);
    }

    /// <summary>
    /// Converts the specified Universally Coordinated Time timestamp to Pacific time timestamp.
    /// </summary>
    /// <param name="universalTimestamp">The Universally Coordinated Time timestamp that is to be converted.</param>
    /// <returns>The timestamp in Pacific time.</returns>
    public static DateTime UniversalTimeToPacificTime(this DateTime universalTimestamp)
    {
        return TimeZoneInfo.ConvertTime(universalTimestamp, TimeZoneInfo.Utc, USTimeZones.PacificTimeZone);
    }

    /// <summary>
    /// Converts the specified Universally Coordinated Time timestamp to timestamp in specified time zone.
    /// </summary>
    /// <param name="universalTimestamp">The Universally Coordinated Time timestamp that is to be converted.</param>
    /// <param name="destinationTimeZoneStandardName">The time zone standard name to which the Universally
    /// Coordinated Time timestamp is to be converted to.</param>
    /// <returns>The timestamp in the specified time zone.</returns>
    public static DateTime UniversalTimeTo(this DateTime universalTimestamp, string destinationTimeZoneStandardName)
    {
        return TimeZoneInfo.ConvertTime(universalTimestamp, TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneStandardName));
    }

    /// <summary>
    /// Converts the specified Universally Coordinated Time timestamp to timestamp in specified time zone.
    /// </summary>
    /// <param name="universalTimestamp">The Universally Coordinated Time timestamp that is to be converted.</param>
    /// <param name="destinationTimeZone">The time zone to which the Universally Coordinated Time timestamp
    /// is to be converted to.</param>
    /// <returns>The timestamp in the specified time zone.</returns>
    public static DateTime UniversalTimeTo(this DateTime universalTimestamp, TimeZoneInfo destinationTimeZone)
    {
        return TimeZoneInfo.ConvertTime(universalTimestamp, TimeZoneInfo.Utc, destinationTimeZone);
    }

    /// <summary>Converts given timestamp from one time zone to another using standard names for time zones.</summary>
    /// <param name="timestamp">Timestamp in source time zone to be converted to time in destination time zone.</param>
    /// <param name="sourceTimeZoneStandardName">Standard name of time zone for given source timestamp.</param>
    /// <param name="destinationTimeZoneStandardName">Standard name of desired end time zone for given source
    /// timestamp.</param>
    /// <returns>
    /// <para>Timestamp in destination time zone.</para>
    /// </returns>
    public static DateTime TimeZoneToTimeZone(this DateTime timestamp, string sourceTimeZoneStandardName, string destinationTimeZoneStandardName)
    {
        return TimeZoneInfo.ConvertTime(timestamp, TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZoneStandardName), TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneStandardName));
    }

    /// <summary>Converts given timestamp from one time zone to another.</summary>
    /// <param name="timestamp">Timestamp in source time zone to be converted to time in destination time
    /// zone.</param>
    /// <param name="sourceTimeZone">Time zone for given source timestamp.</param>
    /// <param name="destinationTimeZone">Desired end time zone for given source timestamp.</param>
    /// <returns>
    /// <para>Timestamp in destination time zone.</para>
    /// </returns>
    public static DateTime TimeZoneToTimeZone(this DateTime timestamp, TimeZoneInfo sourceTimeZone, TimeZoneInfo destinationTimeZone)
    {
        return TimeZoneInfo.ConvertTime(timestamp, sourceTimeZone, destinationTimeZone);
    }

    /// <summary>Gets the 3-letter month abbreviation for given month number (1-12).</summary>
    /// <param name="monthNumber">Numeric month number (1-12).</param>
    /// <remarks>Month abbreviations are English only.</remarks>
    public static string ShortMonthName(this DateTime timestamp)
    {
        switch (timestamp.Month)
        {
            case 1:
                return "Jan";
            case 2:
                return "Feb";
            case 3:
                return "Mar";
            case 4:
                return "Apr";
            case 5:
                return "May";
            case 6:
                return "Jun";
            case 7:
                return "Jul";
            case 8:
                return "Aug";
            case 9:
                return "Sep";
            case 10:
                return "Oct";
            case 11:
                return "Nov";
            case 12:
                return "Dec";
            default:
                throw new ArgumentOutOfRangeException("monthNumber", "Invalid month number \"" + timestamp.Month + "\" specified - expected a value between 1 and 12");
        }
    }

    /// <summary>Gets the full month name for given month number (1-12).</summary>
    /// <param name="monthNumber">Numeric month number (1-12).</param>
    /// <remarks>Month names are English only.</remarks>
    public static string LongMonthName(this DateTime timestamp)
	{
		switch (timestamp.Month)
		{
			case 1:
				return "January";
			case 2:
				return "February";
			case 3:
				return "March";
			case 4:
				return "April";
			case 5:
				return "May";
			case 6:
				return "June";
			case 7:
				return "July";
			case 8:
				return "August";
			case 9:
				return "September";
			case 10:
				return "October";
			case 11:
				return "November";
			case 12:
				return "December";
			default:
				throw new ArgumentOutOfRangeException("monthNumber", "Invalid month number \"" + timestamp.Month + "\" specified - expected a value between 1 and 12")
		}
	}
}