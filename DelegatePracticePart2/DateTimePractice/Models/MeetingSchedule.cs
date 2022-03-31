using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimePractice.Models
{
    internal class MeetingSchedule
    {
        List<Meeting> _meetingList;

        public MeetingSchedule()
        {
            _meetingList = new List<Meeting>();
        }

        public void AddMeeting(Meeting meeting)
        {
            if (_meetingList.Exists(m => m.FromDate >= meeting.FromDate && m.ToDate <= meeting.ToDate))
                throw new Exception();

            _meetingList.Add(meeting);
        }
        public int FindMeetingsCount(DateTime dateTime)
        {
            return _meetingList.FindAll(m => m.FromDate > dateTime).Count;
        }
        public List<Meeting> FindMeetings(Predicate<Meeting> predicate)
        {
            return _meetingList.FindAll(predicate);
        }
        public bool ExistMeetingsByName(string name)
        {
            return _meetingList.Exists(m => m.Name == name);
        }
        public bool ExistMeetings(Predicate<Meeting> predicate)
        {
            return _meetingList.Exists(predicate);
        }
    }
}
