using CoreApiResponse;
using DokanDar.Application.DTO;
using DokanDar.Application.IServices.DBServices;
using DokanDar.Application.IServices.EntityServices;
using DokanDar.Domain.DBModels;
using DokanDar.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace DokanDar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : BaseController
    {
        private readonly IShelfService _shelfService;
        private readonly IProcedureService _procedureService;

        public ShelfController(IShelfService shelfService, IProcedureService procedureService)
        {
            _shelfService = shelfService;
            _procedureService = procedureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShelves()
        {
            try
            {
                IEnumerable<ShelfDto>? shelves = await _shelfService.GetAllAsync();
                return CustomResult("Shelves retured successfully", shelves, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetShelf(int id)
        {
            try
            {
                var shelf = await _shelfService.GetByIdAsync(id);
                if (shelf == null)
                {
                    return CustomResult("Shelf not found", HttpStatusCode.NotFound);
                }
                else
                {
                    return CustomResult("Shelf retured successfully", shelf, HttpStatusCode.OK);
                }
                
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddShelf([FromBody] ShelfDto objToCreate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objToCreate.CreateUser = "mostak";
                    objToCreate.CreateDate = DateTime.Now.Date;
                    var shelf = await _shelfService.AddAsync(objToCreate);
                    if (shelf == false)
                    {
                        return CustomResult("Shelf Added Failed", HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        return CustomResult("Shelf Added successfully", shelf, HttpStatusCode.Created);
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
        public async Task<IActionResult> EditShelf([FromBody] ShelfDto objToUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objToUpdate.UpdateUser = "mostak";
                    objToUpdate.UpdateDate = DateTime.Now.Date;
                    var shelf = await _shelfService.UpdateAsync(objToUpdate);
                    if (shelf == false)
                    {
                        return CustomResult("Shelf Update Failed", HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        return CustomResult("Shelf Updated successfully", shelf, HttpStatusCode.Created);
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
        public async Task<IActionResult> DeleteShelf(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var shelf = await _shelfService.DeleteAsync(id);
                    if (shelf == false)
                    {
                        return CustomResult("Shelf Delete Failed", HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        return CustomResult("Shelf Deleted successfully", shelf, HttpStatusCode.Created);
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
