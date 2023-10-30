using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDo_List.Context;
using ToDo_List.Models;

namespace ToDo_List.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        public IActionResult AllView()
        {
            ViewBag.Tasks = new DataContext().Tasks;
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(string inp_title, string inp_desc)
        {
            using (var db = new DataContext())
            {
                db.Tasks.Add(
                    new MyTask()
                    {
                        Title = inp_title,
                        Description = inp_desc
                    });
                db.SaveChanges();
            }
            return RedirectToAction("AllView");
        }

        [HttpDelete]
        public IActionResult DelTask(Dictionary<string, int> data)
        {
            using (var db = new DataContext())
            {
                MyTask task = new MyTask() { Id = data["id"] };
                db.Entry(task).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("AllView");
        }
    }
}
