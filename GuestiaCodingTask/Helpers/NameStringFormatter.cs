using System;
using GuestiaCodingTask.Data;

namespace GuestiaCodingTask.Helpers;

public static class NameStringFormatter
{
    public static string FormatName(Guest guest)
    {
        return guest.GuestGroup.NameDisplayFormat switch
        {
            NameDisplayFormatType.UpperCaseLastNameSpaceFirstName =>
                guest.LastName.ToUpperInvariant() + " " + guest.FirstName,
            NameDisplayFormatType.LastNameCommaFirstNameInitial =>
                guest.LastName + ", " + guest.FirstName.Substring(0, 1).ToUpperInvariant(),
            _ => throw new ArgumentException($"Unsupported enum value {guest.GuestGroup.NameDisplayFormat}")
        };
    }
}