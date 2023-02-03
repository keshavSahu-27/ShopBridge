using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge.Dal.Entities;
using System.Threading.Tasks;
using ShopBridge.Repository.Contracts;
using ShopBridge.Dto;
using AutoMapper;

namespace ShopBridge.Controllers;

[ApiController]
public class InventoryController : Controller
{
    public InventoryController(IInventoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("api/getAllInventories")]
    public async Task<ActionResult<IEnumerable<InventoryDto>>> FetchInventories()
    {
        var inventories = await _repository.FetchInventories();
        var mappedInventories = _mapper.Map<IEnumerable<InventoryDto>>(inventories);
        return Ok(inventories);
    }

    [HttpGet]
    [Route("api/getInventoryById")]
    public async Task<ActionResult<IEnumerable<InventoryDto>>> FetchInventoryById([FromQuery] long id)
    {
        var inventories = await _repository.FetchInventoryById(id);
        var mappedInventories = _mapper.Map<InventoryDto>(inventories);
        return Ok(inventories);
    }

    [HttpPost]
    [Route("api/createInventory")]
    public async Task<ActionResult<Inventory?>> CreateInventory([FromBody] InventoryDto inventory)
    {
        var mappedInventory = _mapper.Map<Inventory>(inventory);
        var createdInventory = await _repository.CreateInventory(mappedInventory);
        if (createdInventory == null)
            throw new DbUpdateException("Having issue Saving to DB.Please try again later");

        return Ok(createdInventory);
           
    }

    [HttpPut]
    [Route("api/updateInventory")]
    public async Task<ActionResult<Inventory?>> UpdateInventory([FromBody] InventoryDto inventory)
    {
        var mappedInventory = _mapper.Map<Inventory>(inventory);
        var updatedInventory = await _repository.UpdateInventory(mappedInventory);
        if (updatedInventory == null)
            throw new DbUpdateException("Having issue Saving to DB.Please try again later");

        return Ok(updatedInventory);
    }

    [HttpDelete]
    [Route("api/deleteInventory")]
    public async Task<ActionResult<bool>> DeleteInventory([FromBody] InventoryDto inventory)
    {
        var mappedInventory = _mapper.Map<Inventory>(inventory);
        var isDeleted = await _repository.DeleteInventory(mappedInventory);

        return isDeleted ? Ok(isDeleted) : BadRequest(isDeleted);
    }


    #region Helpers

    private readonly IInventoryRepository _repository;
    private readonly IMapper _mapper;

    #endregion

}

