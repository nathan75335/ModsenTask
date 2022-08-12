using TaskModsen.Entities;

namespace TaskModsen.Models
{
    public class EventFeastRequest
    {
        public string NameOfEvent { get; set; }
        public string DesctiptionOfEvent { get; set; }
        public string FioOrganizator { get; set; }
        public string FioSpeaker { get; set; }
        public DateTime TimeOfEvent { get; set; }
        public string Adress { get; set; }
    }
}
