using GuestiaCodingTask.Data;
using GuestiaCodingTask.Helpers;

namespace GuestiaCodingTask.DTOs;

public class GuestReportItem
{
    public GuestReportItem(Guest guest)
    {
        GroupName = guest.GuestGroup.Name;
        GuestName = NameStringFormatter.FormatName(guest);
    }
    
    public string GroupName { get; private set; }
    
    public string GuestName { get; private set; }
}