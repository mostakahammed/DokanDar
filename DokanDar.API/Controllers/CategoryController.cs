using CoreApiResponse;
using DokanDar.Application.DTO;
using DokanDar.Application.IServices.DBServices;
using DokanDar.Application.IServices.EntityServices;
using DokanDar.Domain.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace DokanDar.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IProcedureService _procedureService;

        public CategoryController(ICategoryService categoryService, IProcedureService procedureService)
        {
            _categoryService = categoryService;
            _procedureService = procedureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                return CustomResult("Categories retured successfully", categories, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCategoriesByIDs()
        {
            try
            {
                var param = new { @FromID = 1, @ToID = 5 };
                DataSet categories =  _procedureService.GetDataWithParameter(param, "Prco_GetCategoryByIDs");
                var categoriesLists = categories.Tables[0].AsEnumerable()
                    .Select(row => new CategoryDbModel()
                    {
                        CategoryID = row.Field<int>("CategoryID"),
                        CategoryName = row.Field<string>("CategoryName")
                    }).ToList();
                return CustomResult("Categories retured successfully", categoriesLists, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            try
            {
                var category = await _categoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return CustomResult("Category not found",HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Category retured successfully", category, HttpStatusCode.OK);
                }
                
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDto objToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objToCreate.CreateUser = "mostak";
                    objToCreate.CreateDate = DateTime.Now.Date;
                    var category = await _categoryService.AddAsync(objToCreate);
                    if (category == false)
                    {
                        return CustomResult("Category Added Failed", HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        return CustomResult("Category Added successfully", category, HttpStatusCode.Created);
                    }
                }
                else
                {
                    return CustomResult("Something went wrong", HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditCategory([FromBody] CategoryDto objToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objToCreate.UpdateUser = "mostak";
                    objToCreate.UpdateDate = DateTime.Now.Date;
                    var category = await _categoryService.UpdateAsync(objToCreate);
                    if (category == false)
                    {
                        return CustomResult("Category Update Failed", HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        return CustomResult("Category Updated successfully", category, HttpStatusCode.Created);
                    }
                }
                else
                {
                    return CustomResult("Something went wrong", HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = await _categoryService.DeleteAsync(id);
                    if (category == false)
                    {
                        return CustomResult("Category Delete Failed", HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        return CustomResult("Category Deleted successfully", category, HttpStatusCode.Created);
                    }
                }
                else
                {
                    return CustomResult("Something went wrong", HttpStatusCode.BadRequest);
                }

            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message);
            }
        }
    }
}
