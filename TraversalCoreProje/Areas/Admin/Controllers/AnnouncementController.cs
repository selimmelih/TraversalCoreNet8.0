using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("/Admin/[controller]/[action]")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.TGetList());
            return View(values);
        }

        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(AnnouncementAddDto model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    AnnouncementDate = DateTime.Now,
                    Content = model.Content,
                    Title = model.Title,
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.TGetByID(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDto>(_announcementService.TGetByID(id));

            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    AnnouncementID = model.AnnouncementID,
                    Content = model.Content,
                    AnnouncementDate = DateTime.Now,
                    Title = model.Title,
                });
            }

            return RedirectToAction("Index");
        }

    }
}
