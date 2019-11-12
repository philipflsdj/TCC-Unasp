using System.Web;
using System.Web.Optimization;

namespace Tcc_Unasp
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));



            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/sb-admin-2").Include(
                      "~/Content/css/sb-admin-2.css",
                      "~/Content/vendor/fontawesome-free/css/all.css",
                      "~/Content/vendor/datatables/dataTables.bootstrap4.css"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/sb-admin-2-scripts").Include(
                        "~/Content/vendor/jquery/jquery.min.js",
                        "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                        "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                        
                        "~/Content/vendor/chart.js/Chart.min.js",
                        "~/Scripts/js/demo/chart-area-demo.js",
                        "~/Scripts/js/demo/chart-pie-demo.js",
                        "~/Scripts/js/demo/datatables-demo.js",
                        "~/Content/vendor/datatables/jquery.dataTables.min.js",
                        "~/Content/vendor/datatables/dataTables.bootstrap4.min.js",
                        "~/Scripts/js/demo/datatables-demo.js",
                        "~/Scripts/js/sb-admin-2.min.js"
                        ));
        }
    }
}
