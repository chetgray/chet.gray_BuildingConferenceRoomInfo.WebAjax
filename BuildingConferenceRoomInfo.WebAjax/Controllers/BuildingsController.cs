using System.Collections.Generic;
using System.Web.Mvc;

using BuildingConferenceRoomInfo.Business.BLLs;
using BuildingConferenceRoomInfo.Business.Models;
using BuildingConferenceRoomInfo.WebAjax.ViewModels;

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
        public ActionResult List()
        {
            throw new System.NotImplementedException();
        }

        // GET api/Buildings/ListByName?name={name}
        public ActionResult ListByName(string name)
        {
            throw new System.NotImplementedException();
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
