namespace BuildingConferenceRoomInfo.WebAjax.ViewModels
{
    public class BuildingInfoViewModel
    {
        public string Name { get; set; }

        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressState { get; set; }
        public string AddressStreet { get; set; }
        public string AddressZip { get; set; }
        public int? ConferenceRoomCount { get; set; }
        public int? FloorCount { get; set; }
        public string MainPhone { get; set; }
    }
}
