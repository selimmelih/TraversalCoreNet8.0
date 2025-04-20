using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentManager _commentManager;

        public CommentController(CommentManager commentManager)
        {
            _commentManager = commentManager;
        }

        [HttpGet]
        public async Task<PartialViewResult> AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = DateTime.Now.Date;
            p.CommentState = true;
            _commentManager.TAdd(p);
            return RedirectToAction("DestinationDetails", "Destination", new { id = p.DestinationID });
        }
    }
}
