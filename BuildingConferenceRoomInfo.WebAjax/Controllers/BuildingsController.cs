using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

using BuildingConferenceRoomInfo.Business.BLLs;
using BuildingConferenceRoomInfo.Business.Models;
using BuildingConferenceRoomInfo.WebAjax.ViewModels;

using Newtonsoft.Json;

namespace BuildingConferenceRoomInfo.WebAjax.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly BuildingBLL _bll = new BuildingBLL();

        // GET api/Buildings/Details/{id}
        public ActionResult Details(int id)
        {
            throw new System.NotImplementedException();
        }

        // GET api/Buildings/List
        [HttpGet]
        public ActionResult List()
        {
            ApiResultViewModel result = new ApiResultViewModel();
            try
            {
                IEnumerable<BuildingModel> buildings = _bll.GetAll();
                result.Data = ConvertToInfoViewModelList(buildings);
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

        // GET api/Buildings/ListByName?name={name}
        [HttpGet]
        public ActionResult ListByName(string name)
        {
            ApiResultViewModel result = new ApiResultViewModel();
            try
            {
                IEnumerable<BuildingModel> allBuildings = _bll.GetAll();
                IList<BuildingModel> matchingBuildings = new List<BuildingModel>();
                foreach (BuildingModel building in allBuildings)
                {
                    if (building.Name.Contains(name))
                    {
                        matchingBuildings.Add(building);
                    }
                }
                result.Data = ConvertToInfoViewModelList(matchingBuildings);
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

        private BuildingInfoViewModel ConvertToInfoViewModel(BuildingModel model)
        {
            BuildingInfoViewModel viewModel = new BuildingInfoViewModel
            {
                Name = model.Name,
                AddressStreet = model.AddressStreet,
                AddressCity = model.AddressCity,
                AddressState = model.AddressState,
                AddressZip = model.AddressZip,
                AddressCountry = model.AddressCountry,
                MainPhone = model.MainPhone,
                FloorCount = model.FloorCount,
                ConferenceRoomCount = model.ConferenceRoomCount
            };
            return viewModel;
        }

        private IList<BuildingInfoViewModel> ConvertToInfoViewModelList(
            IEnumerable<BuildingModel> models
        )
        {
            IList<BuildingInfoViewModel> viewModels = new List<BuildingInfoViewModel>();
            foreach (BuildingModel model in models)
            {
                viewModels.Add(ConvertToInfoViewModel(model));
            }
            return viewModels;
        }
    }
}
