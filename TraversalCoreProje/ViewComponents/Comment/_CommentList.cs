using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        private readonly CommentManager _commentManager;

        public _CommentList(ICommentDal commentDal)
        {
            _commentManager = new CommentManager(commentDal);
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentManager.TGetListCommentWithDestinationAndUser(id);
            ViewBag.commentCount = values.Count;
            return View(values);
        }
    }
}
