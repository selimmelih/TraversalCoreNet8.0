using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        private readonly Context _context;

        public EfCommentDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<Comment> GetListCommentWithDestination()
        {
            return _context.Comments.Include(x => x.Destination).ToList();
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            return _context.Comments
                           .Where(x => x.DestinationID == id)
                           .Include(x => x.AppUser)
                           .ToList();
        }
    }
}
