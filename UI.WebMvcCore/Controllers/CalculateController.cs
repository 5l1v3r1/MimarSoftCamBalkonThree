﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Repository.Business.Abstract;
using Repository.Entities.DTOs;
using System;
using System.Drawing.Printing;

namespace UI.WebMvcCore.Controllers
{
    public class CalculateController : Controller
    {
        private ICalculateService _calculateService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CalculateController(ICalculateService calculateService, IWebHostEnvironment webHostEnvironment)
        {
            _calculateService = calculateService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "AKR3P,YÖNETİM,FABRİKA,BAYİİ")]
        public IActionResult TrendCalculate()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "AKR3P,YÖNETİM,FABRİKA,BAYİİ")]
        public IActionResult TrendCalculate(BalconyCalculateDto balconyCalculateDTO)
        {
            _calculateService.TrendCalculate(balconyCalculateDTO);

            string result = Print(balconyCalculateDTO);
            try
            {
                return Redirect(result);
            }
            catch (Exception x)
            {
                return BadRequest(x);
            }
            //return Ok(result);
        }

        public string Print(BalconyCalculateDto balconyCalculateDTO)
        {
            var ctt = _calculateService.GetCTipiTuval(balconyCalculateDTO);
            PrintDocument pd = new PrintDocument();
            //ctt.PrintPreview();
            pd.PrintPage += new PrintPageEventHandler(ctt.Pd_PrintPage);

            var url = Request.Scheme + "://" + Request.Host.Value;
            string newFile = Guid.NewGuid() + ".pdf";
            string ContentRootPath = _webHostEnvironment.ContentRootPath + "\\wwwroot\\PDF\\";
            string fullPath = ContentRootPath + newFile;
            pd.DefaultPageSettings.PrinterSettings.PrintToFile = true;
            pd.DefaultPageSettings.PrinterSettings.PrintFileName = fullPath;
            pd.PrintController = new StandardPrintController();
            string result = url + "/PDF/" + newFile;
            pd.Print();
            //pd.Dispose();

            return "/PDF/" + newFile;
        }

        [Authorize(Roles = "AKR3P,YÖNETİM,FABRİKA,BAYİİ")]
        public IActionResult IsiCamSistem()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "AKR3P,YÖNETİM,FABRİKA,BAYİİ")]
        public IActionResult IsiCamSistem(BalconyCalculateDto balconyCalculateDTO)
        {
            _calculateService.IsiCamCalculate(balconyCalculateDTO);

            string result = Print(balconyCalculateDTO);
            return Redirect(result);
        }

        [Authorize(Roles = "AKR3P,YÖNETİM,FABRİKA,BAYİİ,USER")]
        public IActionResult SurmeSistem()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "AKR3P,YÖNETİM,FABRİKA,BAYİİ,USER")]
        public IActionResult SurmeSistem(BalconyCalculateDto balconyCalculateDTO)
        {
            if (ModelState.IsValid)
            {
                _calculateService.SurmeSistemCalculate(balconyCalculateDTO);

                string result = Print(balconyCalculateDTO);
                return Redirect(result);
            }
            return View();
        }
    }
}