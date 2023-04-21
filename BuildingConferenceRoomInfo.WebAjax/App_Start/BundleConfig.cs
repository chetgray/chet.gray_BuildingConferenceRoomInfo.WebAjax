using System.Web.Optimization;

namespace BuildingConferenceRoomInfo.WebAjax
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js")
            );

            bundles.Add(
                new ScriptBundle("~/bundles/jqueryui").Include(
                    "~/Scripts/jquery-ui-{version}.js"
                )
            );

            bundles.Add(new Bundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(
                new StyleBundle("~/Content/themes/base/css").Include(
                    "~/Content/themes/base/jquery-ui.css"
                //
                //"~/Content/themes/base/all.css"
                //
                //"~/Content/themes/base/theme.css",
                //"~/Content/themes/base/base.css"
                //
                //"~/Content/themes/base/core.css",
                //"~/Content/themes/base/accordion.css",
                //"~/Content/themes/base/autocomplete.css",
                //"~/Content/themes/base/button.css",
                //"~/Content/themes/base/datepicker.css",
                //"~/Content/themes/base/dialog.css",
                //"~/Content/themes/base/draggable.css",
                //"~/Content/themes/base/menu.css",
                //"~/Content/themes/base/progressbar.css",
                //"~/Content/themes/base/resizable.css",
                //"~/Content/themes/base/selectable.css",
                //"~/Content/themes/base/selectmenu.css",
                //"~/Content/themes/base/slider.css",
                //"~/Content/themes/base/sortable.css",
                //"~/Content/themes/base/spinner.css",
                //"~/Content/themes/base/tabs.css",
                //"~/Content/themes/base/tooltip.css"
                )
            );

            bundles.Add(
                new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/Site.css"
                )
            );

            bundles.Add(new ScriptBundle("~/bundles/index").Include("~/Scripts/index.js"));
        }
    }
}
