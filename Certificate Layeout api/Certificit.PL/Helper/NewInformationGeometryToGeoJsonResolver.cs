using AutoMapper;
using Certificit.DAL.Entities;
using Certificit.PL.DTO;
using GeoJSON.Net.Geometry;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using Newtonsoft.Json;
using System;
public class NewInformationGeometryToGeoJsonResolver : IValueResolver<CertificateViewLayout33, ReturnCertficateInformation, string>
{
    public string Resolve(CertificateViewLayout33 source, ReturnCertficateInformation destination, string destMember, ResolutionContext context)
    {
        try
        {
            // Create a GeoJSON writer
            var geoJsonWriter = new GeoJsonWriter();

            // Convert the geometry object to NetTopologySuite geometry
            var netTopologyGeometry = (Geometry)source.Geom;

            // Convert the NetTopologySuite geometry to GeoJSON
            string geoJson = geoJsonWriter.Write(netTopologyGeometry);

            return geoJson;
        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log the error message)
            Console.WriteLine("Error converting geometry to GeoJSON: " + ex.Message);
            return null; // or throw an exception, depending on your requirements
        }

    }
}
