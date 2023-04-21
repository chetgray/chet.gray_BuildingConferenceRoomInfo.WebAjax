using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

using BuildingConferenceRoomInfo.Business.BLLs;
using BuildingConferenceRoomInfo.Business.Models;
using BuildingConferenceRoomInfo.WebAjax.ViewModels;

using Newtonsoft.Json;

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
        [HttpGet]
        public ActionResult List()
        {
            ApiResultViewModel result = new ApiResultViewModel();
            try
            {
                IEnumerable<ConferenceRoomModel> models = _bll.GetAll();
                result.Data = ConvertToInfoViewModelList(models);
                result.Context = BootstrapContext.success;
                result.Message = "Success";
            }
            catch (System.Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.Context = BootstrapContext.danger;
                result.Message = ex.Message;
                result.Data = null;
            }
            ContentResult content = Content(
                JsonConvert.SerializeObject(result),
                "application/json"
            );
            return content;
        }

        // GET api/ConferenceRooms/ListByName?name={name}
        [HttpGet]
        public ActionResult ListByName(string name)
        {
            ApiResultViewModel result = new ApiResultViewModel();
            try
            {
                IEnumerable<ConferenceRoomModel> allConferenceRooms = _bll.GetAll();
                IList<ConferenceRoomModel> matchingConferenceRooms =
                    new List<ConferenceRoomModel>();
                foreach (ConferenceRoomModel conferenceRoom in allConferenceRooms)
                {
                    if (conferenceRoom.Name.Contains(name))
                    {
                        matchingConferenceRooms.Add(conferenceRoom);
                    }
                }
                result.Data = ConvertToInfoViewModelList(matchingConferenceRooms);
                result.Context = BootstrapContext.success;
                result.Message = "Success";
            }
            catch (System.Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.Context = BootstrapContext.danger;
                result.Message = ex.Message;
                result.Data = null;
            }
            ContentResult content = Content(
                JsonConvert.SerializeObject(result),
                "application/json"
            );
            return content;
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
