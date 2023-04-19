using System.Collections.Generic;
using System.Web.Mvc;

using BuildingConferenceRoomInfo.Business.BLLs;
using BuildingConferenceRoomInfo.Business.Models;
using BuildingConferenceRoomInfo.WebAjax.ViewModels;

namespace BuildingConferenceRoomInfo.WebAjax.Controllers
{
    public class ConferenceRoomsController : Controller
    {
        private readonly ConferenceRoomBLL _bll = new ConferenceRoomBLL();

        // GET api/ConferenceRooms/Details/{id}
        public ActionResult Details(int id)
        {
            throw new System.NotImplementedException();
        }

        // GET api/ConferenceRooms/List
        public ActionResult List()
        {
            throw new System.NotImplementedException();
        }

        // GET api/ConferenceRooms/ListByName?name={name}
        public ActionResult ListByName(string name)
        {
            throw new System.NotImplementedException();
        }

        private ConferenceRoomInfoViewModel ConvertToInfoViewModel(ConferenceRoomModel model)
        {
            ConferenceRoomInfoViewModel viewModel = new ConferenceRoomInfoViewModel
            {
                Name = model.Name,
                BuildingName = model.BuildingName,
                Phone = model.Phone,
                IsAVCapable = model.IsAVCapable,
                Capacity = model.Capacity
            };
            return viewModel;
        }

        private IList<ConferenceRoomInfoViewModel> ConvertToInfoViewModelList(
            IEnumerable<ConferenceRoomModel> models
        )
        {
            IList<ConferenceRoomInfoViewModel> viewModels =
                new List<ConferenceRoomInfoViewModel>();
            foreach (ConferenceRoomModel model in models)
            {
                viewModels.Add(ConvertToInfoViewModel(model));
            }
            return viewModels;
        }
    }
}
