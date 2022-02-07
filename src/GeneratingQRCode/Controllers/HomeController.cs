using GeneratingQRCode.Extensions;
using GeneratingQRCode.Models;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Drawing;

namespace GeneratingQRCode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult CreateQRCode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateQRCode(QRCodeModel qrCodeModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrCodeModel.QRCodeText, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeBitmap = qrCode.GetGraphic(60);
            byte[] qrCodeByteArray = qrCodeBitmap.BitmapToByteArray();
            string qrCodeUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(qrCodeByteArray));
            ViewBag.QrCodeUri = qrCodeUri;
            return View();
        }
    }
}
