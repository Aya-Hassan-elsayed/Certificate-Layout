using Certificit.BLL.Interfaces;
using Certificit.BLL.Repositories;
using Certificit.BLL.Specification;
using Certificit.PL.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Drawing.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Certificit.PL.Controllers;
using Microsoft.AspNetCore.Routing;
using AutoMapper;
using Certificit.DAL.Entities;
using Certificit.PL.DTO;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;
using Certificit.DAL.Interfaces;
using Certificit.DAL.Entities.Identity;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Linq;
using System.Text.Json;
using GeoJSON.Net.Geometry;
using System.Xml;
using Newtonsoft.Json;
using GeoJSON.Net.Feature;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System.Text;

namespace Certificit_.PL.Controllers
{
    //[Authorize(Roles = "Admin")]
    //[Authorize(Roles = "New")]
    public class CertificateLayoutController : ApiController
    {
        public RSCContext RSCContext { get; }
        public IGenaricInterface<CertificateFolder> _Folders { get; }
        public ICertificateLayout _CertificateLayout { get; }
        public IUniteType _UniteType { get; }
        public IConfiguration _Configuration { get; }
        public IEditeCertificateLayout _EditeCertificateLayout { get; }
        public IMapper _Mapper { get; }

        public CertificateLayoutController(RSCContext rSCContext, IGenaricInterface<CertificateFolder> Folders, ICertificateLayout certificateLayout, IUniteType uniteType, IConfiguration configuration, IEditeCertificateLayout editeCertificateLayout, IMapper mapper)
        {
            RSCContext = rSCContext;
            this._Folders = Folders;
            this._CertificateLayout = certificateLayout;
            _UniteType = uniteType;
            _Configuration = configuration;
            _EditeCertificateLayout = editeCertificateLayout;
            _Mapper = mapper;
        }

        #region Get UntiType
        [HttpGet]
        public async Task<ActionResult> getuntitype()
        {
            try
            {
                var unittype = _UniteType.GetAll();
                if (unittype is null)
                {
                    return NotFound(new ApiResponse(404, "not founded data !"));
                }
                return Ok(unittype);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " an a error in procces");
            }
        }
        #endregion

        #region ScreenShot
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequest request)
        {

            string ImagesDirectoryLog = _Configuration.GetSection("LogFolderCer").Value;
            string ImagesDirectoryMain = _Configuration.GetSection("MainFolderCer").Value;

            if (request == null || request.Image == null)
            {
                return BadRequest("No image provided.");
            }

            if (string.IsNullOrWhiteSpace(request.RequestNumber))
            {
                return BadRequest("Request number is required.");
            }

            var directoryPath = Path.Combine(ImagesDirectoryLog, request.RequestNumber);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var directoryPathMain = Path.Combine(ImagesDirectoryMain, DateTime.Now.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(directoryPathMain))
            {
                Directory.CreateDirectory(directoryPathMain);
            }

            // Save the image for log
            var filePathLog = Path.Combine(directoryPath, $"{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.png");
            using (var stream = new FileStream(filePathLog, FileMode.Create))
            {
                await request.Image.CopyToAsync(stream);
            }

            for (int i = 1; i <= request.Numberofcopies; i++)
            {

                if (request.Numberofcopies == 1)
                {
                    var filePathMain = Path.Combine(directoryPathMain, $"{request.RequestNumber}.png");
                    using (var stream = new FileStream(filePathMain, FileMode.Create))
                    {
                        await request.Image.CopyToAsync(stream);
                    }
                }
                else
                {
                    var filePathMain = Path.Combine(directoryPathMain, $"{request.RequestNumber}-{i}.png");
                    using (var stream = new FileStream(filePathMain, FileMode.Create))
                    {
                        await request.Image.CopyToAsync(stream);
                    }
                }
            }
            return Ok("Image uploaded successfully.");
        }

        #endregion

        #region Get New Data
        [HttpPost("GetNewData")]
        public async Task<ActionResult> GetNewCertificationList(SpecificationPrams specificationPrams)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Not valid Response"));
                }

                var Spec = new FilterSpecification(specificationPrams);
                var RequestResultData = await _CertificateLayout.GetAllWithPram(Spec);
                var count = await _CertificateLayout.GetTotalIteamCount(Spec);

                if (RequestResultData == null || !RequestResultData.Any())
                {
                    return NotFound(new ApiResponse(404, "Not found certificates"));
                }

                var mapped = _Mapper.Map<IEnumerable<CertificateViewLayout33>, List<ReturnListDto>>(RequestResultData);


                var returnCertificateListDto = new ReturnCertificateListDto
                {
                    certificateList = mapped,
                    PageInfo = new PageInfoDetiles
                    {
                        TotalItems = count,
                        ItemsPerPage = specificationPrams.PageSize,
                        CurrentPage = specificationPrams.PageIndex
                    }
                };

                return Ok(returnCertificateListDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        #endregion

        #region Get Edit Data
        [HttpPost("GetEditData")]
        public async Task<ActionResult> GetEditCertificationList(SpecificationPrams specificationPrams)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Not valid Rsponse"));
                }
                var Spec = new EditeFilterSpecification(specificationPrams);
                var RequestResultData = await _EditeCertificateLayout.GetAllWithPram(Spec);
                var count = _EditeCertificateLayout.GetTotalIteamCount(Spec);

                ReturnCertificateListDto returnCertificateListDto = new ReturnCertificateListDto();

                var mapped = _Mapper.Map<IEnumerable<CertificateViewLayoutEdit>, List<ReturnListDto>>(RequestResultData);

                returnCertificateListDto.certificateList = mapped;

                PageInfoDetiles pagingInfo = new PageInfoDetiles
                {
                    TotalItems = await count,
                    ItemsPerPage = specificationPrams.PageSize,
                    CurrentPage = specificationPrams.PageIndex
                };
                returnCertificateListDto.PageInfo = pagingInfo;

                if (RequestResultData is null)
                {
                    return NotFound(new ApiResponse(404, "notFound certificates"));
                }
                return Ok(returnCertificateListDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " an a error in procces");
            }
        }
        #endregion

        #region Get New Certifcate information

        [HttpGet("CertificateInformations")]
        public async Task<ActionResult> GetCertificate(string Requestnumber)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Invalid Request"));
                }

                var cer = await _CertificateLayout.GetByRequestNumber(Requestnumber);
                if (cer == null)
                {
                    return NotFound(new ApiResponse(404, "Data not found"));
                }
                var mapped = _Mapper.Map<CertificateViewLayout33, ReturnCertficateInformation>(cer);

                return Ok(mapped);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        #endregion

        #region Get Edit Certifcate information
        [HttpGet("EditCertificateInformations")]

        public async Task<ActionResult> GetEditCertificate(int ShipingOdeder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Not valid Rsponse"));
                }

                var Cer = await _EditeCertificateLayout.GetByShipingOdeder(ShipingOdeder);
                if (Cer == null)
                {
                    return NotFound(new ApiResponse(404, "not founded data !"));
                }
                var mapped = _Mapper.Map<CertificateViewLayoutEdit, ReturnCertficateInformation>(Cer);

                return Ok(mapped);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " an a error in procces");
            }
        }
        #endregion

        #region Get Folders Paths
        [HttpGet("FolderPathes")]
        public async Task<ActionResult> getFolderPathes(PathsDto pathsDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse(400, "Not valid Rsponse"));
                }
                var FolderPathe = _Folders.GetAll();
                if (FolderPathe is null)
                {
                    return NotFound(new ApiResponse(404, "not founded data !"));
                }
                var mapped = _Mapper.Map<PathsDto, CertificateFolder>(pathsDto);
                return Ok(mapped);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, " an a error in procces");
            }
        }
        #endregion

    }
}


