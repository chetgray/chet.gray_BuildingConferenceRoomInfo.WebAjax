namespace BuildingConferenceRoomInfo.WebAjax.ViewModels
{
    public class ConferenceRoomInfoViewModel
    {
        public string Name { get; set; }

        public string BuildingName { get; set; }

        public int? Capacity { get; set; }
        public bool IsAVCapable { get; set; }
        public string Phone { get; set; }
    }
}
