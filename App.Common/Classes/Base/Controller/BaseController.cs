using App.Common.Classes.Base.DTO;
using App.Common.Classes.Base.Extensions;
using App.Common.Classes.Base.Services;
using App.Common.Classes.Constants.Common;
using App.Common.Classes.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace App.Common.Classes.Base.Controller
{
    public abstract class BaseController<TDTO> : ControllerBase where TDTO : class
    {
        private IBaseService<TDTO> _service;

        public BaseController(IBaseService<TDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getAll")]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await _service.GetAllAsync();

                if (result == null || !result.Any())
                {
                    return NotFound(new ResponseDTO<string>
                    {
                        Data = null,
                        Header = new HeaderDTO
                        {
                            ReponseCode = 404,
                            Message = GlobalConstants.ERROR_ITEM_NOT_FOUND,
                            Success = false,
                            ErrorList = null
                        }
                    });
                }

                return Ok(result.AsResponseDTO(200, GlobalConstants.SUCCESS_PROCESS, null, true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("getById")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _service.FindByIdAsync(id);

                if (result == null)
                {
                    return NotFound(new ResponseDTO<string>
                    {
                        Data = null,
                        Header = new HeaderDTO
                        {
                            ReponseCode = 404,
                            Message = GlobalConstants.ERROR_ITEM_NOT_FOUND,
                            Success = false,
                            ErrorList = null
                        }
                    });
                }

                return Ok(result.AsResponseDTO(200, GlobalConstants.SUCCESS_PROCESS, null, true));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public virtual async Task<IActionResult> CreateAsync([FromBody] TDTO dto)
        {
            try
            {
                var result = await _service.CreateAsync(dto);

                if (result == null)
                {
                    return BadRequest(new ResponseDTO<string>
                    {
                        Data = null,
                        Header = new HeaderDTO
                        {
                            ReponseCode = 400,
                            Message = GlobalConstants.ERROR_CREATE_RECORD,
                            Success = false,
                            ErrorList = null
                        }
                    });
                }

                return Ok(result.AsResponseDTO(200, GlobalConstants.SUCCESS_PROCESS, null, true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public virtual async Task<IActionResult> Update([FromBody] TDTO modelDTO)
        {
            try
            {
                object id = modelDTO.GetPrimaryKeyValue();

                if (id == null)
                {
                    return BadRequest(new ResponseDTO<string>
                    {
                        Data = null,
                        Header = new HeaderDTO
                        {
                            ReponseCode = 400,
                            Message = GlobalConstants.ERROR_PRIMARY_KEY,
                            Success = false,
                            ErrorList = null
                        }
                    });
                }

                if (await _service.FindByIdAsync(id) == null)
                {
                    return NotFound(new ResponseDTO<string>
                    {
                        Data = null,
                        Header = new HeaderDTO
                        {
                            ReponseCode = 404,
                            Message = GlobalConstants.ERROR_ITEM_NOT_FOUND,
                            Success = false,
                            ErrorList = null
                        }
                    });
                }

                return Ok((await _service.UpdateAsync(modelDTO)).AsResponseDTO(200, GlobalConstants.SUCCESS_PROCESS,null,true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public virtual async Task<IActionResult> DeleteAsync([FromBody] Guid id)
        {
            try
            {
                TDTO record = await _service.FindByIdAsync(id);

                if (record == null)
                {
                    return NotFound(new ResponseDTO<string>
                    {
                        Data = null,
                        Header = new HeaderDTO
                        {
                            ReponseCode = 404,
                            Message = GlobalConstants.ERROR_ITEM_NOT_FOUND,
                            Success = false,
                            ErrorList = null
                        }
                    });
                }

                return Ok((await _service.DeleteAsync(id)).AsResponseDTO(200, GlobalConstants.SUCCESS_PROCESS,null,true));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}