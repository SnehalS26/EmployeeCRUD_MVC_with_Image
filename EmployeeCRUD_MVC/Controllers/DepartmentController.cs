using EmployeeCRUD_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCRUD_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        IConfiguration configuration;
        private DepartmentCrud deptcrud;
        public DepartmentController(IConfiguration configuration)
        {
            this.configuration = configuration;
            deptcrud = new DepartmentCrud(this.configuration);
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var model = deptcrud.GetDepartments();
            return View(model);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int did)
        {
            var result = deptcrud.GetDepartmentById(did);
            return View(result);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dept)
        {
            try
            {
                var res = deptcrud.AddDepartment(dept);
                if(res == 1)
                return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int did)
        {
            var result = deptcrud.GetDepartmentById(did);
            return View(result);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dept)
        {
            try
            {
                var res = deptcrud.UpdateDepartment(dept);
                if (res == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int did)
        {
            var result = deptcrud.GetDepartmentById(did);
            return View(result);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(Department dept)
        {
            try
            {
                var res = deptcrud.DeleteDepartment(dept);
                if (res == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
