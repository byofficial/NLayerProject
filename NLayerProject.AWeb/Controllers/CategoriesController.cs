using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLayerProject.AWeb.ApiService;
using NLayerProject.AWeb.DTOs;
using NLayerProject.AWeb.Filters;



namespace NLayerProject.AWeb.Controllers
{

    public class CategoriesController : Controller
    {

        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoriesController(CategoryApiService categoryApiService, IMapper mapper)
        {
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));

        }

        //Html Sayfası
        public IActionResult Create()
        {
            return View();
        }

        //Create içerisinde submit yapıldığında çalışır.
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
        }

        //Güncelleme Html Sayfası
        public async Task<IActionResult> Update(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            return View(_mapper.Map<CategoryDto>(category));

        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _categoryApiService.Update(categoryDto);
            return RedirectToAction("Index");
        }

        // Delete işlemi için HTML sayfası bulunmuyor.
        // Sadece Metot içerisinde silme işlemi yapılıyor.
        [ServiceFilter(typeof(CategoryNotFoundFilter))]
        public async Task<IActionResult> Delete(int id)
        {

            await _categoryApiService.Remove(id);

            return RedirectToAction("Index");
        }
    }

}
