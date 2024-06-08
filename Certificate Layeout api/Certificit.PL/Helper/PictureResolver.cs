﻿using AutoMapper;
using Certificit.DAL.Entities;
using Certificit.PL.DTO;
using GeoJSON.Net.Geometry;
using Microsoft.Extensions.Configuration;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
using System.IO;
public class PictureResolver : IValueResolver<CertificateViewLayout33, ReturnCertficateInformation, string>
{
    private readonly IConfiguration _configuration;

    public PictureResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(CertificateViewLayout33 source, ReturnCertficateInformation destination, string destMember, ResolutionContext context)
    {
        try
        {
            // Create a GeoJSON writer
            string baseImageUrl = _configuration.GetSection("Baseurl").Value;

            string imageUrl = Path.Combine(baseImageUrl, "Share", "New", $"{source.Requestnumber}.jpg");

            return imageUrl;

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log the error message)
            Console.WriteLine("Error converting geometry to GeoJSON: " + ex.Message);
            return null; // or throw an exception, depending on your requirements
        }

    }
}
