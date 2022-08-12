using System.ComponentModel.DataAnnotations;

namespace TaskModsen.Entities
{
    /// <summary>
    /// The event Class that will be used To Create the table EventFeast in the database
    /// </summary>
    public class EventFeast
    {
        [Key]
        public Guid Id { get; set; }
        public string NameOfEvent { get; set; }
        public string DesctiptionOfEvent { get; set; }
        public string FioOrganizator { get; set; }
        public string FioSpeaker { get; set; }
        public DateTime TimeOfEvent { get; set; }
        public string Adress { get; set; }
    }
}
